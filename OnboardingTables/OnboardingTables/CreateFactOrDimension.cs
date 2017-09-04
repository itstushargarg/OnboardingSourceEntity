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
        public IEnumerable<DataRow> sourceTableColumns;
        public List<DataRow> finalTableColumns;
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

        private void SelectAllTables_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllTables.Checked)
            {
                for (int i = 0; i < TablesList.Items.Count; i++)
                {
                    TablesList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < TablesList.Items.Count; i++)
                {
                    TablesList.SetItemChecked(i, false);
                }
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
            if (TablesList.CheckedItems.Count == 1)
            {
                //var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True", ServerName.Text, DatabaseName.Text);
                var connectionString = String.Format("Data Source=AZICDDHUAT01.partners.extranet.microsoft.com;Initial Catalog=ICDDH;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
                var tableDetails = TablesList.CheckedItems[0].ToString().Split('.');
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string[] restrictions = new string[4] { null, tableDetails[0], tableDetails[1], null };
                    connection.Open();
                    sourceTableColumns = connection.GetSchema("Columns", restrictions).Rows.Cast<DataRow>();
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

        private void SelectAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllColumns.Checked)
            {
                for (int i = 0; i < ColumnsList.Items.Count; i++)
                {
                    ColumnsList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < ColumnsList.Items.Count; i++)
                {
                    ColumnsList.SetItemChecked(i, false);
                }
            }
        }

        private void AddColumns_Click(object sender, EventArgs e)
        {
            if (ColumnsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select atleast one column.");
                return;
            }
            else
            {
                //Add a check to check if the same column exists from before
                List<string> duplicateColumns = new List<string>();
                foreach (var dupCol in ColumnsList.CheckedItems.Cast<String>().ToList().Intersect(SelectedColumnsList.Items.Cast<String>().ToList()))
                {
                    duplicateColumns.Add(dupCol.ToString());
                }
                if (duplicateColumns.Count != 0)
                {
                    var duplicateColumnsString = string.Join("\n\t- ", duplicateColumns.ToArray());
                    MessageBox.Show(String.Format("Below is a list of column(s) that already exist in the 'Selected Columns' list: \n\t- {0}\nPlease make the required changes to add the selected column(s) to the list!", duplicateColumnsString));
                }
                else
                {
                    SelectedColumnsList.Items.AddRange(ColumnsList.CheckedItems.Cast<string>().ToArray());
                    finalTableColumns = (from col in sourceTableColumns 
                                        join a in ColumnsList.CheckedItems.Cast<string>().ToArray() on col.ItemArray[3] equals a
                                        select col).ToList();
                }
            }
        }

        private void SelectAllSelectedColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllSelectedColumns.Checked)
            {
                for (int i = 0; i < SelectedColumnsList.Items.Count; i++)
                {
                    SelectedColumnsList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < SelectedColumnsList.Items.Count; i++)
                {
                    SelectedColumnsList.SetItemChecked(i, false);
                }
            }
        }

        private void DeleteSelectedColumns_Click(object sender, EventArgs e)
        {
            if (SelectedColumnsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select atleast one column.");
                return;
            }
            else
            {
                foreach (var col in SelectedColumnsList.CheckedItems.Cast<string>().ToList())
                {
                    SelectedColumnsList.Items.Remove(col);
                    SelectedPKColumnsList.Items.Remove(col);
                }
            }
        }

        private void SelectAsPKColumns_Click(object sender, EventArgs e)
        {

            if (SelectedColumnsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select atleast one column.");
                return;
            }
            else
            {
                List<string> duplicateColumns = new List<string>();
                foreach (var dupCol in SelectedColumnsList.CheckedItems.Cast<String>().ToList().Intersect(SelectedPKColumnsList.Items.Cast<String>().ToList()))
                {
                    duplicateColumns.Add(dupCol.ToString());
                }
                if (duplicateColumns.Count != 0)
                {
                    var duplicateColumnsString = string.Join("\n\t- ", duplicateColumns.ToArray());
                    MessageBox.Show(String.Format("Below is a list of column(s) that already exist in the 'PK Columns' list: \n\t- {0}\nPlease make the required changes to add the selected column(s) to the list!", duplicateColumnsString));
                }
                else
                {
                    SelectedPKColumnsList.Items.AddRange(SelectedColumnsList.CheckedItems.Cast<string>().ToArray());
                }
            }
        }

        private void SelectAllPKColumns_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllPKColumns.Checked)
            {
                for (int i = 0; i < SelectedPKColumnsList.Items.Count; i++)
                {
                    SelectedPKColumnsList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < SelectedPKColumnsList.Items.Count; i++)
                {
                    SelectedPKColumnsList.SetItemChecked(i, false);
                }
            }
        }

        private void DeleteSelectedColumnsFromPK_Click(object sender, EventArgs e)
        {

            if (SelectedPKColumnsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select atleast one column.");
                return;
            }
            else
            {
                foreach (var col in SelectedPKColumnsList.CheckedItems.Cast<string>().ToList())
                {
                    SelectedPKColumnsList.Items.Remove(col);
                }
            }
        }
    }
}
