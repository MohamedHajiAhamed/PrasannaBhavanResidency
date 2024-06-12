using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class check_out : Form
    {
        public check_out(string user_id, string mail)
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

        private void comboBox_room_no_Click(object sender, EventArgs e)
        {
            comboBox_room_no.DroppedDown = true;
        }

        private void btn_check_out_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();
                SqlCommand sp_fetch_check_in = new SqlCommand("sp_fetch_check_in", connect);
                sp_fetch_check_in.CommandType = CommandType.StoredProcedure;
                SqlParameter room_number1 = new SqlParameter("@room_number", SqlDbType.VarChar);
                sp_fetch_check_in.Parameters.Add(room_number1).Value = comboBox_room_no.Text;
                SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_check_in);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (comboBox_room_no.Text != "" && txtbox_name.Text != "" && txtbox_mobile_no.Text != "" && txtbox_balance.Text != "")
                {
                    SqlCommand sp_insert_reservation = new SqlCommand("sp_insert_reservation", connect);
                    sp_insert_reservation.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(room_number).Value = comboBox_room_no.Text;
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(name).Value = txtbox_name.Text.Trim();
                    SqlParameter mobile_number = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                    sp_insert_reservation.Parameters.Add(mobile_number).Value = txtbox_mobile_no.Text.Trim();

                    string check_in_date_custom = txtbox_check_in_date.Value.Day.ToString() + "-" + txtbox_check_in_date.Value.Month.ToString() + "-" + txtbox_check_in_date.Value.Year.ToString();

                    SqlParameter check_in_date = new SqlParameter("@check_in_date", SqlDbType.Date);
                    sp_insert_reservation.Parameters.Add(check_in_date).Value = check_in_date_custom;
                    SqlParameter time_in = new SqlParameter("@time_in", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(time_in).Value = dt.Rows[0]["time_in"];
                    SqlParameter purpose_of_visit = new SqlParameter("@purpose_of_visit", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(purpose_of_visit).Value = dt.Rows[0]["purpose_of_visit"];
                    SqlParameter no_of_gents = new SqlParameter("@no_of_gents", SqlDbType.Int);
                    sp_insert_reservation.Parameters.Add(no_of_gents).Value = dt.Rows[0]["no_of_gents"];
                    SqlParameter no_of_ladies = new SqlParameter("@no_of_ladies", SqlDbType.Int);
                    sp_insert_reservation.Parameters.Add(no_of_ladies).Value = dt.Rows[0]["no_of_ladies"];
                    SqlParameter no_of_children = new SqlParameter("@no_of_children", SqlDbType.Int);
                    sp_insert_reservation.Parameters.Add(no_of_children).Value = dt.Rows[0]["no_of_children"];
                    SqlParameter proof = new SqlParameter("@proof", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(proof).Value = dt.Rows[0]["proof"];
                    SqlParameter proof_number = new SqlParameter("@proof_number", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(proof_number).Value = dt.Rows[0]["proof_number"];
                    SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(address).Value = dt.Rows[0]["address"];
                    SqlParameter advance_amount = new SqlParameter("@advance_amount", SqlDbType.Float);
                    sp_insert_reservation.Parameters.Add(advance_amount).Value = dt.Rows[0]["advance_amount"];
                    double balance_amount = Convert.ToDouble(dt.Rows[0]["balance_amount"]);
                    double advance = Convert.ToDouble(dt.Rows[0]["advance_amount"]);
                    double total = balance_amount + advance;

                    SqlParameter total_rent_amount = new SqlParameter("@total_rent_amount", SqlDbType.Float);
                    sp_insert_reservation.Parameters.Add(total_rent_amount).Value = total;
                    SqlParameter payment_method_checkin = new SqlParameter("@payment_method_checkin", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(payment_method_checkin).Value = dt.Rows[0]["payment_method_checkin"];
                    SqlParameter time_out = new SqlParameter("@time_out", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(time_out).Value = dateTimePicker_time_out.Text;
                    SqlParameter payment_method_checkout = new SqlParameter("@payment_method_checkout", SqlDbType.VarChar);
                    sp_insert_reservation.Parameters.Add(payment_method_checkout).Value = comboBox_payment_method.Text;
                    if (txtbox_check_out_date.Visible == true)
                    {
                        string check_out_date_custom = txtbox_check_out_date.Value.Day.ToString() + "-" + txtbox_check_out_date.Value.Month.ToString() + "-" + txtbox_check_out_date.Value.Year.ToString();
                        SqlParameter check_out_date = new SqlParameter("@check_out_date", SqlDbType.Date);
                        sp_insert_reservation.Parameters.Add(check_out_date).Value = check_out_date_custom;
                    }
                    else
                    {
                        string check_out_date_custom = dateTimePicker_check_out_date.Value.Day.ToString() + "-" + dateTimePicker_check_out_date.Value.Month.ToString() + "-" + dateTimePicker_check_out_date.Value.Year.ToString();
                        SqlParameter check_out_date = new SqlParameter("@check_out_date", SqlDbType.VarChar);
                        sp_insert_reservation.Parameters.Add(check_out_date).Value = check_out_date_custom;
                    }
                    int i = sp_insert_reservation.ExecuteNonQuery();

                    if (i > 0)
                    {
                        SqlCommand sp_update_check_in_status = new SqlCommand("sp_update_check_in_status", connect);
                        sp_update_check_in_status.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number2 = new SqlParameter("@room_number", SqlDbType.VarChar);
                        sp_update_check_in_status.Parameters.Add(room_number2).Value = comboBox_room_no.Text;
                        SqlParameter check_status = new SqlParameter("@check_status", SqlDbType.VarChar);
                        sp_update_check_in_status.Parameters.Add(check_status).Value = "No";
                        sp_update_check_in_status.ExecuteNonQuery();
                        SqlCommand sp_delete_check_in = new SqlCommand("sp_delete_check_in", connect);
                        sp_delete_check_in.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number3 = new SqlParameter("@room_number", SqlDbType.VarChar);
                        sp_delete_check_in.Parameters.Add(room_number3).Value = comboBox_room_no.Text;
                        sp_delete_check_in.ExecuteNonQuery();
                        connect.Close();
                        lbl_loading.Visible = true;
                        MessageBox.Show("Check out Successfully");
                        int parseduser_id = Convert.ToInt32(lbl_user_id.Text);
                        SqlCommand sp_fetch_user_single = new SqlCommand("sp_fetch_single_user", connect);
                        sp_fetch_user_single.CommandType = CommandType.StoredProcedure;

                        SqlParameter user_id = new SqlParameter("@user_id", SqlDbType.Int);
                        sp_fetch_user_single.Parameters.Add(user_id).Value = parseduser_id;

                        SqlDataAdapter sda1 = new SqlDataAdapter(sp_fetch_user_single);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        DataRow row = dt1.Rows[0];

                        string owner_email = row["owner_email"].ToString();
                        string manager_email = row["manager_email"].ToString();
                        if (owner_email != "" && manager_email != "")
                        {
                            try
                            {
                                string check_out_date_custom = dateTimePicker_check_out_date.Value.Day.ToString() + "-" + dateTimePicker_check_out_date.Value.Month.ToString() + "-" + dateTimePicker_check_out_date.Value.Year.ToString();

                                SmtpClient client = new SmtpClient("smtp.gmail.com");
                                client.Port = 587;
                                client.Credentials = new System.Net.NetworkCredential("pcpoint656@gmail.com", " ");
                                client.EnableSsl = true;
                                MailMessage mail = new MailMessage();
                                mail.From = new MailAddress(row["email"].ToString());
                                mail.To.Add(owner_email);
                                mail.To.Add(manager_email);
                                mail.Subject = "Room Check Out";
                                mail.Body = $"Room Number: {comboBox_room_no.Text}\n" +
                                $"Check Out Date: {check_out_date_custom}\n" +
                                $"Check Out Time: {dateTimePicker_time_out.Text}\n" +
                                $"Customer Name: {txtbox_name.Text}\n" +
                                $"Customer Address: {dt.Rows[0][11]}\n" +
                                $"Total Amount: {total}";

                                client.Send(mail);
                                lbl_loading.Visible = false;
                                MessageBox.Show("Mail Sent Successfully");
                            }
                            catch (Exception ex)
                            {
                                lbl_loading.Visible = false;
                                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            lbl_loading.Visible = false;
                            MessageBox.Show("Add Owner E-Mail And Manager E-Mail To Send Mail");

                        }
                        if (MessageBox.Show("Do You Want Print Check Out Receipt", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            print();
                            comboBox_room_no.DataSource = null;
                            roomNo();
                            txtbox_name.Clear();
                            txtbox_mobile_no.Clear();
                            txtbox_balance.Clear();
                            txtbox_total_rent.Clear();
                            checkBox_change_check_out.Checked = false;
                            time();
                        }
                        else
                        {
                            comboBox_room_no.DataSource = null;
                            roomNo();
                            txtbox_name.Clear();
                            txtbox_mobile_no.Clear();
                            txtbox_balance.Clear();
                            txtbox_total_rent.Clear();
                            checkBox_change_check_out.Checked = false;
                            time();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Try Again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void print()
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                PaperSize paperSize = new PaperSize("A4", 827, 1169);
                printDocument.DefaultPageSettings.PaperSize = paperSize;

                printDocument.PrintPage += printDocument1_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                    printPreviewDialog.Height = 604;
                    printPreviewDialog.Width = 1094;
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_out_Load(object sender, EventArgs e)
        {

            roomNo();
            time();
            detailsfetch();
        }
        private void time()
        {
            DateTime time = DateTime.Now;
            string time_custom = time.ToString("hh:mm tt");
            string date_custom = time.ToString("dd-MM-yyyy");

            dateTimePicker_check_out_date.Format = DateTimePickerFormat.Short;
            txtbox_check_out_date.Format = DateTimePickerFormat.Short;
            dateTimePicker_time_out.Format = DateTimePickerFormat.Custom;
            dateTimePicker_time_out.CustomFormat = "hh:mm tt";

            dateTimePicker_time_out.Value = Convert.ToDateTime(time_custom);
            dateTimePicker_check_out_date.Value = Convert.ToDateTime(date_custom);
            //txtbox_check_out_date.Value = Convert.ToDateTime(date_custom);
        }

        private void roomNo()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();

                SqlCommand sp_fetch_room_number_check_out = new SqlCommand("sp_fetch_room_number_check_out", connect);
                sp_fetch_room_number_check_out.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = sp_fetch_room_number_check_out.ExecuteReader();

                AutoCompleteStringCollection room_number = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    room_number.Add(dr.GetString(0).ToString());
                }
                comboBox_room_no.DataSource = room_number;
                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void detailsfetch()
        {
            checkBox_change_check_out.Checked = false;
            dateTimePicker_check_out_date.Visible = false;
            txtbox_check_out_date.Visible = true;
            time();
            try
            {
                if (comboBox_room_no.Text != "")
                {
                    lbl_days.Text = "1";
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_fetch_check_in = new SqlCommand("sp_fetch_check_in", connect);
                    sp_fetch_check_in.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number1 = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_fetch_check_in.Parameters.Add(room_number1).Value = comboBox_room_no.Text;
                    SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_check_in);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    txtbox_name.Text = dt.Rows[0]["name"].ToString();
                    txtbox_mobile_no.Text = dt.Rows[0]["mobile_number"].ToString();
                    txtbox_total_rent.Text = dt.Rows[0]["rent_amount"].ToString();
                    lbl_rent.Text = dt.Rows[0]["rent_amount"].ToString();
                    txtbox_balance.Text = dt.Rows[0]["balance_amount"].ToString();
                    lbl_balance.Text = dt.Rows[0]["balance_amount"].ToString();
                    txtbox_check_in_date.Text = dt.Rows[0]["check_in_date"].ToString();
                    //dateTimePicker_check_out_date.Text = dt.Rows[0]["check_out_date"];
                    txtbox_check_out_date.Text = dt.Rows[0]["check_out_date"].ToString();
                    txtbox_proof.Text = dt.Rows[0]["proof"].ToString();
                    txtbox_proof_number.Text = dt.Rows[0]["proof_number"].ToString();
                    txtbox_address.Text = dt.Rows[0]["address"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_room_no_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_room_no.Text != "")
            {
                detailsfetch();
            }

        }

        private void comboBox_payment_method_Click(object sender, EventArgs e)
        {
            comboBox_payment_method.DroppedDown = true;
        }

        private void checkBox_change_check_out_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_change_check_out.Checked)
            {
                txtbox_check_out_date.Visible = false;
                dateTimePicker_check_out_date.Visible = true;
            }
            else
            {
                lbl_days.Text = "1";
                detailsfetch();
                txtbox_check_out_date.Visible = true;
                dateTimePicker_check_out_date.Visible = false;
            }
        }



        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Bitmap bitmap = Properties.Resources.Logo1;
                Image image = new Bitmap(bitmap);

                int marginX = 380;
                int marginY = 10;
                int newWidth = 60;
                int newHeight = (int)((double)image.Height / image.Width * newWidth);

                Rectangle destinationRect = new Rectangle(marginX, marginY, newWidth, newHeight);
                e.Graphics.DrawImage(image, destinationRect);

                DateTime dateTime = DateTime.Now;

                string check_in_date_custom = txtbox_check_in_date.Value.Day.ToString() + "-" + txtbox_check_in_date.Value.Month.ToString() + "-" + txtbox_check_in_date.Value.Year.ToString();

                string check_out_date_custom = dateTimePicker_check_out_date.Value.Day.ToString() + "-" + dateTimePicker_check_out_date.Value.Month.ToString() + "-" + dateTimePicker_check_out_date.Value.Year.ToString();

                Pen blackPen = new Pen(Color.Black, 3);

                string textToPrint = "Room Check Out Receipt";
                string textToPrint1 = "Address:";
                string textToPrint2 = "Prasanna Bhavan Residency,";
                string textToPrint3 = "Near Sengurichi Tollgate,";
                string textToPrint4 = "Ulundurpet, Tamil Nadu 606107";
                string textToPrint6 = $"Date:{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
                Font Font_for_invoice = new Font("Tahoma", 22, FontStyle.Bold);
                Font Font_for_heading = new Font("Tahoma", 16, FontStyle.Underline);
                Font Font_for_tblheading = new Font("Tahoma", 15, FontStyle.Bold);
                Font Font_for_other = new Font("Arial", 15);
                e.Graphics.DrawString(textToPrint, Font_for_invoice, Brushes.Black, 230, 80);
                e.Graphics.DrawString(textToPrint1, Font_for_other, Brushes.Black, 15, 200);
                e.Graphics.DrawString(textToPrint2, Font_for_other, Brushes.Black, 15, 230);
                e.Graphics.DrawString(textToPrint3, Font_for_other, Brushes.Black, 15, 258);
                e.Graphics.DrawString(textToPrint4, Font_for_other, Brushes.Black, 15, 288);
                e.Graphics.DrawString(textToPrint6, Font_for_other, Brushes.Black, 650, 238);
                e.Graphics.DrawLine(Pens.Black, 10, 328, 800, 328);

                e.Graphics.DrawString("Customer Details", Font_for_heading, Brushes.Black, 320, 350);
                e.Graphics.DrawString("Name :" + txtbox_name.Text.Trim(), Font_for_other, Brushes.Black, 20, 388);
                e.Graphics.DrawString("Mobile Number :" + txtbox_mobile_no.Text.Trim(), Font_for_other, Brushes.Black, 20, 428);
                e.Graphics.DrawString("Proof :" + txtbox_proof.Text, Font_for_other, Brushes.Black, 520, 388);
                e.Graphics.DrawString("Proof Number :" + txtbox_proof_number.Text, Font_for_other, Brushes.Black, 520, 428);
                e.Graphics.DrawString("Address :" + txtbox_address.Text, Font_for_other, Brushes.Black, 20, 468);

                e.Graphics.DrawRectangle(blackPen, 10, 538, 800, 220);

                e.Graphics.DrawString("Room Number", Font_for_tblheading, Brushes.Black, 20, 553);
                e.Graphics.DrawString("Check In Date", Font_for_tblheading, Brushes.Black, 220, 553);
                e.Graphics.DrawString("Check Out Time", Font_for_tblheading, Brushes.Black, 440, 553);
                e.Graphics.DrawString("Check Out Date", Font_for_tblheading, Brushes.Black, 640, 553);

                e.Graphics.DrawString(comboBox_room_no.Text, Font_for_other, Brushes.Black, 30, 583);
                e.Graphics.DrawString(check_in_date_custom, Font_for_other, Brushes.Black, 230, 583);
                e.Graphics.DrawString(dateTimePicker_time_out.Text, Font_for_other, Brushes.Black, 450, 583);
                e.Graphics.DrawString(check_out_date_custom, Font_for_other, Brushes.Black, 650, 583);


                e.Graphics.DrawString("Total Rent Amount", Font_for_tblheading, Brushes.Black, 450, 658);
                e.Graphics.DrawString("₹" + txtbox_total_rent.Text, Font_for_other, Brushes.Black, 700, 658);

                e.Graphics.DrawString("Balance Amount", Font_for_tblheading, Brushes.Black, 450, 698);
                e.Graphics.DrawString("₹" + txtbox_balance.Text, Font_for_other, Brushes.Black, 700, 698);

                e.Graphics.DrawString("Signature", Font_for_other, Brushes.Black, 680, 978);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker_check_out_date_ValueChanged(object sender, EventArgs e)
        {
            if (txtbox_check_in_date.Value != null && dateTimePicker_check_out_date.Value != null)
            {

                int date = (dateTimePicker_check_out_date.Value.Date - txtbox_check_in_date.Value.Date).Days;
                if (date >= 1)
                {

                    lbl_days.Text = date.ToString();
                    txtbox_total_rent.Clear();
                    txtbox_balance.Clear();
                    int rent = Convert.ToInt32(lbl_rent.Text);
                    int total = rent * Convert.ToInt32(lbl_days.Text);
                    txtbox_total_rent.Text = total.ToString();
                    if (date > 1)
                    {
                        int balance = Convert.ToInt32(txtbox_total_rent.Text) + Convert.ToInt32(lbl_balance.Text);
                        txtbox_balance.Text = balance.ToString();
                    }
                    else
                    {
                        txtbox_balance.Text = lbl_balance.Text;
                    }


                }
                else if (date == 0)
                {
                    lbl_days.Text = "1";
                    txtbox_total_rent.Clear();
                    txtbox_balance.Clear();
                    int rent = Convert.ToInt32(lbl_rent.Text);
                    int total = rent * Convert.ToInt32(lbl_days.Text);
                    txtbox_total_rent.Text = total.ToString();
                    if (date > 1)
                    {
                        int balance = Convert.ToInt32(txtbox_total_rent.Text) + Convert.ToInt32(lbl_balance.Text);
                        txtbox_balance.Text = balance.ToString();
                    }
                    else
                    {
                        txtbox_balance.Text = lbl_balance.Text;
                    }

                }
                else
                {
                    txtbox_total_rent.Clear();
                    txtbox_balance.Clear();
                    MessageBox.Show("Please Select Valid Check Out/Check In Date");
                }

            }
        }
    }
}
