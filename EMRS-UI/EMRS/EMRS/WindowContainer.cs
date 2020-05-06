using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EMRS
{
    public partial class WindowContainer : Form
    {
        #region Header
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public string userType = "Physician";
        public string userTitle = "Dr.";


        public DBConnector dbh;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void WindowContainer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public WindowContainer()
        {
            dbh = new DBConnector();
            //Console.WriteLine(dbh.OpenConnection());
            InitializeComponent();
        }
        #endregion

        #region Title Bar
        private void exitBox_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(dbh.CloseConnection());
            dbh = null;
            Application.Exit();
        }

        private void minimizeBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Body Controls
        private void SymptomButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Yup still here");
        }

        private void PDiagnosesButton_Click(object sender, EventArgs e)
        {

        }

        private void PPrescriptionsButton_Click(object sender, EventArgs e)
        {

        }

        private void IPrescriptionsButton_Click(object sender, EventArgs e)
        {

        }

        private void EPrescriptionsButton_Click(object sender, EventArgs e)
        {

        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {

        }

        private void CPatientButton_Click(object sender, EventArgs e)
        {
            PatientSearchPanel.Visible = true;
            CPatientButton.Cursor = DefaultCursor;

            string sql = "select * from patients;";
            string result = "";
            int rsCount = 0;
            if(dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                while(dReader.Read())
                {
                    result += "UserID -> " + dReader["UserID"] + "\n";
                    result += "Password -> " + dReader["Password"] + "\n";
                    result += "Name -> " + dReader["FName"] + " " + dReader["LName"] + "\n";
                    result += "Age -> " + dReader["Age"] + "\n";
                    result += "Sex -> " + dReader["Sex"] + "\n";
                    result += "Address -> " + dReader["Address"] + "\n";
                    result += "SSN -> " + dReader["SSN"] + "\n";
                    rsCount++;
                }

                dReader.Close();

                //Console.WriteLine(result);
                //Console.WriteLine(rsCount);

                dbh.CloseConnection();
            }
        }

        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            AddMedRecordPanel.Visible = true;
        }
        #endregion

        #region Change Patient Panel Controls
        private void BackButton_Click(object sender, EventArgs e)
        {
            PFNameBox.Text = "";
            PLNameBox.Text = "";
            PAgeSearchBox.Text = "";
            PSexBox.Text = "";
            MissingTextLabel.Visible = false;
            PatientSearchPanel.Visible = false;
            CPatientButton.Cursor = Cursors.Hand;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MissingTextLabel.Text = "Please ensure all fields are filled";
            string sql = "";
            MissingTextLabel.Visible = false;
            bool cond = PFNameBox.Text == "" || PLNameBox.Text == "" || PAgeSearchBox.Text == "" || PSexBox.Text == "";
            if(cond)
            {
                MissingTextLabel.Visible = true;
                return;
            }

            int age = 0;
            if(int.TryParse(PAgeSearchBox.Text, out age))
            {
                sql = "select FName, LName, Age, Sex, Address from patients where " +
                            "FName like '%" + PFNameBox.Text + "%' and " +
                            "LName like '%" + PLNameBox.Text + "%' and " +
                            "Age = " + PAgeSearchBox.Text + " and " +
                            "Sex = '" + PSexBox.Text + "';";
            }
            else
            {
                MissingTextLabel.Text = "Age must be a number";
                MissingTextLabel.Visible = true;
                return;
            }

            
            Console.WriteLine(sql);

            if (dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                if (!dReader.HasRows)
                {
                    ResultList.Items.Clear();
                    ResultList.Items.Add("< No Patients Found >");
                    dbh.CloseConnection();
                    return;
                }

                while (dReader.Read())
                {
                    ResultList.Items.Clear();
                    string result = dReader["FName"] + " " + dReader["LName"] + " Age: " + dReader["Age"] + " Sex: " + dReader["Sex"] + " Address: " + dReader["Address"];
                    ResultList.Items.Add(result);

                    PNameLabel.Text = "Current Patient: " + dReader["FName"] + " " + dReader["LName"];
                    PAgeLabel.Text = "Age: " + dReader["Age"];
                    PSexLabel.Text = "Sex: " + dReader["Sex"];
                    PAddressLabel.Text = "Address: " + dReader["Address"];
                }

                dbh.CloseConnection();
            }

            PFNameBox.Text = "";
            PLNameBox.Text = "";
            PAgeSearchBox.Text = "";
            PSexBox.Text = "";
            MissingTextLabel.Visible = false;
            PatientSearchPanel.Visible = false;
            CPatientButton.Cursor = Cursors.Hand;
        }
        #endregion

        #region Add Medical Record Controls
        private void AddMRBackButton_Click(object sender, EventArgs e)
        {
            AddMedRecordPanel.Visible = false;
            MissingPatLabel.Visible = false;
            TreatmentDescriptionBox.Text = "";
            SymptomsDescBox.Text = "";
            PrescriptionDescBox.Text = "";
        }

        private void MRSubmitButton_Click(object sender, EventArgs e)
        {
            if(PNameLabel.Text.Split(' ').Length <= 2)
            {
                MissingPatLabel.Visible = true;
                return;
            }
            string[] submitData = new string[9];
            submitData[0] = null;

            string FName = PNameLabel.Text.Split(' ')[2];
            string LName = PNameLabel.Text.Split(' ')[3];
            
            string sql = "select UserID from patients where FName = '" + FName + "' and LName = '" + LName + "';";

            if(dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();
                if(dReader.Read())
                {
                    submitData[1] = dReader["UserID"] + "";
                }
                dbh.CloseConnection();
            }

            submitData[2] = "TanakaBam";
            submitData[3] = TreatmentDescriptionBox.Text;
            submitData[4] = PrescriptionDescBox.Text;
            
            string today = DateTime.Now.ToString();
            submitData[5] = today.Split('/')[2].Split(' ')[0] + "-" + today.Split('/')[0] + "-" + today.Split('/')[1];
            submitData[6] = "420.69";
            submitData[7] = SymptomsDescBox.Text;
            submitData[8] = "0";

            dbh.insert(submitData, "medical_record");

            TreatmentDescriptionBox.Text = "";
            SymptomsDescBox.Text = "";
            PrescriptionDescBox.Text = "";
            MissingPatLabel.Visible = false;
            AddMedRecordPanel.Visible = false;
        }
        #endregion
    }
}
