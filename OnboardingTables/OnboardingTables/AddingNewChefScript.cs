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
    public partial class AddingNewChefScript : Form
    {
        public TableOnboarding tob;
        public static string ScriptName;
        public AddingNewChefScript()
        {
            InitializeComponent();
        }

        private void ChefScriptSubmit_Click(object sender, EventArgs e)
        {
            ScriptName = this.ChefScriptName.Text;
            String SourcePath = TableOnboarding.SqlProjpath;
            String chefpath = SourcePath.Replace("DIDataManagement\\DIDataManagement.sqlproj", "CHEF.Customization\\dbo\\Scripts\\"+ ScriptName+".sql");
            File.Create(chefpath).Dispose();
            var p = TableOnboarding.projectPath;
            p.AddItem("Build", chefpath);
            p.Save();
        }
    }
}
