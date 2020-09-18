CREATE DATABASE QL_CUAHANGNOITHAT
USE QL_CUAHANGNOITHAT
GO

CREATE TABLE CHUCNANG
(
	MACHUCNANG CHAR(10) PRIMARY KEY,
	TENCHUCNANG NVARCHAR(50)
)

INSERT INTO CHUCNANG VALUES('CN0001', N'Tạo Tài Khoản Nhân Viên')
INSERT INTO CHUCNANG VALUES('CN0002', N'Lập Hóa Đơn')
INSERT INTO CHUCNANG VALUES('CN0003', N'Nhập Kho')
INSERT INTO CHUCNANG VALUES('CN0004', N'Xuất Kho')
INSERT INTO CHUCNANG VALUES('CN0005', N'Kiểm Kho')
INSERT INTO CHUCNANG VALUES('CN0006', N'Thống Kê')
INSERT INTO CHUCNANG VALUES('CN0007', N'Lập Phiếu Giao Hàng')
INSERT INTO CHUCNANG VALUES('CN0008', N'Tạo Thẻ Khách Hàng')
INSERT INTO CHUCNANG VALUES('CN0009', N'Tra Cứu Thông Tin Khách Hàng')
INSERT INTO CHUCNANG VALUES('CN0010', N'Lập Phiếu Đổi Trả')
INSERT INTO CHUCNANG VALUES('CN0011', N'Lấy Thông Tin Khách Hàng')
INSERT INTO CHUCNANG VALUES('CN0012', N'Lấy Thông Tin Hóa Đơn')
INSERT INTO CHUCNANG VALUES('CN0013', N'Vận Chuyển')


CREATE TABLE PHANQUYEN
(
	MAPHANQUYEN CHAR(10) PRIMARY KEY,
	TENPHANQUYEN NVARCHAR(50),
	CHUTHICH NVARCHAR(100)

)

INSERT INTO PHANQUYEN VALUES ('PQ0001', N'Nhân Viên Quản Lí', NULL)
INSERT INTO PHANQUYEN VALUES ('PQ0002', N'Nhân Viên Bán Hàng', NULL)
INSERT INTO PHANQUYEN VALUES ('PQ0003', N'Nhân Viên Thu Ngân', NULL)
INSERT INTO PHANQUYEN VALUES ('PQ0004', N'Nhân Viên Kho', NULL)
INSERT INTO PHANQUYEN VALUES ('PQ0005', N'Nhân Viên Vận Chuyển', NULL)

CREATE TABLE CTPHANQUYEN
(
	MAPHANQUYEN CHAR(10),
	MACHUCNANG CHAR(10),

	CONSTRAINT PK_MAPQ_MACN PRIMARY KEY (MAPHANQUYEN,MACHUCNANG),
	CONSTRAINT FK_MAPQ_PHANQUYEN FOREIGN KEY (MAPHANQUYEN) REFERENCES PHANQUYEN(MAPHANQUYEN),
	CONSTRAINT FK_MACN_CHUCNANG FOREIGN KEY (MACHUCNANG) REFERENCES CHUCNANG(MACHUCNANG)
)

INSERT INTO CTPHANQUYEN VALUES('PQ0001','CN0001'),('PQ0001','CN0005'),('PQ0001','CN0006')
INSERT INTO CTPHANQUYEN VALUES('PQ0002','CN0011'),('PQ0002','CN0012')
INSERT INTO CTPHANQUYEN VALUES('PQ0003','CN0002'),('PQ0003','CN0008'),('PQ0003','CN0010'),('PQ0003','CN0007')
INSERT INTO CTPHANQUYEN VALUES('PQ0004','CN0004'),('PQ0004','CN0005'),('PQ0004','CN0006')
INSERT INTO CTPHANQUYEN VALUES('PQ0005','CN0013')

CREATE TABLE NHANVIEN
(
	MANV CHAR(10) PRIMARY KEY,
	TENDN NVARCHAR(50) ,
	MATKHAU NVARCHAR(100),
	TENNV NVARCHAR(100),
	DIACHI NVARCHAR(100),
	DIENTHOAI INT,
	MAPHANQUYEN CHAR(10),
	CHUTHICH NVARCHAR(100),
	constraint FK_NV_QUYEN foreign key (MAPHANQUYEN) references PHANQUYEN(MAPHANQUYEN),
)

INSERT INTO NHANVIEN VALUES ('NV0001','CVB','CVB01',N'Cao Văn Bình',N'TP HCM', 0385462851, 'PQ0001', NULL)
INSERT INTO NHANVIEN VALUES ('NV0002','TQK','TQK09',N'Trần Quốc Khuyến',N'Bến Tre', 0376894172, 'PQ0001', NULL)
INSERT INTO NHANVIEN VALUES ('NV0003','NLD','NLD03',N'Nguyễn Lê Duy',N'Tiền Giang', 0375138428, 'PQ0001', NULL)
INSERT INTO NHANVIEN VALUES ('NV0004','TMD','TMD07',N'Trương Minh Đức',N'Vĩnh Long', 0375374325, 'PQ0002', NULL)
INSERT INTO NHANVIEN VALUES ('NV0005','MTH','MTH06',N'Mai Thanh Hà',N'Long An', 0376265198, 'PQ0002', NULL)
INSERT INTO NHANVIEN VALUES ('NV0006','TTT','TTT91',N'Trần Tiến Thịnh',N'Lạng Sơn', 0378963132, 'PQ0002', NULL)
INSERT INTO NHANVIEN VALUES ('NV0007','VDT','VDT81',N'Vũ Đức Thành',N'Thanh Hóa', 0365812063, 'PQ0003', NULL)
INSERT INTO NHANVIEN VALUES ('NV0008','TBA','TBA71',N'Trần Bửu Ái',N'Bắc Giang', 0370417429, 'PQ0003', NULL)
INSERT INTO NHANVIEN VALUES ('NV0009','NVS','NVS11',N'Nguyễn Văn Song',N'Phú Yên', 0378512963, 'PQ0003', NULL)
INSERT INTO NHANVIEN VALUES ('NV0010','NVD','NVD15',N'Nguyễn Văn Dũng',N'Cần Thơ', 0375318735, 'PQ0004', NULL)
INSERT INTO NHANVIEN VALUES ('NV0011','NCM','NCM18',N'Nguyễn Chí Minh',N'Tây Ninh', 0379842963, 'PQ0004', NULL)
INSERT INTO NHANVIEN VALUES ('NV0012','TVT','TVT16',N'Trương Việt Toàn',N'Đồng Tháp', 0378511372, 'PQ0004', NULL)
INSERT INTO NHANVIEN VALUES ('NV0013','NTHN','NTHN54',N'Nguyễn Thị Hồng Ngọc',N'Hưng Yên', 0379412754, 'PQ0005', NULL)
INSERT INTO NHANVIEN VALUES ('NV0014','MTH','MTH87',N'Mai Tôn Hà',N'Hà Giang', 0370635612, 'PQ0005', NULL)
INSERT INTO NHANVIEN VALUES ('NV0015','HTT','HTT56',N'Hồ Thanh Trung',N'Lâm Đòng', 0378539518, 'PQ0005', NULL)

SELECT * FROM NHANVIEN

CREATE TABLE KHACHHANG
(
	MAKHACHHANG CHAR(10) PRIMARY KEY,
	TENDN NVARCHAR(50),
	MATKHAU NVARCHAR(100),
	TENKHACHHANG NVARCHAR(100),
	DIACHI NVARCHAR(MAX),
	DIENTHOAI char(10),
	EMAIL NVARCHAR(50) NULL,
)
-- thiếu tendn mk
INSERT INTO KHACHHANG VALUES ('KH0001','NVLinh','NVL45',N'Nguyễn Văn Linh', N'Bến Tre', '0379876545', 'LVN@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0002','NVNam1','NVN85',N'Nguyễn Vĩnh Nam', N'TP HCM', '0377325685', 'NVN@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0003','VTNNgan','VTNN40',N'Vũ Thị Ngọc Ngân', N'Tây Ninh', '0378956140', 'NNVT@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0004','LCThanh','LCT97',N'La Chí Thành', N'Vũng Tàu', '0379376197', 'TCL@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0005','HTHGiang','HTHG51',N'Hoàng Thị Hà Giang', N'Phú Yên', '0379769451', 'GHTH@gmail.com')
INSERT INTO KHACHHANg VALUES ('KH0006','TTThao','TTT35',N'Trương Thị Thảo', N'Tiền Giang', '0977666335', 'TTT@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0007','MVTan1','MVT86',N'Mai Văn Tân', N'TP HCM', '0988965886', 'TVM@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0008','NTHoa02','NTH54',N'Ngô Thị Hoa', N'Khánh Hòa', '0918176354', 'HTN@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0009','LTKQuynh','LTKQ81',N'Lê Thị Khánh Quỳnh', N'Nghệ An', '0903880081', 'QKTL@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0010','NTBinh','NTB69',N'Nguyễn Thái Bình', N'Thái Bình', '0909232169', 'BTN@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0011','NDTri','NDT04',N'Nguyễn Đức Trí', N'Long An', '093845404', 'TDN@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0012','TVToan','TVT28',N'Trương Việt Toàn', N'Bình Phước', '0909232745', 'TVT@gmail.com')
INSERT INTO KHACHHANG VALUES ('KH0013','DKKha1','DKK34',N'Đỗ Kim Kha', N'Trà Vinh', '0995310734', 'KKD@gmail.com')

--DBCC CHECKIDENT ('dbo.KHACHHANG', RESEED, 0) --- RESET LẠI MÃ KHÁCH HÀNG VỀ 0 ---
SELECT * FROM KHACHHANG

/*CREATE TABLE THEKHACHHANG
(
	MATHEKH CHAR(10) PRIMARY KEY,
	MAKHACHHANG CHAR(10),
	NGAYLAPTHE DATE,

	CONSTRAINT FK_MAKH_TKH FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG)
)

INSERT INTO THEKHACHHANG VALUES('MTKH0001','KH0001','10/10/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0002','KH0002','11/10/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0003','KH0003','12/10/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0004','KH0004','10/10/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0005','KH0005','09/09/2018')
INSERT INTO THEKHACHHANG VALUES('MTKH0006','KH0006','15/05/2017')
INSERT INTO THEKHACHHANG VALUES('MTKH0007','KH0007','10/07/2018')
INSERT INTO THEKHACHHANG VALUES('MTKH0008','KH0008','25/01/2018')
INSERT INTO THEKHACHHANG VALUES('MTKH0009','KH0009','21/08/2017')
INSERT INTO THEKHACHHANG VALUES('MTKH0010','KH0010','10/07/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0011','KH0011','18/11/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0012','KH0012','13/03/2019')
INSERT INTO THEKHACHHANG VALUES('MTKH0013','KH0013','14/04/2019')*/



CREATE TABLE DANHMUCHANG
(
	MADM CHAR(10) PRIMARY KEY,
	TENDM NVARCHAR(50)
)

-----
INSERT INTO DANHMUCHANG VALUES('DM0001', N'Nội Thất Gỗ')
INSERT INTO DANHMUCHANG VALUES('DM0002', N'Gỗ Trang Trí')
-----

CREATE TABLE LOAIHANG
(
	MALOAI CHAR(10) PRIMARY KEY,
	TENLOAI NVARCHAR(100),
	MADM CHAR(10),
	CONSTRAINT FK_MADM_LOAIHANG FOREIGN KEY (MADM) REFERENCES DANHMUCHANG(MADM)
)
-----
INSERT INTO LOAIHANG VALUES ('ML0001',N'Tủ','DM0001')
INSERT INTO LOAIHANG VALUES ('ML0002',N'Bàn','DM0001')
INSERT INTO LOAIHANG VALUES ('ML0003',N'Ghế','DM0001')
INSERT INTO LOAIHANG VALUES ('ML0004',N'Giường','DM0001')
INSERT INTO LOAIHANG VALUES ('ML0005',N'Kệ','DM0002')
INSERT INTO LOAIHANG VALUES ('ML0006',N'Tủ Trang Trí','DM0002')
------

CREATE TABLE PHONG
(
	MAPH CHAR(10) NOT NULL PRIMARY KEY,
	TENPHONG NVARCHAR(50)
)

------
INSERT INTO PHONG VALUES ('MP0001',N'Phòng Khách')
INSERT INTO PHONG VALUES ('MP0002',N'Phòng Ngủ')
INSERT INTO PHONG VALUES ('MP0003',N'Phòng Bếp')
INSERT INTO PHONG VALUES ('MP0005',N'Phòng Làm Việc')
------

CREATE TABLE NHACUNGCAP
(
	MANCC CHAR(10) PRIMARY KEY,
	TENNCC NVARCHAR(100) ,
	DIACHI NVARCHAR(100),
	DIENTHOAI CHAR(10),
	CHUTHICH NVARCHAR(100),
)

INSERT INTO NHACUNGCAP(MANCC,TENNCC,DIACHI,DIENTHOAI,CHUTHICH)
VALUES('NCC001',N'Công Ty TNHH Gỗ Phương Đông',N'346/9 Bình Lợi, P. 13, Q. Bình Thạnh','0942981657',null),
('NCC002',N'Công ty TNHH Gỗ Phương Nam',N'Số 37 Tôn Đức Thắng, P. Bến Nghé, Q. 1','0932115177',null),
('NCC003',N'Công ty TNHH Gỗ SUWO',N'Số 117-119, Lý Chính Thắng, P. 7, Q. 3','0942014717',null)
select * from NHACUNGCAP
--=====================================================

CREATE TABLE KHOHANG
(
	MASP CHAR(10) PRIMARY KEY,
	MALOAI CHAR(10),
	TENSP NVARCHAR(100),	
	DONGIA MONEY,
	SOLUONG INT,
	BAOHANH NVARCHAR(30),
	MANCC CHAR(10),
	constraint FK_KHOHANG_NCC foreign key (MANCC) references NHACUNGCAP(MANCC),
	constraint FK_KHOHANG_LOAIHANG  foreign key (MALOAI) references LOAIHANG(MALOAI),
)
select * from KHOHANG
--insert into KHOHANG values ('sp001','ML0001',N'tủ',800,55,N'36 tháng','NCC001')
--INSERT INTO KHOHANG VALUES('SP001','ML0001',N'Tủ Tivi Mây','3000000','5',N'36 tháng','NCC001'),
--delete from KHOHANG
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP001','ML0001',N'Tủ Tivi Mây',3000000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP002','ML0001',N'Tủ Tivi Secret',5000000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP003','ML0001',N'Tủ Tivi Secret',5000000,5,N'36 tháng','NCC001')
--phòng khách, kệ MP0001 - ML0005
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP004','ML0005',N'Kệ trang trí Eden',2100000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP005','ML0005',N'Kệ sách Addict',3250000,5,N'36 tháng','NCC002')
--phòng khách, bàn  MP0001 - ML0002
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP006','ML0002',N'Bàn Artigo',2390000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP007','ML0002',N'Bàn console Art Marble',2590000,5,N'36 tháng','NCC002')
--phòng khách, ghế  MP0001 - ML0003
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP008','ML0003',N'Sofa góc phải Urban da Brown',15200000,5,N'36 tháng','NCC003')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP009','ML0003',N'Sofa Jazz 3 chỗ da nâu',3590000,5,N'36 tháng','NCC003')
-- phòng ngủ , giường MP0002 - ML0004
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP010','ML0004',N'Giường Shadow 1m8',3190000,5,N'36 tháng','NCC003')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP011','ML0004',N'Giường Skagen 1m6',2390000,5,N'36 tháng','NCC003')
-- phòng ngủ , bàn MP0002 - ML0002
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP012','ML0002',N'Bàn đầu giường Shadow',950000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP013','ML0002',N'Bàn đầu giường Skagen',450000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP014','ML0002',N'Bàn trang điểm và đôn Harmony',450000,5,N'36 tháng','NCC001')
-- phòng ngủ , tủ MP0002 - ML0001
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP015','ML0001',N'Tủ áo Kiwi',2850000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP016','ML0001',N'Tủ âm tường Kiwi',4850000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP017','ML0001',N'Tủ hộc kéo 3+2 Harmony',840000,5,N'36 tháng','NCC001')
---phongbep -mp0003 -ML0001',N'Tủ','DM0001'
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP018','ML0001',N'Tủ bếp Moka',4000000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP019','ML0001',N'Tủ Bếp ViVo',5000000,5,N'36 tháng','NCC002')
 ----phongbep -mp0003- ML0002',N'Bàn','DM0001'
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP020','ML0002',N'Bàn ghế ăn đẹp bằng gỗ sồi',1200000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP021','ML0002',N'Bộ bàn ăn gia đình phong cách ',1600000,5,N'36 tháng','NCC002')
 ----phongbep -mp0003-ML0005',N'Kệ','DM0002'
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP022','ML0005',N'Kệ gỗ treo thực phẩm ',1500000,5,N'36 tháng','NCC003')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP023','ML0005',N'Kệ gỗ để đồ tiện dụng ',1500000,5,N'36 tháng','NCC003')
 ----phonglamviec -mp0005 -ban-ml0002
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP024','ML0002',N'Bàn làm việc Maxine ',13900000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP025','ML0002',N'Bàn làm việc Touka ',33900000,5,N'36 tháng','NCC001')
  ----phonglamviec -mp0005 -ghe-ml0003
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP026','ML0003',N'Ghế Bridge Có tay',23900000,5,N'36 tháng','NCC001')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP027','ML0003',N'Bàn làm việc Maxine',11100000,5,N'36 tháng','NCC001')
 ----phonglamviec -mp0005 -ML0005',N'Kệ','DM0002
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES ('SP028','ML0005',N'Kệ sách Maxine',3000000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES('SP029','ML0005',N'Kệ sách Gamma',4000000,5,N'36 tháng','NCC002')
    ----phonglamviec -mp0005 -ML0006',N'Tủ Trang Trí','DM0002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES ('SP030','ML0006',N'Tủ hồ sơ bắc Âu',6000000,5,N'36 tháng','NCC002')
INSERT INTO KHOHANG(MASP,MALOAI,TENSP,DONGIA,SOLUONG,BAOHANH,MANCC)VALUES  ('SP031','ML0006',N'Tủ hồ sơ bắc Âu',5000000,5,N'36 tháng','NCC002')
-----------------------------
select * from KHOHANG
CREATE TABLE SANPHAM
(
	MASP CHAR(10) NOT NULL PRIMARY KEY,
	TENSP NVARCHAR(100),
	MAPH CHAR(10),
	MALOAI CHAR(10),
	MOTA NVARCHAR(MAX),
	ANHSP NVARCHAR(MAX),
	BAOHANH NVARCHAR(30),
	GIA MONEY,
	constraint FK_KHOHANG_SANPHAM foreign key (MASP) references KHOHANG(MASP),
	CONSTRAINT FK_MAPH_SANPHAM FOREIGN KEY (MAPH) REFERENCES PHONG(MAPH),
	CONSTRAINT FK_MALOAI_LOAIHANG FOREIGN KEY (MALOAI) REFERENCES LOAIHANG(MALOAI)
)
--INSERT INTO SANPHAM (MASP, TENSP, MAPH,MALOAI,MOTA,ANHSP,BAOHANH,GIA)VALUES
--phòng khách ,tủ MP0001 - ML0001
insert into SANPHAM values
('SP001',N'Tủ Tivi Mây','MP0001','ML0001',N'Điểm nhấn của tủ tivi Mây chính là phần kết cấu cách tủ mở ra theo một cách đặc biệt và duyên dáng. 
Ngoài ra, sự tính toán kỹ càng giúp nó giải quyết đầy đủ công năng sử dụng của một chiếc tủ trong phòng khách.
 Tủ tivi Mây sử dụng đá marble trắng cho bề mặt kết hợp với khung gỗ và nhấn nhá bằng chất liệu mây. Gỗ tần bì - Mây - Đá marble - Chân bọc inox mạ gold'
 ,N'tutivimay',N'36 tháng',3000000)

insert into SANPHAM values('SP002',N'Tủ Tivi Secret','MP0001','ML0001',N'Chân kim loại - MDF Veneer - Kính',N'tutivisecret',N'36 tháng',5000000)

insert into SANPHAM values('SP003',N'Tủ giày Chio trắng','MP0001','ML0001',N'Với thiết kế gọn gàng, sang trọng, tủ giày Chio sẽ góp phần làm cho gian ngôi nhà của bạn trở nên ngăn nắp
 và gọn gàng nhưng không thiếu phần hiện đại hơn. Gỗ xà cừ (Mahogany)- MDF veneer sơn trắng',N'tugiaychinotrang',N'36 tháng',1500000)

--phòng khách, kệ MP0001 - ML0005
insert into SANPHAM values('SP004',N'Kệ trang trí Eden','MP0001','ML0005',N'Kim loại màu gold - Kính',N'ketrangtrieden',N'36 tháng',2100000)

insert into SANPHAM values('SP005',N'Kệ sách Addict','MP0001','ML0005',N'Kim loại màu đen',N'tusachaddict',N'36 tháng',3250000)

--phòng khách, bàn  MP0001 - ML0002
insert into SANPHAM values('SP006',N'Bàn Artigo','MP0001','ML0002',N'Thương hiệu Pháp Gautier. MDF veneer, chân thép sơn tĩnh điện',N'banartigo',N'36 tháng',2390000)

insert into SANPHAM values('SP007',N'Bàn console Art Marble','MP0001','ML0002',N'Chân kim loại màu gold - mặt kính',N'banconsoleartmarble',N'36 tháng',2590000)

--phòng khách, ghế  MP0001 - ML0003
insert into SANPHAM values('SP008',N'Sofa góc phải Urban da Brown','MP0001','ML0003',N' Sofa góc Urban là sự kết hợp thanh lịch, đơn giản với một kiểu dáng đẹp, thiết kế hiện đại. Sofa Urban 
hoàn toàn phù hợp cho cả nội thất hiện đại và cổ điển. Với thiết kế tay dựa cong và thanh mảnh được kéo dài xuống mặt đất cùng đường chỉ viền đôi nổi bật với là 
thiết kế tiêu biểu và đặc trưng của dòng sản phẩm này. Đệm ngồi được thiết kế với mật độ PU và Pholyurethane (loại nhựa tổng hợp)
 đàn hồi dày đặc đa chiều đem lại cảm giác thoải mái khi ngồi. Thương hiệu Ý- Calligaris Chân kim loại chrome - Da Esprit brown tự nhiên cao cấp',
 N'sofagocphaiUrbandaBrown',N'36 tháng',15200000)

insert into SANPHAM values('SP009',N'Sofa Jazz 3 chỗ da nâu','MP0001','ML0003',N'Nếu bạn đang tìm kiếm một bộ Sofa ấn tượng cho không gian phòng khách của mình, 
đừng bỏ qua bộ Sofa Jazz này. Với thiết kế hiện đại mang nét đẹp độc đáo từ hình khối thanh lịch, đường nét tinh tế. 
Điều đặc biệt nhất ở chiếc Sofa đơn giản này chính là được bao bọc bởi lớp da bò cao cấp đem lại cảm giác mềm mại, 
êm ái, thư giãn tuyệt vời cho gia chủ. Khung gỗ bọc da tự nhiên cao cấp',N'sofaJazz3chodanau',N'36 tháng',3590000)

-- phòng ngủ , giường MP0002 - ML0004
insert into SANPHAM values('SP010',N'Giường Shadow 1m8','MP0002','ML0004',N'Giường Shadow được thiết kế bọc vải hoàn toàn với khung gỗ beech chắc chắn. Những chi tiết nhấn nhá tại đầu giường, 
gối đầu giường giúp nó trở nên lạ mắt và ấn tượng. Sử dụng chân thon gọn giúp phòng ngủ của bạn trở nên thông thoáng và thanh lịch hơn.Shadow – Vẻ đẹp yên bình giữa
 lối sống đô thị. Chân kim loại màu đồng + MDF Veneer sồi',N'giuongShadow1m8',N'36 tháng',3190000)

insert into SANPHAM values('SP011',N'Giường Skagen 1m6','MP0002','ML0004',N'Giường Skagen nổi bật cho phòng ngủ theo phong cách Bắc Âu. Đầu giường bo cong bọc vải mềm mại như thể hiện sự chào 
đón bạn với vòng tay rộng mở và mời bạn dành buổi tối sớm và buổi sáng lười biếng trong sự thoải mái và phong cách. Là sản phẩm trong bộ sưu tập Skagen, 
giường ngủ Skagen phù hợp với những phòng ngủ có diện tích lớn. Gỗ Walnut + Vải',N'giuongSkagen1m6',N'36 tháng',2390000)
-- phòng ngủ , bàn MP0002 - ML0002
insert into SANPHAM values('SP012',N'Bàn đầu giường Shadow','MP0002','ML0002',N'Chân, tay nắm kim loại màu đồng + MDF Veneer sồi',N'bandaugiuongshadow',N'36 tháng',950000)

insert into SANPHAM values('SP013',N'Bàn đầu giường Skagen','MP0002','ML0002',N'Gỗ + MDF Veneer Walnut',N'bandaugiuongskagen',N'36 tháng',450000)

insert into SANPHAM values('SP014',N'Bàn trang điểm và đôn Harmony','MP0002','ML0002',N'Là sự kết hợp của màu trắng tinh khôi với màu gỗ ấm áp trên nền những đường nét thiết kế hiện đại, 
trang nhã. Bàn trang điểm Harmony được đánh giá rất cao cả về kiểu dáng và công năng. Bàn được làm bằng gỗ tràm kết hợp ván lạng sồi, trước bàn là mặt giương soi 
thuận tiện trong quá trình sử dụng. Gỗ sồi+ tràm, MDF sơn trắng',N'bantrangdiemvadonHarmony',N'36 tháng',1260000)

-- phòng ngủ , tủ MP0002 - ML0001
insert into SANPHAM values('SP015',N'Tủ áo Kiwi ','MP0002','ML0001',N'Tủ có nhiều ngăn tiện dụng, màu tự nhiên mang đến cảm giác gần gũi với thiên nhiên. Gỗ - MDF Veneer - Sơn',
N'tuaokiwi',N'36 tháng',2850000)

insert into SANPHAM values('SP016',N'Tủ âm tường Kiwi ','MP0002','ML0001',N'Tủ có nhiều ngăn tiện dụng, màu tự nhiên mang đến cảm giác gần gũi với thiên nhiên. Gỗ óc chó (Walnut), 
gỗ ép và ván lạng óc chó nhân tạo (Walnut recon)',N'tuamtuongkiwi',N'36 tháng',4850000)

insert into SANPHAM values('SP017',N'Tủ hộc kéo 3+2 Harmony ','MP0002','ML0001',N'Là sự kết hợp của màu trắng tinh khôi với màu gỗ ấm áp trên nền những đường nét thiết kế hiện đại, trang nhã. 
Harmony được đánh giá rất cao cả về kiểu dáng và công năng, đó sẽ là niềm tự hào của gia chủ khi khách đến thăm nhà.',N'tuhockeo',N'36 tháng',840000)

---phongbep -mp0003 -ML0001',N'Tủ','DM0001'

insert into SANPHAM values('SP018',N'Tủ bếp Moka','MP0003','ML0001',N'Là sự kết hợp giữa da bò tự nhiên trên
 phần lưng, nệm ngồi với gỗ tràm',N'tuBepMoka',N'36 tháng ',4000000)

insert into SANPHAM values ('SP019',N'Tủ Bếp ViVo','MP0003','ML0001',N'Tủ bếp Vivo có thẩm mỹ và độ bền cao của gỗ công nghiệp chống ẩm sơn trắng phối hợp với các 
 mảng màu sắc của ván lạng óc chó. ',N'tuBepViVo',N'36 tháng ',5000000)
 ----phongbep -mp0003- ML0002',N'Bàn','DM0001'
 insert into SANPHAM values('SP020',N'Bàn ghế ăn đẹp bằng gỗ sồi','MP0003','ML0002',N'được thiết kế theo xu hướng hiện đại, tiện dụng nhưng mang tới cảm giác ấm áp. Đến Nội thất Go
  Home để chọn lựa bộ bàn ăn phù hợp cho gia đình. ',N'banGheGoSoi',N'36 tháng ',1200000)

 insert into SANPHAM values('SP021',N'Bộ bàn ăn gia đình phong cách ','MP0003','ML0002',N'một tuyệt tác mang phong cách
  Á Đông sẽ khiến nhiều khách hàng thích thú. ',N'banGhePC',N'36 tháng ',1600000)

 ----phongbep -mp0003-ML0005',N'Kệ','DM0002'
 insert into SANPHAM values('SP022',N'Kệ gỗ treo thực phẩm','MP0003','ML0005',N'Sản phẩm được làm bằng Gỗ tự nhiên dùng để treo để đồ các loại gia vị nhỏ gọn trong nhà Bếp.
  Go Home chắc chắn rằng bạn sẽ tiết kiệm được không gian cho căn bếp nhà mình. ',N'keGoPB01',N'36 tháng ',1500000)

 insert into SANPHAM values('SP023',N'Kệ gỗ để đồ tiện dụng','MP0003','ML0005',N'Kệ bếp mở đơn giản được thiết với những thanh gỗ hay kim đặt song song nhau dùng để sắp xếp các
  vật dụng như ly, chén, đĩa…và tìm kiếm cũng rất dễ dàng. ',N'keGoPB02',N'36 tháng ',1500000)

 ----phonglamviec -mp0005 -ban-ml0002
insert into SANPHAM values('SP024',N'Bàn làm việc Maxine','MP0005','ML0002',N'Đơn giản, đẹp và cá tính theo phong cách nội thất thập niên 60. Bàn làm việc Touka được chăm chút tỉ mỉ
 từ kiểu dáng bên ngoài đến chất lượng bên trong.',N'banMaxine',N'36 tháng ',13900000)

insert into SANPHAM values('SP025',N'Bàn làm việc Touka','MP0005','ML0002',N'Một thiết kế bàn làm việc đẳng cấp cho
 không gian làm việc của bạn',N'banTouka',N'36 tháng ',33900000)
  ----phonglamviec -mp0005 -ghe-ml0003
insert into SANPHAM values('SP026',N'Ghế Bridge Có tay','MP0005','ML0003',N'Cảm giác thoái mái và dễ chịu của ghế ăn Bridge mang
 lại là trải nghiệm tuyệt vời ',N'gheBri',N'36 tháng ',23900000)

insert into SANPHAM values('SP027',N'Bàn làm việc Maxine','MP0005','ML0003',N'Là sự kết hợp giữa da bò tự nhiên trên
 phần lưng, nệm ngồi với gỗ tràm',N'gheKhongTay',N'36 tháng ',11100000)
 ----phonglamviec -mp0005 -ML0005',N'Kệ','DM0002

insert into SANPHAM values('SP028',N'Kệ sách Maxine','MP0005','ML0005',N'Kệ sách Maxine với thiết kế đơn giản hiện đại, chất gỗ walnut tự nhiên kết hợp cùng veneer walnut sang trọng,
  có thể sử dụng được cả hai mặt, đường nét tinh tế đến từng góc cạnh. ',N'keSachMaxine',N'36 tháng ',3000000)

 insert into SANPHAM values('SP029',N'Kệ sách Gamma','MP0005','ML0005',N'Kệ sách Gamma với thiết kế đơn giản hiện đại, chất gỗ walnut tự nhiên kết hợp cùng veneer walnut sang trọng, 
 có thể sử dụng được cả hai mặt, đường nét tinh tế đến từng góc cạnh. ',N'keSachGamma',N'36 tháng ',4000000)

  ----phonglamviec -mp0005 -ML0006',N'Tủ Trang Trí','DM0002')
insert into SANPHAM values ('SP030',N'Tủ hồ sơ bắc Âu','MP0005','ML0006',N'Là sản phẩm tủ trang trí cao cấp của thương hiệu 
 nội thất Top 3 tại Hàn Quốc - Dongsuh Furniture. ',N'tuTrangTri01',N'36 tháng ',6000000)

 insert into SANPHAM values('SP031',N'Tủ hồ sơ tiện lợi','MP0005','ML0006',N'Là sản phẩm tủ trang trí cao cấp 
 của thương hiệu nội thất Top 3 tại Hàn Quốc - Dongsuh Furniture.
  Chuyên cung cấp những mẫu bàn ghế trang điểm nội thất phòng khách, ',N'tuTrangTri01',N'36 tháng ',5000000)
select * from SANPHAM

CREATE TABLE BAOHANH
(
	MABAOHANH CHAR(10) PRIMARY KEY,
	MAKHACHHANG CHAR(10),
	MASP CHAR(10),
	YEUCAUBAOHANH NVARCHAR(MAX),
	NGAYNHAN DATETIME ,
	NGAYTRA DATETIME ,
	constraint FK_BAOHANH_KHOHANG foreign key (MASP) references SANPHAM(MASP),
	CONSTRAINT FK_MAKHACHHANG_KH FOREIGN KEY (MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG)
)

set dateformat dmy
INSERT INTO BAOHANH VALUES('BH0001','KH0001','SP001',N'SƠN','12/03/2020','15/03/2020')
INSERT INTO BAOHANH VALUES('BH0002','KH0002','SP002',N'SƠN BÓNG','15/04/2020','17/04/2020')
INSERT INTO BAOHANH VALUES('BH0003','KH0003','SP003',N'CỬA KÉO','18/05/2020','18/05/2020')


CREATE TABLE PHIEUNHAP
(
	MAPN CHAR(10) PRIMARY KEY,
	MANV CHAR(10),
	MANCC CHAR(10),
	NGAYLAP DATETIME,
	constraint FK_PHIEUNHAP_NV foreign key (MANV) references NHANVIEN(MANV),
	constraint FK_PHIEUNHAP_NCC  foreign key (MANCC) references NHACUNGCAP(MANCC),
)

INSERT INTO PHIEUNHAP VALUES('MAPN0001','NV0010','NCC001','12/01/2020')
INSERT INTO PHIEUNHAP VALUES('MAPN0002','NV0011','NCC002 ','12/02/2020')
INSERT INTO PHIEUNHAP VALUES('MAPN0003','NV0012','NCC003','12/03/2020')

CREATE TABLE CHITIETPHIEUNHAP
(
	MACTPN CHAR(10),
	MASP CHAR(10),
	SOLUONG INT,
	DONGIA MONEY,
	THANHTIEN MONEY,
	CONSTRAINT PK_CHITIETPHIEUNHAP PRIMARY KEY (MACTPN, MASP),
	constraint FK_CHITIETPHIEUNHAP_PHIEUNHAP foreign key (MACTPN) references PHIEUNHAP(MAPN),
	constraint FK_CHITIETPHIEUNHAP_KHOHANG  foreign key (MASP) references SANPHAM(MASP)
)

INSERT INTO CHITIETPHIEUNHAP VALUES('MAPN0001','SP002',10,2000000,20000000)
INSERT INTO CHITIETPHIEUNHAP VALUES('MAPN0002','SP002',10,1500000,15000000)
INSERT INTO CHITIETPHIEUNHAP VALUES('MAPN0002','SP003',10,2000000,20000000)
INSERT INTO CHITIETPHIEUNHAP VALUES('MAPN0003','SP002',10,3000000,30000000)
INSERT INTO CHITIETPHIEUNHAP VALUES('MAPN0003','SP005',10,1000000,10000000)



CREATE TABLE HOADON
(
	MAHD CHAR(10) PRIMARY KEY,
	MANV CHAR(10),
	NGAYLAP DATE,
	CHIETKHAU FLOAT,
	THANHTIEN MONEY,
	MAKHACHHANG CHAR(10),
	TENKHACHHANG NVARCHAR(50),
	DIACHIGIAOHANG NVARCHAR(100),
	SDTGIAOHANG CHAR(11),
	TRANGTHAI NVARCHAR(20) DEFAULT N'ĐANG CHỜ GIAO HÀNG',/*TRẠNG THÁI ĐƠN HÀNG ĐÃ GIAO HAY CHƯA, NẾU GIAO RỒI THÌ SẼ ĐỂ HOÀN THÀNH, CHƯA GIAO THÌ ĐỂ ĐANG CHỜ GIAO HÀNG*/
	
	constraint FK_HOADON_NV foreign key (MANV) references NHANVIEN(MANV),

)

SET DATEFORMAT DMY
INSERT INTO HOADON(MAHD,MANV,NGAYLAP,CHIETKHAU,MAKHACHHANG,TENKHACHHANG, DIACHIGIAOHANG,SDTGIAOHANG) 
VALUES ('HD001','NV0001','20/6/2020','0','KH0001',N'NGUYỄN VĂN TUẤN', N'12, ĐƯỜNG LŨY BÁN BÍCH, PHƯỜNG TÂY THÀNH, QUẬN TÂN PHÚ','0383912405'),
('HD002','NV0001','20/6/2020','0','KH0002',N'NGUYỄN NGỌC TOÀN',N'53, ĐƯỜNG C1, PHƯỜNG 13, QUẬN TÂN BÌNH','0383315405'),
('HD003','NV0001','24/6/2020','0','KH0003',N'NGUYỄN VĂN ĐẠT',N'53, ĐƯỜNG C1, PHƯỜNG 13, QUẬN TÂN BÌNH','0383315405')



CREATE TABLE CHITIETHOADON
(
	MAHD CHAR(10),
	MASP CHAR(10),
	SOLUONG INT,
	DONGIA MONEY,
	TONGTIEN MONEY,
	CONSTRAINT PK_CHITIETHOADON PRIMARY KEY (MAHD, MASP),
	CONSTRAINT FK_CHITIETHOADON_HD foreign key (MAHD) references HOADON(MAHD),
	CONSTRAINT FK_CHITIETHOADON_HANG foreign key (MASP) references SANPHAM(MASP),
)
INSERT INTO CHITIETHOADON(MAHD,MASP,SOLUONG,DONGIA)
VALUES ('HD001','SP001','4','200000'),
('HD001','SP003','1','1500000'),
('HD001','SP004','2','4000000')

INSERT INTO CHITIETHOADON(MAHD,MASP,SOLUONG,DONGIA)
VALUES ('HD002','SP002','2','600000'),
('HD002','SP005','1','5000000'),
('HD002','SP006','1','6300000')

INSERT INTO CHITIETHOADON(MAHD,MASP,SOLUONG,DONGIA)
VALUES ('HD003','SP006','4','200000'),
('HD003','SP008','3','1500000'),
('HD003','SP005','5','200000')

select * from HOADON order by CAST(SUBSTRING(MAHD,3,4) AS integer) DESC

/*BẢNG CHỨA DANH SÁCH CÁC HÓA ĐƠN MÀ KHÁCH HÀNG CÓ TÀI KHOẢN MUA*/
/*NẾU KHÁCH HÀNG MUA TRỰC TIẾP MÀ KHÔNG THÔNG QUA ĐĂNG NHẬP TK THÌ KHÔNG THÊM VÀO BẢNG DANHSACHMUA*/
/*CREATE TABLE DANHSACHMUA 
(
	MAKHACHHANG CHAR(10),
	MAHD CHAR(10),
	CONSTRAINT PK_HOADON_KHACHHANG PRIMARY KEY (MAKHACHHANG, MAHD),
	constraint FK_KHACHHANG_DSMUA foreign key (MAKHACHHANG) references KHACHHANG(MAKHACHHANG),
	constraint FK_HOADON_DSMUA foreign key (MAHD) references HOADON(MAHD)
)

INSERT INTO DANHSACHMUA
VALUES ('KH0001','HD001'),
('KH0001','HD002'),
('KH0001','HD003')

INSERT INTO DANHSACHMUA
VALUES ('KH0001','HD001'),
('KH0001','HD002'),
('KH0001','HD003')*/

SET DATEFORMAT DMY

INSERT INTO HOADON(MAHD,MANV,NGAYLAP,CHIETKHAU,MAKHACHHANG,TENKHACHHANG, DIACHIGIAOHANG,SDTGIAOHANG) 
VALUES ('HD','NV0001','25/6/2020','0','KH0001',N'NGUYỄN VĂN TUẤN', N'12, ĐƯỜNG LŨY BÁN BÍCH, PHƯỜNG TÂY THÀNH, QUẬN TÂN PHÚ','0383912405')

create trigger tg_mahd on HOADON
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)SUBSTRING(MAHD,3,7) + 1 from HOADON ORDER BY CAST(SUBSTRING(MAHD,3,7) AS integer) DESC) ;
	Update HOADON
	Set MAHD = 'HD' + convert(nchar(8),@ma)
	where MAHD = (select MAHD from inserted)
end


create trigger tg_makh on KHACHHANG
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)CAST(SUBSTRING(MAKHACHHANG,3,7) AS integer) + 1 from KHACHHANG ORDER BY CAST(SUBSTRING(MAKHACHHANG,3,7) AS integer) DESC);
	

	Update KHACHHANG
	Set MAKHACHHANG = 'KH' + CONVERT(NCHAR(10),@ma)
	where MAKHACHHANG = (select MAKHACHHANG from inserted)
end


create trigger tg_maPN on PHIEUNHAP
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)CAST(SUBSTRING(MAPN,3,7) AS integer) + 1 from PHIEUNHAP ORDER BY CAST(SUBSTRING(MAPN,3,7) AS integer) DESC);
	


	Update PHIEUNHAP
	Set MAPN = 'PN' + CONVERT(NCHAR(10),@ma)
	where MAPN = (select MAPN from inserted)
end







CREATE TABLE PHIEUXUAT
(
	MAPHIEUXUAT CHAR(10) PRIMARY KEY,
	MAKHACHHANG CHAR(10),
	MANV CHAR(10),
	NGAYLAPPHIEU DATETIME,
	constraint FK_PHIEUXUAT_MAKHACHHANG foreign key (MAKHACHHANG) references KHACHHANG(MAKHACHHANG),
	constraint FK_PHIEUXUAT_NHANVIEN  foreign key (MANV) references NHANVIEN(MANV),
)

INSERT INTO PHIEUXUAT VALUES('PX','KH0003','NV0011',13/02/2020)
INSERT INTO PHIEUXUAT VALUES('PX0002','KH0002','NV0012',13/03/2020)
INSERT INTO PHIEUXUAT VALUES('PX0003','KH0003','NV0013',13/04/2020)

select * from phieuxuat

CREATE TABLE CHITIETPHIEUXUAT
(
	MACTPHIEUXUAT CHAR(10), 
	MASP CHAR(10),
	DONGIA MONEY,
	SOLUONG INT,
	THANHTIEN MONEY,
	CHUTHICH NVARCHAR(50),
	constraint PK_CHITIETPHIEUXUAT PRIMARY KEY (MACTPHIEUXUAT, MASP),
	constraint FK_CHITIETPHIEUXUAT_PHIEUXUAT foreign key (MACTPHIEUXUAT) references PHIEUXUAT(MAPHIEUXUAT),
	constraint FK_CHITIETPHIEUXUAT_KHOHANG  foreign key (MASP) references SANPHAM(MASP),
)



INSERT INTO CHITIETPHIEUXUAT VALUES('PX5','SP001',2200000,1,4400000,NULL)
INSERT INTO CHITIETPHIEUXUAT VALUES('PX0002','SP002',1800000,1,1800000,NULL)
INSERT INTO CHITIETPHIEUXUAT VALUES('PX0003','SP003',2200000,2,4400000,NULL)


create trigger tg_mapx on PHIEUXUAT
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)CAST(SUBSTRING(MAPHIEUXUAT,3,7) AS integer) + 1 from PHIEUXUAT ORDER BY CAST(SUBSTRING(MAPHIEUXUAT,3,7) AS integer) DESC);
	 

	Update PHIEUXUAT
	Set MAPHIEUXUAT = 'PX' + CONVERT(NCHAR(10),@ma)
	where MAPHIEUXUAT = (select MAPHIEUXUAT from inserted)
end



CREATE TABLE MAGIAMGIA
(
	MAGIAMGIA CHAR(10) NOT NULL PRIMARY KEY,
	MASP CHAR(10),
	TILEGIAM NCHAR(20),
	GHICHU NVARCHAR(MAX),

	CONSTRAINT FK_MASP_MAGG FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
)

INSERT INTO MAGIAMGIA VALUES('GG0001','SP001','0,2',NULL)
INSERT INTO MAGIAMGIA VALUES('GG0002','SP002','0,1',NULL)
INSERT INTO MAGIAMGIA VALUES('GG0003','SP003','0,1',NULL)
select *from SANPHAM

delete KHACHHANG WHERE MAKHACHHANG='KH15'

CREATE TABLE PHIEUGIAO
(
	MAPHIEUGIAO CHAR(10) PRIMARY KEY,
	MAKHACHHANG CHAR(10),
	MAPHIEUXUAT CHAR(10),
	TENNGUOINHAN NVARCHAR(50),
	DIACHIGIAOHANG NVARCHAR(100),
	MANV CHAR(10),
	NGAYLAPPHIEU DATETIME,
	TONGTHANHTIEN MONEY,
	constraint FK_PHIEUGIAO_PHIEUXUAT  foreign key (MAPHIEUXUAT) references PHIEUXUAT(MAPHIEUXUAT),
	constraint FK_PHIEUGIAO_MAKHACHHANG foreign key (MAKHACHHANG) references KHACHHANG(MAKHACHHANG),
	constraint FK_PHIEUGIAO_NHANVIEN  foreign key (MANV) references NHANVIEN(MANV),
)


CREATE TABLE CHITIETPHIEUGIAO
(
	MACTPHIEUGIAO CHAR(10), 
	MASP CHAR(10),
	DONGIA MONEY,
	SOLUONG INT,
	THANHTIEN MONEY,
	CHUTHICH NVARCHAR(50),
	constraint PK_CHITIETPHIEUGIAO PRIMARY KEY (MACTPHIEUGIAO, MASP),
	constraint FK_CHITIETPHIEUGIAO_PHIEUXUAT foreign key (MACTPHIEUGIAO) references PHIEUGIAO(MAPHIEUGIAO),
	constraint FK_CHITIETPHIEUGIAO_KHOHANG  foreign key (MASP) references SANPHAM(MASP),
)


create trigger tg_maPG on PHIEUGIAO
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)CAST(SUBSTRING(MAPHIEUGIAO,3,7) AS integer) + 1 from PHIEUGIAO ORDER BY CAST(SUBSTRING(MAPHIEUGIAO,3,7) AS integer) DESC);
	

	Update PHIEUGIAO
	Set MAPHIEUGIAO = 'PG' + CONVERT(NCHAR(10),@ma)
	where MAPHIEUGIAO = (select MAPHIEUGIAO from inserted)
end


create trigger tg_maSP on SANPHAM
for insert
as 
Begin
	declare @ma int;
	set @ma = (select top(1)CAST(SUBSTRING(MASP,3,7) AS integer) + 1 from SANPHAM ORDER BY CAST(SUBSTRING(MASP,3,7) AS integer) DESC);
	

	Update SANPHAM
	Set MASP = 'SP' + CONVERT(NCHAR(10),@ma)
	where MASP = (select MASP from inserted)
end

create trigger tg_maPN_KHO on CHITIETPHIEUNHAP
for insert, UPDATE
as 
Begin
	declare @ma int;
	set @ma = (select SOLUONG from CHITIETPHIEUNHAP WHERE MASP = (select MASP from inserted) AND MACTPN = (select MACTPN from inserted));
	

	Update KHOHANG
	Set SOLUONG = SOLUONG + @ma
	where MASP = (select MASP from inserted)
end

create trigger tg_maPX_KHO on CHITIETPHIEUXUAT
for insert, UPDATE
as 
Begin
	declare @ma int;
	set @ma = (select SOLUONG from CHITIETPHIEUXUAT WHERE MASP = (select MASP from inserted) AND MACTPHIEUXUAT = (select MACTPHIEUXUAT from inserted));
	

	Update KHOHANG
	Set SOLUONG = SOLUONG - @ma
	where MASP = (select MASP from inserted)
end


