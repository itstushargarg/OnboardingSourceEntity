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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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

        public void AddConnectionStringToChef()
        {
            var connectionString = String.Format("Data Source=AZICDMPERF01;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("INSERT INTO CHEF.Configuration VALUES ('{0}', '{1}', NULL, NULL, GETUTCDATE(), GETUTCDATE())", NewSourceName.Text, ConnectionString.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void AddToSourceMaster()
        {
            //Checking if Catalog ID exists in the Table ProcessMonitor
            //var connectionString = String.Format("Data Source=AZICUATDIWSQl2;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            var connectionString = String.Format("Data Source=AZICDMPERF01;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataReader reader;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT SourceName FROM CHEF.SourceMaster Where SourceName = '{0}'", NewSourceName.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    String file = TableOnboarding.ChefSqlProjpath.Replace("CHEF.sqlproj", "Scripts\\Post-Deployment\\CHEF_SourceMaster_Insert.sql");
                    string data = String.Format("\n,('{0}'\t\t\t\t\t,1440	, DATEADD(MINUTE,1740,CONVERT(DATETIME, CONVERT(VARCHAR, GETDATE(), 101))) , 1 , 0 , 0 , NULL , DATEADD( MINUTE , -1440 , DATEADD(dd, 0, DATEDIFF(dd, 0, GETUTCDATE())) ),1);", tob.SourceName.Text);
                    string text = File.ReadAllText(file);
                    int lastindex = text.LastIndexOf("GETUTCDATE()", StringComparison.OrdinalIgnoreCase);
                    lastindex += 12;
                    //Finding index of next newline character
                    while (text[lastindex] != '\n')
                    {
                        lastindex++;
                    }
                    text = text.Insert(lastindex, data);
                    using (TextWriter tw = new StreamWriter(file))
                    {
                        tw.Write(text);
                        tw.Close();
                    }
                }
                reader.Close();
                connection.Close();
            }
        }
        public void AddSqlcmdVariable()
        {

            String file = TableOnboarding.ChefSqlProjpath;
            string text = File.ReadAllText(file);
            int count = Regex.Matches(text, "</SqlCmdVariable>").Count;
            int lastindex = text.LastIndexOf("</SqlCmdVariable>", StringComparison.OrdinalIgnoreCase);
            lastindex += 17;
            //Finding index of next newline character
            while (text[lastindex] != '\n')
            {
                lastindex++;
            }
            string data = String.Format("\n<SqlCmdVariable Include=\"{0}\">", NewSourceName.Text);
            data += String.Format("\n\t<DefaultValue>'{0}'</DefaultValue>", ConnectionString.Text);
            data += String.Format("\n\t<Value>$(SqlCmdVar__{0})</Value>", count+1);
            data += String.Format("\n</SqlCmdVariable>");
            text = text.Insert(lastindex, data);
            using (TextWriter tw = new StreamWriter(file))
            {
                tw.Write(text);
                tw.Close();
            }
        }

        public void AddToPublishFiles()
        {
            //Making an array consisting of all the publish files
            String[] publishFiles =
            {
                "Dev_CHEF.publish.xml",
                "Perf_CHEF.publish.xml",
                "Prod_CHEF.publish.xml",
                "Test_CHEF.publish.xml",
                "UAT_CHEF.publish.xml"
            };  
            foreach (string publish in publishFiles)
            {
                String file = TableOnboarding.ChefSqlProjpath.Replace("CHEF.sqlproj", publish);
                string text = File.ReadAllText(file);
                int lastindex = text.LastIndexOf("</SqlCmdVariable>", StringComparison.OrdinalIgnoreCase);
                lastindex += 17;
                //Finding index of next newline character
                while (text[lastindex] != '\n')
                {
                    lastindex++;
                }
                string data = String.Format("\n\t\t<SqlCmdVariable Include=\"{0}\">", NewSourceName.Text);
                data += String.Format("\n\t\t\t<Value>'{0}'</Value>", ConnectionString.Text);
                data += String.Format("\n\t\t</SqlCmdVariable>");
                text = text.Insert(lastindex, data);
                using (TextWriter tw = new StreamWriter(file))
                {
                    tw.Write(text);
                    tw.Close();
                }
            }
            
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            AddConnectionStringToChef();
            AddToSourceMaster();
            AddSqlcmdVariable();
            AddToPublishFiles();
            tob.ListofSources();
            this.Close();
            MessageBox.Show("The Source " + SourceName + " Successfully added");
        }
    }
}
