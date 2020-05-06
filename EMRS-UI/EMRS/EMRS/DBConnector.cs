using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EMRS
{
    public class DBConnector
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnector()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "emrs";
            uid = "root";
            password = "pass260word";

            string connectionstring;
            connectionstring = "SERVER=" + server + ";DATABASE=" + 
                               database + ";UID=" + uid + ";PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionstring);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            } catch(MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact DB administrator.");
                        break;

                    case 1:
                        MessageBox.Show("Invalid username/password, please try again.");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            } catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void insert(string[] data, string table)
        {
            string sql = "";
            switch (table)
            {
                case "patients":
                    sql = "insert into patients values ('" +
                          data[0] + "', '" + //UserID      varchar
                          data[1] + "', '" + //Password    varchar
                          data[2] + "', '" + //FName       varchar
                          data[3] + "', " +  //LName       varchar
                          data[4] + ", '" +  //Age         int
                          data[5] + "', '" + //Sex         char(1)
                          data[6] + "', '" + //Address     varchar
                          data[7] + "', " +  //SSN         char(11)
                          data[8] + ", " +   //FinancialID int
                          data[9] + ");";    //InsuranceID int
                    break;
                case "physicians":
                    sql = "insert into physicians values ('" +
                          data[0] + "', '" + //UserID   varchar
                          data[1] + "', '" + //Password varchar
                          data[2] + "', '" + //FName    varchar
                          data[3] + "', '" + //LName    varchar
                          data[4] + "', '" + //SSN      char(11)
                          data[5] + "');";   //Title    varchar
                    break;
                case "financial_record":
                    sql = "insert into financial_record values (" +
                          data[0] + ", '" + //FID       int
                          data[1] + "', " + //Inst_Type enum('CU', 'Bank', 'CC')
                          data[2] + ", " +  //Acct_Num  int
                          data[3] + ", '" + //Rout_Num  int
                          data[4] + "');";  //Acct_Type enum('CHECKING', 'SAVINGS', 'OTHER')
                    break;
                case "insurance_record":
                    sql = "insert into insurance_record values (" +
                          data[0] + ", " + //IID          int
                          data[1] + ", " + //Company_Code int
                          data[2] + ");";  //Agent_Num    int
                    break;
                case "medical_record":
                    sql = "insert into medical_record values (" +
                          data[0] + ", " + //RecID        int
                          data[1] + ", " + //PatientID    varchar FK patients(UserID)
                          data[2] + ", " + //PhysID       varchar FK physicians(UserID)
                          data[3] + ", " + //Treatment    varchar
                          data[4] + ", " + //Prescription varchar
                          data[5] + ", " + //Appt_Date    date
                          data[6] + ", " + //Bill_Amt     float(2)
                          data[7] + ");";  //Symptoms     varchar
                    break;
            }

            if(this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }

        }
    }
}
