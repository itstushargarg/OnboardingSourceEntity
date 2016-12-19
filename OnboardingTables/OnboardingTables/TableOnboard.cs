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
        public DataRowCollection schemaColumns;
        public static string SqlProjpath;
        public static string dbopath;
        public static Microsoft.Build.Evaluation.Project projectPath;
        public TableOnboarding()
        {
            InitializeComponent();
        }

        private void AddCheckList()
        {
            try
            {
                foreach (DataRow rowColumn in schemaColumns)
                {
                    //Gets the url name and path when the status is enabled. The status of Enabled / Disabled is setup in the users option page
                    string URLName = (rowColumn[3].ToString());
                    //bool enabled = true;
                    ColumnList.Items.Add(URLName, true);
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
                schemaColumns = connection.GetSchema("Columns", restrictions).Rows;

                foreach (System.Data.DataRow rowColumn in schemaColumns)
                {
                    var ColumnName = (rowColumn[3].ToString());
                }
                AddCheckList();
            }
        }
        public void CreateStgTable(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TableName.Text + ".sql";
            p.AddItem("Build", path);
            p.Save();
            //File.Create(path).Dispose();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE Table [stg].[" + TableName.Text +"]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateStgView(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\View\vw" + TableName.Text + ".sql";
            p.AddItem("Build", path);
            p.Save();
            //File.Create(path).Dispose();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [stg].[vw" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateDboTable(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\dbo\MSSales\Table\" + TableName.Text + ".sql";
            p.AddItem("Build", path);
            p.Save();
            //File.Create(path).Dispose();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }

        public void CreateDboView(string pathi, Microsoft.Build.Evaluation.Project p)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\dbo\MSSales\View\vw" + TableName.Text + ".sql";
            p.AddItem("Build", path);
            p.Save();
            //File.Create(path).Dispose();
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("CREATE VIEW [dbo].[" + TableName.Text + "]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            CreateColumnList();
            //string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TableName.Text + ".sql";
            //if (!File.Exists(path))
            //{
            //    CreateStgTable(path, projectPath);
            //    CreateStgView(path, projectPath);
            //    CreateDboTable(path, projectPath);
            //    CreateDboView(path, projectPath);
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
           
            String dboFilePath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "dbo\\");
            SqlProjpath = ProjectPath.Text;
            dbopath = dboFilePath;
            projectPath = new Microsoft.Build.Evaluation.Project(SqlProjpath);
            DirectoryInfo d = new DirectoryInfo(@dboFilePath);//Assuming Test is your Folder
            DirectoryInfo[] Files = d.GetDirectories(); //Getting Text files
            foreach (DirectoryInfo file in Files)
            {
               
                SourceName.Items.Add(file);
            }
            
        }

        private void AddSource_Click(object sender, EventArgs e)
        {
            AddingNewSource AddingNewSource = new AddingNewSource();
            AddingNewSource.Show();
        }
    }
}
