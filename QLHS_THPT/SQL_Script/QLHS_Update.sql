----------------------------------------------------------
--drop database QLHS

GO
USE QLHS
----------------------------------------------------------
--1. Create table and its columns
CREATE TABLE [dbo].[NAMHOC] (
	[MaNamHoc]		[varchar](6) NOT NULL);
GO
--2. Create table and its columns
CREATE TABLE [dbo].[MONHOC] (
	[MaMonHoc]		[varchar](6) NOT NULL,
	[TenMonHoc]		[nvarchar](30) NOT NULL,
	[SoTiet]		[int] NOT NULL,
	[HeSo]			[int] NOT NULL);
GO

--3. Create table and its columns
CREATE TABLE [dbo].[GIAOVIEN] (
	[MaGiaoVien]	[varchar](6) NOT NULL,
	[TenGiaoVien]	[nvarchar](30) NOT NULL);	
GO

--4. Create table and its columns
CREATE TABLE [dbo].[LOP] (
	[MaLop]			[varchar](15) NOT NULL,
	[TenLop]		[nvarchar](30) NOT NULL,
	[MaKhoiLop]		[tinyint] NOT NULL,
	[MaNamHoc]		[varchar](6) NOT NULL,
	[SiSo]			[int] NOT NULL,
	[MaGiaoVien]	[varchar](6) NOT NULL);
GO

--5. Create table and its columns
CREATE TABLE [dbo].[HOCSINH] (
	[MaHocSinh]		[varchar](7) NOT NULL,
	[TenHocSinh]	[nvarchar](30) NULL,
	[Email]			[nvarchar](50) NULL,
	[GioiTinh]		[bit] NULL,                  
	[NgaySinh]		[datetime] NULL,
	[NoiSinh]		[nvarchar](50) NULL,	
	[DiaChi]		[nvarchar](100) NULL);
GO

--6. Create table and its columns
CREATE TABLE [dbo].[PHANLOP] (
	[MaHocSinh]		[varchar](7) NOT NULL,
	[MaLop]			[varchar](15) NOT NULL);
GO
--7. Create table and its columns
CREATE TABLE [dbo].[BANGDIEM] (
	[MaHocSinh]		[varchar](7) NOT NULL,
	[MaMonHoc]		[varchar](6) NOT NULL,	
	[DM_1]			[real] NULL,
	[DM_2]			[real] NULL,
	[D15_1]			[real] NULL,
	[D15_2]			[real] NULL,
	[D15_3]			[real] NULL,
	[D15_4]			[real] NULL,
	[D1T_1]			[real] NULL,
	[D1T_2]			[real] NULL,
	[DThi]			[real] NULL,
	[MaHocKy]		[varchar](3) NOT NULL);
GO
--8. Create table and its columns
CREATE TABLE [dbo].[CHUYENLOP] (	
	[TuLop]			[varchar](15) NOT NULL,
	[DenLop]		[varchar](15) NOT NULL,
	[NgayChuyen]	[datetime] NOT NULL,
	[LyDoChuyen]	[nvarchar](250) NULL,
	[ChuyenBangDiem] [bit] NULL,
	[MaHocSinh]		[varchar](7) NOT NULL);
GO

--9. Create table and its columns
CREATE TABLE [dbo].[LOAINGUOIDUNG] (
	[MaLoaiND]		[varchar](6) NOT NULL,
	[TenLoaiND]		[nvarchar](30) NOT NULL);
GO

--10. Create table and its columns
CREATE TABLE [dbo].[NGUOIDUNG] (
	[MaND]			[varchar](6) NOT NULL,
	[MaLoaiND]		[varchar](6) NOT NULL,
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
ALTER TABLE [dbo].[BANGDIEM] ADD CONSTRAINT [PK_BANGDIEM] PRIMARY KEY ([MaHocSinh],[MaHocKy],[MaMonHoc]) 
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

--2. 7_2-Foreign key BANGDIEM_MONHOC
	ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK_BANGDIEM_MONHOC] FOREIGN KEY([MaMonHoc])
	REFERENCES [dbo].[MONHOC] ([MaMonHoc])
	GO

	ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK_BANGDIEM_MONHOC]
	GO

--3. 4_3-Foreign key LOP_GIAOVIEN
	ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_GIAOVIEN] FOREIGN KEY([MaGiaoVien])
	REFERENCES [dbo].[GIAOVIEN] ([MaGiaoVien])
	GO

	ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_GIAOVIEN]
	GO

--4. 6_4-Foreign key PHANLOP_LOP
	ALTER TABLE [dbo].[PHANLOP]  WITH CHECK ADD  CONSTRAINT [FK_PHANLOP_LOP] FOREIGN KEY([MaLop])
	REFERENCES [dbo].[LOP] ([MaLop])
	GO

	ALTER TABLE [dbo].[PHANLOP] CHECK CONSTRAINT [FK_PHANLOP_LOP]
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

--7. 6_5-Foreign key PHANLOP_HOCSINH
	ALTER TABLE [dbo].[PHANLOP]  WITH CHECK ADD  CONSTRAINT [FK_PHANLOP_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[PHANLOP] CHECK CONSTRAINT [FK_PHANLOP_HOCSINH]
	GO

--8. 7_5-Foreign key BANGDIEM_HOCSINH
	ALTER TABLE [dbo].[BANGDIEM]  WITH CHECK ADD  CONSTRAINT [FK_BANGDIEM_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[BANGDIEM] CHECK CONSTRAINT [FK_BANGDIEM_HOCSINH]
	GO

--9. 8_5-Foreign key CHUYENLOP_HOCSINH
	ALTER TABLE [dbo].[CHUYENLOP]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENLOP_HOCSINH] FOREIGN KEY([MaHocSinh])
	REFERENCES [dbo].[HOCSINH] ([MaHocSinh])
	GO

	ALTER TABLE [dbo].[CHUYENLOP] CHECK CONSTRAINT [FK_CHUYENLOP_HOCSINH]
	GO

--10. 10_9-Foreign key NGUOIDUNG_LOAINGUOIDUNG
	ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG] FOREIGN KEY([MaLoaiND])
	REFERENCES [dbo].[LOAINGUOIDUNG] ([MaLoaiND])
	GO

	ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG]
	GO

--11. 10_3-Foreign key GIAOVIEN_NGUOIDUNG
	ALTER TABLE [dbo].[GIAOVIEN]  WITH CHECK ADD  CONSTRAINT [FK_GIAOVIEN_NGUOIDUNG] FOREIGN KEY([MaGiaoVien])
	REFERENCES [dbo].[NGUOIDUNG] ([MaND])
	GO

	ALTER TABLE [dbo].[GIAOVIEN] CHECK CONSTRAINT [FK_GIAOVIEN_NGUOIDUNG]
	GO






