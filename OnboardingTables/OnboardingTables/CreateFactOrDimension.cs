using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnboardingTables
{
    public partial class CreateFactOrDimension : Form
    {
        public CheckedListBox OriginalTable;
        public DataRowCollection sourceTableColumns;
        public CreateFactOrDimension()
        {
            InitializeComponent();
            SearchTable.TextChanged += new EventHandler(SearchTable_TextChanged);
            OriginalTable = new CheckedListBox();
            ListOfTables();
        }

        public void ListOfTables()
        {
            var connectionString = String.Format("Data Source=AZICDDHUAT01.partners.extranet.microsoft.com;Initial Catalog=ICDDH;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable dt = connection.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[1] + '.' + (string)row[2];
                    TablesList.Items.Add(tablename);
                    OriginalTable.Items.Add(tablename);
                }
                dt = connection.GetSchema("Views");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[1] + '.' + (string)row[2];
                    TablesList.Items.Add(tablename);
                    OriginalTable.Items.Add(tablename);
                }
                connection.Close();
            }
        }

        private void SearchTable_TextChanged(object sender, EventArgs e)
        {
            var registrationsList = OriginalTable.Items.Cast<String>().ToList();
            TablesList.BeginUpdate();
            TablesList.Items.Clear();
            foreach (string str in registrationsList)
            {
                if (str.ToUpper().Contains(SearchTable.Text.ToUpper()))
                {
                    TablesList.Items.Add(str);
                }
            }
            TablesList.EndUpdate();
        }

        private void GetColumns_Click(object sender, EventArgs e)
        {
            if(TablesList.CheckedItems.Count == 1)
            {
                //var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True", ServerName.Text, DatabaseName.Text);
                var connectionString = String.Format("Data Source=AZICDDHUAT01.partners.extranet.microsoft.com;Initial Catalog=ICDDH;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
                var tableDetails = TablesList.CheckedItems[0].ToString().Split('.');
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string[] restrictions = new string[4] { null, tableDetails[0], tableDetails[1], null };
                    connection.Open();
                    sourceTableColumns = connection.GetSchema("Columns", restrictions).Rows;

                    foreach (System.Data.DataRow rowColumn in sourceTableColumns)
                    {
                        var ColumnName = (rowColumn[3].ToString());
                    }
                    connection.Close();
                }
                AddColumnList();
            }
            else
            {
                MessageBox.Show("Please select one table at a time.");
            }
        }
        private void AddColumnList()
        {
            ColumnsList.Items.Clear();
            try
            {
                foreach (DataRow rowColumn in sourceTableColumns)
                {
                    //Fetchting Column Names from the Source Table
                    ColumnsList.Items.Add(rowColumn[3].ToString(), true);
                }
            }
            catch (Exception ex)
            {
                //Error message the user will see
                //string FriendlyError = "There has been populating checkboxes with the urls - A notification has been sent to development";
                //ShowMessageBox.MsgBox(FriendlyError, "There has been an Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
