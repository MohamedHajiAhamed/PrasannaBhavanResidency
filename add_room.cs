using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class add_room : Form
    {
        public add_room(string user_id, string mail)
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


        private void btn_logout_Click(object sender, EventArgs e)
        {
            string user_id = lbl_user_id.Text;
            string mail = lbl_mail.Text;
            Dashboard_admin wp = new Dashboard_admin(user_id, mail);
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

        private void btn_close1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximize1_Click(object sender, EventArgs e)
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

        private void btn_minimize1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void radioButton_add_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_add.Visible = true;
            groupBox_edit.Visible = false;
        }

        private void radioButton_edit_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_add.Visible = false;
            groupBox_edit.Visible = true;
            refreshdata();
        }

        private void comboBox_room_type_add_Click(object sender, EventArgs e)
        {
            comboBox_room_type_add.DroppedDown = true;
        }

        private void comboBox_room_status_add_Click(object sender, EventArgs e)
        {
            comboBox_room_status_add.DroppedDown = true;
        }

        private void comboBox_room_type_Click(object sender, EventArgs e)
        {
            comboBox_room_type.DroppedDown = true;
        }

        private void comboBox_room_status_Click(object sender, EventArgs e)
        {
            comboBox_room_status.DroppedDown = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_room_no_add.Text.Trim() != "" && txtbox_room_rent_add.Text.Trim() != "" && comboBox_room_status_add.Text.Trim() != "" && comboBox_room_status_add.Text.Trim() != "")
                {

                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_insert_room = new SqlCommand("sp_insert_room", connect);
                    sp_insert_room.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_insert_room.Parameters.Add(room_number).Value = txtbox_room_no_add.Text.Trim();
                    SqlParameter room_type = new SqlParameter("@room_type", SqlDbType.VarChar);
                    sp_insert_room.Parameters.Add(room_type).Value = comboBox_room_type_add.Text;
                    SqlParameter room_rent = new SqlParameter("@room_rent", SqlDbType.Float);
                    sp_insert_room.Parameters.Add(room_rent).Value = txtbox_room_rent_add.Text.Trim();
                    SqlParameter room_status = new SqlParameter("@room_status", SqlDbType.VarChar);
                    sp_insert_room.Parameters.Add(room_status).Value = comboBox_room_status_add.Text;
                    int i = sp_insert_room.ExecuteNonQuery();
                    connect.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Room Added Successfully");
                        refreshdata();
                    }
                    else
                    {
                        MessageBox.Show("Try Again");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtbox_room_no_add.Clear();
            txtbox_room_rent_add.Clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_room_no.Text.Trim() != "" && txtbox_room_rent.Text.Trim() != "" && comboBox_room_status.Text.Trim() != "" && comboBox_room_status.Text.Trim() != "")
                {

                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_update_room = new SqlCommand("sp_update_room", connect);
                    sp_update_room.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_update_room.Parameters.Add(room_number).Value = txtbox_room_no.Text.Trim();
                    SqlParameter room_type = new SqlParameter("@room_type", SqlDbType.VarChar);
                    sp_update_room.Parameters.Add(room_type).Value = comboBox_room_type.Text;
                    SqlParameter room_rent = new SqlParameter("@room_rent", SqlDbType.Float);
                    sp_update_room.Parameters.Add(room_rent).Value = txtbox_room_rent.Text.Trim();
                    SqlParameter room_status = new SqlParameter("@room_status", SqlDbType.VarChar);
                    sp_update_room.Parameters.Add(room_status).Value = comboBox_room_status.Text;
                    int i = sp_update_room.ExecuteNonQuery();
                    connect.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Updated Successfully");
                        refreshdata();
                    }
                    else
                    {
                        MessageBox.Show("Try Again");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_room_no.Text.Trim() != "" && txtbox_room_rent.Text.Trim() != "" && comboBox_room_status.Text.Trim() != "" && comboBox_room_status.Text.Trim() != "")
                {
                    if (MessageBox.Show("Are You Sure to delete", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_delete_room = new SqlCommand("sp_delete_room", connect);
                        sp_delete_room.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                        sp_delete_room.Parameters.Add(room_number).Value = txtbox_room_no.Text.Trim();
                        int i = sp_delete_room.ExecuteNonQuery();
                        connect.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("Deleted Successfully");
                            refreshdata();
                        }
                        else
                        {
                            MessageBox.Show("Try Again");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refreshdata()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();
                SqlCommand sp_fetch_room = new SqlCommand("sp_fetch_room_edit", connect);
                sp_fetch_room.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_room);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                txtbox_room_no.Clear();
                txtbox_room_rent.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add_room_Load(object sender, EventArgs e)
        {
            refreshdata();
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtbox_room_no.Text = dataGridView1.Rows[e.RowIndex].Cells["room_number"].FormattedValue.ToString();
                    comboBox_room_type.Text = dataGridView1.Rows[e.RowIndex].Cells["room_type"].FormattedValue.ToString();
                    txtbox_room_rent.Text = dataGridView1.Rows[e.RowIndex].Cells["room_rent"].FormattedValue.ToString();
                    comboBox_room_status.Text = dataGridView1.Rows[e.RowIndex].Cells["room_status"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
