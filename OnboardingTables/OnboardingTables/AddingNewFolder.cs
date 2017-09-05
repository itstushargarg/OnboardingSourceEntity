using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnboardingTables
{
    public partial class AddingNewFolder : Form
    {
        public TableOnboarding tob;
        public static string SourceName;
        public AddingNewFolder()
        {
            InitializeComponent();
        }

        public void AddNewFolder()
        {
            SourceName = this.NewFolderName.Text;
            String SourcePath = StartingPage.SqlProjpath;
            String dboPath = StartingPage.dbopath;
            String stgPath = StartingPage.stgpath;
            String NewSourcePath = dboPath + SourceName + "\\";
            String stgNewSourcePath = stgPath + SourceName + "\\";
            String TablePath = "dbo\\" + SourceName + "\\Table";
            String ViewPath = "dbo\\" + SourceName + "\\View";
            String ProcedurePath = "dbo\\" + SourceName + "\\Procedure";
            String FunctionsPath = "dbo\\" + SourceName + "\\Functions";
            String stgTablePath = "stg\\" + SourceName + "\\Table";
            String stgViewPath = "stg\\" + SourceName + "\\View";
            String stgProcedurePath = "stg\\" + SourceName + "\\Procedure";
            String stgFunctionsPath = "stg\\" + SourceName + "\\Functions";
            var p = StartingPage.projectPath;
            System.IO.Directory.CreateDirectory(NewSourcePath);
            System.IO.Directory.CreateDirectory(stgNewSourcePath);
            p.AddItem("Folder", "dbo\\" + SourceName);
            p.AddItem("Folder", "stg\\" + SourceName);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Table");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Table");
            p.AddItem("Folder", TablePath);
            p.AddItem("Folder", stgTablePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "View");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "View");
            p.AddItem("Folder", ViewPath);
            p.AddItem("Folder", stgViewPath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Procedure");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Procedure");
            p.AddItem("Folder", ProcedurePath);
            p.AddItem("Folder", stgProcedurePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Function");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Function");
            p.AddItem("Folder", FunctionsPath);
            p.AddItem("Folder", stgFunctionsPath);
            p.Save();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }
    }
}
