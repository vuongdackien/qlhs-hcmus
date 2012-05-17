----------------------------------------------------------
--drop database QLHS

GO
USE QLHS
----------------------------------------------------------
--1. Create table and its columns
CREATE TABLE [dbo].[NAMHOC] (
	[MaNamHoc]		[varchar](6) NOT NULL,
	[TenNamHoc]		[nvarchar](30) NOT NULL);
GO
--2. Create table and its columns
CREATE TABLE [dbo].[MONHOC] (
	[MaMonHoc]		[varchar](10) NOT NULL,
	[TenMonHoc]		[nvarchar](50) NOT NULL,
	[SoTiet]		[int] NOT NULL,
	[HeSo]			[int] NOT NULL);
GO

--3. Create table and its columns
CREATE TABLE [dbo].[GIAOVIEN] (
	[MaGiaoVien]	[varchar](10) NOT NULL,
	[TenGiaoVien]	[nvarchar](50) NOT NULL);	
GO

--4. Create table and its columns
CREATE TABLE [dbo].[LOP] (
	[MaLop]			[varchar](15) NOT NULL,
	[TenLop]		[nvarchar](50) NOT NULL,
	[MaKhoiLop]		[tinyint] NOT NULL,
	[MaNamHoc]		[varchar](6) NOT NULL,
	[SiSo]			[int] NOT NULL,
	[MaGiaoVien]	[varchar](10) NOT NULL);
GO

--5. Create table and its columns
CREATE TABLE [dbo].[HOCSINH] (
	[MaHocSinh]		[varchar](10) NOT NULL,
	[TenHocSinh]	[nvarchar](50) NULL,
	[Email]			[nvarchar](50) NULL,
	[GioiTinh]		[bit] NULL,                  
	[NgaySinh]		[datetime] NULL,
	[NoiSinh]		[nvarchar](100) NULL,	
	[DiaChi]		[nvarchar](100) NULL);
GO

--6. Create table and its columns
CREATE TABLE [dbo].[PHANLOP] (
	[MaHocSinh]		[varchar](10) NOT NULL,
	[MaLop]			[varchar](15) NOT NULL);
GO
--7. Create table and its columns
CREATE TABLE [dbo].[BANGDIEM] (
	[MaHocSinh]		[varchar](10) NOT NULL,
	[MaMonHoc]		[varchar](10) NOT NULL,	
	[DM_1]			[real] NULL,
	[DM_2]			[real] NULL,
	[D15_1]			[real] NULL,
	[D15_2]			[real] NULL,
	[D15_3]			[real] NULL,
	[D15_4]			[real] NULL,
	[D1T_1]			[real] NULL,
	[D1T_2]			[real] NULL,
	[DThi]			[real] NULL,
	[MaLop]			[varchar](15) NOT NULL,
	[MaHocKy]		[varchar](10) NOT NULL);
GO
--8. Create table and its columns
CREATE TABLE [dbo].[CHUYENLOP] (	
	[TuLop]			[varchar](15) NOT NULL,
	[DenLop]		[varchar](15) NOT NULL,
	[NgayChuyen]	[datetime] NOT NULL,
	[LyDoChuyen]	[nvarchar](250) NULL,
	[ChuyenBangDiem] [bit] NULL,
	[MaHocSinh]		[varchar](10) NOT NULL);
GO

--9. Create table and its columns
CREATE TABLE [dbo].[LOAINGUOIDUNG] (
	[MaLoaiND]		[varchar](10) NOT NULL,
	[TenLoaiND]		[nvarchar](30) NOT NULL);
GO

--10. Create table and its columns
CREATE TABLE [dbo].[NGUOIDUNG] (
	[MaND]			[varchar](10) NOT NULL,
	[MaLoaiND]		[varchar](10) NOT NULL,
	[TenDNhap]		[varchar](30) NOT NULL,
	[MatKhau]		[varchar](35) NOT NULL,
	[TrangThai]		[bit] NOT NULL CONSTRAINT [DF_NGUOIDUNG_TrangThai] DEFAULT ((1)));
GO

--11. Create table and its columns
CREATE TABLE [dbo].[QUYDINH] (
	[Khoa]			[varchar](50) NOT NULL,
	[GiaTri]		[int]	      NOT NULL);
GO

----------------------------------------------------------
--PRIMARY KEY
----------------------------------------------------------
--1. Primary key NAMHOC
ALTER TABLE [dbo].[NAMHOC] ADD CONSTRAINT [PK_NAMHOC] PRIMARY KEY ([MaNamHoc]) 
GO

--2. Primary key MONHOC
ALTER TABLE [dbo].[MONHOC] ADD CONSTRAINT [PK_MONHOC] PRIMARY KEY ([MaMonHoc]) 
GO

--3. Primary key GIAOVIEN
ALTER TABLE [dbo].[GIAOVIEN] ADD CONSTRAINT [PK_GIAOVIEN] PRIMARY KEY ([MaGiaoVien]) 
GO

--4. Primary key LOP
ALTER TABLE [dbo].[LOP] ADD CONSTRAINT [PK_LOP] PRIMARY KEY ([MaLop]) 
GO
--5. Primary key HOCSINH
ALTER TABLE [dbo].[HOCSINH] ADD CONSTRAINT [PK_HOCSINH] PRIMARY KEY ([MaHocSinh]) 
GO

--6. Primary key PHANLOP
ALTER TABLE [dbo].[PHANLOP] ADD CONSTRAINT [PK_PHAN] PRIMARY KEY ([MaHocSinh],[MaLop]) 
GO

--7. Primary key BANGDIEM
ALTER TABLE [dbo].[BANGDIEM] ADD CONSTRAINT [PK_BANGDIEM] PRIMARY KEY ([MaHocSinh],[MaHocKy],[MaMonHoc], [MaLop]) 
GO

--8. Primary key CHUYENLOP
ALTER TABLE [dbo].[CHUYENLOP] ADD CONSTRAINT [PK_CHUYENLOP] PRIMARY KEY ([TuLop],[DenLop],[NgayChuyen]) 
GO

--9. Primary key LOAINGUOIDUNG
ALTER TABLE [dbo].[LOAINGUOIDUNG] ADD CONSTRAINT [PK_LOAINGUOIDUNG] PRIMARY KEY ([MaLoaiND]) 
GO

--10. Primary key NGUOIDUNG
ALTER TABLE [dbo].[NGUOIDUNG] ADD CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY ([MaND]) 
GO

--11. Primary key QUYDINH
ALTER TABLE [dbo].[QUYDINH] ADD CONSTRAINT [PK_QUYDINH] PRIMARY KEY ([Khoa]) 
GO

----------------------------------------------------------
--FOREIGN KEY
----------------------------------------------------------
--1. 4_1-Foreign key LOP_NAMHOC
	ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_NAMHOC] FOREIGN KEY([MaNamHoc])
	REFERENCES [dbo].[NAMHOC] ([MaNamHoc])
	GO

	ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_NAMHOC]
	GO

--3. 4_3-Foreign key LOP_GIAOVIEN
	ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_GIAOVIEN] FOREIGN KEY([MaGiaoVien])
	REFERENCES [dbo].[GIAOVIEN] ([MaGiaoVien])
	GO

	ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_GIAOVIEN]
	GO

--2. 7_2-Foreign key BANGDIEM_MONHOC
	ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK_BANGDIEM_MONHOC] FOREIGN KEY([MaMonHoc])
	REFERENCES [dbo].[MONHOC] ([MaMonHoc])
	GO

	ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK_BANGDIEM_MONHOC]
	GO

--8. 7_5-Foreign key BANGDIEM_HOCSINH
	ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK_BANGDIEM_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK_BANGDIEM_HOCSINH]
	GO

--8. 7_5-Foreign key BANGDIEM_LOP
	ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK_BANGDIEM_LOP] FOREIGN KEY([MaLop])
	REFERENCES [dbo].[LOP] ([MaLop])
	GO

	ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK_BANGDIEM_LOP]
	GO

--4. 6_4-Foreign key PHANLOP_LOP
	ALTER TABLE [dbo].[PHANLOP]  WITH CHECK ADD  CONSTRAINT [FK_PHANLOP_LOP] FOREIGN KEY([MaLop])
	REFERENCES [dbo].[LOP] ([MaLop])
	GO

	ALTER TABLE [dbo].[PHANLOP] CHECK CONSTRAINT [FK_PHANLOP_LOP]
	GO

--7. 6_5-Foreign key PHANLOP_HOCSINH
	ALTER TABLE [dbo].[PHANLOP]  WITH CHECK ADD  CONSTRAINT [FK_PHANLOP_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[PHANLOP] CHECK CONSTRAINT [FK_PHANLOP_HOCSINH]
	GO

--5. 8_4-Foreign key CHUYENLOP_LOP (TuLop)
	ALTER TABLE [dbo].[CHUYENLOP]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENLOP_LOP1] FOREIGN KEY([TuLop])
	REFERENCES [dbo].[LOP] ([MaLop])
	GO

	ALTER TABLE [dbo].[CHUYENLOP] CHECK CONSTRAINT [FK_CHUYENLOP_LOP1]
	GO

--6. 8_4-Foreign key CHUYENLOP_LOP (DenLop)

	ALTER TABLE [dbo].[CHUYENLOP]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENLOP_LOP2] FOREIGN KEY([DenLop])
	REFERENCES [dbo].[LOP] ([MaLop])
	GO

	ALTER TABLE [dbo].[CHUYENLOP] CHECK CONSTRAINT [FK_CHUYENLOP_LOP2]
	GO

--9. 8_5-Foreign key CHUYENLOP_HOCSINH
	ALTER TABLE [dbo].[CHUYENLOP]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENLOP_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[CHUYENLOP] CHECK CONSTRAINT [FK_CHUYENLOP_HOCSINH]
	GO

--11. 10_3-Foreign key NGUOIDUNG_GIAOVIEN
	ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_GIAOVIEN] FOREIGN KEY([MaND])
	REFERENCES [dbo].[GIAOVIEN] ([MaGiaoVien])
	GO

	ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_GIAOVIEN]
	GO

--10. 10_9-Foreign key NGUOIDUNG_LOAINGUOIDUNG
	ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG] FOREIGN KEY([MaLoaiND])
	REFERENCES [dbo].[LOAINGUOIDUNG] ([MaLoaiND])
	GO

	ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG]
	GO

------------------------------------------------------------------------------
					/*Insert CSDL*/
------------------------------------------------------------------------------

--Table HOCSINH
set dateformat dmy
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00001',  N'Nguyễn Hồng Phú', 'hongphu8790@gmail.com', 0,  '08-07-1990',	N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00002',	N'Nguyễn Duy Hà', 'duyha@gmail.com', 0,	'01-01-1990', N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00003',	N'Nguyễn Thị Mỷ Diện', 'mydien2009@gmail.com', 1, '20-09-1990',	N'Vĩnh Long', N'Vũng Liêm')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00004',	N'Nguyễn Văn Đại', 'vandai@gmail.com', 0, '01-01-1990',	N'Hải Dương', N'Không Biết')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00005',	N'Nguyễn Văn An', 'vanan@gmail.com', 0,	'08-07-1991', N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00006',	N'Nguyễn Bình Minh', 'binhminh@gmail.com', 0, '01-01-1992',	N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00007',	N'Nguyễn Thị Lan Anh', 'lananh@gmail.com', 1, '20-09-1991', N'Vĩnh Long', N'Vũng Liêm')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00008',	N'Lê Thị Thu Hà', 'thuha@gmail.com', 1,	'01-01-1992', N'Hải Dương',	N'Không Biết')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00009',	N'Nguyễn Thị Thanh Trúc', 'thanhtruc@gmail.com', 1,	'08-07-1993', N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00010',	N'Trần Duy Khoa', 'duykhoa@gmail.com', 0, '01-01-1991',	N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00011',	N'Nguyễn Thị Thùy Dương', 'thuyduong@gmail.com', 1,	'20-09-1992', N'Vĩnh Long',	N'Vũng Liêm')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00012',	N'Nguyễn Thị Bảo Ngọc', 'baongoc@gmail.com', 1,	'01-01-1991', N'Hải Dương',	N'Không Biết')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00013',	N'Nguyễn Văn Tân', 'vanTan@gmail.com', 0, '08-07-1993', N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00014',	N'Nguyễn Bình Minh', 'binhminh@gmail.com', 0, '01-01-1992',	N'TP.HCM', N'Q.9')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00015',	N'Huỳnh Thanh Tùng', 'lananh@gmail.com', 0,	'20-09-1993', N'Vĩnh Long', N'Vũng Liêm')
GO
INSERT INTO HOCSINH ([MaHocSinh],[TenHocSinh],[Email],[GioiTinh], [NgaySinh],[NoiSinh],	[DiaChi]) 
	VALUES	('HS00016',	N'Lê Thị Ngọc Thu', 'thuha@gmail.com', 1, '01-01-1992', N'Hải Dương', N'Không Biết')


--Table GIAOVIEN
GO
INSERT INTO GIAOVIEN ([MaGiaoVien],[TenGiaoVien]) 
	VALUES	('GV001',  N'Nguyễn Thị Thanh')
GO
INSERT INTO GIAOVIEN ([MaGiaoVien],[TenGiaoVien]) 
	VALUES	('GV002',  N'Nguyễn Đăng Khoa')
GO
INSERT INTO GIAOVIEN ([MaGiaoVien],[TenGiaoVien]) 
	VALUES	('GV003',  N'Nguyễn Ngọc Anh Thư')
GO
INSERT INTO GIAOVIEN ([MaGiaoVien],[TenGiaoVien]) 
	VALUES	('GV004',  N'Phạm Thanh Huy')


--NAMHOC
GO	
INSERT INTO NAMHOC ([MaNamHoc],[TenNamHoc]) 
	VALUES	('NH1112',	'2011 - 2012')
GO
INSERT INTO NAMHOC ([MaNamHoc],[TenNamHoc]) 
	VALUES	('NH1213',	'2012 - 2013')

--Table LOP
GO
INSERT INTO LOP ([MaLop],[TenLop],[MaKhoiLop],[MaNamHoc],[SiSo],[MaGiaoVien]) 
	VALUES	('10A01NH1112',	'10A1',	10,	'NH1112', 40, 'GV001')
GO
INSERT INTO LOP ([MaLop],[TenLop],[MaKhoiLop],[MaNamHoc],[SiSo],[MaGiaoVien]) 
	VALUES	('10A02NH1112',	'10A2',	10,	'NH1112', 40, 'GV002')
GO
INSERT INTO LOP ([MaLop],[TenLop],[MaKhoiLop],[MaNamHoc],[SiSo],[MaGiaoVien]) 
	VALUES	('11A01NH1112',	'11A1',	10,	'NH1112', 40, 'GV003')
GO
INSERT INTO LOP ([MaLop],[TenLop],[MaKhoiLop],[MaNamHoc],[SiSo],[MaGiaoVien]) 
	VALUES	('12A01NH1112',	'12A1',	12,	'NH1112', 40, 'GV004')
