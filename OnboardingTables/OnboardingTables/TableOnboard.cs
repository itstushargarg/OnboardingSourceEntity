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


        private void CreateColumnList(String connectionString)
        {
            //var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True", ServerName.Text, DatabaseName.Text);
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
            if (PrimaryKeyColumns.CheckedItems.Count > 0 && PrimaryKeyColumns.CheckedItems.Count != ColumnList.CheckedItems.Count)
            {
                script += String.Format("\n\t[HashPK]\t[BINARY](16) NOT NULL,");
                script += String.Format("\n\t[HashNonPK] [BINARY](16) NOT NULL,");
            }
            else
            {
                script += String.Format("\n\t[HashRowKey] [BINARY](16) NOT NULL,");
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
            string path = String.Format("{0}{1}\\Table\\{2}.sql", stgpath, TargetFolderName.Text,TargetTableName.Text);
            projectPath.AddItem("Build", path);
            projectPath.Save();
            File.Create(path).Dispose();
            String script = String.Format("CREATE Table [stg].[{0}]\n(", TargetTableName.Text);


            AddTableColumns(ref script);

            //Adding Primary Key Constraint
            if (PrimaryKeyColumns.CheckedItems.Count == 0 || PrimaryKeyColumns.CheckedItems.Count == ColumnList.CheckedItems.Count)
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
            string path = String.Format("{0}{1}\\View\\{2}.sql", stgpath, TargetFolderName.Text,TargetTableName.Text);
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

            if (PrimaryKeyColumns.CheckedItems.Count == 0 || PrimaryKeyColumns.CheckedItems.Count == ColumnList.CheckedItems.Count)
            {
                //HashRowKey
                script += "\n\t,CONVERT(BINARY(16),HASHBYTES('md5', ";
                index = script.Length;
                foreach (String column in ColumnList.CheckedItems)
                {
                    script += String.Format("\n\t+ ISNULL(CONVERT(NVARCHAR,([{0}])),'^') + '|'", column);
                }
                if (FiscalYearCheck.Checked)
                {
                    script += "\n\t+ ISNULL(CONVERT(NVARCHAR,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear')),'^'))) AS HashRowKey";
                }
                else
                {
                    script = script.Remove(script.Length - 6, 6);
                    script += ")) AS HashRowKey";
                }
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
                if (FiscalYearCheck.Checked)
                {
                    hashPK += "\n\t+ ISNULL(CONVERT(NVARCHAR,(SELECT CAST(ConfigValue AS SMALLINT) FROM [dbo].[Configuration] WITH (NOLOCK) WHERE ConfigName = 'CurrentFiscalYear')),'^'))) AS HashPK";
                }
                else
                {
                    hashPK = hashPK.Remove(hashPK.Length - 6, 6);
                    hashPK += ")) AS hashPK";
                }
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
            string path = String.Format("{0}{1}\\Table\\{2}.sql", dbopath, TargetFolderName.Text,TargetTableName.Text);
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
            if (PrimaryKeyColumns.CheckedItems.Count == 0 || PrimaryKeyColumns.CheckedItems.Count == ColumnList.CheckedItems.Count)
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
            string path = String.Format("{0}{1}\\View\\{2}.sql", dbopath, TargetFolderName.Text,TargetTableName.Text);
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
            if (PrimaryKeyColumns.CheckedItems.Count > 0 && PrimaryKeyColumns.CheckedItems.Count != ColumnList.CheckedItems.Count)
            {
                script += String.Format("\n\t,[HashPK]");
                script += String.Format("\n\t,[HashNonPK]");
            }
            else
            {
                script += String.Format("\n\t,[HashRowKey]");
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
        public void CreateMetadataFile()
        {
            ScriptName.Text = ScriptName.SelectedItem.ToString();
            int dboProcessid = Int32.Parse(ProcessID.Text) + 1;
            String chefpath_filepath = SqlProjpath.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\");
            String file = chefpath_filepath + ScriptName.Text;
            String mergeQuery = null;
            if ((TemporalTableCheck.Checked) && (PrimaryKeyColumns.CheckedItems.Count == 0 || ColumnList.CheckedItems.Count == PrimaryKeyColumns.CheckedItems.Count))
                mergeQuery = String.Format("SELECT dbo.fnICDDHMergeSQL(''stg'', ''vw{0}'', ''dbo'', ''{0}'', 0, 1, '''', '''', ''HashRowKey'', &quot; +@[CHEF::ETLRunId]+&quot;)", TargetTableName.Text);
            else if ((TemporalTableCheck.Checked) && (PrimaryKeyColumns.CheckedItems.Count > 0 || ColumnList.CheckedItems.Count > PrimaryKeyColumns.CheckedItems.Count))
                mergeQuery = String.Format("SELECT dbo.fnICDDHMergeSQL(''stg'', ''vw{0}'', ''dbo'', ''{0}'', 0,0,''HashPK'',''HashNonPK'','''', &quot; +@[CHEF::ETLRunId]+&quot;)", TargetTableName.Text);
            else if (!(TemporalTableCheck.Checked) && (PrimaryKeyColumns.CheckedItems.Count == 0 || ColumnList.CheckedItems.Count == PrimaryKeyColumns.CheckedItems.Count))
                mergeQuery = String.Format("SELECT dbo.fnMergeSQL(''stg'', ''vw{0}'', ''dbo'', ''{0}'', 0, 1, '''', '''', ''HashRowKey'', &quot; +@[CHEF::ETLRunId]+&quot;)", TargetTableName.Text);
            else if (!(TemporalTableCheck.Checked) && (PrimaryKeyColumns.CheckedItems.Count > 0 || ColumnList.CheckedItems.Count > PrimaryKeyColumns.CheckedItems.Count))
                mergeQuery = String.Format("SELECT dbo.fnMergeSQL(''stg'', ''vw{0}'', ''dbo'', ''{0}'', 0,0,''HashPK'',''HashNonPK'','''', &quot; +@[CHEF::ETLRunId]+&quot;)", TargetTableName.Text);
            var x = new FileInfo(file);
            string xml = String.Format("SELECT\n {0},\n{1},\n'{2}\',\n1,\n'stg_{3}' \n,' < CHEFMetaData ApplicationName =\"IncentiveCompensation\">\n <Process ID = \"{0}\" Name=\"stg_{3}\" DefaultAllowTruncate = \"False\" VerboseLogging = \"False\" ExecuteExistingPackage = \"False\" > \n    <ConnectionSet>\n<SQLConnection key = \"{2}\" />\n<SQLConnection key = \"ICDDH\" />\n<SQLConnection key = \"CHEF\" />\n</ConnectionSet>\n  <Step ID=\"{0}1\" Name=\"{2}_{3}\" TypeID=\"1\" TypeName=\"Staging\"> \n<DataFlowSet Name=\"Loading {3}\" SourceConnection=\"{2}\" TargetConnection=\"ICDDH\" SourceType=\"SELECTSQL\" TargetType=\"Table\" PickColumnsFromTarget=\"True\" RunParallel=\"True\" TruncateOrDeleteBeforeInsert=\"Truncate\" DeleteFilterClause=\"\">\n <DataFlow Name=\"Populate {3}\" SourceName=\"select 1\" TargetName=\"[stg].[{3}]\" />\n</DataFlowSet>\n</Step>\n</Process>\n</CHEFMetaData>', \n0,\nSystem_User, \nGetDate(), \nSystem_User, \nGetDate() \nUNION ALL\n\n  SELECT \n{4}, \n{1} ,\n'{2}',\n 2, \n'dbo_{3}', \n'<CHEFMetaData ApplicationName=\"IncentiveCompensation\">\n<Process ID = \"{4}\" Name = \"dbo_{3}\" DefaultAllowTruncate = \"False\" VerboseLogging = \"False\" ExecuteExistingPackage = \"False\" >  \n  <ConnectionSet>\n<SQLConnection key = \"CHEF\" />\n<SQLConnection key = \"ICDDH\" />\n</ConnectionSet>\n<Variables>\n<Variable Name = \"MergeQuery\" DataType = \"String\" Value = \"\"/>\n<Variable Name = \"ETLRunId\" DataType = \"String\" Value = \"\" />\n</Variables><Step ID=\"{4}1\" Name=\"{3} Generate Merge Query\" TypeID=\"1\" TypeName=\"Staging\">\n<SetVariables>\n<SetVariable SQLStatement = \"SELECT CHEF.fnETLRunID(''{2}'')\" TargetConnection = \"CHEF\">\n<ResultSet VariableName = \"ETLRunId\" Order = \"0\" />\n</SetVariable >\n<SetVariable SQLStatement = \"{5}\" TargetConnection = \"ICDDH\" ><ResultSet VariableName = \"MergeQuery\" Order = \"0\" />\n</SetVariable>\n</SetVariables>\n</Step>\n<Step ID=\"{4}2\" Name=\"{3} Execute Merge Query\" TypeID=\"1\" TypeName=\"Staging\"><SQLTaskSet Name = \"Execute Merge\" TargetConnection = \"ICDDH\" RunParallel = \"False\" >\n<SQLTask Name = \"Execute Merge\" SQLStatement = \"&quot;+@[CHEF::MergeQuery]+&quot;\" />\n</SQLTaskSet>\n</Step>\n</Process>\n</CHEFMetaData>'\n,0\n,System_User\n,GetDate()\n,System_User\n,GetDate()\n", ProcessID.Text, CatalogID.Text, SourceName.Text, TargetTableName.Text, dboProcessid, mergeQuery);
            string data = String.Format("USE [$(DatabaseName)];\nGO\n--------------------------------------------------\n--Insert / Update / Delete script for table MetaData\n--------------------------------------------------\nSET NOCOUNT ON\nCREATE TABLE #MetaData\n(\n\n[ProcessID][int] NOT NULL,\n[CatalogID][int] NOT NULL,\n[CatalogName][varchar](128) NOT NULL,\n[Precedence][int] NOT NULL,\n[ProcessName][varchar](128) NOT NULL,\n[MetaData][xml] NOT NULL,\n[Type][tinyint] NOT NULL,\n[CreatedBy][varchar](32) NOT NULL CONSTRAINT[DF_MetaData_CreatedBy]  DEFAULT(left(suser_sname(), (32))),\n[CreatedDate][datetime] NOT NULL CONSTRAINT[DF_MetaData_CreatedDate]  DEFAULT(getdate()),\n[UpdatedBy][varchar](32) NOT NULL CONSTRAINT[DF_MetaData_UpdatedBy]  DEFAULT(left(suser_sname(), (32))),\n[UpdatedDate][datetime] NOT NULL CONSTRAINT[DF_MetaData_UpdatedDate]  DEFAULT(getdate())\n)\nGO\n DECLARE\n@vInsertedRows INT = 0\n, @vUpdatedRows INT = 0\n, @vDeletedRows INT = 0\n, @vNow         DATETIME\nSELECT @vNow = GETDATE()\n\n--------------------------------------------------\n-- Populate base temp table.\n--------------------------------------------------\nINSERT #MetaData\n([ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])\n-------------------------------------------------------\n-- Begin script transaction\n----------------------------------------------------\nBEGIN TRAN\n\n\n--------------------------------------------------\n-- UPDATE existing data.\n\n--------------------------------------------------\n-- Dev Note - Update will not update ' to NULL OR 0 to NULL\nUPDATE[CHEF].[MetaData]\nSET[CatalogName] = source.[CatalogName],\n[Precedence] = source.[Precedence],\n[ProcessName] = source.[ProcessName],\n [MetaData] = source.[MetaData],\n[Type] = source.[Type],\n[UpdatedBy] = source.[UpdatedBy],\n[UpdatedDate] = source.[UpdatedDate]\nFROM #MetaData source\nJOIN[CHEF].[MetaData] target\nON      source.ProcessID = target.ProcessID AND source.CatalogID = target.CatalogID\nAND(\nISNULL(source.[CatalogName], '') <> ISNULL(target.[CatalogName], '')\nOR  ISNULL(source.[Precedence], '') <> ISNULL(target.[Precedence], '')\nOR  ISNULL(source.[ProcessName], '') <> ISNULL(target.[ProcessName], '')\nOR  CONVERT(VARCHAR(MAX), source.[MetaData]) <> CONVERT(VARCHAR(MAX), target.[MetaData])\n\nOR  ISNULL(source.[Type], 0) <> ISNULL(target.[Type], 0)\nOR  ISNULL(source.[UpdatedBy], '') <> ISNULL(target.[UpdatedBy], ''))\n\nSELECT @vUpdatedRows = @@ROWCOUNT\n--------------------------------------------------\n-- Insert new data.{0}\n--------------------------------------------------\nINSERT[CHEF].[MetaData]([ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate])\nSELECT[ProcessID],[CatalogID],[CatalogName],[Precedence],[ProcessName],[MetaData],[Type],[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate]\nFROM #MetaData source\nWHERE NOT EXISTS\n(\nSELECT* FROM [CHEF].[MetaData] target WHERE source.ProcessID = target.ProcessID AND source.CatalogID = target.CatalogID\n)\nSELECT @vInsertedRows = @@ROWCOUNT\nGOTO SuccessfulExit\nFailureExit:\nROLLBACK\nRETURN\nSuccessfulExit:\nPRINT 'Data for MetaData modified. Inserted: ' + CONVERT(VARCHAR(10), @vInsertedRows) + ' rows. Updated: ' + CONVERT(VARCHAR(10), @vUpdatedRows) + ' rows. Deleted: ' + CONVERT(VARCHAR(10), ISNULL(@vDeletedRows, 0)) + ' rows'\nCOMMIT\n--------------------------------------------------\n-- Drop temp table \n--------------------------------------------------\nGO\nDROP TABLE #MetaData\nGO\n", xml);

            if (new FileInfo(file).Length == 0)
            {
                TextWriter tw = new StreamWriter(file);
                tw.WriteLine(data);
                tw.Close();
            }
            else
            {
                //string breakpoint = "-----------------------------------------------------\n-- Begin script transaction\n---------------------------------------------------- - ";
                string text = File.ReadAllText(file);
                int lastindex = text.LastIndexOf("GETUTCDATE()", StringComparison.OrdinalIgnoreCase);
                lastindex += 12;
                text = text.Insert(lastindex, "\nUNION ALL\n" + xml);
                string initialpart = text.Substring(0, lastindex + 12);
                string lastpart = text.Substring(lastindex + 12);
                using (TextWriter tw = new StreamWriter(file))
                {
                    tw.Write(text);
                    tw.Close();
                }
            }
        }
        public void AddToTemporal()
        {
            String file = SqlProjpath.Replace("DIDataManagement.sqlproj", "Scripts\\Post-Deployment\\TemporalSystemVersioning.sql");
            string data = String.Format("\nUNION ALL SELECT '{0}'", TargetTableName.Text);
            string text = File.ReadAllText(file);
            int lastindex = text.LastIndexOf("UNION ALL SELECT", StringComparison.OrdinalIgnoreCase);
            lastindex += 16;
            //Finding index of next newline character
            while (text[lastindex] != '\n')
            {
                lastindex++;
            }
            text = text.Insert(lastindex, data);
            using (TextWriter tw = new StreamWriter(file))
            {
                tw.Write(text);
                tw.Close();
            }
        }

        public void AddToSourceMaster()
        {
            String file = ChefSqlProjpath.Replace("CHEF.sqlproj", "Scripts\\Post-Deployment\\CHEF_SourceMaster_Insert.sql");
            string data = String.Format("\n,('{0}'\t\t\t\t\t,1440	, DATEADD(MINUTE,1740,CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 101))) , 1 , 0 , 0 , NULL , DATEADD( MINUTE , -1440 , DATEADD(dd, 0, DATEDIFF(dd, 0, GETUTCDATE())) ),1);", SourceName.Text);
            string text = File.ReadAllText(file);
            int lastindex = text.LastIndexOf("GETUTCDATE()", StringComparison.OrdinalIgnoreCase);
            lastindex += 12;
            //Finding index of next newline character
            while (text[lastindex] != '\n')
            {
                lastindex++;
            }
            text = text.Insert(lastindex, data);
            using (TextWriter tw = new StreamWriter(file))
            {
                tw.Write(text);
                tw.Close();
            }
        }
        public void AddToProcessMonior()
        {
            //Checking if Catalog ID exists in the Table ProcessMonitor
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataReader reader;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT CatalogID FROM CHEF.ProcessMonitor Where CatalogID = {0};", CatalogID.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    String file = ChefSqlProjpath.Replace("CHEF.sqlproj", "Scripts\\Post-Deployment\\CHEF_ProcessMonitor_insert.sql");
                    string data = String.Format("\nUNION ALL");
                    data += String.Format("\nSELECT SourceMasterID, {0}, GETUTCDATE() , NULL FROM  [CHEF].[SourceMaster] WITH (NOLOCK) WHERE Sourcename ='{1}'", CatalogID.Text, SourceName.Text);
                    string text = File.ReadAllText(file);
                    int lastindex = text.LastIndexOf("Sourcename", StringComparison.OrdinalIgnoreCase);
                    lastindex += 10;
                    //Finding index of next newline character
                    while (text[lastindex] != '\n')
                    {
                        lastindex++;
                    }
                    text = text.Insert(lastindex, data);
                    using (TextWriter tw = new StreamWriter(file))
                    {
                        tw.Write(text);
                        tw.Close();
                    }
                }
                reader.Close();
                connection.Close();
            }
        }
        public void Submit_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TargetTableName.Text + ".sql";
            if (!File.Exists(path))
            {
                CreateMetadataFile();
                AddToProcessMonior();
                AddToSourceMaster();
                CreateStgTable();
                CreateStgView();
                CreateDboTable();
                CreateDboView();
                //Adding temporal table to TemporalSystemVersioning
                if (TemporalTableCheck.Checked)
                {
                    AddToTemporal();
                }
                MessageBox.Show("All the required scripts for  the Table: " + TargetTableName.Text + "have been successfully added");
                this.Close();

            }
            else if (File.Exists(path))
            {
                //Error Handling
            }
        }


        private void SelectProject_Click(object sender, EventArgs e)
        {
            if (BrowseProjectPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProjectPath.Text = BrowseProjectPath.FileName;
            }
            String chefpath = ProjectPath.Text.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\");

            dbopath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "dbo\\");
            stgpath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "stg\\");
            SqlProjpath = ProjectPath.Text;
            projectPath = new Microsoft.Build.Evaluation.Project(SqlProjpath);
            ListofSources();
            ListOfFolders(dbopath);
            ListofChefScripts(chefpath);
            ChefSqlProjpath = ProjectPath.Text.Replace("\\DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "\\CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\CHEF.sqlproj");
            chefprojectPath = new Microsoft.Build.Evaluation.Project(ChefSqlProjpath);
        }
        public void ListofSources()
        {
            SourceName.Items.Clear();
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT ConfigKey FROM CHEF.Configuration WHERE TValue like 'Data%'");
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader =  command.ExecuteReader();
                while (reader.Read())
                {
                    SourceName.Items.Add(reader.GetString(0));
                }
                connection.Close();
            }

            SourceName.Text = AddingNewSource.SourceName;
        }

        public void ListOfFolders(String dboFilePath)
        {
            TargetFolderName.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@dboFilePath);//Assuming Test is your Folder
            DirectoryInfo[] Files = d.GetDirectories();
            foreach (DirectoryInfo file in Files)
            {
                if (file.Name != "Common" && file.Name != "Fact" && file.Name != "Dimension")
                    TargetFolderName.Items.Add(file);
            }
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

                //ScriptName.Text = "newScript";
                ScriptName.Text = AddingNewChefScript.ScriptName;
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
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            String reader;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT TValue FROM CHEF.Configuration WHERE ConfigKey = '{0}'", SourceName.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                reader =(String) command.ExecuteScalar();
                if (reader.Contains("Thumbprint"))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(reader);
                    if (builder.IntegratedSecurity == false)
                    {
                        ConnectionEncryption Decrypter = new ConnectionEncryption();
                        builder.Password = Decrypter.DecryptString(builder.Password);
                    }
                    CreateColumnList(builder.ToString());
                }
                else
                {
                    CreateColumnList(ConnectionString.Text);
                }
                connection.Close();
            }
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

        private void SourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT TValue FROM CHEF.Configuration WHERE ConfigKey = '{0}'", SourceName.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                ConnectionString.Text = (String)command.ExecuteScalar();
                connection.Close();
            }
        }
    }
}