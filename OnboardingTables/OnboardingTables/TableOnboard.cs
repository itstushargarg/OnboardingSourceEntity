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
                    //Fetchting Column Names from the Source Table
                    ColumnList.Items.Add(rowColumn[3].ToString(), true);
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

        public void AddTableColumns(ref string script)
        {
            //Building the Column List for the table
            int i = 0;
            string isNull = null;
            string dataType = null;
            foreach (DataRow rowColumn in sourceTableColumns)
            {
                if (rowColumn[3].ToString() == ColumnList.CheckedItems[i].ToString())
                {
                    if (rowColumn[6].ToString() == "NO") isNull = "NOT NULL";
                    else isNull = "NULL";
                    var x = rowColumn[8].ToString();
                    if (rowColumn[8].ToString() != "") dataType = String.Format("[{0}]({1})", rowColumn[7].ToString().ToUpper(), rowColumn[8].ToString());
                    else if (rowColumn[12].ToString() != "" && rowColumn[12].ToString() != "0") dataType = String.Format("[{0}]({1},{2})", rowColumn[7].ToString().ToUpper(), rowColumn[10].ToString(), rowColumn[12].ToString());
                    else dataType = String.Format("[{0}]", rowColumn[7].ToString().ToUpper());
                    script += String.Format("\n\t[{0}]\t\t\t{1}\t\t{2},", rowColumn[3].ToString(), dataType, isNull);
                    string URLName = (rowColumn[3].ToString());
                    i++;
                }
            }
        }

        public void AddInhouseColumns(ref string script)
        {
            if (PrimaryKeyColumns.CheckedItems.Count > 0)
            {
                script += String.Format("\n\t[HashPK]\t[BINARY](16) NOT NULL,");
                script += String.Format("\n\t[HashNonPK] [BINARY](16) NOT NULL,");
            }
            else
            {
                script += String.Format("\n\t[HashRowPK] [BINARY](16) NOT NULL,");
            }
            if (TemporalTableCheck.Checked)
            {
                script += String.Format("\n\t[ICDIUpdatedBy] [VARCHAR](50) NOT NULL CONSTRAINT [DF_{0}_ICDIUpdatedBy] DEFAULT SUSER_SNAME(),", TargetTableName.Text);
                script += String.Format("\n\t[ICDIIsLocked] [BIT] NOT NULL CONSTRAINT [DF_{0}_ICDIIsLocked] DEFAULT 0,", TargetTableName.Text);
                script += String.Format("\n\t[ICDILockedTillDate] [DATETIME] NULL,");
                script += String.Format("\n\t[ICDIETLRunID] [INT] NOT NULL CONSTRAINT [DF_{0}_ICDIETLRunID] DEFAULT 0,", TargetTableName.Text);
                script += String.Format("\n\t[SysStartTime] DATETIME2(0) GENERATED ALWAYS AS ROW START  DEFAULT GETUTCDATE() NOT NULL,");
                script += String.Format("\n\t[SysEndTime] DATETIME2(0) GENERATED ALWAYS AS ROW END  DEFAULT CONVERT (DATETIME2, '9999-12-31 23:59:59.9999999') NOT NULL,");
                script += String.Format("\n\tPERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime),");
            }
            else
            {
                script += String.Format("\n\t[ICDICreatedDate] [DATETIME] NOT NULL CONSTRAINT [DF_{0}_ICDICreatedDate] DEFAULT GETUTCDATE(),", TargetTableName.Text);
                script += String.Format("\n\t[ICDICreatedBy] [VARCHAR](50) NOT NULL CONSTRAINT [DF_{0}_ICDICreatedBy] DEFAULT SUSER_SNAME(),", TargetTableName.Text);
                script += String.Format("\n\t[ICDIUpdatedDate] [DATETIME] NOT NULL CONSTRAINT [DF_{0}_ICDIUpdatedDate] DEFAULT GETUTCDATE(),", TargetTableName.Text);
                script += String.Format("\n\t[ICDIUpdatedBy] [VARCHAR](50) NOT NULL CONSTRAINT [DF_{0}_ICDIUpdatedBy] DEFAULT SUSER_SNAME(),", TargetTableName.Text);
                script += String.Format("\n\t[ICDIIsDeleted] [BIT] NOT NULL CONSTRAINT [DF_{0}_ICDIIsDeleted] DEFAULT 0,", TargetTableName.Text);
                script += String.Format("\n\t[ICDIETLRunID] [INT] NOT NULL CONSTRAINT [DF_{0}_ICDIETLRunID] DEFAULT 0,", TargetTableName.Text);
                script += String.Format("\n\t[ICDIIsLocked] [BIT] NOT NULL CONSTRAINT [DF_{0}_ICDIIsLocked] DEFAULT 0,", TargetTableName.Text);
                script += String.Format("\n\t[ICDILockedTillDate] [DATETIME] NULL,");
            }
        }
        public void CreateStgTable()
        {
            string path = String.Format("{0}{1}\\Table\\{2}.sql", stgpath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE Table [stg].[{0}]\n(", TargetTableName.Text);


            AddTableColumns(ref script);

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
                //var ax = script[index + 2];
                script = script.Remove(index, 3);
            }
            else
            {
                //HashPK and HashNonPK 
                List<int> indices = PrimaryKeyColumns.CheckedIndices.OfType<int>().ToList();
                String hashPK = null, hashNonPK = null;
                hashPK += "\n\t,CONVERT(BINARY(16),HASHBYTES('md5', ";
                hashNonPK += "\n\t,CONVERT(BINARY(16),HASHBYTES('md5', ";
                index = hashPK.Length;
                for (var i = 0; i < ColumnList.CheckedItems.Count; i++)
                {
                    if (indices.IndexOf(i) >= 0)
                    {
                        //HashPK
                        hashPK += String.Format("\n\t+ ISNULL(CONVERT(NVARCHAR,([{0}])),'^') + '|'", ColumnList.CheckedItems[i]);

                    }
                    else
                    {
                        //HashNonPK
                        hashNonPK += String.Format("\n\t+ ISNULL(CONVERT(NVARCHAR,([{0}])),'^') + '|'", ColumnList.CheckedItems[i]);
                    }
                }
                hashPK = hashPK.Remove(index, 3);
                hashNonPK = hashNonPK.Remove(index, 3);
                hashNonPK = hashNonPK.Remove(hashNonPK.Length - 6, 6);
                hashPK += "\n\t+ ISNULL(CONVERT(NVARCHAR,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear')),'^'))) AS HashPK";
                hashNonPK += ")) AS HashNonPK";
                script += hashPK + hashNonPK;
            }
            if(FiscalYearCheck.Checked)
            {
                script += String.Format("\n\t,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear') AS FiscalYear");
            }
            script += String.Format("\nFROM [stg].[{0}] WITH (NOLOCK)\nGO", TargetTableName.Text);
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(script);
                tw.Close();
            }
        }

        public void CreateDboTable()
        {
            string path = String.Format("{0}{1}\\Table\\{2}.sql", dbopath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE Table [dbo].[{0}]\n(", TargetTableName.Text);

            AddTableColumns(ref script);
            if (FiscalYearCheck.Checked)
            {
                script += String.Format("\n\t[FiscalYear] [SMALLINT] NOT NULL,");
            }
            AddInhouseColumns(ref script);

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
                if (FiscalYearCheck.Checked)
                {
                    pkColumns += String.Format("[FiscalYear],");
                }
                pkColumns = pkColumns.Remove(pkColumns.Length - 1, 1);

                script += String.Format("{0} ASC\n)", pkColumns);
            }

            script += "\n) ON [dbo_Filegroup]";
            if (TemporalTableCheck.Checked)
            {
                script += String.Format("\nWITH\n(\nSYSTEM_VERSIONING = ON (HISTORY_TABLE = History.{0}),\nDATA_COMPRESSION = PAGE\n)", TargetTableName.Text);
            }
            else
            {
                script += " WITH(DATA_COMPRESSION = PAGE)";
            }
            script += "\nGO";
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(script);
                tw.Close();
            }
        }

        public void CreateDboView()
        {
            string path = String.Format("{0}{1}\\View\\{2}.sql", dbopath, SourceName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE View [dbo].[vw{0}]\nAS\nSELECT", TargetTableName.Text);
            var index = script.Length;
            //Adding Table Columns to the View
            foreach (String column in ColumnList.CheckedItems)
            {
                script += String.Format("\n\t,[{0}]", column);
            }
            script = script.Remove(index + 2, 1);
            if (FiscalYearCheck.Checked)
            {
                script += String.Format("\n\t,[FiscalYear]");
            }
            //
            if (PrimaryKeyColumns.CheckedItems.Count > 0)
            {
                script += String.Format("\n\t,[HashPK]");
                script += String.Format("\n\t,[HashNonPK]");
            }
            else
            {
                script += String.Format("\n\t,[HashRowPK]");
            }
            if (TemporalTableCheck.Checked)
            {
                script += String.Format("\n\t,[ICDIUpdatedBy]");
                script += String.Format("\n\t,[ICDIIsLocked]");
                script += String.Format("\n\t,[ICDILockedTillDate]");
                script += String.Format("\n\t,[ICDIETLRunID]");
                script += String.Format("\n\t,[SysStartTime]");
                script += String.Format("\n\t,[SysEndTime]");
            }
            else
            {
                script += String.Format("\n\t,[ICDICreatedDate]");
                script += String.Format("\n\t,[ICDICreatedBy]");
                script += String.Format("\n\t,[ICDIUpdatedDate]");
                script += String.Format("\n\t,[ICDIUpdatedBy]");
                script += String.Format("\n\t,[ICDIIsDeleted]");
                script += String.Format("\n\t,[ICDIETLRunID]");
                script += String.Format("\n\t,[ICDIIsLocked]");
                script += String.Format("\n\t,[ICDILockedTillDate]");
            }
            script += String.Format("\nFROM [dbo].[{0}] WITH (NOLOCK)\nGO", TargetTableName.Text);
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(script);
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
                CreateDboTable();
                CreateDboView();
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