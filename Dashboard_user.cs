using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class Dashboard_user : Form
    {
        public Dashboard_user(string user_id)
        {
            InitializeComponent();
            lbl_user_id.Text = user_id;

        }
        public string connectionstring = Connection.GetConnectionString();
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            Profile_user profile_user = new Profile_user(user_id);
            profile_user.Show();
            this.Hide();
        }

        

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Welcome_page wp = new Welcome_page();
            wp.Show();
            this.Hide();
        }

        

        private void btn_logout_MouseHover(object sender, EventArgs e)
        {
            btn_logout.BackColor = Color.Red;
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
            btn_logout.BackColor = Color.Transparent;
        }

        private void Dashboard_admin_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();

                SqlCommand sp_active_room = new SqlCommand("sp_active_room", connect);
                sp_active_room.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sp_active_room);
                DataTable active_room = new DataTable();
                sda.Fill(active_room);

                SqlCommand sp_reserved_room = new SqlCommand("sp_reserved_room", connect);
                sp_reserved_room.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda1 = new SqlDataAdapter(sp_reserved_room);
                DataTable reserved_room = new DataTable();
                sda1.Fill(reserved_room);

                SqlCommand sp_available_room = new SqlCommand("sp_available_room", connect);
                sp_available_room.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda2 = new SqlDataAdapter(sp_available_room);
                DataTable available_room = new DataTable();
                sda2.Fill(available_room);

                lbl_active_room.Text = active_room.Rows[0][0].ToString();
                lbl_reserved_room.Text = reserved_room.Rows[0][0].ToString();
                lbl_available_room.Text = available_room.Rows[0][0].ToString();


                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_report_Click(object sender, EventArgs e)
        {

        }
    }
}
