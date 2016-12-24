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
        public static string ChefSqlProjpath;
        public static Microsoft.Build.Evaluation.Project projectPath;
        public static Microsoft.Build.Evaluation.Project chefprojectPath;
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
        public void CreateMetadataFile()
        {
            ScriptName.Text = ScriptName.SelectedItem.ToString();
            int dboProcessid = Int32.Parse(ProcessID.Text)+1;
            String chefpath_filepath = SqlProjpath.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\");
            String file = chefpath_filepath + ScriptName.Text;
            if (new FileInfo(file).Length == 0) { 
            string data = String.Format("USE [$(DatabaseName)];\nGO\n--------------------------------------------------\n--Insert / Update / Delete script for table MetaData\n--------------------------------------------------\nSET NOCOUNT ON\nCREATE TABLE #MetaData\n(\n\n[ProcessID][int] NOT NULL,\n[CatalogID][int] NOT NULL,\n[CatalogName][varchar](128) NOT NULL,\n[Precedence][int] NOT NULL,\n[ProcessName][varchar](128) NOT NULL,\n[MetaData][xml] NOT NULL,\n[Type][tinyint] NOT NULL,\n[CreatedBy][varchar](32) NOT NULL CONSTRAINT[DF_MetaData_CreatedBy]  DEFAULT(left(suser_sname(), (32))),\n[CreatedDate][datetime] NOT NULL CONSTRAINT[DF_MetaData_CreatedDate]  DEFAULT(getdate()),\n[UpdatedBy][varchar](32) NOT NULL CONSTRAINT[DF_MetaData_UpdatedBy]  DEFAULT(left(suser_sname(), (32))),\n[UpdatedDate][datetime] NOT NULL CONSTRAINT[DF_MetaData_UpdatedDate]  DEFAULT(getdate())\n)\nGO\n DECLARE\n@vInsertedRows INT = 0\n, @vUpdatedRows INT = 0\n, @vDeletedRows INT = 0\n, @vNow         DATETIME\nSELECT @vNow = GETDATE()\n\n--------------------------------------------------\n-- Populate base temp table.\n--------------------------------------------------\nINSERT #MetaData\n([ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])\nSELECT\n {0},\n{1},\n'{2}\',\n1,\n'stg_{3}' \n,'<CHEFMetaData ApplicationName=\"IncentiveCompensation\">\n <Process ID = \"{0}\" Name=\"stg_{3}\" DefaultAllowTruncate = \"False\" VerboseLogging = \"False\" ExecuteExistingPackage = \"False\" > \n    <ConnectionSet>\n<SQLConnection key = \"{2}\" />\n<SQLConnection key = \"ICDDH\" />\n<SQLConnection key = \"CHEF\" />\n</ConnectionSet>\n  <Step ID=\"{0}1\" Name=\"{2}_{3}\" TypeID=\"1\" TypeName=\"Staging\"> \n<DataFlowSet Name=\"Loading {3}\" SourceConnection=\"{2}\" TargetConnection=\"ICDDH\" SourceType=\"SELECTSQL\" TargetType=\"Table\" PickColumnsFromTarget=\"True\" RunParallel=\"True\" TruncateOrDeleteBeforeInsert=\"Truncate\" DeleteFilterClause=\"\">\n <DataFlow Name=\"Populate {3}\" SourceName=\"select 1\" TargetName=\"[stg].[{3}]\" />\n</DataFlowSet>\n</Step>\n</Process>\n</CHEFMetaData>', \n0,\nSystem_User, \nGetDate(), \nSystem_User, \nGetDate() \nUNION ALL\n\n  SELECT \n{4}, \n{1} ,\n'{2}',\n 2, \n'dbo_{3}', \n'<CHEFMetaData ApplicationName=\"IncentiveCompensation\">\n<Process ID = \"{4}\" Name = \"dbo_{3}\" DefaultAllowTruncate = \"False\" VerboseLogging = \"False\" ExecuteExistingPackage = \"False\" >  \n  <ConnectionSet>\n<SQLConnection key = \"CHEF\" />\n<SQLConnection key = \"ICDDH\" />\n</ConnectionSet>\n<Variables>\n<Variable Name = \"MergeQuery\" DataType = \"String\" Value = \"\"/>\n<Variable Name = \"ETLRunId\" DataType = \"String\" Value = \"\" />\n</Variables><Step ID=\"{4}1\" Name=\"{3} Generate Merge Query\" TypeID=\"1\" TypeName=\"Staging\">\n<SetVariables>\n<SetVariable SQLStatement = \"SELECT CHEF.fnETLRunID(''{2}'')\" TargetConnection = \"CHEF\">\n<ResultSet VariableName = \"ETLRunId\" Order = \"0\" />\n</SetVariable >\n<SetVariable SQLStatement = \"SELECT dbo.fnMergeSQL(''stg'',''vw{3}'',''dbo'',''{3}'',0,1,'''','''',''HashRowKey'',&quot;+@[CHEF::ETLRunId]+&quot;)\" TargetConnection = \"ICDDH\" ><ResultSet VariableName = \"MergeQuery\" Order = \"0\" />\n</SetVariable>\n</SetVariables>\n</Step>\n<Step ID=\"{4}2\" Name=\"{3} Execute Merge Query\" TypeID=\"1\" TypeName=\"Staging\"><SQLTaskSet Name = \"Execute Merge\" TargetConnection = \"ICDDH\" RunParallel = \"False\" >\n<SQLTask Name = \"Execute Merge\" SQLStatement = \"&quot;+@[CHEF::MergeQuery]+&quot;\" />\n</SQLTaskSet>\n</Step>\n</Process>\n</CHEFMetaData>'\n,0\n,System_User\n,GetDate()\n,System_User\n,GetDate()\n-------------------------------------------------------\n-- Begin script transaction\n----------------------------------------------------\nBEGIN TRAN\n\n\n--------------------------------------------------\n-- UPDATE existing data.\n\n--------------------------------------------------\n-- Dev Note - Update will not update ' to NULL OR 0 to NULL\nUPDATE[CHEF].[MetaData]\nSET[CatalogName] = source.[CatalogName],\n[Precedence] = source.[Precedence],\n[ProcessName] = source.[ProcessName],\n [MetaData] = source.[MetaData],\n[Type] = source.[Type],\n[UpdatedBy] = source.[UpdatedBy],\n[UpdatedDate] = source.[UpdatedDate]\nFROM #MetaData source\nJOIN[CHEF].[MetaData] target\nON      source.ProcessID = target.ProcessID AND source.CatalogID = target.CatalogID\nAND(\nISNULL(source.[CatalogName], '') <> ISNULL(target.[CatalogName], '')\nOR  ISNULL(source.[Precedence], '') <> ISNULL(target.[Precedence], '')\nOR  ISNULL(source.[ProcessName], '') <> ISNULL(target.[ProcessName], '')\nOR  CONVERT(VARCHAR(MAX), source.[MetaData]) <> CONVERT(VARCHAR(MAX), target.[MetaData])\n\nOR  ISNULL(source.[Type], 0) <> ISNULL(target.[Type], 0)\nOR  ISNULL(source.[UpdatedBy], '') <> ISNULL(target.[UpdatedBy], ''))\n\nSELECT @vUpdatedRows = @@ROWCOUNT\n--------------------------------------------------\n-- Insert new data.\n--------------------------------------------------\nINSERT[CHEF].[MetaData]([ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])\nSELECT[ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate]\nFROM #MetaData source\nWHERE NOT EXISTS\n(\nSELECT* FROM [CHEF].[MetaData] target WHERE source.ProcessID = target.ProcessID AND source.CatalogID = target.CatalogID\n)\nSELECT @vInsertedRows = @@ROWCOUNT\nGOTO SuccessfulExit\nFailureExit:\nROLLBACK\nRETURN\nSuccessfulExit:\nPRINT 'Data for MetaData modified. Inserted: ' + CONVERT(VARCHAR(10), @vInsertedRows) + ' rows. Updated: ' + CONVERT(VARCHAR(10), @vUpdatedRows) + ' rows. Deleted: ' + CONVERT(VARCHAR(10), ISNULL(@vDeletedRows, 0)) + ' rows'\nCOMMIT\n--------------------------------------------------\n-- Drop temp table \n--------------------------------------------------\nGO\nDROP TABLE #MetaData\nGO\n", ProcessID.Text, CatalogID.Text, SourceName.Text, TableName.Text, dboProcessid);
            TextWriter tw = new StreamWriter(AddingNewChefScript.chefpath);
            tw.WriteLine(data);
            tw.Close();
        }

        }
        private void Submit_Click(object sender, EventArgs e)
        {
            CreateMetadataFile();
            //string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TableName.Text + ".sql";
            //if (!File.Exists(path))
            //{
            //    CreateStgTable();
            //    //CreateStgView(path, projectPath);
            //    //CreateDboTable(path, projectPath);
            //    //CreateDboView(path, projectPath);

            //}
            //else if (File.Exists(path))
            //{
            //    //Error Handling
            //}
            ////string text = System.IO.File.ReadAllText(@"C:\Users\tugar\Desktop\ReadMe.txt");
            ////System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
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
            ChefSqlProjpath = ProjectPath.Text.Replace("\\DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "\\CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\CHEF.sqlproj");
            chefprojectPath = new Microsoft.Build.Evaluation.Project(ChefSqlProjpath);
        }
        public void ListofSources(String dboFilePath)
        {

            SourceName.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@dboFilePath);//Assuming Test is your Folder
            DirectoryInfo[] Files = d.GetDirectories();
            foreach (DirectoryInfo file in Files)
            {
                if(file.Name!="Common" && file.Name != "Fact" && file.Name != "Dimension")
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
            if (ScriptName.SelectedItem != null) { 
            
            ScriptName.Text = "newScript";
            }

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