using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnboardingTables
{
    public partial class TableOnboarding : Form
    {
        public DataRowCollection sourceTableColumns;
        public DataRowCollection targetTableColumns;
        public CheckedListBox.CheckedItemCollection TargetTableColumns;
        public static string SqlProjpath;
        public static string dbopath;
        public static string stgpath;
        public static Microsoft.Build.Evaluation.Project projectPath;
        public TableOnboarding()
        {
            InitializeComponent();
        }

        private void AddCheckList()
        {
            ColumnList.Items.Clear();
            try
            {
                foreach (DataRow rowColumn in sourceTableColumns)
                {
                    //Gets the url name and path when the status is enabled. The status of Enabled / Disabled is setup in the users option page
                    string columnName = (rowColumn[3].ToString());
                    //bool enabled = true;
                    ColumnList.Items.Add(columnName, true);
                }
            }
            catch (Exception ex)
            {
                //Error message the user will see
                //string FriendlyError = "There has been populating checkboxes with the urls - A notification has been sent to development";
                //ShowMessageBox.MsgBox(FriendlyError, "There has been an Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CreateColumnList()
        {
            var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True", ServerName.Text, DatabaseName.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, SourceSchemaName.Text, SourceTableName.Text, null };
                connection.Open();
                sourceTableColumns = connection.GetSchema("Columns", restrictions).Rows;

                foreach (System.Data.DataRow rowColumn in sourceTableColumns)
                {
                    var ColumnName = (rowColumn[3].ToString());
                }
                connection.Close();
            }
            AddCheckList();
        }
        public void CreateStgTable()
        {
            string path = String.Format("{0}{1}\\Table\\{2}.sql", stgpath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE Table [stg].[{0}]\n(", TargetTableName.Text);
            
            //Building the Column List for the table
            int i = 0;
            string isNull = null;
            string dataType = null;
            foreach (DataRow rowColumn in sourceTableColumns)
            {
                if(rowColumn[3].ToString() == ColumnList.CheckedItems[i].ToString())
                {
                    if(rowColumn[6].ToString() == "NO") isNull = "NOT NULL";
                    else isNull = "NULL";
                    var x = rowColumn[8].ToString();
                    if (rowColumn[8].ToString() != "") dataType = String.Format("[{0}]({1})", rowColumn[7].ToString().ToUpper(), rowColumn[8].ToString());
                    else dataType = String.Format("[{0}]",rowColumn[7].ToString().ToUpper());
                    script += String.Format("\n\t[{0}]\t\t\t{1}\t\t{2},", rowColumn[3].ToString(), dataType, isNull);
                    string URLName = (rowColumn[3].ToString());
                    i++;
                }
            }

            //Adding Primary Key Constraint
            if (PrimaryKeyColumns.CheckedItems.Count == 0)
            {
                script = script.Remove(script.Length - 1, 1);
            }
            else
            {
                script += String.Format("\nCONSTRAINT [PK_{0}_{1}] PRIMARY KEY CLUSTERED\n(\n\t", TargetTableName.Text, PrimaryKeyColumns.CheckedItems[0]);
                string pkColumns = null;
                foreach (var pkColumn in PrimaryKeyColumns.CheckedItems)
                {
                    pkColumns += String.Format("[{0}],", pkColumn);
                }
                pkColumns = pkColumns.Remove(pkColumns.Length - 1, 1);

                script += String.Format("{0} ASC\n)", pkColumns);
            }

            script += "\n) ON [stg_Filegroup] WITH (DATA_COMPRESSION = PAGE)";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(script);
                tw.Close();
            }
        }

        public void CreateStgView()
        {
            string path = String.Format("{0}{1}\\View\\{2}.sql", stgpath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE View [stg].[vw{0}]\nAS\nSELECT", TargetTableName.Text);
            var index = script.Length;
            foreach(String column in ColumnList.CheckedItems)
            {
                script += String.Format("\n\t,[{0}]", column);
            }
            //var x = script[index + 2];
            script = script.Remove(index + 2, 1);

            if (PrimaryKeyColumns.CheckedItems.Count == 0)
            {
                //HashRowKey
                script += "\n\t,CONVERT(BINARY(16),HASHBYTES('md5', ";
                index = script.Length;
                foreach (String column in ColumnList.CheckedItems)
                {
                    script += String.Format("\n\t+ ISNULL(CONVERT(NVARCHAR,([{0}])),'^') + '|'", column);
                }
                script += "\n\t+ ISNULL(CONVERT(NVARCHAR,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear')),'^'))) AS HashRowKey";
            }
            //var ax = script[index + 2];
            script = script.Remove(index, 3);

            script += String.Format("\n\t,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear') AS FiscalYear\nFROM [stg].[{0}] WITH (NOLOCK)\nGO", TargetTableName.Text);

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(script);
                tw.Close();
            }
        }

        public void CreateDboTable(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = String.Format("{0}{1}\\Table\\{2}.sql", dbopath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TargetTableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateDboView(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = String.Format("{0}{1}\\View\\{2}.sql", dbopath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TargetTableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {

            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TargetTableName.Text + ".sql";
            if (!File.Exists(path))
            {
                CreateStgTable();
                CreateStgView();
                //CreateDboTable(path, projectPath);
                //CreateDboView(path, projectPath);
            }
            else if (File.Exists(path))
            {
                //Error Handling
            }
            //string text = System.IO.File.ReadAllText(@"C:\Users\tugar\Desktop\ReadMe.txt");
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
        }


        private void SelectProject_Click(object sender, EventArgs e)
        {
            if (BrowseProjectPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProjectPath.Text = BrowseProjectPath.FileName;
            }
            String chefpath = ProjectPath.Text.Replace("DIDataManagement\\DIDataManagement.sqlproj", "CHEF.Customization\\dbo\\Scripts");

            dbopath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "dbo\\");
            stgpath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "stg\\");
            SqlProjpath = ProjectPath.Text;
            projectPath = new Microsoft.Build.Evaluation.Project(SqlProjpath);
            ListofSources(dbopath);
            ListofChefScripts(chefpath);
        }
        public void ListofSources(String dboFilePath)
        {

            SourceName.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@dboFilePath);//Assuming Test is your Folder
            DirectoryInfo[] Files = d.GetDirectories(); //Getting Text files
            foreach (DirectoryInfo file in Files)
            {

                SourceName.Items.Add(file);
            }
            SourceName.Text = AddingNewSource.SourceName;
        }
        public void ListofChefScripts(String ChefFilePath)
        {

            ScriptName.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(ChefFilePath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            foreach (FileInfo file in Files)
            {

                ScriptName.Items.Add(file);
            }
            ScriptName.Text = AddingNewChefScript.ScriptName;
        }

        private void AddSource_Click(object sender, EventArgs e)
        {
            AddingNewSource AddingNewSource = new AddingNewSource();
            AddingNewSource.tob = this;
            AddingNewSource.Show();
        }

        private void AddScript_Click(object sender, EventArgs e)
        {
            AddingNewChefScript AddingNewChefScript = new AddingNewChefScript();
            AddingNewChefScript.tob = this;
            AddingNewChefScript.Show();
        }

        private void GetTableDetails_Click(object sender, EventArgs e)
        {
            CreateColumnList();
        }

        private void SelectPrimaryKey_Click(object sender, EventArgs e)
        {
            PrimaryKeyColumns.Items.Clear();
            TargetTableColumns = ColumnList.CheckedItems;
            foreach (var columnName in ColumnList.CheckedItems)
            {
                PrimaryKeyColumns.Items.Add(columnName, false);
            }
        }
    }
}