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
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("INSERT INTO CHEF.Configuration VALUES ('{0}', {1}, NULL, NULL, GETUTCDATE(), GETUTCDATE())", NewSourceName.Text, ConnectionString.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteScalar();
                connection.Close();
            }

        }

        public void AddFoldersForNewSource()
        {
            SourceName = this.NewSourceName.Text;
            String SourcePath = TableOnboarding.SqlProjpath;
            String dboPath = TableOnboarding.dbopath;
            String stgPath = TableOnboarding.stgpath;
            String NewSourcePath = dboPath + SourceName + "\\";
            String stgNewSourcePath = stgPath + SourceName + "\\";
            String TablePath = "dbo\\" + SourceName + "\\Table";
            String ViewPath = "dbo\\" + SourceName + "\\View";
            String ProcedurePath = "dbo\\" + SourceName + "\\Procedure";
            String FunctionsPath = "dbo\\" + SourceName + "\\Functions";
            String stgTablePath = "stg\\" + SourceName + "\\Table";
            String stgViewPath = "stg\\" + SourceName + "\\View";
            String stgProcedurePath = "stg\\" + SourceName + "\\Procedure";
            String stgFunctionsPath = "stg\\" + SourceName + "\\Functions";
            var p = TableOnboarding.projectPath;
            System.IO.Directory.CreateDirectory(NewSourcePath);
            System.IO.Directory.CreateDirectory(stgNewSourcePath);
            p.AddItem("Folder", "dbo\\" + SourceName);
            p.AddItem("Folder", "stg\\" + SourceName);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Table");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Table");
            p.AddItem("Folder", TablePath);
            p.AddItem("Folder", stgTablePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "View");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "View");
            p.AddItem("Folder", ViewPath);
            p.AddItem("Folder", stgViewPath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Procedure");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Procedure");
            p.AddItem("Folder", ProcedurePath);
            p.AddItem("Folder", stgProcedurePath);
            p.Save();
            System.IO.Directory.CreateDirectory(NewSourcePath + "Function");
            System.IO.Directory.CreateDirectory(stgNewSourcePath + "Function");
            p.AddItem("Folder", FunctionsPath);
            p.AddItem("Folder", stgFunctionsPath);
            p.Save();
        }

        public void AddToSourceMaster()
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
        public void AddToProcessMonior()
        {
            //Checking if Catalog ID exists in the Table ProcessMonitor
            var connectionString = String.Format("Data Source=AZICDEVDISQL1;Initial Catalog=CHEF;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataReader reader;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string[] restrictions = new string[4] { null, "CHEF", "Configuration", null };
                string queryString = String.Format("SELECT CatalogID FROM CHEF.ProcessMonitor Where CatalogID = {0};", tob.CatalogID.Text);
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    String file = TableOnboarding.ChefSqlProjpath.Replace("CHEF.sqlproj", "Scripts\\Post-Deployment\\CHEF_ProcessMonitor_insert.sql");
                    string data = String.Format("\nUNION ALL");
                    data += String.Format("\nSELECT SourceMasterID, {0}, GETUTCDATE() , NULL FROM  [CHEF].[SourceMaster] WITH (NOLOCK) WHERE Sourcename ='{1}'", tob.CatalogID.Text, tob.SourceName.Text);
                    string text = File.ReadAllText(file);
                    int lastindex = text.LastIndexOf("Sourcename", StringComparison.OrdinalIgnoreCase);
                    lastindex += 10;
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

        }
        private void Submit_Click(object sender, EventArgs e)
        {
            AddFoldersForNewSource();
            AddConnectionStringToChef();
            AddToProcessMonior();
            AddToSourceMaster();
            tob.ListofSources();
            this.Close();
            MessageBox.Show("The Source " + SourceName + " Successfully added");
        }
    }
}
