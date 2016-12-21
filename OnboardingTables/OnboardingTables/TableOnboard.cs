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
            string path = String.Format("{0}{1}\\Table\\{2}.sql", stgpath, SourceName.Text,TableName.Text);
            //projectPath.AddItem("Build", path);
            //projectPath.Save();
            //File.Create(path).Dispose();
            var script = String.Format("CREATE Table [stg].[{0}]", TableName.Text);
            
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
                    else dataType = rowColumn[7].ToString().ToUpper();
                    script += String.Format("\n\t[{0}]\t\t\t{1}\t\t{2},", rowColumn[3].ToString(), dataType, isNull);
                    string URLName = (rowColumn[3].ToString());
                    i++;
                }
                //bool enabled = true;
            }
            script = script.Remove(script.Length - 1, 1);





            using (TextWriter tw = new StreamWriter(path))
            {

                tw.WriteLine(script);
                tw.Close();
            }
        }

        public void CreateStgView(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = String.Format("{0}{1}\\View\\{2}.sql", stgpath, SourceName.Text,TableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [stg].[vw" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateDboTable(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = String.Format("{0}{1}\\Table\\{2}.sql", dbopath, SourceName.Text,TableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateDboView(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = String.Format("{0}{1}\\View\\{2}.sql", dbopath, SourceName.Text,TableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {

            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TableName.Text + ".sql";
            if (!File.Exists(path))
            {
                CreateStgTable();
                //CreateStgView(path, projectPath);
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