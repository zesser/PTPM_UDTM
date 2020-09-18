using DoAnCNPM;
using System;

namespace DoAnCNPM
{
    partial class FormMenu
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
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoguot = new System.Windows.Forms.Button();
            this.labelTenNV = new System.Windows.Forms.Label();
            this.labelMaNV = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnXuatHang = new System.Windows.Forms.Button();
            this.btnGiaoHang = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnGioiThieu = new System.Windows.Forms.Button();
            this.btnNhap = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChildForm
            // 
            this.panelChildForm.AllowDrop = true;
            this.panelChildForm.AutoSize = true;
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelChildForm.Location = new System.Drawing.Point(104, 98);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1005, 604);
            this.panelChildForm.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 700);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.btnBanHang);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnNhap);
            this.flowLayoutPanel1.Controls.Add(this.btnNhapHang);
            this.flowLayoutPanel1.Controls.Add(this.btnXuatHang);
            this.flowLayoutPanel1.Controls.Add(this.btnGiaoHang);
            this.flowLayoutPanel1.Controls.Add(this.btnSanPham);
            this.flowLayoutPanel1.Controls.Add(this.btnGioiThieu);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(103, 700);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 96);
            this.panel3.TabIndex = 0;
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnBanHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBanHang.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnBanHang.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBanHang.Image = global::DoAnCNPM.Properties.Resources.icons8_shopping_cart_20;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Location = new System.Drawing.Point(2, 104);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(99, 38);
            this.btnBanHang.TabIndex = 7;
            this.btnBanHang.Text = "Mua hàng";
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BackgroundImage = global::DoAnCNPM.Properties.Resources._28f44aba1e4b794a267daaa6fc35e264;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbChucVu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnLoguot);
            this.panel2.Controls.Add(this.labelTenNV);
            this.panel2.Controls.Add(this.labelMaNV);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 100);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "FURNITE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(72, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "OAK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOLID";
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.BackColor = System.Drawing.Color.Transparent;
            this.lbChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.Location = new System.Drawing.Point(871, 64);
            this.lbChucVu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(61, 19);
            this.lbChucVu.TabIndex = 7;
            this.lbChucVu.Text = "ChucVu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(746, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Chức vụ: ";
            // 
            // btnLoguot
            // 
            this.btnLoguot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoguot.BackColor = System.Drawing.Color.Wheat;
            this.btnLoguot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoguot.Location = new System.Drawing.Point(1042, 2);
            this.btnLoguot.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoguot.Name = "btnLoguot";
            this.btnLoguot.Size = new System.Drawing.Size(64, 27);
            this.btnLoguot.TabIndex = 5;
            this.btnLoguot.Text = "Exit";
            this.btnLoguot.UseVisualStyleBackColor = false;
            this.btnLoguot.Click += new System.EventHandler(this.btnLoguot_Click);
            // 
            // labelTenNV
            // 
            this.labelTenNV.AutoSize = true;
            this.labelTenNV.BackColor = System.Drawing.Color.Transparent;
            this.labelTenNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNV.Location = new System.Drawing.Point(871, 40);
            this.labelTenNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(34, 19);
            this.labelTenNV.TabIndex = 4;
            this.labelTenNV.Text = "Ten";
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.BackColor = System.Drawing.Color.Transparent;
            this.labelMaNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaNV.Location = new System.Drawing.Point(871, 18);
            this.labelMaNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(33, 19);
            this.labelMaNV.TabIndex = 3;
            this.labelMaNV.Text = "Ma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(746, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tên Nhân Viên :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(746, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mã Nhân Viên :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = global::DoAnCNPM.Properties.Resources.icons8_find_user_male_20;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(2, 146);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 36);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Thông tin KH";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnNhapHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNhapHang.Image = global::DoAnCNPM.Properties.Resources.icons8_buy_201;
            this.btnNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapHang.Location = new System.Drawing.Point(2, 226);
            this.btnNhapHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(99, 0);
            this.btnNhapHang.TabIndex = 10;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnXuatHang
            // 
            this.btnXuatHang.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnXuatHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXuatHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXuatHang.Image = global::DoAnCNPM.Properties.Resources.icons8_return_purchase_20;
            this.btnXuatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatHang.Location = new System.Drawing.Point(2, 230);
            this.btnXuatHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatHang.Name = "btnXuatHang";
            this.btnXuatHang.Size = new System.Drawing.Size(99, 36);
            this.btnXuatHang.TabIndex = 9;
            this.btnXuatHang.Text = "Xuất hàng";
            this.btnXuatHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatHang.UseVisualStyleBackColor = false;
            this.btnXuatHang.Click += new System.EventHandler(this.btnXuatHang_Click);
            // 
            // btnGiaoHang
            // 
            this.btnGiaoHang.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnGiaoHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGiaoHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGiaoHang.Image = global::DoAnCNPM.Properties.Resources.icons8_delivery_20;
            this.btnGiaoHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaoHang.Location = new System.Drawing.Point(2, 270);
            this.btnGiaoHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiaoHang.Name = "btnGiaoHang";
            this.btnGiaoHang.Size = new System.Drawing.Size(99, 36);
            this.btnGiaoHang.TabIndex = 11;
            this.btnGiaoHang.Text = "Giao hàng";
            this.btnGiaoHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGiaoHang.UseVisualStyleBackColor = false;
            this.btnGiaoHang.Click += new System.EventHandler(this.btnGiaoHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSanPham.Image = global::DoAnCNPM.Properties.Resources.icons8_shop_20;
            this.btnSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.Location = new System.Drawing.Point(2, 310);
            this.btnSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(99, 36);
            this.btnSanPham.TabIndex = 12;
            this.btnSanPham.Text = "Kho hàng";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnGioiThieu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGioiThieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGioiThieu.Image = global::DoAnCNPM.Properties.Resources.icons8_price_tag_20;
            this.btnGioiThieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGioiThieu.Location = new System.Drawing.Point(2, 350);
            this.btnGioiThieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnGioiThieu.Name = "btnGioiThieu";
            this.btnGioiThieu.Size = new System.Drawing.Size(99, 36);
            this.btnGioiThieu.TabIndex = 13;
            this.btnGioiThieu.Text = "Giới thiệu";
            this.btnGioiThieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGioiThieu.UseVisualStyleBackColor = false;
            this.btnGioiThieu.Click += new System.EventHandler(this.btnGioiThieu_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNhap.Image = global::DoAnCNPM.Properties.Resources.icons8_buy_201;
            this.btnNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhap.Location = new System.Drawing.Point(2, 186);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(99, 36);
            this.btnNhap.TabIndex = 14;
            this.btnNhap.Text = "Nhập hàng";
            this.btnNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhap.UseVisualStyleBackColor = false;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // FormMenu
            // 
            this.AcceptButton = this.btnBanHang;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 702);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelChildForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnLoguot_Click(object sender, EventArgs e)
        {
            frm_DangNhap dn = new frm_DangNhap();
            this.Close();
            dn.Show();
        }

        #endregion
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTenNV;
        private System.Windows.Forms.Label labelMaNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoguot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnXuatHang;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGiaoHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnGioiThieu;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNhap;
    }
}