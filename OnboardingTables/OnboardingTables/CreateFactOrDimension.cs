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
        public CreateFactOrDimension()
        {
            InitializeComponent();
            SearchTable.TextChanged += new EventHandler(SearchTable_TextChanged);
            OriginalTable = new CheckedListBox();
            ListOfTables();
            //ListofSources();
        }

        public void ListofSources()
        {
            TablesList.Items.Clear();
            var connectionString = String.Format("Data Source=AZICUATDIWSQl2;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT ConfigKey FROM CHEF.Configuration WHERE TValue like 'Data%'");
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TablesList.Items.Add(reader.GetString(0));
                }
                connection.Close();
            }

            TablesList.Text = AddingNewSource.SourceName;
        }

        public void ListOfTables()
        {
            //string reader;
            var connectionString = String.Format("Data Source=AZICDDHUAT01.partners.extranet.microsoft.com;Initial Catalog=ICDDH;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //List<string> tables = new List<string>();
                DataTable dt = connection.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[1] + '.' + (string)row[2];
                    TablesList.Items.Add(tablename);
                    OriginalTable.Items.Add(tablename);
                    //tables.Add(tablename);
                }
                dt = connection.GetSchema("Views");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[1] + '.' + (string)row[2];
                    TablesList.Items.Add(tablename);
                    OriginalTable.Items.Add(tablename);
                    //tables.Add(tablename);
                }
                connection.Close();
                //OriginalTable.Items.Add(TablesList.Items);
                //AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
                //allowedTypes.AddRange(tables.ToArray());
                //SearchTable.AutoCompleteCustomSource = allowedTypes;
                //SearchTable.AutoCompleteMode = AutoCompleteMode.Suggest;
                //SearchTable.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
    }
}
