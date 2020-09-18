namespace DoAnCNPM
{
    partial class frm_SanPham
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SanPham));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtLoai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.txtTenSP = new DevExpress.XtraEditors.TextEdit();
            this.txtBaoHanh = new DevExpress.XtraEditors.TextEdit();
            this.txtMoTa = new DevExpress.XtraEditors.TextEdit();
            this.txtMaSP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gcTimKiemSP = new DevExpress.XtraGrid.GridControl();
            this.gvTimKiemSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MASP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MALOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOTA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ANHSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BAOHANH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTimKiemSP = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThoatSP = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuaSP = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuuSP = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaoHanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTimKiemSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimKiemSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupControl1.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl1.Controls.Add(this.txtLoai);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.txtPhong);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtDonGia);
            this.groupControl1.Controls.Add(this.txtTenSP);
            this.groupControl1.Controls.Add(this.txtBaoHanh);
            this.groupControl1.Controls.Add(this.txtMoTa);
            this.groupControl1.Controls.Add(this.txtMaSP);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 340);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(676, 140);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Thông Tin";
            // 
            // txtLoai
            // 
            this.txtLoai.Location = new System.Drawing.Point(416, 83);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Properties.ReadOnly = true;
            this.txtLoai.Size = new System.Drawing.Size(180, 20);
            this.txtLoai.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(329, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 13);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Mã Loại";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(108, 83);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Properties.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(180, 20);
            this.txtPhong.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 112);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Mô tả";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(416, 28);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(180, 20);
            this.txtDonGia.TabIndex = 10;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(108, 57);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Properties.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(180, 20);
            this.txtTenSP.TabIndex = 9;
            this.txtTenSP.EditValueChanged += new System.EventHandler(this.txtTenSP_EditValueChanged);
            // 
            // txtBaoHanh
            // 
            this.txtBaoHanh.Location = new System.Drawing.Point(416, 53);
            this.txtBaoHanh.Name = "txtBaoHanh";
            this.txtBaoHanh.Properties.ReadOnly = true;
            this.txtBaoHanh.Size = new System.Drawing.Size(180, 20);
            this.txtBaoHanh.TabIndex = 8;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(108, 109);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Properties.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(180, 20);
            this.txtMoTa.TabIndex = 7;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(108, 31);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Properties.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(180, 20);
            this.txtMaSP.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(329, 31);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 13);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Đơn Giá";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(329, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Bảo Hành";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Tên Sản Phẩm";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Mã Phòng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mã Sản Phẩm";
            // 
            // gcTimKiemSP
            // 
            this.gcTimKiemSP.Location = new System.Drawing.Point(12, 98);
            this.gcTimKiemSP.MainView = this.gvTimKiemSP;
            this.gcTimKiemSP.Name = "gcTimKiemSP";
            this.gcTimKiemSP.Size = new System.Drawing.Size(676, 226);
            this.gcTimKiemSP.TabIndex = 7;
            this.gcTimKiemSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTimKiemSP});
            this.gcTimKiemSP.Click += new System.EventHandler(this.gcTimKiemSP_Click);
            // 
            // gvTimKiemSP
            // 
            this.gvTimKiemSP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MASP,
            this.TENSP,
            this.MAPH,
            this.MALOAI,
            this.MOTA,
            this.ANHSP,
            this.BAOHANH,
            this.GIA});
            this.gvTimKiemSP.GridControl = this.gcTimKiemSP;
            this.gvTimKiemSP.Name = "gvTimKiemSP";
            this.gvTimKiemSP.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvTimKiemSP_FocusedRowChanged);
            // 
            // MASP
            // 
            this.MASP.Caption = "Mã Sản Phẩm";
            this.MASP.FieldName = "MASP";
            this.MASP.MinWidth = 19;
            this.MASP.Name = "MASP";
            this.MASP.Visible = true;
            this.MASP.VisibleIndex = 0;
            // 
            // TENSP
            // 
            this.TENSP.Caption = "Tên Sản Phẩm";
            this.TENSP.FieldName = "TENSP";
            this.TENSP.MinWidth = 19;
            this.TENSP.Name = "TENSP";
            this.TENSP.Visible = true;
            this.TENSP.VisibleIndex = 1;
            // 
            // MAPH
            // 
            this.MAPH.Caption = "Mã Phòng";
            this.MAPH.FieldName = "MAPH";
            this.MAPH.MinWidth = 19;
            this.MAPH.Name = "MAPH";
            this.MAPH.Visible = true;
            this.MAPH.VisibleIndex = 2;
            // 
            // MALOAI
            // 
            this.MALOAI.Caption = "Mã Loại";
            this.MALOAI.FieldName = "MALOAI";
            this.MALOAI.MinWidth = 19;
            this.MALOAI.Name = "MALOAI";
            this.MALOAI.Visible = true;
            this.MALOAI.VisibleIndex = 3;
            // 
            // MOTA
            // 
            this.MOTA.Caption = "Mô Tả";
            this.MOTA.FieldName = "MOTA";
            this.MOTA.MinWidth = 19;
            this.MOTA.Name = "MOTA";
            this.MOTA.Visible = true;
            this.MOTA.VisibleIndex = 4;
            // 
            // ANHSP
            // 
            this.ANHSP.Caption = "Ảnh Sản Phẩm";
            this.ANHSP.FieldName = "ANHSP";
            this.ANHSP.MinWidth = 19;
            this.ANHSP.Name = "ANHSP";
            this.ANHSP.Visible = true;
            this.ANHSP.VisibleIndex = 5;
            // 
            // BAOHANH
            // 
            this.BAOHANH.Caption = "Bảo Hành";
            this.BAOHANH.FieldName = "BAOHANH";
            this.BAOHANH.MinWidth = 19;
            this.BAOHANH.Name = "BAOHANH";
            this.BAOHANH.Visible = true;
            this.BAOHANH.VisibleIndex = 6;
            // 
            // GIA
            // 
            this.GIA.Caption = "Giá";
            this.GIA.FieldName = "GIA";
            this.GIA.MinWidth = 19;
            this.GIA.Name = "GIA";
            this.GIA.Visible = true;
            this.GIA.VisibleIndex = 7;
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.Location = new System.Drawing.Point(12, 59);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemSP.TabIndex = 6;
            this.btnTimKiemSP.Text = "Tìm Kiếm";
            this.btnTimKiemSP.Click += new System.EventHandler(this.btnTimKiemSP_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(102, 61);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(586, 20);
            this.searchControl1.TabIndex = 5;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoatSP});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoatSP, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThoatSP
            // 
            this.btnThoatSP.Caption = "Thoát";
            this.btnThoatSP.Id = 0;
            this.btnThoatSP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoatSP.ImageOptions.SvgImage")));
            this.btnThoatSP.Name = "btnThoatSP";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(711, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 576);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(711, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 552);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(711, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 552);
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupControl5.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl5.Controls.Add(this.btnThem);
            this.groupControl5.Controls.Add(this.btnSuaSP);
            this.groupControl5.Controls.Add(this.btnLuuSP);
            this.groupControl5.Location = new System.Drawing.Point(12, 486);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(676, 74);
            this.groupControl5.TabIndex = 13;
            this.groupControl5.Text = "Chức Năng";
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(5, 26);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 40);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaSP.ImageOptions.Image")));
            this.btnSuaSP.Location = new System.Drawing.Point(86, 26);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(75, 40);
            this.btnSuaSP.TabIndex = 2;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnLuuSP
            // 
            this.btnLuuSP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuSP.ImageOptions.Image")));
            this.btnLuuSP.Location = new System.Drawing.Point(167, 26);
            this.btnLuuSP.Name = "btnLuuSP";
            this.btnLuuSP.Size = new System.Drawing.Size(75, 40);
            this.btnLuuSP.TabIndex = 0;
            this.btnLuuSP.Text = "Lưu";
            this.btnLuuSP.Click += new System.EventHandler(this.btnLuuSP_Click);
            // 
            // frm_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(711, 576);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcTimKiemSP);
            this.Controls.Add(this.btnTimKiemSP);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_SanPham";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.frm_TimKiemSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaoHanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTimKiemSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimKiemSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDonGia;
        private DevExpress.XtraEditors.TextEdit txtTenSP;
        private DevExpress.XtraEditors.TextEdit txtBaoHanh;
        private DevExpress.XtraEditors.TextEdit txtMoTa;
        private DevExpress.XtraEditors.TextEdit txtMaSP;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gcTimKiemSP;
        private DevExpress.XtraEditors.SimpleButton btnTimKiemSP;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThoatSP;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton btnSuaSP;
        private DevExpress.XtraEditors.SimpleButton btnLuuSP;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.TextEdit txtLoai;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPhong;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTimKiemSP;
        private DevExpress.XtraGrid.Columns.GridColumn MASP;
        private DevExpress.XtraGrid.Columns.GridColumn TENSP;
        private DevExpress.XtraGrid.Columns.GridColumn MAPH;
        private DevExpress.XtraGrid.Columns.GridColumn MALOAI;
        private DevExpress.XtraGrid.Columns.GridColumn MOTA;
        private DevExpress.XtraGrid.Columns.GridColumn ANHSP;
        private DevExpress.XtraGrid.Columns.GridColumn BAOHANH;
        private DevExpress.XtraGrid.Columns.GridColumn GIA;
    }
}