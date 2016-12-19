using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace OnboardingTables
{
    public partial class AddingNewSource : Form
    {
        public TableOnboarding tob;
        public static string SourceName;
        public AddingNewSource()
        {
            InitializeComponent();
        }
        
        private void Submit_Click(object sender, EventArgs e)
        {
            SourceName = this.NewSourceName.Text;
            String SourcePath = TableOnboarding.SqlProjpath;
            String dboPath = TableOnboarding.dbopath;
            String NewSourcePath = dboPath + SourceName + "\\";
            String TablePath = "\\dbo\\" + SourceName + "\\Table";
            String ViewPath = "\\dbo\\" + SourceName + "\\View";
            String ProcedurePath = "\\dbo\\" + SourceName + "\\Procedure";
            String FunctionsPath = "\\dbo\\" + SourceName + "\\Functions";
            var p = new Microsoft.Build.Evaluation.Project(SourcePath);
            System.IO.Directory.CreateDirectory(NewSourcePath);
            p.AddItem("Folder", "dbo\\" + SourceName);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Table");
            p.AddItem("Folder", TablePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "View");
            p.AddItem("Folder", ViewPath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Procedure");
            p.AddItem("Folder", ProcedurePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Function");
            p.AddItem("Folder", FunctionsPath);
            p.Save();
            tob.ListofSources(dboPath);
            this.Close();
            MessageBox.Show("The Source " + SourceName + " Successfully added");
        }
    }
}
