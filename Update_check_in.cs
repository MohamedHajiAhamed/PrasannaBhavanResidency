using Org.BouncyCastle.Asn1.X509;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Windows.Forms;


namespace Prasanna_Bhavan_Residency
{
    public partial class Update_check_in : Form
    {
        public Update_check_in(string user_id, string mail)
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
        private void Employee_details_admin_Load(object sender, EventArgs e)
        {
            dateTimePicker_time_in.Format = DateTimePickerFormat.Custom;
            dateTimePicker_time_in.CustomFormat = "hh:mm tt";
            roomNo();
            lbl_days.Text = "1";
        }
        public void roomNo()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionstring);
                connect.Open();

                SqlCommand sp_fetch_room_number_check_in_update = new SqlCommand("sp_fetch_room_number_check_in_update", connect);
                sp_fetch_room_number_check_in_update.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = sp_fetch_room_number_check_in_update.ExecuteReader();

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
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void data()
        {
            try
            {
                if (comboBox_room_no.Text != "")
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
                    txtbox_name.Text = dt.Rows[0]["name"].ToString();
                    txtbox_mobile_no.Text = dt.Rows[0]["mobile_number"].ToString();
                    txtbox_purpose.Text = dt.Rows[0]["purpose_of_visit"].ToString();
                    comboBox_gents.Text = dt.Rows[0]["no_of_gents"].ToString();
                    comboBox_ladies.Text = dt.Rows[0]["no_of_ladies"].ToString();
                    comboBox_children.Text = dt.Rows[0]["no_of_children"].ToString();
                    try
                    {
                        // Assuming 'dt' is your DataTable and it has a valid datetime string in the "time_in" column
                        string timeInString = dt.Rows[0]["time_in"].ToString();

                        // Parse the string to a DateTime object
                        DateTime timeIn = DateTime.ParseExact(timeInString, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

                        // Set the DateTimePicker's format and value
                        dateTimePicker_time_in.Format = DateTimePickerFormat.Custom;
                        dateTimePicker_time_in.CustomFormat = "hh:mm tt";
                        dateTimePicker_time_in.Value = timeIn;
                    }
                    catch (FormatException)
                    {
                        // Handle parsing error
                        MessageBox.Show("Invalid time format. Please check the data source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dateTimePicker_check_in_date.Text = dt.Rows[0]["check_in_date"].ToString();
                    dateTimePicker_check_out_date.Text = dt.Rows[0]["check_out_date"].ToString();
                    txtbox_advance.Text = dt.Rows[0]["advance_amount"].ToString();
                    txtbox_balance.Text = dt.Rows[0]["balance_amount"].ToString();
                    lbl_balance.Text = dt.Rows[0]["balance_amount"].ToString();
                    txtbox_rent.Text = dt.Rows[0]["rent_amount"].ToString();
                    comboBoxproof.Text = dt.Rows[0]["proof"].ToString();
                    txtbox_proof_no.Text = dt.Rows[0]["proof_number"].ToString();
                    comboBox_payment_method.Text = dt.Rows[0]["payment_method_checkin"].ToString();
                    richTextBox_address.Text = dt.Rows[0]["address"].ToString();
                    lbl_gst.Value = Convert.ToInt32(dt.Rows[0]["GST_amount"]);
                    lbl_extra_bed.Value = Convert.ToInt32(dt.Rows[0]["extra_bed_amount"]);

                    int date = (dateTimePicker_check_out_date.Value.Date - dateTimePicker_check_in_date.Value.Date).Days;
                    if (date > 0)
                    {
                        lbl_days.Text = date.ToString();
                    }
                    
                    else
                    {
                        lbl_days.Text = "1";
                    }
                        

                    if (lbl_gst.Value > 0)
                    {
                        checkBox_gst.Visible = true;
                        checkBox_gst.Checked = true;
                        checkBox_gst_new.Visible = false;
                    }
                    else
                    {
                        checkBox_gst.Visible = true;
                        checkBox_gst.Checked = false;
                        checkBox_gst_new.Visible = true;
                    }
                    if (lbl_extra_bed.Value > 0)
                    {
                        checkBox_extra_bed.Visible = true;
                        checkBox_extra_bed.Checked = true;
                        checkBox_extra_bed_new.Visible = false;
                    }
                    else
                    {
                        checkBox_extra_bed.Visible = true;
                        checkBox_extra_bed.Checked = false;
                        checkBox_extra_bed_new.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxproof_Click(object sender, EventArgs e)
        {
            comboBoxproof.DroppedDown = true;
        }

        private void comboBox_payment_method_Click(object sender, EventArgs e)
        {
            comboBox_payment_method.DroppedDown = true;
        }

        private void comboBox_gents_Click(object sender, EventArgs e)
        {
            comboBox_gents.DroppedDown = true;
        }

        private void comboBox_ladies_Click(object sender, EventArgs e)
        {
            comboBox_ladies.DroppedDown = true;
        }

        private void comboBox_children_Click(object sender, EventArgs e)
        {
            comboBox_children.DroppedDown = true;
        }

        private void comboBox_room_no_Click(object sender, EventArgs e)
        {
            comboBox_room_no.DroppedDown = true;
        }

        private void btn_check_in_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_room_no.Text != "" && txtbox_name.Text.Trim() != "" && txtbox_mobile_no.Text.Trim() != "" && dateTimePicker_time_in.Text != "" && comboBox_gents.Text != "" && comboBox_ladies.Text != "" && comboBox_children.Text != "" && txtbox_advance.Text.Trim() != "" && txtbox_balance.Text.Trim() != "" && comboBoxproof.Text != "" && txtbox_proof_no.Text.Trim() != "" && comboBox_payment_method.Text != "" && richTextBox_address.Text.Trim() != "")
                {
                    SqlConnection connect = new SqlConnection(connectionstring);
                    connect.Open();
                    SqlCommand sp_insert_check_in = new SqlCommand("sp_update_check_in", connect);
                    sp_insert_check_in.CommandType = CommandType.StoredProcedure;
                    SqlParameter room_number = new SqlParameter("@room_number", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(room_number).Value = comboBox_room_no.Text;
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(name).Value = txtbox_name.Text.Trim();
                    SqlParameter mobile_number = new SqlParameter("@mobile_number", SqlDbType.BigInt);
                    sp_insert_check_in.Parameters.Add(mobile_number).Value = txtbox_mobile_no.Text.Trim();
                    SqlParameter time_in = new SqlParameter("@time_in", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(time_in).Value = dateTimePicker_time_in.Text;
                    SqlParameter purpose_of_visit = new SqlParameter("@purpose_of_visit", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(purpose_of_visit).Value = txtbox_purpose.Text.Trim();
                    SqlParameter no_of_gents = new SqlParameter("@no_of_gents", SqlDbType.Int);
                    sp_insert_check_in.Parameters.Add(no_of_gents).Value = comboBox_gents.Text;
                    SqlParameter no_of_ladies = new SqlParameter("@no_of_ladies", SqlDbType.Int);
                    sp_insert_check_in.Parameters.Add(no_of_ladies).Value = comboBox_ladies.Text;
                    SqlParameter no_of_children = new SqlParameter("@no_of_children", SqlDbType.Int);
                    sp_insert_check_in.Parameters.Add(no_of_children).Value = comboBox_children.Text;
                    SqlParameter proof = new SqlParameter("@proof", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(proof).Value = comboBoxproof.Text;
                    SqlParameter proof_number = new SqlParameter("@proof_number", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(proof_number).Value = txtbox_proof_no.Text.Trim();
                    SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(address).Value = richTextBox_address.Text.Trim();
                    SqlParameter rent_amount = new SqlParameter("@rent_amount", SqlDbType.Float);
                    sp_insert_check_in.Parameters.Add(rent_amount).Value = txtbox_rent.Text.Trim();
                    SqlParameter advance_amount = new SqlParameter("@advance_amount", SqlDbType.Float);
                    sp_insert_check_in.Parameters.Add(advance_amount).Value = txtbox_advance.Text.Trim();
                    SqlParameter balance_amount = new SqlParameter("@balance_amount", SqlDbType.Float);
                    sp_insert_check_in.Parameters.Add(balance_amount).Value = txtbox_balance.Text.Trim();
                    SqlParameter payment_method_checkin = new SqlParameter("@payment_method_checkin", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(payment_method_checkin).Value = comboBox_payment_method.Text;
                    string check_out_date_custom = dateTimePicker_check_out_date.Value.Day.ToString() + "-" + dateTimePicker_check_out_date.Value.Month.ToString() + "-" + dateTimePicker_check_out_date.Value.Year.ToString();
                    SqlParameter check_out_date = new SqlParameter("@check_out_date", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(check_out_date).Value = check_out_date_custom;

                    string check_in_date_custom = dateTimePicker_check_in_date.Value.Day.ToString() + "-" + dateTimePicker_check_in_date.Value.Month.ToString() + "-" + dateTimePicker_check_in_date.Value.Year.ToString();

                    SqlParameter check_in_date = new SqlParameter("@check_in_date", SqlDbType.VarChar);
                    sp_insert_check_in.Parameters.Add(check_in_date).Value = check_in_date_custom;
                    SqlParameter GST_amount = new SqlParameter("@GST_amount", SqlDbType.Int);
                    sp_insert_check_in.Parameters.Add(GST_amount).Value = lbl_gst.Value;
                    SqlParameter extra_bed_amount = new SqlParameter("@extra_bed_amount", SqlDbType.Int);
                    sp_insert_check_in.Parameters.Add(extra_bed_amount).Value = lbl_extra_bed.Value;

                    int i = sp_insert_check_in.ExecuteNonQuery();

                    connect.Close();

                    if (i > 0)
                    {

                        MessageBox.Show("Check IN Updated Successfully");

                        if (MessageBox.Show("Do You Want Print Check In Receipt", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            print();
                            comboBox_room_no.DataSource = null;
                            roomNo();
                            clearField();
                        }
                        else
                        {
                            comboBox_room_no.DataSource = null;
                            roomNo();
                            clearField();
                        }

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



        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearField();

        }
        public void clearField()
        {
            comboBox_room_no.Text = "";
            txtbox_name.Clear();
            txtbox_mobile_no.Clear();
            txtbox_purpose.Clear();
            comboBox_gents.Text = "0";
            comboBox_ladies.Text = "0";
            comboBox_children.Text = "0";
            txtbox_advance.Clear();
            txtbox_balance.Clear();
            txtbox_rent.Clear();
            txtbox_proof_no.Clear();
            richTextBox_address.Clear();
            checkBox_extra_bed.Checked = false;
            checkBox_gst.Checked = false;
            checkBox_extra_bed_new.Checked = false;
            checkBox_gst_new.Checked = false;

            
        }
        

        private void checkBox_extra_bed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_extra_bed.Checked == false)
            {
                checkBox_extra_bed.Visible = false;
                checkBox_extra_bed_new.Visible = true;
                int extra_bed_amount = Convert.ToInt32(lbl_extra_bed.Value);
                int balance = Convert.ToInt32(txtbox_balance.Text.Trim());
                int total = balance - extra_bed_amount;
                txtbox_balance.Text = total.ToString();
                lbl_extra_bed.Value = 0;

            }

        }

        private void checkBox_gst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_gst.Checked == false)
            {
                checkBox_gst.Visible = false;
                checkBox_gst_new.Visible = true;
                int gst = Convert.ToInt32(lbl_gst.Value);
                int rent = Convert.ToInt32(txtbox_rent.Text.Trim());
                int total = rent - gst;
                txtbox_rent.Text = total.ToString();
                lbl_gst.Value = 0;
            }
        }

        private void txtbox_advance_TextChanged_1(object sender, EventArgs e)
        {
            txtbox_balance.Clear();
            try
            {
                int rent = Convert.ToInt32(txtbox_rent.Text.Trim());
                int advance = Convert.ToInt32(txtbox_advance.Text);
                int old_balance = Convert.ToInt32(lbl_balance.Text);
                int total = rent - advance;
                txtbox_balance.Text = total.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show($"Please Enter Valid Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_room_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_room_no.Text != "")
            {
                data();
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

            string check_out_date_custom = dateTimePicker_check_out_date.Value.Day.ToString() + "-" + dateTimePicker_check_out_date.Value.Month.ToString() + "-" + dateTimePicker_check_out_date.Value.Year.ToString();

            Pen blackPen = new Pen(Color.Black, 3);

            string textToPrint = "Room Check IN Receipt";
            string textToPrint1 = "Address:";
            string textToPrint2 = "Prasanna Bhavan Residency,";
            string textToPrint3 = "Near Sengurichi Tollgate,";
            string textToPrint4 = "Ulundurpet, Tamil Nadu 606107";
            string textToPrint6 = $"Date:{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
            Font Font_for_invoice = new Font("Tahoma", 22, FontStyle.Bold);
            Font Font_for_heading = new Font("Tahoma", 16, FontStyle.Underline);
            Font Font_for_tblheading = new Font("Tahoma", 15, FontStyle.Bold);
            Font Font_for_other = new Font("Arial", 15);
            e.Graphics.DrawString(textToPrint, Font_for_invoice, Brushes.Black, 240, 80);
            e.Graphics.DrawString(textToPrint1, Font_for_other, Brushes.Black, 15, 200);
            e.Graphics.DrawString(textToPrint2, Font_for_other, Brushes.Black, 15, 230);
            e.Graphics.DrawString(textToPrint3, Font_for_other, Brushes.Black, 15, 258);
            e.Graphics.DrawString(textToPrint4, Font_for_other, Brushes.Black, 15, 288);
            e.Graphics.DrawString(textToPrint6, Font_for_other, Brushes.Black, 650, 238);
            e.Graphics.DrawLine(Pens.Black, 10, 328, 800, 328);

            e.Graphics.DrawString("Customer Details", Font_for_heading, Brushes.Black, 320, 350);
            e.Graphics.DrawString("Name :"+txtbox_name.Text.Trim(), Font_for_other, Brushes.Black, 20, 388);
            e.Graphics.DrawString("Mobile Number :"+txtbox_mobile_no.Text.Trim(), Font_for_other, Brushes.Black, 20, 428);
            e.Graphics.DrawString("Proof :"+comboBoxproof.Text, Font_for_other, Brushes.Black, 520, 388);
            e.Graphics.DrawString("Proof Number :"+txtbox_proof_no.Text.Trim(), Font_for_other, Brushes.Black, 520, 428);
            e.Graphics.DrawString("Address :"+richTextBox_address.Text.Trim(), Font_for_other, Brushes.Black, 20, 468);

            e.Graphics.DrawRectangle(blackPen, 10, 538, 800, 220);

            e.Graphics.DrawString("Room Number", Font_for_tblheading, Brushes.Black, 20, 553);
            e.Graphics.DrawString("Check In Date", Font_for_tblheading, Brushes.Black, 220, 553);
            e.Graphics.DrawString("Check In Time", Font_for_tblheading, Brushes.Black, 440, 553);
            e.Graphics.DrawString("Check Out Date", Font_for_tblheading, Brushes.Black, 640, 553);

            e.Graphics.DrawString(comboBox_room_no.Text, Font_for_other, Brushes.Black, 30, 583);
            e.Graphics.DrawString(check_in_date_custom, Font_for_other, Brushes.Black, 230, 583);
            e.Graphics.DrawString(dateTimePicker_time_in.Text, Font_for_other, Brushes.Black, 450, 583);
            e.Graphics.DrawString(check_out_date_custom, Font_for_other, Brushes.Black, 650, 583);

            e.Graphics.DrawString("Advance Amount Paid", Font_for_tblheading, Brushes.Black, 450, 633);
            e.Graphics.DrawString("₹"+txtbox_advance.Text.Trim(), Font_for_other, Brushes.Black, 700, 633);
            e.Graphics.DrawString("GST 12%", Font_for_tblheading, Brushes.Black, 450, 668);
            if (checkBox_gst.Checked)
            {
                e.Graphics.DrawString("₹" + lbl_gst.Text, Font_for_other, Brushes.Black, 700, 668);
            }
            else if (checkBox_gst_new.Checked)
            {
                e.Graphics.DrawString("₹" + lbl_gst.Text, Font_for_other, Brushes.Black, 700, 668);
            }
            else
            {
                e.Graphics.DrawString("₹", Font_for_other, Brushes.Black, 700, 668);
            }
            e.Graphics.DrawString("Balance Amount", Font_for_tblheading, Brushes.Black, 450, 708);
            e.Graphics.DrawString("₹"+txtbox_balance.Text.Trim(), Font_for_other, Brushes.Black, 700, 708);

            e.Graphics.DrawString("Signature", Font_for_other, Brushes.Black, 680, 978);

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

        private void dateTimePicker_check_out_date_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_check_in_date.Value != null && dateTimePicker_check_out_date.Value != null)
            {
                int date = (dateTimePicker_check_out_date.Value.Date - dateTimePicker_check_in_date.Value.Date).Days;
                if (date > 0)
                {

                    lbl_days.Text = date.ToString();
                    txtbox_rent.Clear();
                    txtbox_advance.Clear();
                    txtbox_balance.Clear();
                    int rent = Convert.ToInt32(lbl_rent.Text);
                    int total = rent * Convert.ToInt32(lbl_days.Text);
                    txtbox_rent.Text = total.ToString();
                    if(txtbox_rent.Text.Trim() == "0")
                    {
                        int rent1 = Fetchrent();
                        int total1 = rent1 * Convert.ToInt32(lbl_days.Text);
                        txtbox_rent.Text = total1.ToString();

                    }
                }
                else if (date == 0)
                {
                    lbl_days.Text = "1";
                    txtbox_rent.Clear();
                    txtbox_advance.Clear();
                    txtbox_balance.Clear();
                    int rent = Convert.ToInt32(lbl_rent.Text);
                    int total = rent * Convert.ToInt32(lbl_days.Text);
                    txtbox_rent.Text = total.ToString();
                    if (txtbox_rent.Text.Trim() == "0")
                    {
                        int rent1 = Fetchrent();
                        int total1 = rent1 * Convert.ToInt32(lbl_days.Text);
                        txtbox_rent.Text = total1.ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Please Select Valid Check Out/Check In Date");
                }
            }

        }

        private void checkBox_gst_new_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox_gst_new.Checked)
                {
                    int room_rent = Convert.ToInt32(txtbox_rent.Text.Trim());
                    int date = Convert.ToInt32(lbl_days.Text);
                    double GST_Amount = (room_rent * 12 / 100) * date;
                    lbl_gst.Text = GST_Amount.ToString();
                    double rent = Convert.ToDouble(txtbox_rent.Text.Trim());
                    txtbox_rent.Text = Convert.ToDecimal(rent + GST_Amount).ToString();

                }
                else
                {
                    int date = Convert.ToInt32(lbl_days.Text);
                    double GST_Amount = Convert.ToDouble(lbl_gst.Text);
                    double rent = Convert.ToDouble(txtbox_rent.Text.Trim());
                    txtbox_rent.Text = Convert.ToDecimal(rent - GST_Amount).ToString();
                    lbl_gst.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_extra_bed_new_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_extra_bed_new.Checked)
                {
                    //double balance = Convert.ToDouble(txtbox_balance.Text);
                    double balance = Convert.ToDouble(txtbox_balance.Text.Trim());
                    int date = Convert.ToInt32(lbl_days.Text);
                    double total = balance + 500 * date;
                    double total_lbl = 500 * date;
                    //txtbox_balance.Text = total.ToString();
                    txtbox_balance.Text = total.ToString();
                    txtbox_balance.Text = total.ToString();
                    lbl_extra_bed.Text = total_lbl.ToString();
                }
                else
                {
                    //double balance = Convert.ToDouble(txtbox_balance.Text);
                    double balance = Convert.ToDouble(txtbox_balance.Text.Trim());
                    int date = Convert.ToInt32(lbl_days.Text);
                    double total = balance - 500 * date;
                    //txtbox_balance.Text = total.ToString();
                    txtbox_balance.Text = total.ToString();
                    lbl_extra_bed.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbox_rent_TextChanged(object sender, EventArgs e)
        {
            //txtbox_advance.Clear();
            //txtbox_balance.Clear();
        }
    }
}
