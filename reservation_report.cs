using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class reservation_report : Form
    {
        public reservation_report(string user_id, string mail)
        {
            InitializeComponent();
            lbl_user_id.Text = user_id;
            lbl_mail.Text = mail;
        }
        public string connectionstring = Connection.GetConnectionString();

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_room_no.Visible == true)
                {
                    if (radioButton_old_record.Checked)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_room_number = new SqlCommand("sp_searchBy_room_number", connect);
                        sp_searchBy_room_number.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                        sp_searchBy_room_number.Parameters.Add(room_number).Value = txtbox_room_no.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_room_number);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }
                    else
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_room_number_new = new SqlCommand("sp_searchBy_room_number_new", connect);
                        sp_searchBy_room_number_new.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                        sp_searchBy_room_number_new.Parameters.Add(room_number).Value = txtbox_room_no.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_room_number_new);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }


                }
                if (txtbox_date.Visible == true)
                {
                    if (radioButton_old_record.Checked)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_checkin_date = new SqlCommand("sp_searchBy_checkin_date", connect);
                        sp_searchBy_checkin_date.CommandType = CommandType.StoredProcedure;

                        string check_in_date_custom = txtbox_date.Value.Day.ToString() + "-" + txtbox_date.Value.Month.ToString() + "-" + txtbox_date.Value.Year.ToString();

                        SqlParameter check_in_date = new SqlParameter("@Old_check_in_date", SqlDbType.VarChar);
                        sp_searchBy_checkin_date.Parameters.Add(check_in_date).Value = check_in_date_custom;
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_checkin_date);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }
                    else
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_checkin_date_new = new SqlCommand("sp_searchBy_checkin_date_new", connect);
                        sp_searchBy_checkin_date_new.CommandType = CommandType.StoredProcedure;

                        string check_in_date_custom = txtbox_date.Value.Day.ToString() + "-" + txtbox_date.Value.Month.ToString() + "-" + txtbox_date.Value.Year.ToString();

                        SqlParameter check_in_date = new SqlParameter("@check_in_date", SqlDbType.Date);
                        sp_searchBy_checkin_date_new.Parameters.Add(check_in_date).Value = check_in_date_custom;
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_checkin_date_new);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }

                }
                if (dateTimePicker_checkOut.Visible == true)
                {
                    if (radioButton_old_record.Checked)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_checkout_date = new SqlCommand("sp_searchBy_checkout_date", connect);
                        sp_searchBy_checkout_date.CommandType = CommandType.StoredProcedure;

                        string check_out_date_custom = dateTimePicker_checkOut.Value.Day.ToString() + "-" + dateTimePicker_checkOut.Value.Month.ToString() + "-" + dateTimePicker_checkOut.Value.Year.ToString();

                        SqlParameter check_out_date = new SqlParameter("@Old_check_out_date", SqlDbType.VarChar);
                        sp_searchBy_checkout_date.Parameters.Add(check_out_date).Value = check_out_date_custom;
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_checkout_date);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }
                    else
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_checkout_date_new = new SqlCommand("sp_searchBy_checkout_date_new", connect);
                        sp_searchBy_checkout_date_new.CommandType = CommandType.StoredProcedure;

                        string check_out_date_custom = dateTimePicker_checkOut.Value.Day.ToString() + "-" + dateTimePicker_checkOut.Value.Month.ToString() + "-" + dateTimePicker_checkOut.Value.Year.ToString();

                        SqlParameter check_out_date = new SqlParameter("@check_out_date", SqlDbType.Date);
                        sp_searchBy_checkout_date_new.Parameters.Add(check_out_date).Value = check_out_date_custom;
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_checkout_date_new);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }

                }
                if (txtbox_customer_name.Visible == true)
                {

                    if (radioButton_old_record.Checked)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_customer_name = new SqlCommand("sp_searchBy_customer_name", connect);
                        sp_searchBy_customer_name.CommandType = CommandType.StoredProcedure;
                        SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                        sp_searchBy_customer_name.Parameters.Add(name).Value = txtbox_customer_name.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_customer_name);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }
                    else
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_customer_name_new = new SqlCommand("sp_searchBy_customer_name_new", connect);
                        sp_searchBy_customer_name_new.CommandType = CommandType.StoredProcedure;
                        SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                        sp_searchBy_customer_name_new.Parameters.Add(name).Value = txtbox_customer_name.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_customer_name_new);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }

                }
                if (txtbox_mobile_no.Visible == true)
                {
                    if (radioButton_old_record.Checked)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_customer_mobile_no = new SqlCommand("sp_searchBy_customer_mobile_no", connect);
                        sp_searchBy_customer_mobile_no.CommandType = CommandType.StoredProcedure;
                        SqlParameter mobile_no = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                        sp_searchBy_customer_mobile_no.Parameters.Add(mobile_no).Value = txtbox_mobile_no.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_customer_mobile_no);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }
                    else
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();
                        SqlCommand sp_searchBy_customer_mobile_no_new = new SqlCommand("sp_searchBy_customer_mobile_no_new", connect);
                        sp_searchBy_customer_mobile_no_new.CommandType = CommandType.StoredProcedure;
                        SqlParameter mobile_no = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                        sp_searchBy_customer_mobile_no_new.Parameters.Add(mobile_no).Value = txtbox_mobile_no.Text.Trim();
                        SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_customer_mobile_no_new);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        connect.Close();
                    }

                }
                if (dateTimePicker_to.Visible == true)
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_searchBy_from_to_date = new SqlCommand("sp_searchBy_from_to_date", connect);
                    sp_searchBy_from_to_date.CommandType = CommandType.StoredProcedure;

                    string from_date_custom = dateTimePicker_from.Value.Day.ToString() + "-" + dateTimePicker_from.Value.Month.ToString() + "-" + dateTimePicker_from.Value.Year.ToString();

                    string to_date_custom = dateTimePicker_to.Value.Day.ToString() + "-" + dateTimePicker_to.Value.Month.ToString() + "-" + dateTimePicker_to.Value.Year.ToString();

                    SqlParameter from_date = new SqlParameter("@from_date", SqlDbType.Date);
                    sp_searchBy_from_to_date.Parameters.Add(from_date).Value = from_date_custom;
                    SqlParameter to_date = new SqlParameter("@to_date", SqlDbType.Date);
                    sp_searchBy_from_to_date.Parameters.Add(to_date).Value = to_date_custom;
                    SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_from_to_date);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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


        private void sales_admin_Load_1(object sender, EventArgs e)
        {
            time();
            try
            {
                lbl_text.Text = "Room Number";
                txtbox_customer_name.Visible = false;
                txtbox_date.Visible = false;
                txtbox_room_no.Visible = true;
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();
                SqlCommand sp_fetch_tbl_reservation_report = new SqlCommand("sp_fetch_tbl_reservation_report", connect);


                SqlDataAdapter sd = new SqlDataAdapter(sp_fetch_tbl_reservation_report);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                connect.Close();

                AutoCompleteStringCollection room_number = new AutoCompleteStringCollection();

                AutoCompleteStringCollection customer_name = new AutoCompleteStringCollection();

                AutoCompleteStringCollection customer_mobile_no = new AutoCompleteStringCollection();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    room_number.Add(dt.Rows[i]["room_number"].ToString());
                    customer_name.Add(dt.Rows[i]["name"].ToString());
                    customer_mobile_no.Add(dt.Rows[i]["mobile_number"].ToString());
                }

                txtbox_room_no.AutoCompleteCustomSource = room_number;

                txtbox_customer_name.AutoCompleteCustomSource = customer_name;

                txtbox_mobile_no.AutoCompleteCustomSource = customer_mobile_no;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void time()
        {
            DateTime time = DateTime.Now;
            string time_custom = time.ToString("hh:mm tt");
            string date_custom = time.ToString("dd-MM-yyyy");

            dateTimePicker_from.Format = DateTimePickerFormat.Short;
            dateTimePicker_checkOut.Format = DateTimePickerFormat.Short;
            dateTimePicker_to.Format = DateTimePickerFormat.Short;
            txtbox_date.Format = DateTimePickerFormat.Short;

            dateTimePicker_from.Value = Convert.ToDateTime(date_custom);
            dateTimePicker_checkOut.Value = Convert.ToDateTime(date_custom);
            dateTimePicker_to.Value = Convert.ToDateTime(date_custom);
            txtbox_date.Value = Convert.ToDateTime(date_custom);
        }

        private void radioButton_SearchByRoomNumber_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Room Number";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = true;
            dateTimePicker_checkOut.Visible = false;
            lbl_to.Visible = false;
            dateTimePicker_to.Visible = false;
            radioButton_check_in.Visible = false;
            radioButton_chceck_out.Visible = false;
            radioButton_from_to_date.Visible = false;
            txtbox_mobile_no.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";
        }



        private void radioButton_SearchByCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Customer Name";
            txtbox_customer_name.Visible = true;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = false;
            lbl_to.Visible = false;
            dateTimePicker_to.Visible = false;
            radioButton_check_in.Visible = false;
            radioButton_chceck_out.Visible = false;
            radioButton_from_to_date.Visible = false;
            txtbox_mobile_no.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";
        }


        private void radioButtonSearchByCustomerMobileNo_CheckedChanged(object sender, EventArgs e)
        {

            lbl_text.Text = "Mobile Number";
            txtbox_mobile_no.Visible = true;
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = false;
            lbl_to.Visible = false;
            dateTimePicker_to.Visible = false;
            radioButton_check_in.Visible = false;
            radioButton_chceck_out.Visible = false;
            radioButton_from_to_date.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";

        }

        private void radioButton_chceck_out_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Check Out";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = true;
            txtbox_mobile_no.Visible = false;
            lbl_to.Visible = false;
            dateTimePicker_to.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";
        }

        private void radioButton_from_to_date_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "     From Date";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = false;
            dateTimePicker_from.Visible = true;
            lbl_to.Visible = true;
            dateTimePicker_to.Visible = true;
            txtbox_mobile_no.Visible = false;
            radioButton_old_record.Visible = false;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";
        }

        private void radioButton_check_in_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Check In";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = true;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = false;
            lbl_to.Visible = false;
            dateTimePicker_to.Visible = false;
            txtbox_mobile_no.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            lbl_total_sales.Text = "0";
        }

        private void radioButton_date_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Check In";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = true;
            txtbox_room_no.Visible = false;
            dateTimePicker_checkOut.Visible = false;
            radioButton_check_in.Visible = true;
            radioButton_chceck_out.Visible = true;
            radioButton_from_to_date.Visible = true;
            txtbox_mobile_no.Visible = false;
            dateTimePicker_from.Visible = false;
            radioButton_old_record.Visible = true;
            radioButton_new_record.Checked = true;
            radioButton_check_in.Checked = true;
            lbl_total_sales.Text = "0";
        }


        private void btn_save_pdf_Click(object sender, EventArgs e)
        {
            if (lbl_total_sales.Text != "0")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel (.xlsx)|  *.xlsx";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                lbl_loading.Visible = true;
                                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                                Microsoft.Office.Interop.Excel._Workbook workbook = XcelApp.Workbooks.Add(Type.Missing);
                                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                                worksheet = workbook.Sheets["Sheet1"];
                                worksheet = workbook.ActiveSheet;
                                worksheet.Name = "Output";
                                worksheet.Application.ActiveWindow.SplitRow = 1;
                                worksheet.Application.ActiveWindow.FreezePanes = true;

                                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                                {
                                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                                    worksheet.Cells[1, i].Font.NAME = "Calibri";
                                    worksheet.Cells[1, i].Font.Bold = true;
                                    worksheet.Cells[1, i].Interior.Color = Color.Wheat;
                                    worksheet.Cells[1, i].Font.Size = 12;
                                }

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                    {
                                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                                double totalAmount = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    totalAmount += Convert.ToDouble(dataGridView1.Rows[i].Cells["total_rent_amount"].Value);
                                }

                                int lastRowIndex = dataGridView1.Rows.Count + 2;
                                worksheet.Cells[lastRowIndex, 13] = "Total Amount";
                                worksheet.Cells[lastRowIndex, 14] = totalAmount;
                                worksheet.Columns.AutoFit();
                                workbook.SaveAs(sfd.FileName);
                                XcelApp.Quit();

                                ReleaseObject(worksheet);
                                ReleaseObject(workbook);
                                ReleaseObject(XcelApp);
                                lbl_loading.Visible = false;
                                MessageBox.Show("Data Exported Successfully !!!", "Info");
                                System.Diagnostics.Process.Start(sfd.FileName);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }
            }
            else
            {
                MessageBox.Show("Please Click Calculate Total Button");
            }




        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.Message, "Error");
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btn_CalculateTotalSales_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DataTable dataTable = (DataTable)dataGridView1.DataSource;

                    if (dataTable.Rows.Count > 0)
                    {
                        double totalAmount = 0;
                        int costColumnIndex = dataTable.Columns["total_rent_amount"].Ordinal;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row[costColumnIndex] != DBNull.Value && double.TryParse(row[costColumnIndex].ToString(), out double cost))
                            {
                                totalAmount += cost;
                            }
                        }
                        lbl_total_sales.Text = totalAmount.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_loading_Click(object sender, EventArgs e)
        {

        }
    }
}
