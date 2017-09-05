using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Build.Evaluation;

namespace OnboardingTables
{
    public partial class StartingPage : Form
    {
        public static bool doesValidProjectPathExists;
        public static string chefpath;
        public static string SqlProjpath;
        public static string dbopath;
        public static string stgpath;
        public static string ChefSqlProjpath;
        public static Microsoft.Build.Evaluation.Project projectPath;
        public static Microsoft.Build.Evaluation.Project chefprojectPath;

        public StartingPage()
        {
            InitializeComponent();
        }

        private void SelectProjectButton_Click(object sender, EventArgs e)
        {
            if (BrowseProjectPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProjectPath.Text = BrowseProjectPath.FileName;
            }
            if (SqlProjpath != ProjectPath.Text)
            {
                if (ProjectPath.Text.EndsWith("DIDataManagement.sqlproj"))
                {
                    chefpath = ProjectPath.Text.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\");

                    dbopath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "dbo\\");
                    stgpath = ProjectPath.Text.Replace("DIDataManagement.sqlproj", "stg\\");
                    SqlProjpath = ProjectPath.Text;
                    projectPath = new Microsoft.Build.Evaluation.Project(SqlProjpath);
                    ChefSqlProjpath = ProjectPath.Text.Replace("\\DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "\\CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\CHEF.sqlproj");
                    chefprojectPath = new Microsoft.Build.Evaluation.Project(ChefSqlProjpath);
                    doesValidProjectPathExists = true;
                }
                else
                {
                    MessageBox.Show("Invalid project path!");
                }
            }
        }

        private void OnboardingBaseTables_Click(object sender, EventArgs e)
        {
            if (doesValidProjectPathExists)
            {
                TableOnboarding frm = new TableOnboarding();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please enter an valid project path to continue!");
            }
        }

        private void AddingFactTablesandViews_Click(object sender, EventArgs e)
        {
            if (doesValidProjectPathExists)
            {
                CreateFactOrDimension frm = new CreateFactOrDimension();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please enter an valid project path to continue!");
            }
        }

        private void AddingDimensionTablesandViews_Click(object sender, EventArgs e)
        {
            if (doesValidProjectPathExists)
            {
                CreateFactOrDimension frm = new CreateFactOrDimension();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Please enter an valid project path to continue!");
            }
        }
    }
}
