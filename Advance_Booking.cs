using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class Advance_Booking : Form
    {
        public Advance_Booking(string user_id, string mail)
        {
            InitializeComponent();
            lbl_user_id.Text = user_id;
            lbl_mail.Text = mail;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            lbl_msg.Visible = true;
            btn_print.Visible = false;

        }
        public string connectionstring = Connection.GetConnectionString();

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbox_room_no.Visible == true)
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_searchBy_booking_room_number = new SqlCommand("sp_searchBy_booking_room_number", connect);
                    sp_searchBy_booking_room_number.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.Int);
                    sp_searchBy_booking_room_number.Parameters.Add(room_number).Value = txtbox_room_no.Text.Trim();
                    SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_booking_room_number);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    connect.Close();
                }
                if (txtbox_date.Visible == true)
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_searchBy_booking_checkin_date = new SqlCommand("sp_searchBy_booking_checkin_date", connect);
                    sp_searchBy_booking_checkin_date.CommandType = CommandType.StoredProcedure;

                    string check_in_date_custom = txtbox_date.Value.Day.ToString() + "-" + txtbox_date.Value.Month.ToString() + "-" + txtbox_date.Value.Year.ToString();

                    SqlParameter check_in_date = new SqlParameter("@check_in_date", SqlDbType.Date);
                    sp_searchBy_booking_checkin_date.Parameters.Add(check_in_date).Value = check_in_date_custom;
                    SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_booking_checkin_date);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    connect.Close();
                }

                if (txtbox_customer_name.Visible == true)
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_searchBy_booking_customer_name = new SqlCommand("sp_searchBy_booking_customer_name", connect);
                    sp_searchBy_booking_customer_name.CommandType = CommandType.StoredProcedure;
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    sp_searchBy_booking_customer_name.Parameters.Add(name).Value = txtbox_customer_name.Text.Trim();
                    SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_booking_customer_name);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    connect.Close();
                }
                if (txtbox_mobile_no.Visible == true)
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_searchBy_booking_customer_mobile_no = new SqlCommand("sp_searchBy_booking_customer_mobile_no", connect);
                    sp_searchBy_booking_customer_mobile_no.CommandType = CommandType.StoredProcedure;
                    SqlParameter mobile_no = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                    sp_searchBy_booking_customer_mobile_no.Parameters.Add(mobile_no).Value = txtbox_mobile_no.Text.Trim();
                    SqlDataAdapter sd = new SqlDataAdapter(sp_searchBy_booking_customer_mobile_no);
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
            date();
            data();
        }

        private void data()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();
                SqlCommand sp_fetch_room = new SqlCommand("sp_fetch_room", connect);
                SqlCommand sp_fetch_booking = new SqlCommand("sp_fetch_booking", connect);

                SqlCommand sp_auto_deletion_booking = new SqlCommand("sp_auto_deletion_booking", connect);
                int s = sp_auto_deletion_booking.ExecuteNonQuery();

                SqlDataAdapter sd = new SqlDataAdapter(sp_fetch_room);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                SqlDataAdapter sd1 = new SqlDataAdapter(sp_fetch_booking);
                DataTable dt1 = new DataTable();
                sd1.Fill(dt1);

                connect.Close();

                AutoCompleteStringCollection room_number = new AutoCompleteStringCollection();
                AutoCompleteStringCollection room_number_view = new AutoCompleteStringCollection();
                AutoCompleteStringCollection cutomer_name = new AutoCompleteStringCollection();
                AutoCompleteStringCollection mobile_no = new AutoCompleteStringCollection();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    room_number.Add(dt.Rows[i][0].ToString());
                }
                comboBox_room_no.DataSource = room_number;
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        room_number_view.Add(dt1.Rows[i]["room_number"].ToString());
                        cutomer_name.Add(dt1.Rows[i]["name"].ToString());
                        mobile_no.Add(dt1.Rows[i]["mobile_number"].ToString());
                    }
                    txtbox_room_no.AutoCompleteCustomSource = room_number_view;
                    txtbox_customer_name.AutoCompleteCustomSource = cutomer_name;
                    txtbox_mobile_no.AutoCompleteCustomSource = mobile_no;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void date()
        {
            DateTime time = DateTime.Now;
            string date_custom = time.ToString("dd-MM-yyyy");

            dateTimePicker_check_in_date.Format = DateTimePickerFormat.Short;
            txtbox_date.Format = DateTimePickerFormat.Short;

            dateTimePicker_check_in_date.Value = Convert.ToDateTime(date_custom);
            txtbox_date.Value = Convert.ToDateTime(date_custom);
        }


        private void radioButton_SearchByRoomNumber_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Room Number";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = true;
            txtbox_mobile_no.Visible = false;

        }
        private void radioButton_SearchByCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Customer Name";
            txtbox_customer_name.Visible = true;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
            txtbox_mobile_no.Visible = false;
        }


        private void radioButtonSearchByCustomerMobileNo_CheckedChanged(object sender, EventArgs e)
        {

            lbl_text.Text = "Mobile Number";
            txtbox_mobile_no.Visible = true;
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = false;
        }
        private void radioButton_check_in_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Check In";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = true;
            txtbox_room_no.Visible = false;
            txtbox_mobile_no.Visible = false;
        }

        private void radioButton_date_CheckedChanged(object sender, EventArgs e)
        {
            lbl_text.Text = "Check In";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = true;
            txtbox_room_no.Visible = false;
            txtbox_mobile_no.Visible = false;
        }

        private void radioButton_book_CheckedChanged(object sender, EventArgs e)
        {
            panel_book.Visible = true;
            panel_view.Visible = false;
        }

        private void radioButton_view_CheckedChanged(object sender, EventArgs e)
        {
            panel_book.Visible = false;
            panel_view.Visible = true;
            lbl_text.Text = "Room Number";
            txtbox_customer_name.Visible = false;
            txtbox_date.Visible = false;
            txtbox_room_no.Visible = true;
            data();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox_room_no.Text != "" && txtbox_name.Text.Trim() != "" && txtbox_mob_no_book.Text.Trim() != "" && txtbox_advance.Text.Trim() != "" && comboBox_payment_method.Text != "")
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_insert_booking = new SqlCommand("sp_insert_booking", connect);
                    sp_insert_booking.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_insert_booking.Parameters.Add(room_number).Value = comboBox_room_no.Text.Trim();
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    sp_insert_booking.Parameters.Add(name).Value = txtbox_name.Text.Trim();
                    SqlParameter mobile_no = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                    sp_insert_booking.Parameters.Add(mobile_no).Value = txtbox_mob_no_book.Text.Trim();
                    SqlParameter check_in_date = new SqlParameter("@check_in_date", SqlDbType.Date);
                    string check_in_date_custom = dateTimePicker_check_in_date.Value.Day.ToString() + "-" + dateTimePicker_check_in_date.Value.Month.ToString() + "-" + dateTimePicker_check_in_date.Value.Year.ToString();
                    sp_insert_booking.Parameters.Add(check_in_date).Value = check_in_date_custom;
                    SqlParameter rent_amount = new SqlParameter("@rent_amount", SqlDbType.Float);
                    sp_insert_booking.Parameters.Add(rent_amount).Value = txtbox_rent.Text.Trim();
                    SqlParameter advance_amount = new SqlParameter("@advance_amount", SqlDbType.Float);
                    sp_insert_booking.Parameters.Add(advance_amount).Value = txtbox_advance.Text.Trim();
                    SqlParameter payment_method = new SqlParameter("@payment_method", SqlDbType.VarChar);
                    sp_insert_booking.Parameters.Add(payment_method).Value = comboBox_payment_method.Text.Trim();

                    DateTime deletion_date_total = dateTimePicker_check_in_date.Value.AddMonths(2);
                    string date_custom = deletion_date_total.ToString("dd-M-yyyy");

                    SqlParameter deletion_date = new SqlParameter("@deletion_date", SqlDbType.Date);
                    sp_insert_booking.Parameters.Add(deletion_date).Value = date_custom;
                    SqlParameter purpose_of_visit = new SqlParameter("@purpose_of_visit", SqlDbType.VarChar);
                    sp_insert_booking.Parameters.Add(purpose_of_visit).Value = txtbox_purpose.Text.Trim();

                    int i = sp_insert_booking.ExecuteNonQuery();

                    if (i > 0)
                    {
                        lbl_loading.Visible = true;
                        MessageBox.Show("Booked Successfully!");
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
                                SmtpClient client = new SmtpClient("smtp.gmail.com");
                                client.Port = 587;
                                client.Credentials = new System.Net.NetworkCredential("pcpoint656@gmail.com", " ");
                                client.EnableSsl = true;
                                MailMessage mail = new MailMessage();
                                mail.From = new MailAddress(row["email"].ToString());
                                mail.To.Add(owner_email);
                                mail.To.Add(manager_email);
                                mail.Subject = "Room Advance Booking";
                                mail.Body = $"Room Number: {comboBox_room_no.Text}\n" +
                                $"Booked in(Date): {check_in_date_custom}\n" +
                                $"Customer Name: {txtbox_name.Text}\n" +
                                $"Customer Mobile Number: {txtbox_mob_no_book.Text}\n" +
                                $"Advance Amount: {txtbox_advance.Text}";

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
                        if (MessageBox.Show("Do You Want Print Check In Receipt", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            print();
                            comboBox_room_no.DataSource = null;
                            data();
                            clear();
                        }
                        else
                        {
                            comboBox_room_no.DataSource = null;
                            clear();
                            data();
                        }
                    }
                }
                else
                    MessageBox.Show("please Fill All Details");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clear()
        {
            txtbox_mob_no_book.Clear();
            txtbox_name.Clear();
            txtbox_advance.Clear();

        }
        public int Fetchrent()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();

                SqlCommand sp_fetch_room_rent = new SqlCommand("sp_fetch_room_rent", connect);
                sp_fetch_room_rent.CommandType = CommandType.StoredProcedure;
                SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                sp_fetch_room_rent.Parameters.Add(room_number).Value = comboBox_room_no.Text;

                SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_room_rent);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                connect.Close();
                int room_rent = Convert.ToInt32(dt.Rows[0][0]);

                return room_rent;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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

            string check_in_date_custom = dateTimePicker_check_in_date.Value.Day.ToString() + "-" + dateTimePicker_check_in_date.Value.Month.ToString() + "-" + dateTimePicker_check_in_date.Value.Year.ToString();

            Pen blackPen = new Pen(Color.Black, 3);

            string textToPrint = "Room Advance Booking Receipt";
            string textToPrint1 = "Address:";
            string textToPrint2 = "Prasanna Bhavan Residency,";
            string textToPrint3 = "Near Sengurichi Tollgate,";
            string textToPrint4 = "Ulundurpet, Tamil Nadu 606107";
            string textToPrint6 = $"Date:{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
            Font Font_for_invoice = new Font("Tahoma", 22, FontStyle.Bold);
            Font Font_for_heading = new Font("Tahoma", 16, FontStyle.Underline);
            Font Font_for_tblheading = new Font("Tahoma", 15, FontStyle.Bold);
            Font Font_for_other = new Font("Arial", 15);
            e.Graphics.DrawString(textToPrint, Font_for_invoice, Brushes.Black, 180, 80);
            e.Graphics.DrawString(textToPrint1, Font_for_other, Brushes.Black, 15, 200);
            e.Graphics.DrawString(textToPrint2, Font_for_other, Brushes.Black, 15, 230);
            e.Graphics.DrawString(textToPrint3, Font_for_other, Brushes.Black, 15, 258);
            e.Graphics.DrawString(textToPrint4, Font_for_other, Brushes.Black, 15, 288);
            e.Graphics.DrawString(textToPrint6, Font_for_other, Brushes.Black, 650, 238);
            e.Graphics.DrawLine(Pens.Black, 10, 328, 800, 328);

            e.Graphics.DrawString("Customer Details", Font_for_heading, Brushes.Black, 320, 350);
            e.Graphics.DrawRectangle(blackPen, 10, 538, 800, 220);
            e.Graphics.DrawString("Room Number", Font_for_tblheading, Brushes.Black, 210, 553);
            e.Graphics.DrawString("Check In Date", Font_for_tblheading, Brushes.Black, 450, 553);
            e.Graphics.DrawString(check_in_date_custom, Font_for_other, Brushes.Black, 470, 583);
            //e.Graphics.DrawString("Rent Amount", Font_for_tblheading, Brushes.Black, 450, 633);
            e.Graphics.DrawString("Advance Amount Paid", Font_for_tblheading, Brushes.Black, 450, 668);
            //e.Graphics.DrawString("Balance Amount", Font_for_tblheading, Brushes.Black, 450, 708);
            e.Graphics.DrawString("Signature", Font_for_other, Brushes.Black, 680, 978);
            if (radioButton_book.Checked == true)
            {
                e.Graphics.DrawString("Name :" + txtbox_name.Text.Trim(), Font_for_other, Brushes.Black, 20, 388);
                e.Graphics.DrawString("Mobile Number :" + txtbox_mob_no_book.Text.Trim(), Font_for_other, Brushes.Black, 20, 428);
                e.Graphics.DrawString(comboBox_room_no.Text, Font_for_other, Brushes.Black, 250, 583);
                //e.Graphics.DrawString("₹" + txtbox_rent.Text.Trim(), Font_for_other, Brushes.Black, 710, 633);
                e.Graphics.DrawString("₹" + txtbox_balance.Text.Trim(), Font_for_other, Brushes.Black, 710, 668);
                //e.Graphics.DrawString("₹" + txtbox_balance.Text.Trim(), Font_for_other, Brushes.Black, 710, 708);


            }
            else
            {
                try
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    int selectedCellIndex = dataGridView1.CurrentCell.ColumnIndex;
                    if (selectedRowIndex >= 0 && selectedCellIndex >= 0)
                    {
                        SqlConnection connect = new SqlConnection(connectionstring);
                        connect.Open();

                        SqlCommand sp_fetch_booking_room_no = new SqlCommand("sp_fetch_booking_room_no", connect);
                        sp_fetch_booking_room_no.CommandType = CommandType.StoredProcedure;
                        SqlParameter room_number = new SqlParameter("@Id", SqlDbType.Int);
                        sp_fetch_booking_room_no.Parameters.Add(room_number).Value = dataGridView1.Rows[selectedRowIndex].Cells["Id"].Value;

                        SqlDataAdapter sda = new SqlDataAdapter(sp_fetch_booking_room_no);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        connect.Close();
                        lbl_room_no.Text = dt.Rows[0]["room_number"].ToString();
                        lbl_name.Text = dt.Rows[0]["name"].ToString();
                        lbl_mob_no.Text = dt.Rows[0]["mobile_number"].ToString();
                        lbl_advance.Text = dt.Rows[0]["advance_amount"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                e.Graphics.DrawString("Name :" + lbl_name.Text, Font_for_other, Brushes.Black, 20, 388);
                e.Graphics.DrawString("Mobile Number :" + lbl_mob_no.Text, Font_for_other, Brushes.Black, 20, 428);
                e.Graphics.DrawString(lbl_room_no.Text, Font_for_other, Brushes.Black, 250, 583);
                //e.Graphics.DrawString("₹" + txtbox_rent.Text, Font_for_other, Brushes.Black, 710, 633);
                e.Graphics.DrawString("₹" + lbl_advance.Text, Font_for_other, Brushes.Black, 710, 668);
                //e.Graphics.DrawString("₹" + txtbox_balance.Text.Trim(), Font_for_other, Brushes.Black, 710, 708);
            }



        }

        private void comboBox_room_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_room_no.Text.Trim() != "")
            {
                int rent = Fetchrent();
                txtbox_rent.Text = rent.ToString();
                txtbox_advance.Clear();
                txtbox_balance.Clear();
            }
        }

        private void txtbox_advance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int rent = Convert.ToInt32(txtbox_rent.Text.Trim());
                int advance = Convert.ToInt32(txtbox_advance.Text);
                int total = rent - advance;
                txtbox_balance.Text = total.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show($"Please Enter Valid Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbox_rent_TextChanged(object sender, EventArgs e)
        {
            txtbox_balance.Clear();
            txtbox_advance.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbl_msg.Visible = false;
            //btn_print.Visible = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                btn_print.Visible = true;
                lbl_msg.Visible = false;
            }
            else
            {
                btn_print.Visible = false;
                lbl_msg.Visible = true;
            }

        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                btn_print.Visible = false;
                lbl_msg.Visible = true;
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            print();
        }
    }
}
