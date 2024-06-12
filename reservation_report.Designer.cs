namespace Prasanna_Bhavan_Residency
{
    partial class reservation_report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reservation_report));
            this.btn_logout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_maximize = new System.Windows.Forms.PictureBox();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_user_id = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_CalculateTotalSales = new System.Windows.Forms.Button();
            this.txtbox_date = new System.Windows.Forms.DateTimePicker();
            this.txtbox_room_no = new System.Windows.Forms.TextBox();
            this.txtbox_customer_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_text = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_total_sales = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButton_SearchByCustomerName = new System.Windows.Forms.RadioButton();
            this.radioButton_SearchByRoomNumber = new System.Windows.Forms.RadioButton();
            this.radioButtonSearchByCustomerMobileNo = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_checkOut = new System.Windows.Forms.DateTimePicker();
            this.txtbox_mobile_no = new System.Windows.Forms.TextBox();
            this.radioButton_date = new System.Windows.Forms.RadioButton();
            this.radioButton_check_in = new System.Windows.Forms.RadioButton();
            this.radioButton_chceck_out = new System.Windows.Forms.RadioButton();
            this.radioButton_from_to_date = new System.Windows.Forms.RadioButton();
            this.lbl_to = new System.Windows.Forms.Label();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.btn_save_pdf = new System.Windows.Forms.Button();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_old_record = new System.Windows.Forms.RadioButton();
            this.radioButton_new_record = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_logout.Location = new System.Drawing.Point(0, 0);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(98, 38);
            this.btn_logout.TabIndex = 94;
            this.btn_logout.Text = "Back";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            this.btn_logout.MouseLeave += new System.EventHandler(this.btn_logout_MouseLeave);
            this.btn_logout.MouseHover += new System.EventHandler(this.btn_logout_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_maximize);
            this.panel1.Controls.Add(this.btn_minimize);
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1192, 38);
            this.panel1.TabIndex = 152;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Image = global::Prasanna_Bhavan_Residency.Properties.Resources.close2;
            this.btn_close.Location = new System.Drawing.Point(1150, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(28, 28);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_close.TabIndex = 134;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SpringGreen;
            this.label2.Location = new System.Drawing.Point(501, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 29);
            this.label2.TabIndex = 156;
            this.label2.Text = "Reservation Report";
            // 
            // btn_maximize
            // 
            this.btn_maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_maximize.BackColor = System.Drawing.Color.Transparent;
            this.btn_maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_maximize.Image = global::Prasanna_Bhavan_Residency.Properties.Resources.maximize1;
            this.btn_maximize.Location = new System.Drawing.Point(1113, 5);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(28, 28);
            this.btn_maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_maximize.TabIndex = 135;
            this.btn_maximize.TabStop = false;
            this.btn_maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Image = global::Prasanna_Bhavan_Residency.Properties.Resources.minimize1;
            this.btn_minimize.Location = new System.Drawing.Point(1075, 5);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(28, 28);
            this.btn_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_minimize.TabIndex = 136;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Aquamarine;
            this.label13.Location = new System.Drawing.Point(476, 278);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 31);
            this.label13.TabIndex = 167;
            this.label13.Text = "List";
            // 
            // lbl_user_id
            // 
            this.lbl_user_id.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_user_id.AutoSize = true;
            this.lbl_user_id.Location = new System.Drawing.Point(1126, 56);
            this.lbl_user_id.Name = "lbl_user_id";
            this.lbl_user_id.Size = new System.Drawing.Size(35, 13);
            this.lbl_user_id.TabIndex = 174;
            this.lbl_user_id.Text = "label2";
            this.lbl_user_id.Visible = false;
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_search.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_search.Location = new System.Drawing.Point(651, 208);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(206, 35);
            this.btn_search.TabIndex = 173;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_CalculateTotalSales
            // 
            this.btn_CalculateTotalSales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CalculateTotalSales.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_CalculateTotalSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CalculateTotalSales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CalculateTotalSales.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CalculateTotalSales.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_CalculateTotalSales.Location = new System.Drawing.Point(897, 208);
            this.btn_CalculateTotalSales.Name = "btn_CalculateTotalSales";
            this.btn_CalculateTotalSales.Size = new System.Drawing.Size(206, 35);
            this.btn_CalculateTotalSales.TabIndex = 172;
            this.btn_CalculateTotalSales.Text = "Calculate Total ";
            this.btn_CalculateTotalSales.UseVisualStyleBackColor = false;
            this.btn_CalculateTotalSales.Click += new System.EventHandler(this.btn_CalculateTotalSales_Click_1);
            // 
            // txtbox_date
            // 
            this.txtbox_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbox_date.CustomFormat = "dd/MM/yyyy";
            this.txtbox_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtbox_date.Location = new System.Drawing.Point(815, 110);
            this.txtbox_date.Name = "txtbox_date";
            this.txtbox_date.Size = new System.Drawing.Size(288, 31);
            this.txtbox_date.TabIndex = 171;
            this.txtbox_date.Visible = false;
            // 
            // txtbox_room_no
            // 
            this.txtbox_room_no.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbox_room_no.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbox_room_no.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtbox_room_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_room_no.Location = new System.Drawing.Point(815, 110);
            this.txtbox_room_no.Name = "txtbox_room_no";
            this.txtbox_room_no.Size = new System.Drawing.Size(288, 31);
            this.txtbox_room_no.TabIndex = 169;
            this.txtbox_room_no.Visible = false;
            // 
            // txtbox_customer_name
            // 
            this.txtbox_customer_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbox_customer_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbox_customer_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtbox_customer_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_customer_name.Location = new System.Drawing.Point(815, 110);
            this.txtbox_customer_name.Name = "txtbox_customer_name";
            this.txtbox_customer_name.Size = new System.Drawing.Size(288, 31);
            this.txtbox_customer_name.TabIndex = 170;
            this.txtbox_customer_name.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label8.Location = new System.Drawing.Point(821, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 18);
            this.label8.TabIndex = 165;
            // 
            // lbl_text
            // 
            this.lbl_text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_text.AutoSize = true;
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_text.Location = new System.Drawing.Point(647, 115);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(136, 22);
            this.lbl_text.TabIndex = 166;
            this.lbl_text.Text = "Room Number";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Aquamarine;
            this.label9.Location = new System.Drawing.Point(1011, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 29);
            this.label9.TabIndex = 163;
            this.label9.Text = "₹";
            // 
            // lbl_total_sales
            // 
            this.lbl_total_sales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_total_sales.AutoSize = true;
            this.lbl_total_sales.BackColor = System.Drawing.Color.Transparent;
            this.lbl_total_sales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_sales.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_total_sales.Location = new System.Drawing.Point(1048, 478);
            this.lbl_total_sales.Name = "lbl_total_sales";
            this.lbl_total_sales.Size = new System.Drawing.Size(25, 25);
            this.lbl_total_sales.TabIndex = 160;
            this.lbl_total_sales.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(996, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 29);
            this.label4.TabIndex = 157;
            this.label4.Text = "Total Income";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(49, 322);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(936, 371);
            this.dataGridView1.TabIndex = 180;
            // 
            // radioButton_SearchByCustomerName
            // 
            this.radioButton_SearchByCustomerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton_SearchByCustomerName.AutoSize = true;
            this.radioButton_SearchByCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SearchByCustomerName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_SearchByCustomerName.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.radioButton_SearchByCustomerName.Location = new System.Drawing.Point(169, 173);
            this.radioButton_SearchByCustomerName.Name = "radioButton_SearchByCustomerName";
            this.radioButton_SearchByCustomerName.Size = new System.Drawing.Size(281, 27);
            this.radioButton_SearchByCustomerName.TabIndex = 178;
            this.radioButton_SearchByCustomerName.Text = "Search By Customer Name";
            this.radioButton_SearchByCustomerName.UseVisualStyleBackColor = false;
            this.radioButton_SearchByCustomerName.CheckedChanged += new System.EventHandler(this.radioButton_SearchByCustomerName_CheckedChanged);
            // 
            // radioButton_SearchByRoomNumber
            // 
            this.radioButton_SearchByRoomNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton_SearchByRoomNumber.AutoSize = true;
            this.radioButton_SearchByRoomNumber.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_SearchByRoomNumber.Checked = true;
            this.radioButton_SearchByRoomNumber.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_SearchByRoomNumber.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.radioButton_SearchByRoomNumber.Location = new System.Drawing.Point(169, 82);
            this.radioButton_SearchByRoomNumber.Name = "radioButton_SearchByRoomNumber";
            this.radioButton_SearchByRoomNumber.Size = new System.Drawing.Size(266, 27);
            this.radioButton_SearchByRoomNumber.TabIndex = 179;
            this.radioButton_SearchByRoomNumber.TabStop = true;
            this.radioButton_SearchByRoomNumber.Text = "Search By Room Number";
            this.radioButton_SearchByRoomNumber.UseVisualStyleBackColor = false;
            this.radioButton_SearchByRoomNumber.CheckedChanged += new System.EventHandler(this.radioButton_SearchByRoomNumber_CheckedChanged);
            // 
            // radioButtonSearchByCustomerMobileNo
            // 
            this.radioButtonSearchByCustomerMobileNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonSearchByCustomerMobileNo.AutoSize = true;
            this.radioButtonSearchByCustomerMobileNo.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSearchByCustomerMobileNo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSearchByCustomerMobileNo.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.radioButtonSearchByCustomerMobileNo.Location = new System.Drawing.Point(169, 213);
            this.radioButtonSearchByCustomerMobileNo.Name = "radioButtonSearchByCustomerMobileNo";
            this.radioButtonSearchByCustomerMobileNo.Size = new System.Drawing.Size(329, 27);
            this.radioButtonSearchByCustomerMobileNo.TabIndex = 181;
            this.radioButtonSearchByCustomerMobileNo.Text = "Search By Customer Mobile No.";
            this.radioButtonSearchByCustomerMobileNo.UseVisualStyleBackColor = false;
            this.radioButtonSearchByCustomerMobileNo.CheckedChanged += new System.EventHandler(this.radioButtonSearchByCustomerMobileNo_CheckedChanged);
            // 
            // dateTimePicker_checkOut
            // 
            this.dateTimePicker_checkOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_checkOut.CustomFormat = "";
            this.dateTimePicker_checkOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_checkOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_checkOut.Location = new System.Drawing.Point(815, 110);
            this.dateTimePicker_checkOut.Name = "dateTimePicker_checkOut";
            this.dateTimePicker_checkOut.Size = new System.Drawing.Size(288, 31);
            this.dateTimePicker_checkOut.TabIndex = 182;
            this.dateTimePicker_checkOut.Value = new System.DateTime(2024, 2, 19, 0, 0, 0, 0);
            this.dateTimePicker_checkOut.Visible = false;
            // 
            // txtbox_mobile_no
            // 
            this.txtbox_mobile_no.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbox_mobile_no.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtbox_mobile_no.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtbox_mobile_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_mobile_no.Location = new System.Drawing.Point(815, 110);
            this.txtbox_mobile_no.Name = "txtbox_mobile_no";
            this.txtbox_mobile_no.Size = new System.Drawing.Size(288, 31);
            this.txtbox_mobile_no.TabIndex = 169;
            this.txtbox_mobile_no.Visible = false;
            // 
            // radioButton_date
            // 
            this.radioButton_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton_date.AutoSize = true;
            this.radioButton_date.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_date.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_date.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.radioButton_date.Location = new System.Drawing.Point(169, 128);
            this.radioButton_date.Name = "radioButton_date";
            this.radioButton_date.Size = new System.Drawing.Size(172, 27);
            this.radioButton_date.TabIndex = 176;
            this.radioButton_date.Text = "Search By Date\r\n";
            this.radioButton_date.UseVisualStyleBackColor = false;
            this.radioButton_date.CheckedChanged += new System.EventHandler(this.radioButton_date_CheckedChanged);
            // 
            // radioButton_check_in
            // 
            this.radioButton_check_in.AutoSize = true;
            this.radioButton_check_in.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_check_in.Checked = true;
            this.radioButton_check_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_check_in.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioButton_check_in.Location = new System.Drawing.Point(23, 11);
            this.radioButton_check_in.Name = "radioButton_check_in";
            this.radioButton_check_in.Size = new System.Drawing.Size(131, 25);
            this.radioButton_check_in.TabIndex = 183;
            this.radioButton_check_in.TabStop = true;
            this.radioButton_check_in.Text = "Check in Date";
            this.radioButton_check_in.UseCompatibleTextRendering = true;
            this.radioButton_check_in.UseVisualStyleBackColor = false;
            this.radioButton_check_in.Visible = false;
            this.radioButton_check_in.CheckedChanged += new System.EventHandler(this.radioButton_check_in_CheckedChanged);
            // 
            // radioButton_chceck_out
            // 
            this.radioButton_chceck_out.AutoSize = true;
            this.radioButton_chceck_out.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_chceck_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_chceck_out.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioButton_chceck_out.Location = new System.Drawing.Point(175, 11);
            this.radioButton_chceck_out.Name = "radioButton_chceck_out";
            this.radioButton_chceck_out.Size = new System.Drawing.Size(152, 24);
            this.radioButton_chceck_out.TabIndex = 183;
            this.radioButton_chceck_out.Text = "Check out Date";
            this.radioButton_chceck_out.UseVisualStyleBackColor = false;
            this.radioButton_chceck_out.Visible = false;
            this.radioButton_chceck_out.CheckedChanged += new System.EventHandler(this.radioButton_chceck_out_CheckedChanged);
            // 
            // radioButton_from_to_date
            // 
            this.radioButton_from_to_date.AutoSize = true;
            this.radioButton_from_to_date.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_from_to_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_from_to_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioButton_from_to_date.Location = new System.Drawing.Point(341, 11);
            this.radioButton_from_to_date.Name = "radioButton_from_to_date";
            this.radioButton_from_to_date.Size = new System.Drawing.Size(147, 24);
            this.radioButton_from_to_date.TabIndex = 183;
            this.radioButton_from_to_date.Text = "From / To Date";
            this.radioButton_from_to_date.UseVisualStyleBackColor = false;
            this.radioButton_from_to_date.Visible = false;
            this.radioButton_from_to_date.CheckedChanged += new System.EventHandler(this.radioButton_from_to_date_CheckedChanged);
            // 
            // lbl_to
            // 
            this.lbl_to.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_to.AutoSize = true;
            this.lbl_to.BackColor = System.Drawing.Color.Transparent;
            this.lbl_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_to.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_to.Location = new System.Drawing.Point(681, 168);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(82, 22);
            this.lbl_to.TabIndex = 184;
            this.lbl_to.Text = "To Date";
            this.lbl_to.Visible = false;
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_to.CustomFormat = "";
            this.dateTimePicker_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_to.Location = new System.Drawing.Point(815, 159);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(288, 31);
            this.dateTimePicker_to.TabIndex = 185;
            this.dateTimePicker_to.Value = new System.DateTime(2024, 2, 20, 23, 35, 0, 0);
            this.dateTimePicker_to.Visible = false;
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker_from.CustomFormat = "";
            this.dateTimePicker_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_from.Location = new System.Drawing.Point(815, 110);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(288, 31);
            this.dateTimePicker_from.TabIndex = 186;
            this.dateTimePicker_from.Value = new System.DateTime(2024, 2, 20, 23, 35, 0, 0);
            this.dateTimePicker_from.Visible = false;
            // 
            // btn_save_pdf
            // 
            this.btn_save_pdf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save_pdf.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_save_pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save_pdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save_pdf.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_pdf.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_save_pdf.Location = new System.Drawing.Point(779, 262);
            this.btn_save_pdf.Name = "btn_save_pdf";
            this.btn_save_pdf.Size = new System.Drawing.Size(206, 35);
            this.btn_save_pdf.TabIndex = 187;
            this.btn_save_pdf.Text = "Export To Excel";
            this.btn_save_pdf.UseVisualStyleBackColor = false;
            this.btn_save_pdf.Click += new System.EventHandler(this.btn_save_pdf_Click);
            // 
            // lbl_loading
            // 
            this.lbl_loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.BackColor = System.Drawing.Color.Transparent;
            this.lbl_loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loading.ForeColor = System.Drawing.Color.Red;
            this.lbl_loading.Location = new System.Drawing.Point(493, 357);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(246, 39);
            this.lbl_loading.TabIndex = 199;
            this.lbl_loading.Text = "Please Wait...";
            this.lbl_loading.Visible = false;
            this.lbl_loading.Click += new System.EventHandler(this.lbl_loading_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radioButton_from_to_date);
            this.panel2.Controls.Add(this.radioButton_check_in);
            this.panel2.Controls.Add(this.radioButton_chceck_out);
            this.panel2.Location = new System.Drawing.Point(610, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 48);
            this.panel2.TabIndex = 200;
            // 
            // radioButton_old_record
            // 
            this.radioButton_old_record.AutoSize = true;
            this.radioButton_old_record.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_old_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_old_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioButton_old_record.Location = new System.Drawing.Point(15, 43);
            this.radioButton_old_record.Name = "radioButton_old_record";
            this.radioButton_old_record.Size = new System.Drawing.Size(126, 24);
            this.radioButton_old_record.TabIndex = 183;
            this.radioButton_old_record.Text = "Old Records";
            this.radioButton_old_record.UseVisualStyleBackColor = false;
            // 
            // radioButton_new_record
            // 
            this.radioButton_new_record.AutoSize = true;
            this.radioButton_new_record.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_new_record.Checked = true;
            this.radioButton_new_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_new_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.radioButton_new_record.Location = new System.Drawing.Point(15, 12);
            this.radioButton_new_record.Name = "radioButton_new_record";
            this.radioButton_new_record.Size = new System.Drawing.Size(126, 25);
            this.radioButton_new_record.TabIndex = 183;
            this.radioButton_new_record.TabStop = true;
            this.radioButton_new_record.Text = "New Records";
            this.radioButton_new_record.UseCompatibleTextRendering = true;
            this.radioButton_new_record.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.radioButton_old_record);
            this.panel3.Controls.Add(this.radioButton_new_record);
            this.panel3.Location = new System.Drawing.Point(486, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 85);
            this.panel3.TabIndex = 202;
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Location = new System.Drawing.Point(1165, 115);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(13, 13);
            this.lbl_mail.TabIndex = 203;
            this.lbl_mail.Text = "0";
            this.lbl_mail.Visible = false;
            // 
            // reservation_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Prasanna_Bhavan_Residency.Properties.Resources.bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1192, 715);
            this.Controls.Add(this.lbl_mail);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_loading);
            this.Controls.Add(this.btn_save_pdf);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.lbl_to);
            this.Controls.Add(this.radioButtonSearchByCustomerMobileNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbl_user_id);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_CalculateTotalSales);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_total_sales);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.radioButton_SearchByCustomerName);
            this.Controls.Add(this.radioButton_date);
            this.Controls.Add(this.radioButton_SearchByRoomNumber);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dateTimePicker_from);
            this.Controls.Add(this.dateTimePicker_checkOut);
            this.Controls.Add(this.txtbox_date);
            this.Controls.Add(this.txtbox_mobile_no);
            this.Controls.Add(this.txtbox_room_no);
            this.Controls.Add(this.txtbox_customer_name);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reservation_report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Report";
            this.Load += new System.EventHandler(this.sales_admin_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_maximize;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_user_id;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_CalculateTotalSales;
        private System.Windows.Forms.DateTimePicker txtbox_date;
        private System.Windows.Forms.TextBox txtbox_room_no;
        private System.Windows.Forms.TextBox txtbox_customer_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_total_sales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButton_SearchByCustomerName;
        private System.Windows.Forms.RadioButton radioButton_SearchByRoomNumber;
        private System.Windows.Forms.RadioButton radioButtonSearchByCustomerMobileNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_checkOut;
        private System.Windows.Forms.TextBox txtbox_mobile_no;
        private System.Windows.Forms.RadioButton radioButton_date;
        private System.Windows.Forms.RadioButton radioButton_check_in;
        private System.Windows.Forms.RadioButton radioButton_chceck_out;
        private System.Windows.Forms.RadioButton radioButton_from_to_date;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.Button btn_save_pdf;
        private System.Windows.Forms.Label lbl_loading;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_old_record;
        private System.Windows.Forms.RadioButton radioButton_new_record;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_mail;
    }
}