using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public TableOnboarding()
        {
            InitializeComponent();
        }

        private void AddSource()
        {
            //Adding a folder for new source
            //p.AddItem("Folder", @"C:\Users\tugar\Documents\Visual Studio 2015\Projects\WindowsFormsApplication1\WindowsFormsApplication1\test2");
            //Adding the file to the provided path
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
                tw.WriteLine("CREATE VIEW [dbo].[vwAccountGrouping]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
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
                tw.WriteLine("CREATE VIEW [dbo].[vwAccountGrouping]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
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
                tw.WriteLine("CREATE VIEW [dbo].[vwAccountGrouping]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
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
                tw.WriteLine("CREATE VIEW [dbo].[vwAccountGrouping]\nAS\nSELECT [AccountGroupingID]\n      ,[AccountGroupingName]\n      ,[FiscalYear]\n      ,[ICDIUpdatedBy]\n      ,[ICDIETLRunID]\n      ,[ICDIIsLocked]\n      ,[ICDILockedTillDate]\n      ,[HashPK]\n      ,[HashNonPK]\n      ,SysStartTime\n      ,SysEndTime\n  FROM [dbo].[AccountGrouping] WITH(NOLOCK)");
                tw.Close();
            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\stg\MSSales\Table\" + TableName.Text + ".sql";
            if (!File.Exists(path))
            {
                var p = new Microsoft.Build.Evaluation.Project(@"C:\Users\tugar\Source\Repos\Sales-IC-Datamg-AthenaDataManagement\DIDataManagement\DIDataManagement\DIDataManagement.sqlproj");
                CreateStgTable(path, p);
                CreateStgView(path, p);
                CreateDboTable(path, p);
                CreateDboView(path, p);
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
            SourceName.Items.Add("Haha");
        }
    }
}
