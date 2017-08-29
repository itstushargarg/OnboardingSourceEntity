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
    public partial class StartingPage : Form
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        private void OnboardingBaseTables_Click(object sender, EventArgs e)
        {
            TableOnboarding frm = new TableOnboarding();
            frm.Show();
        }

        private void AddingFactTablesandViews_Click(object sender, EventArgs e)
        {
            CreateFactOrDimension frm = new CreateFactOrDimension();
            frm.Show();
        }

        private void AddingDimensionTablesandViews_Click(object sender, EventArgs e)
        {
            CreateFactOrDimension frm = new CreateFactOrDimension();
            frm.Show();
        }
    }
}
