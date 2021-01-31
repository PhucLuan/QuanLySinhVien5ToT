namespace QuanLySinhVien5ToT
{
    partial class Edit_TGX
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgvTG = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaThoiGianXet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sua = new System.Windows.Forms.DataGridViewImageColumn();
            this.Apply = new System.Windows.Forms.DataGridViewImageColumn();
            this.pn_ThemXoaSua = new Guna.UI2.WinForms.Guna2Panel();
            this.lbDen = new System.Windows.Forms.Label();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnLuuTime = new Guna.UI2.WinForms.Guna2Button();
            this.lbTu = new System.Windows.Forms.Label();
            this.cbTime = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpkTu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpkDen = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXEdit_TG = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnXTime = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnThemTG = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTG)).BeginInit();
            this.pn_ThemXoaSua.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvTG
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgvTG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvTG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTG.BackgroundColor = System.Drawing.Color.White;
            this.dtgvTG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvTG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvTG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvTG.ColumnHeadersHeight = 21;
            this.dtgvTG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaThoiGianXet,
            this.TuNgay,
            this.DenNgay,
            this.Sua,
            this.Apply});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvTG.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvTG.EnableHeadersVisualStyles = false;
            this.dtgvTG.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvTG.Location = new System.Drawing.Point(18, 82);
            this.dtgvTG.Name = "dtgvTG";
            this.dtgvTG.RowHeadersVisible = false;
            this.dtgvTG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTG.Size = new System.Drawing.Size(746, 361);
            this.dtgvTG.TabIndex = 0;
            this.dtgvTG.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dtgvTG.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvTG.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgvTG.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgvTG.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgvTG.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgvTG.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgvTG.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvTG.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgvTG.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvTG.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgvTG.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvTG.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgvTG.ThemeStyle.HeaderStyle.Height = 21;
            this.dtgvTG.ThemeStyle.ReadOnly = false;
            this.dtgvTG.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvTG.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvTG.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgvTG.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvTG.ThemeStyle.RowsStyle.Height = 22;
            this.dtgvTG.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvTG.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvTG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTG_CellContentClick);
            // 
            // MaThoiGianXet
            // 
            this.MaThoiGianXet.HeaderText = "Mã Thời Gian Xét";
            this.MaThoiGianXet.Name = "MaThoiGianXet";
            // 
            // TuNgay
            // 
            this.TuNgay.HeaderText = "Từ ";
            this.TuNgay.Name = "TuNgay";
            // 
            // DenNgay
            // 
            this.DenNgay.HeaderText = "Đến";
            this.DenNgay.Name = "DenNgay";
            // 
            // Sua
            // 
            this.Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sua.HeaderText = "";
            this.Sua.Name = "Sua";
            this.Sua.Width = 20;
            // 
            // Apply
            // 
            this.Apply.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Apply.HeaderText = "";
            this.Apply.Name = "Apply";
            this.Apply.Width = 20;
            // 
            // pn_ThemXoaSua
            // 
            this.pn_ThemXoaSua.BorderRadius = 20;
            this.pn_ThemXoaSua.Controls.Add(this.btnXTime);
            this.pn_ThemXoaSua.Controls.Add(this.lbDen);
            this.pn_ThemXoaSua.Controls.Add(this.lbTieuDe);
            this.pn_ThemXoaSua.Controls.Add(this.guna2Separator1);
            this.pn_ThemXoaSua.Controls.Add(this.btnLuuTime);
            this.pn_ThemXoaSua.Controls.Add(this.lbTu);
            this.pn_ThemXoaSua.Controls.Add(this.cbTime);
            this.pn_ThemXoaSua.Controls.Add(this.dtpkTu);
            this.pn_ThemXoaSua.Controls.Add(this.dtpkDen);
            this.pn_ThemXoaSua.FillColor = System.Drawing.Color.White;
            this.pn_ThemXoaSua.Location = new System.Drawing.Point(473, 82);
            this.pn_ThemXoaSua.Name = "pn_ThemXoaSua";
            this.pn_ThemXoaSua.ShadowDecoration.Parent = this.pn_ThemXoaSua;
            this.pn_ThemXoaSua.Size = new System.Drawing.Size(291, 238);
            this.pn_ThemXoaSua.TabIndex = 46;
            this.pn_ThemXoaSua.Visible = false;
            // 
            // lbDen
            // 
            this.lbDen.AutoSize = true;
            this.lbDen.BackColor = System.Drawing.Color.Transparent;
            this.lbDen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbDen.ForeColor = System.Drawing.Color.Gray;
            this.lbDen.Location = new System.Drawing.Point(21, 156);
            this.lbDen.Name = "lbDen";
            this.lbDen.Size = new System.Drawing.Size(36, 15);
            this.lbDen.TabIndex = 16;
            this.lbDen.Text = "Đến :";
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbTieuDe.ForeColor = System.Drawing.Color.Gray;
            this.lbTieuDe.Location = new System.Drawing.Point(15, 11);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(159, 21);
            this.lbTieuDe.TabIndex = 17;
            this.lbTieuDe.Text = "Thêm Thời Gian Xét";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.White;
            this.guna2Separator1.Location = new System.Drawing.Point(18, 44);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(245, 10);
            this.guna2Separator1.TabIndex = 18;
            // 
            // btnLuuTime
            // 
            this.btnLuuTime.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuTime.BorderRadius = 20;
            this.btnLuuTime.CheckedState.Parent = this.btnLuuTime;
            this.btnLuuTime.CustomImages.Parent = this.btnLuuTime;
            this.btnLuuTime.FillColor = System.Drawing.Color.LimeGreen;
            this.btnLuuTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTime.ForeColor = System.Drawing.Color.White;
            this.btnLuuTime.HoverState.Parent = this.btnLuuTime;
            this.btnLuuTime.Location = new System.Drawing.Point(223, 188);
            this.btnLuuTime.Name = "btnLuuTime";
            this.btnLuuTime.ShadowDecoration.Parent = this.btnLuuTime;
            this.btnLuuTime.Size = new System.Drawing.Size(60, 35);
            this.btnLuuTime.TabIndex = 10;
            this.btnLuuTime.Text = "Lưu";
            this.btnLuuTime.Visible = false;
            this.btnLuuTime.Click += new System.EventHandler(this.btnLuuTime_Click);
            // 
            // lbTu
            // 
            this.lbTu.AutoSize = true;
            this.lbTu.BackColor = System.Drawing.Color.Transparent;
            this.lbTu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbTu.ForeColor = System.Drawing.Color.Gray;
            this.lbTu.Location = new System.Drawing.Point(21, 117);
            this.lbTu.Name = "lbTu";
            this.lbTu.Size = new System.Drawing.Size(28, 15);
            this.lbTu.TabIndex = 15;
            this.lbTu.Text = "Từ :";
            // 
            // cbTime
            // 
            this.cbTime.BackColor = System.Drawing.Color.Transparent;
            this.cbTime.BorderRadius = 20;
            this.cbTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTime.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTime.FocusedState.Parent = this.cbTime;
            this.cbTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTime.HoverState.Parent = this.cbTime;
            this.cbTime.ItemHeight = 30;
            this.cbTime.ItemsAppearance.Parent = this.cbTime;
            this.cbTime.Location = new System.Drawing.Point(6, 56);
            this.cbTime.Name = "cbTime";
            this.cbTime.ShadowDecoration.Parent = this.cbTime;
            this.cbTime.Size = new System.Drawing.Size(280, 36);
            this.cbTime.TabIndex = 19;
            // 
            // dtpkTu
            // 
            this.dtpkTu.CheckedState.Parent = this.dtpkTu;
            this.dtpkTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpkTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkTu.HoverState.Parent = this.dtpkTu;
            this.dtpkTu.Location = new System.Drawing.Point(86, 103);
            this.dtpkTu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpkTu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpkTu.Name = "dtpkTu";
            this.dtpkTu.ShadowDecoration.Parent = this.dtpkTu;
            this.dtpkTu.Size = new System.Drawing.Size(200, 36);
            this.dtpkTu.TabIndex = 0;
            this.dtpkTu.Value = new System.DateTime(2020, 12, 29, 10, 0, 14, 942);
            // 
            // dtpkDen
            // 
            this.dtpkDen.CheckedState.Parent = this.dtpkDen;
            this.dtpkDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpkDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkDen.HoverState.Parent = this.dtpkDen;
            this.dtpkDen.Location = new System.Drawing.Point(86, 144);
            this.dtpkDen.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpkDen.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpkDen.Name = "dtpkDen";
            this.dtpkDen.ShadowDecoration.Parent = this.dtpkDen;
            this.dtpkDen.Size = new System.Drawing.Size(200, 36);
            this.dtpkDen.TabIndex = 1;
            this.dtpkDen.Value = new System.DateTime(2020, 12, 29, 10, 0, 14, 942);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.guna2TextBox1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(18, 15);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(504, 61);
            this.guna2Panel1.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Thời Gian Xét Hiện Tại :";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2TextBox1.BorderRadius = 20;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Location = new System.Drawing.Point(156, 10);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Size = new System.Drawing.Size(335, 36);
            this.guna2TextBox1.TabIndex = 49;
            // 
            // btnXEdit_TG
            // 
            this.btnXEdit_TG.BackColor = System.Drawing.Color.Transparent;
            this.btnXEdit_TG.Checked = true;
            this.btnXEdit_TG.CheckedState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnXEdit_TG.CheckedState.Parent = this.btnXEdit_TG;
            this.btnXEdit_TG.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnXEdit_TG.HoverState.Parent = this.btnXEdit_TG;
            this.btnXEdit_TG.Image = global::QuanLySinhVien5ToT.Properties.Resources.icons8_macos_close_96;
            this.btnXEdit_TG.ImageRotate = 0F;
            this.btnXEdit_TG.ImageSize = new System.Drawing.Size(25, 25);
            this.btnXEdit_TG.Location = new System.Drawing.Point(754, 3);
            this.btnXEdit_TG.Name = "btnXEdit_TG";
            this.btnXEdit_TG.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXEdit_TG.PressedState.Parent = this.btnXEdit_TG;
            this.btnXEdit_TG.Size = new System.Drawing.Size(30, 31);
            this.btnXEdit_TG.TabIndex = 47;
            this.btnXEdit_TG.Click += new System.EventHandler(this.btnXEdit_TG_Click);
            // 
            // btnXTime
            // 
            this.btnXTime.BackColor = System.Drawing.Color.White;
            this.btnXTime.Checked = true;
            this.btnXTime.CheckedState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnXTime.CheckedState.Parent = this.btnXTime;
            this.btnXTime.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnXTime.HoverState.Parent = this.btnXTime;
            this.btnXTime.Image = global::QuanLySinhVien5ToT.Properties.Resources.icons8_macos_close_96;
            this.btnXTime.ImageRotate = 0F;
            this.btnXTime.ImageSize = new System.Drawing.Size(25, 25);
            this.btnXTime.Location = new System.Drawing.Point(243, 7);
            this.btnXTime.Name = "btnXTime";
            this.btnXTime.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnXTime.PressedState.Parent = this.btnXTime;
            this.btnXTime.Size = new System.Drawing.Size(30, 31);
            this.btnXTime.TabIndex = 15;
            this.btnXTime.Click += new System.EventHandler(this.btnXTime_Click);
            // 
            // btnThemTG
            // 
            this.btnThemTG.BackColor = System.Drawing.Color.Transparent;
            this.btnThemTG.BorderRadius = 20;
            this.btnThemTG.CheckedState.Parent = this.btnThemTG;
            this.btnThemTG.CustomImages.Parent = this.btnThemTG;
            this.btnThemTG.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTG.ForeColor = System.Drawing.Color.White;
            this.btnThemTG.HoverState.Parent = this.btnThemTG;
            this.btnThemTG.Image = global::QuanLySinhVien5ToT.Properties.Resources.icons8_plus_96;
            this.btnThemTG.Location = new System.Drawing.Point(559, 25);
            this.btnThemTG.Name = "btnThemTG";
            this.btnThemTG.ShadowDecoration.Parent = this.btnThemTG;
            this.btnThemTG.Size = new System.Drawing.Size(157, 45);
            this.btnThemTG.TabIndex = 45;
            this.btnThemTG.Text = "Thêm Thời Gian Xét";
            this.btnThemTG.Click += new System.EventHandler(this.btnThemTG_Click);
            // 
            // Edit_TGX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnXEdit_TG);
            this.Controls.Add(this.pn_ThemXoaSua);
            this.Controls.Add(this.btnThemTG);
            this.Controls.Add(this.dtgvTG);
            this.Name = "Edit_TGX";
            this.Size = new System.Drawing.Size(787, 475);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTG)).EndInit();
            this.pn_ThemXoaSua.ResumeLayout(false);
            this.pn_ThemXoaSua.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgvTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThoiGianXet;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenNgay;
        private System.Windows.Forms.DataGridViewImageColumn Sua;
        private System.Windows.Forms.DataGridViewImageColumn Apply;
        private Guna.UI2.WinForms.Guna2Button btnThemTG;
        private Guna.UI2.WinForms.Guna2Panel pn_ThemXoaSua;
        private Guna.UI2.WinForms.Guna2ImageButton btnXTime;
        private System.Windows.Forms.Label lbDen;
        private System.Windows.Forms.Label lbTieuDe;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnLuuTime;
        private System.Windows.Forms.Label lbTu;
        private Guna.UI2.WinForms.Guna2ComboBox cbTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkTu;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkDen;
        private Guna.UI2.WinForms.Guna2ImageButton btnXEdit_TG;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label1;
    }
}
