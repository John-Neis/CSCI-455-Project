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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

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

                Console.WriteLine(result);
                Console.WriteLine(rsCount);

                dbh.CloseConnection();
            }
        }
    }
}
