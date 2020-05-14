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
        public string patID = "";


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
            ArchivePanel.Parent = bodyPanel;
            ArchivePanel.Location = new Point(307, 5);
            ArchivePanel.BringToFront();

            PatientSearchPanel.Parent = bodyPanel;
            PatientSearchPanel.Location = new Point(307, 5);
            PatientSearchPanel.BringToFront();

            AddMedRecordPanel.Parent = bodyPanel;
            AddMedRecordPanel.Location = new Point(307, 5);
            AddMedRecordPanel.BringToFront();

            VSymptomPanel.Parent = bodyPanel;
            VSymptomPanel.Location = new Point(307, 5);
            VSymptomPanel.BringToFront();

            VPDiagnosesPanel.Parent = bodyPanel;
            VPDiagnosesPanel.Location = new Point(307, 5);
            VPDiagnosesPanel.BringToFront();

            VPPresctiptPanel.Parent = bodyPanel;
            VPPresctiptPanel.Location = new Point(307, 5);
            VPPresctiptPanel.BringToFront();

            IPrescriptPanel.Parent = bodyPanel;
            IPrescriptPanel.Location = new Point(307, 5);
            IPrescriptPanel.BringToFront();

            EPrescriptPanel.Parent = bodyPanel;
            EPrescriptPanel.Location = new Point(307, 5);
            EPrescriptPanel.BringToFront();
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
            VSymptomPanel.Visible = true;
            SympRTBox.Text = "";
            string sql = "select symptoms from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";
            if(dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                if(!dReader.HasRows)
                {
                    SympRTBox.Text = "No Patient Selected";
                }
                else
                {
                    string symptoms = "";
                    while (dReader.Read())
                    {
                        symptoms = dReader["symptoms"] + "";
                    }

                    SympRTBox.Text = symptoms;
                }

                dbh.CloseConnection();
            }
        }

        private void PDiagnosesButton_Click(object sender, EventArgs e)
        {
            VPDiagnosesPanel.Visible = true;
            string sql = "select Treatment, Appt_Date from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";

            if(dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                if(!dReader.HasRows)
                {
                    VPDiagRTBox.Text = "No record available";
                }
                else
                {
                    VPDiagRTBox.Text = "";
                    while(dReader.Read())
                    {
                        VPDiagRTBox.Text += dReader["Appt_Date"] + ": " + dReader["Treatment"] + "\n\n";
                    }
                }

                dbh.CloseConnection();
            }
        }

        private void PPrescriptionsButton_Click(object sender, EventArgs e)
        {
            VPPresctiptPanel.Visible = true;
            string sql = "select Prescription, Appt_Date from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";

            if (dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                if (!dReader.HasRows)
                {
                    VPPrescriptRTBox.Text = "No record available";
                }
                else
                {
                    VPPrescriptRTBox.Text = "";
                    while (dReader.Read())
                    {
                        VPPrescriptRTBox.Text += dReader["Appt_Date"] + ": " + dReader["Prescription"] + "\n\n";
                    }
                }

                dbh.CloseConnection();
            }
        }

        private void IPrescriptionsButton_Click(object sender, EventArgs e)
        {
            IPrescriptPanel.Visible = true;
        }

        private void EPrescriptionsButton_Click(object sender, EventArgs e)
        {
           

            if(patID == "")
            {
                return;
            }

            EPrescriptPanel.Visible = true;

            string pre_sql = "select RecID, Prescription from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";
            if (dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(pre_sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                string activePrescription = "";
                while (dReader.Read())
                {
                    activePrescription = dReader["Prescription"] + "";
                }
                dReader.Close();

                EPrescriptRTBox.Text = activePrescription;
                dbh.CloseConnection();
            }
        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {
            ArchivePanel.Visible = true;
            if(dbh.OpenConnection())
            {
                string sql = "select * from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam' and archive_flag = '0';";
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                ArchListBox.Items.Clear();
                if(!dReader.HasRows)
                {
                    ArchListBox.Items.Add("< No Records Selected >");
                }

                while(dReader.Read())
                {
                    ArchListBox.Items.Add("Rec: " + dReader["RecID"] + "\tPatient ID: " + dReader["PatientID"] + "\tAppointment: " + dReader["Appt_Date"]);
                }

                dbh.CloseConnection();
            }
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
                sql = "select * from patients where " +
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
                    patID = dReader["UserID"] + "";
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

        #region Archive Record Controls
        private void ArchiveBackBtn_Click(object sender, EventArgs e)
        {
            ArchivePanel.Visible = false;
        }

        private void ArchSubmitBtn_Click(object sender, EventArgs e)
        {
            string recID = "";
            if(ArchListBox.SelectedIndex >= 0)
            {
                recID = ArchListBox.SelectedItem.ToString().Split(' ')[1].Split('\t')[0];
            }
            else
            {
                return;
            }
            
            string sql = "update medical_record set archive_flag = '1' where RecID = " + recID + ";";
            if(dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sql, dbh.connection);
                cmd.ExecuteNonQuery();
                dbh.CloseConnection();
            }
            

            ArchivePanel.Visible = false;
        }
        #endregion

        #region View Symptoms Controls
        private void VSymptomBtn_Click(object sender, EventArgs e)
        {
            VSymptomPanel.Visible = false;
            SympRTBox.Text = "";
        }
        #endregion

        #region View Previous Diagnoses Controls
        private void VPDiagnosesBackBtn_Click(object sender, EventArgs e)
        {
            VPDiagnosesPanel.Visible = false;
        }

        #endregion

        #region View Previous Prescription Controls
        private void VPPrescriptBackBtn_Click(object sender, EventArgs e)
        {
            VPPresctiptPanel.Visible = false;
        }
        #endregion

        #region Issue Prescription Controls
        private void IPrescriptBackBtn_Click(object sender, EventArgs e)
        {
            IPrescriptPanel.Visible = false;
            IPMissingPatLabel.Visible = false;
            IPrescriptRTBox.Text = "";
        }

        private void IPrescriptSubmitBtn_Click(object sender, EventArgs e)
        {
            if(patID == "")
            {
                IPMissingPatLabel.Visible = true;
                return;
            }

            string pre_sql = "select RecID, Prescription from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";
            string recID = "";
            if (dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(pre_sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                string activePrescription = "";
                while (dReader.Read())
                {
                    activePrescription = dReader["Prescription"] + "";
                    recID = dReader["RecID"] + "";
                }
                dReader.Close();

                string sql = "update medical_record set Prescription = '" + activePrescription + "; " + IPrescriptRTBox.Text + "' where RecID = " + recID + ";";
                cmd = new MySqlCommand(sql, dbh.connection);
                cmd.ExecuteNonQuery();

                dbh.CloseConnection();
            }

            IPrescriptPanel.Visible = false;
            IPMissingPatLabel.Visible = false;
            IPrescriptRTBox.Text = "";
        }

        #endregion

        #region Edit Prescription Controls
        private void EPrescriptBackBtn_Click(object sender, EventArgs e)
        {
            EPrescriptPanel.Visible = false;
            EPrescriptMissingPatLabel.Visible = false;
            EPrescriptRTBox.Text = "";
        }

        private void EPrescriptSubmitBtn_Click(object sender, EventArgs e)
        {
            string pre_sql = "select RecID from medical_record where PatientID = '" + patID + "' and PhysID = 'TanakaBam';";
            string recID = "";
            if (dbh.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(pre_sql, dbh.connection);
                MySqlDataReader dReader = cmd.ExecuteReader();

                while (dReader.Read())
                {
                    recID = dReader["RecID"] + "";
                }
                dReader.Close();

                string sql = "update medical_record set Prescription = '" + EPrescriptRTBox.Text + "' where RecID = " + recID + ";";
                cmd = new MySqlCommand(sql, dbh.connection);
                cmd.ExecuteNonQuery();

                dbh.CloseConnection();
            }

            EPrescriptPanel.Visible = false;
            EPrescriptMissingPatLabel.Visible = false;
            EPrescriptRTBox.Text = "";
        }
        #endregion
    }
}
