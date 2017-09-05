﻿using System;
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
    public partial class AddingNewChefScript : Form
    {
        public TableOnboarding tob;
        public static string ScriptName;
        public static string chefpath;
        public AddingNewChefScript()
        {
            InitializeComponent();
        }

        private void ChefScriptSubmit_Click(object sender, EventArgs e)
        {
            ScriptName = this.ChefScriptName.Text;
            String SourcePath = StartingPage.SqlProjpath;
            String chefsqlproj = StartingPage.ChefSqlProjpath;
            String chefpath_filepath = SourcePath.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\");
            chefpath = SourcePath.Replace("DIDataManagement\\DIDataManagement\\DIDataManagement.sqlproj", "CHEF 5.1-SQL2016\\CHEF.Database\\CHEF\\Scripts\\Post-Deployment\\"+ ScriptName+".sql");
            File.Create(chefpath).Dispose();
            var p = StartingPage.chefprojectPath;
            p.AddItem("None", "Scripts\\Post-Deployment\\" + ScriptName + ".sql");
            p.Save();
            tob.ListofChefScripts(chefpath_filepath);
            this.Close();
            MessageBox.Show("The Source " + ScriptName + " Successfully added");
        }
    }
}
