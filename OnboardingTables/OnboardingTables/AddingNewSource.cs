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
        public static string SourceName;
        public AddingNewSource()
        {
            InitializeComponent();
        }

        private void NewSourceName_TextChanged(object sender, EventArgs e)
        {
            SourceName = this.NewSourceName.Text;
            String SourcePath = TableOnboarding.SqlProjpath;
            String dboPath = TableOnboarding.dbopath;
            String NewSourcePath= SourcePath + SourceName+"\\";
            var p = new Microsoft.Build.Evaluation.Project(SourcePath);
            p.AddItem("Folder", dboPath);
            System.IO.Directory.CreateDirectory(NewSourcePath);
            System.IO.Directory.CreateDirectory(NewSourcePath+"Table");
            p.AddItem("Folder", NewSourcePath + "Table");
            System.IO.Directory.CreateDirectory(NewSourcePath + "View");
            p.AddItem("Folder", NewSourcePath + "View");
            System.IO.Directory.CreateDirectory(NewSourcePath + "Procedure");
            p.AddItem("Folder", NewSourcePath + "Procedure");
            System.IO.Directory.CreateDirectory(NewSourcePath + "Function");
            p.AddItem("Folder", NewSourcePath + "Function");
            p.Save();

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("The Source " +SourceName + " Successfully added");
        }
    }
}
