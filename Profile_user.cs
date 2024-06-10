using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class Profile_user : Form
    {
        public Profile_user(string user_id)
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
        private void Profile_admin_Load(object sender, EventArgs e)
        {

            try
            {
                int parseduser_id = Convert.ToInt32(lbl_user_id.Text);

                using (SqlConnection connect = new SqlConnection(connectionstring))
                {
                    connect.Open();

                    SqlCommand sp_fetch_user_single = new SqlCommand("sp_fetch_user_single", connect);
                    sp_fetch_user_single.CommandType = CommandType.StoredProcedure;

                    SqlParameter user_id = new SqlParameter("@user_id", SqlDbType.Int);
                    sp_fetch_user_single.Parameters.Add(user_id).Value = parseduser_id;

                    SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_user_single);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        txtbox_firstname.Text = row["first_name"].ToString();
                        txtbox_lastname.Text = row["last_name"].ToString();
                        txtbox_username.Text = row["user_name"].ToString();
                        txtbox_mail.Text = row["email"].ToString();


                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.txtbox_firstname.Clear();
            this.txtbox_lastname.Clear();
            this.txtbox_username.Clear();
            this.txtbox_mail.Clear();
            this.txtbox_password.Clear();
            this.txtbox_cpassword.Clear();
            txtbox_owner_mail.Clear();
        }


        private void btn_logout_MouseHover(object sender, EventArgs e)
        {
            btn_logout.BackColor = Color.Red;
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
            btn_logout.BackColor = Color.Transparent;
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            Dashboard_user wp = new Dashboard_user(user_id);
            wp.Show();
            this.Hide();
        }




        public bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int parseduser_id = Convert.ToInt32(lbl_user_id.Text);
                if (txtbox_firstname.Text.Trim() != "" && txtbox_lastname.Text.Trim() != "" && txtbox_username.Text.Trim() != "" && txtbox_mail.Text.Trim() != "" && txtbox_password.Text.Trim() != "" && txtbox_cpassword.Text.Trim() != "")
                {
                    string emailAddress = txtbox_mail.Text;
                    bool isValid = IsEmailValid(emailAddress);
                    string owneremailAddress = txtbox_mail.Text;
                    bool ownermailisValid = IsEmailValid(emailAddress);
                    if (isValid && ownermailisValid)
                    {

                        if (txtbox_password.Text.Trim().Length >= 8)
                        {
                            if (txtbox_password.Text.Trim() == txtbox_cpassword.Text.Trim())
                            {

                                SqlConnection connect = new SqlConnection(connectionstring);
                                connect.Open();
                                SqlCommand sp_update_user_single = new SqlCommand("sp_update_user_single", connect);
                                sp_update_user_single.CommandType = CommandType.StoredProcedure;

                                SqlParameter first_name = new SqlParameter("@first_name", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(first_name).Value = txtbox_firstname.Text.Trim();

                                SqlParameter last_name = new SqlParameter("@last_name", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(last_name).Value = txtbox_lastname.Text.Trim();

                                SqlParameter user_name = new SqlParameter("@user_name", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(user_name).Value = txtbox_username.Text.Trim();

                                SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(email).Value = txtbox_mail.Text.Trim();

                                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(password).Value = txtbox_password.Text.Trim();

                                SqlParameter cpassword = new SqlParameter("@confirm_password", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(cpassword).Value = txtbox_cpassword.Text.Trim();

                                SqlParameter owner_email = new SqlParameter("@owner_email", SqlDbType.VarChar);
                                sp_update_user_single.Parameters.Add(owner_email).Value = txtbox_owner_mail.Text.Trim();

                                SqlParameter user_id = new SqlParameter("@user_id", SqlDbType.Int);
                                sp_update_user_single.Parameters.Add(user_id).Value = parseduser_id;

                                int i = sp_update_user_single.ExecuteNonQuery();

                                if (i > 0)
                                {
                                    MessageBox.Show("updated Successfully");

                                }
                                else
                                {
                                    MessageBox.Show("Try Again");
                                }
                                connect.Close();
                            }
                            else
                            {
                                MessageBox.Show("Password and Confirm Password Must be Same");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password must be atleast 8 characters");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid E-Mail");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill the Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (txtbox_password.UseSystemPasswordChar == true)
            {
                txtbox_password.UseSystemPasswordChar = false;
                txtbox_cpassword.UseSystemPasswordChar = false;
                btn_show.SendToBack();
            }
            else
            {
                txtbox_password.UseSystemPasswordChar = true;
                txtbox_cpassword.UseSystemPasswordChar = true;
                btn_show.BringToFront();

            }
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            if (txtbox_password.UseSystemPasswordChar == false)
            {
                txtbox_password.UseSystemPasswordChar = true;
                txtbox_cpassword.UseSystemPasswordChar = true;
                btn_hide.SendToBack();

            }
            else
            {
                txtbox_password.UseSystemPasswordChar = false;
                txtbox_cpassword.UseSystemPasswordChar = false;
                btn_hide.BringToFront();

            }
        }
    }
}
