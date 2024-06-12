using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class Dashboard_admin : Form
    {
        public Dashboard_admin(string user_id, string mail)
        {
            InitializeComponent();
            lbl_user_id.Text = user_id;
            lbl_mail.Text = mail;

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
            string mail = lbl_mail.Text;
            Profile_admin profile_admin = new Profile_admin(user_id, mail);
            profile_admin.Show();
            this.Hide();
        }

        private void btn_user_detail_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            User_Details_admin user_Details_admin = new User_Details_admin(user_id, mail);
            user_Details_admin.Show();
            this.Hide();
        }

        private void btn_Stocks_admin_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            add_room add_Room = new add_room(user_id, mail);
            add_Room.Show();
            this.Hide();
        }

        private void btn_profile_s_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            Profile_admin profile_admin = new Profile_admin(user_id, mail);
            profile_admin.Show();
            this.Hide();
        }

        private void btn_billing_admin_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            check_in check_In = new check_in(user_id, mail);
            check_In.Show();
            this.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Welcome_page wp = new Welcome_page();
            wp.Show();
            this.Hide();
        }

        private void btn_sales_admin_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            reservation_report reservation_Report = new reservation_report(user_id, mail);
            reservation_Report.Show();
            this.Hide();

        }

        private void btn_employee_details_admin_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            check_out check_Out = new check_out(user_id, mail);
            check_Out.Show();
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
            data();
            remainder();
            int count = Convert.ToInt32(lbl_remainder.Text);
            if (lbl_mail.Text == "0" && count > 0)
            {
                mail();
                panel_remainder_main.Visible = true;
            }

        }

        private DataTable GetDataTableFromDataGridView(DataGridView dgv)
        {
            var dt = new DataTable();

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = row.Cells[j].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private string ConvertDataTableToHTML(DataTable dt)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<table border='1'>");

            // Header
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.AppendFormat("<th>{0}</th>", column.ColumnName);
            }
            html.Append("</tr>");

            // Rows
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.AppendFormat("<td>{0}</td>", row[column.ColumnName]);
                }
                html.Append("</tr>");
            }

            html.Append("</table>");
            return html.ToString();
        }


        private void mail()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();
                int parseduser_id = Convert.ToInt32(lbl_user_id.Text);
                SqlCommand sp_fetch_user_single = new SqlCommand("sp_fetch_single_user", connect);
                sp_fetch_user_single.CommandType = CommandType.StoredProcedure;

                SqlParameter user_id = new SqlParameter("@user_id", SqlDbType.Int);
                sp_fetch_user_single.Parameters.Add(user_id).Value = parseduser_id;

                SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_user_single);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow row = dt.Rows[0];
                string owner_email = row["owner_email"].ToString();
                string manager_email = row["manager_email"].ToString();
                if (owner_email != "" && manager_email != "")
                {
                    try
                    {
                        DataTable dataTable = GetDataTableFromDataGridView(dataGridView_remainder);
                        string htmlTable = ConvertDataTableToHTML(dataTable);
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.Credentials = new System.Net.NetworkCredential("pcpoint656@gmail.com", " ");
                        client.EnableSsl = true;
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(row["email"].ToString());
                        mail.To.Add(owner_email);
                        mail.To.Add(manager_email);
                        mail.Subject = "Room Advance Booking";
                        mail.IsBodyHtml = true;
                        mail.Body = htmlTable;
                        client.Send(mail);
                        lbl_mail.Text = "1";


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Add Owner E-Mail And Manager E-Mail To Send Mail");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data()
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




            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void remainder()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();

                SqlCommand sp_search_remainder = new SqlCommand("sp_search_remainder", connect);
                SqlDataAdapter sd = new SqlDataAdapter(sp_search_remainder);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView_remainder.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    lbl_remainder.Text = dt.Rows.Count.ToString();
                }
                else
                {
                    lbl_remainder.Text = "0";
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_check_in_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            Update_check_in update_check_in = new Update_check_in(user_id, mail);
            update_check_in.Show();
            this.Hide();
        }

        private void btn_adv_booking_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            Advance_Booking advance_Booking = new Advance_Booking(user_id, mail);
            advance_Booking.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_remainder_main.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel_remainder_main.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel_remainder_main.Visible = true;
        }
    }
}
