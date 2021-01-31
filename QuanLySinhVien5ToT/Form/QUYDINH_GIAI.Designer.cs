namespace QuanLySinhVien5ToT
{
    partial class QUYDINH_GIAI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgv_QD = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnThemTT = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.MaQuyDinhGiai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTieuChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sua = new System.Windows.Forms.DataGridViewImageColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.pn_ThemTC = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cbTC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTC = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLuuTC = new Guna.UI2.WinForms.Guna2Button();
            this.btnX_TC = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_QD)).BeginInit();
            this.pn_ThemTC.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgv_QD
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dtgv_QD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgv_QD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_QD.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_QD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_QD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_QD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_QD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgv_QD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_QD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaQuyDinhGiai,
            this.TenTieuChuan,
            this.Sua,
            this.Xoa});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_QD.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgv_QD.EnableHeadersVisualStyles = false;
            this.dtgv_QD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_QD.Location = new System.Drawing.Point(37, 121);
            this.dtgv_QD.Name = "dtgv_QD";
            this.dtgv_QD.RowHeadersVisible = false;
            this.dtgv_QD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_QD.Size = new System.Drawing.Size(970, 497);
            this.dtgv_QD.TabIndex = 0;
            this.dtgv_QD.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dtgv_QD.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_QD.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgv_QD.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgv_QD.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgv_QD.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgv_QD.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_QD.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_QD.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgv_QD.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_QD.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgv_QD.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgv_QD.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_QD.ThemeStyle.HeaderStyle.Height = 21;
            this.dtgv_QD.ThemeStyle.ReadOnly = false;
            this.dtgv_QD.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgv_QD.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgv_QD.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtgv_QD.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_QD.ThemeStyle.RowsStyle.Height = 22;
            this.dtgv_QD.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgv_QD.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgv_QD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_QD_CellContentClick);
            // 
            // btnThemTT
            // 
            this.btnThemTT.BackColor = System.Drawing.Color.Transparent;
            this.btnThemTT.BorderRadius = 20;
            this.btnThemTT.CheckedState.Parent = this.btnThemTT;
            this.btnThemTT.CustomImages.Parent = this.btnThemTT;
            this.btnThemTT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTT.ForeColor = System.Drawing.Color.White;
            this.btnThemTT.HoverState.Parent = this.btnThemTT;
            this.btnThemTT.Image = global::QuanLySinhVien5ToT.Properties.Resources.icons8_plus_96;
            this.btnThemTT.Location = new System.Drawing.Point(833, 37);
            this.btnThemTT.Name = "btnThemTT";
            this.btnThemTT.ShadowDecoration.Parent = this.btnThemTT;
            this.btnThemTT.Size = new System.Drawing.Size(174, 45);
            this.btnThemTT.TabIndex = 29;
            this.btnThemTT.Text = "Thêm Quy Định";
            this.btnThemTT.Click += new System.EventHandler(this.btnThemTT_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiem.BorderRadius = 10;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.Parent = this.txtTimKiem;
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.FocusedState.Parent = this.txtTimKiem;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.HoverState.Parent = this.txtTimKiem;
            this.txtTimKiem.Location = new System.Drawing.Point(37, 37);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "Tìm Kiếm";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.ShadowDecoration.Parent = this.txtTimKiem;
            this.txtTimKiem.Size = new System.Drawing.Size(790, 44);
            this.txtTimKiem.TabIndex = 30;
            // 
            // MaQuyDinhGiai
            // 
            this.MaQuyDinhGiai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaQuyDinhGiai.HeaderText = "Mã Quy Định";
            this.MaQuyDinhGiai.Name = "MaQuyDinhGiai";
            this.MaQuyDinhGiai.Width = 115;
            // 
            // TenTieuChuan
            // 
            this.TenTieuChuan.HeaderText = "Tên Tiêu Chuẩn";
            this.TenTieuChuan.Name = "TenTieuChuan";
            // 
            // Sua
            // 
            this.Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sua.HeaderText = "";
            this.Sua.Name = "Sua";
            this.Sua.Width = 20;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Xoa.HeaderText = "";
            this.Xoa.Name = "Xoa";
            this.Xoa.Width = 20;
            // 
            // pn_ThemTC
            // 
            this.pn_ThemTC.Controls.Add(this.btnX_TC);
            this.pn_ThemTC.Controls.Add(this.btnLuuTC);
            this.pn_ThemTC.Controls.Add(this.label2);
            this.pn_ThemTC.Controls.Add(this.cbTC);
            this.pn_ThemTC.Controls.Add(this.txtTC);
            this.pn_ThemTC.Location = new System.Drawing.Point(37, 20);
            this.pn_ThemTC.Name = "pn_ThemTC";
            this.pn_ThemTC.ShadowDecoration.Parent = this.pn_ThemTC;
            this.pn_ThemTC.Size = new System.Drawing.Size(790, 95);
            this.pn_ThemTC.TabIndex = 32;
            this.pn_ThemTC.Visible = false;
            // 
            // cbTC
            // 
            this.cbTC.BackColor = System.Drawing.Color.Transparent;
            this.cbTC.BorderRadius = 20;
            this.cbTC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTC.FocusedState.Parent = this.cbTC;
            this.cbTC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTC.HoverState.Parent = this.cbTC;
            this.cbTC.ItemHeight = 30;
            this.cbTC.ItemsAppearance.Parent = this.cbTC;
            this.cbTC.Location = new System.Drawing.Point(118, 13);
            this.cbTC.Name = "cbTC";
            this.cbTC.ShadowDecoration.Parent = this.cbTC;
            this.cbTC.Size = new System.Drawing.Size(610, 36);
            this.cbTC.TabIndex = 20;
            // 
            // txtTC
            // 
            this.txtTC.BackColor = System.Drawing.Color.Transparent;
            this.txtTC.BorderRadius = 20;
            this.txtTC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTC.DefaultText = "";
            this.txtTC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTC.DisabledState.Parent = this.txtTC;
            this.txtTC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTC.FocusedState.Parent = this.txtTC;
            this.txtTC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTC.HoverState.Parent = this.txtTC;
            this.txtTC.Location = new System.Drawing.Point(118, 15);
            this.txtTC.Name = "txtTC";
            this.txtTC.PasswordChar = '\0';
            this.txtTC.PlaceholderText = "";
            this.txtTC.SelectedText = "";
            this.txtTC.ShadowDecoration.Parent = this.txtTC;
            this.txtTC.Size = new System.Drawing.Size(610, 34);
            this.txtTC.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tên Tiêu Chuẩn :";
            // 
            // btnLuuTC
            // 
            this.btnLuuTC.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuTC.BorderRadius = 20;
            this.btnLuuTC.CheckedState.Parent = this.btnLuuTC;
            this.btnLuuTC.CustomImages.Parent = this.btnLuuTC;
            this.btnLuuTC.FillColor = System.Drawing.Color.LimeGreen;
            this.btnLuuTC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTC.ForeColor = System.Drawing.Color.White;
            this.btnLuuTC.HoverState.Parent = this.btnLuuTC;
            this.btnLuuTC.Location = new System.Drawing.Point(717, 55);
            this.btnLuuTC.Name = "btnLuuTC";
            this.btnLuuTC.ShadowDecoration.Parent = this.btnLuuTC;
            this.btnLuuTC.Size = new System.Drawing.Size(60, 35);
            this.btnLuuTC.TabIndex = 25;
            this.btnLuuTC.Text = "Lưu";
            this.btnLuuTC.Visible = false;
            this.btnLuuTC.Click += new System.EventHandler(this.btnLuuTC_Click);
            // 
            // btnX_TC
            // 
            this.btnX_TC.BackColor = System.Drawing.Color.White;
            this.btnX_TC.Checked = true;
            this.btnX_TC.CheckedState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnX_TC.CheckedState.Parent = this.btnX_TC;
            this.btnX_TC.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnX_TC.HoverState.Parent = this.btnX_TC;
            this.btnX_TC.Image = global::QuanLySinhVien5ToT.Properties.Resources.icons8_macos_close_96;
            this.btnX_TC.ImageRotate = 0F;
            this.btnX_TC.ImageSize = new System.Drawing.Size(25, 25);
            this.btnX_TC.Location = new System.Drawing.Point(747, 9);
            this.btnX_TC.Name = "btnX_TC";
            this.btnX_TC.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnX_TC.PressedState.Parent = this.btnX_TC;
            this.btnX_TC.Size = new System.Drawing.Size(30, 31);
            this.btnX_TC.TabIndex = 30;
            this.btnX_TC.Click += new System.EventHandler(this.btnX_TC_Click);
            // 
            // QUYDINH_GIAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_ThemTC);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnThemTT);
            this.Controls.Add(this.dtgv_QD);
            this.Name = "QUYDINH_GIAI";
            this.Size = new System.Drawing.Size(1044, 661);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_QD)).EndInit();
            this.pn_ThemTC.ResumeLayout(false);
            this.pn_ThemTC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgv_QD;
        private Guna.UI2.WinForms.Guna2Button btnThemTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuyDinhGiai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTieuChuan;
        private System.Windows.Forms.DataGridViewImageColumn Sua;
        private System.Windows.Forms.DataGridViewImageColumn Xoa;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pn_ThemTC;
        private Guna.UI2.WinForms.Guna2ComboBox cbTC;
        private Guna.UI2.WinForms.Guna2TextBox txtTC;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLuuTC;
        private Guna.UI2.WinForms.Guna2ImageButton btnX_TC;
    }
}
