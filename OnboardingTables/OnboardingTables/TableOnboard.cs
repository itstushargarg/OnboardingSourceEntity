using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private List<String> CreateColumnList()
        {
            String columnName = null;
            List<String> columnList = new List<String>();
            String column = ColumnList.Text;
            int j = 0;
            for (int i = 0; i < column.Length; i++)
            {
                column = ColumnList.Text.Substring(j, ColumnList.Text.Length - j);
                i = 0;
                while (column[i] == '[' || column[i] == ' ' || column[i] == '\t' || column[i] == '\n')
                {
                    i++;
                }
                while (column[i] != ']' && column[i] != ' ')
                {
                    columnName += column[i++];
                }
                columnList.Add(columnName);
                columnName = null;
                while (i < column.Length && column[i] != ',')
                {
                    i++;
                }
                j += i + 2;

            }
            return columnList;
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
