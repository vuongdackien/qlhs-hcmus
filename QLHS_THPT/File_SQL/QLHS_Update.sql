----------------------------------------------------------
--drop database QLHS
use master
GO
drop database QLHS
GO
create database QLHS
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
	[STT]			[int]	default 1 NOT NULL,
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
	[GiaTri]		[nvarchar]	(250)     NULL);
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
SELECT	
'HS00000001',   N'Nguyễn Hồng Phú', 'hongphu8790@gmail.com', 0,  '08-07-1990',	N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000002',	N'Nguyễn Duy Hà', 'duyha@gmail.com', 0,	'01-01-1990', N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000003',	N'Nguyễn Thị Mỷ Diện', 'mydien2009@gmail.com', 1, '20-09-1990',	N'Vĩnh Long', N'Vũng Liêm' UNION SELECT 
'HS00000004',	N'Nguyễn Văn Đại', 'vandai@gmail.com', 0, '01-01-1990',	N'Hải Dương', N'Không Biết' UNION SELECT 
'HS00000005',	N'Nguyễn Văn An', 'vanan@gmail.com', 0,	'08-07-1991', N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000006',	N'Nguyễn Bình Minh', 'binhminh@gmail.com', 0, '01-01-1992',	N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000007',	N'Nguyễn Thị Lan Anh', 'lananh@gmail.com', 1, '20-09-1991', N'Vĩnh Long', N'Vũng Liêm' UNION SELECT 
'HS00000008',	N'Lê Thị Thu Hà', 'thuha@gmail.com', 1,	'01-01-1992', N'Hải Dương',	N'Không Biết' UNION SELECT 
'HS00000009',	N'Nguyễn Thị Thanh Trúc', 'thanhtruc@gmail.com', 1,	'08-07-1993', N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000010',	N'Trần Duy Khoa', 'duykhoa@gmail.com', 0, '01-01-1991',	N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000011',	N'Nguyễn Thị Thùy Dương', 'thuyduong@gmail.com', 1,	'20-09-1992', N'Vĩnh Long',	N'Vũng Liêm' UNION SELECT 
'HS00000012',	N'Nguyễn Thị Bảo Ngọc', 'baongoc@gmail.com', 1,	'01-01-1991', N'Hải Dương',	N'Không Biết' UNION SELECT 
'HS00000013',	N'Nguyễn Văn Tân', 'vantan@gmail.com', 0, '08-07-1993', N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000014',	N'Nguyễn Bình Minh', 'binhminh@gmail.com', 0, '01-01-1992',	N'TP.HCM', N'Q.9' UNION SELECT 
'HS00000015',	N'Huỳnh Thanh Tùng', 'lananh@gmail.com', 0,	'20-09-1993', N'Vĩnh Long', N'Vũng Liêm' UNION SELECT 
'HS00000016',	N'Lê Thị Ngọc Thu', 'thuha@gmail.com', 1, '01-01-1992', N'Hải Dương', N'Không Biết'


--Table GIAOVIEN
GO
INSERT INTO GIAOVIEN ([MaGiaoVien],[TenGiaoVien]) 
SELECT 'GV001',  N'Nguyễn Thị Thanh' UNION
SELECT 'GV002',  N'Nguyễn Đăng Khoa' UNION
SELECT 'GV003',  N'Nguyễn Ngọc Anh Thư' UNION
SELECT 'GV004',  N'Phạm Thanh Huy'


--NAMHOC
GO	
INSERT INTO NAMHOC ([MaNamHoc],[TenNamHoc]) 
SELECT 'NH1112',	'2011 - 2012' UNION
SELECT 'NH1213',	'2012 - 2013' 

--Table LOP
GO
INSERT INTO LOP ([MaLop],[TenLop],[MaKhoiLop],[MaNamHoc],[SiSo],[MaGiaoVien])  
SELECT '10A01NH1112',	'10A1',	10,	'NH1112', 40, 'GV001' UNION 
SELECT '10A02NH1112',	'10A2',	10,	'NH1112', 40, 'GV002' UNION 
SELECT '11A01NH1112',	'11A1',	11,	'NH1112', 40, 'GV003' UNION 
SELECT '12A01NH1112',	'12A1',	12,	'NH1112', 40, 'GV004'
-- Mon hoc
GO
INSERT INTO MONHOC(MaMonHoc,TenMonHoc,SoTiet,HeSo) 
SELECT 'daoduc',N'Đạo đức',45,1 UNION 
SELECT 'dia',N'Địa lý',45,1 UNION 
SELECT 'hoa',N'Hóa học',45,1 UNION 
SELECT 'ly',N'Vật lý',45,	1 UNION 
SELECT 'sinh',N'Sinh học',45,1 UNION 
SELECT 'su',N'Lịch sử',45,1 UNION 
SELECT 'theduc',N'Thể dục',45,1 UNION 
SELECT 'toan',N'Toán',60,2 UNION 
SELECT 'van',N'Văn học',60,2

-- Phan lop
GO	
INSERT INTO PHANLOP ([STT],[MaHocSinh],[MaLop]) 
SELECT 1,'HS00000001',	'10A01NH1112' UNION 
SELECT 2,'HS00000002',	'10A01NH1112' UNION 
SELECT 3,'HS00000003',	'10A01NH1112' UNION 
SELECT 4,'HS00000004',	'10A01NH1112' UNION 
SELECT 1,'HS00000005',	'10A02NH1112' UNION 
SELECT 2,'HS00000006',	'10A02NH1112' UNION 
SELECT 3,'HS00000007',	'10A02NH1112' UNION 
SELECT 4,'HS00000008',	'10A02NH1112' UNION 
SELECT 1,'HS00000009',	'11A01NH1112' UNION 
SELECT 2,'HS00000010',	'11A01NH1112' UNION 
SELECT 3,'HS00000011',	'11A01NH1112' UNION 
SELECT 4,'HS00000012',	'11A01NH1112' UNION 
SELECT 1,'HS00000013',	'12A01NH1112' UNION 
SELECT 2,'HS00000014',	'12A01NH1112' UNION 
SELECT 3,'HS00000015',	'12A01NH1112' UNION 
SELECT 4,'HS00000016',	'12A01NH1112'

-- Quy Dinh
INSERT INTO QUYDINH (Khoa,GiaTri)  
SELECT 'DiaChiTruong','Q9 - TP.HCM' UNION 
SELECT 'DiemChuan','8' UNION 
SELECT 'SiSoCanDuoi','30' UNION 
SELECT 'SiSoCanTren','45' UNION 
SELECT 'SoLuongLop','20' UNION 
SELECT 'TenTruong',N'THPT Nguyễn Huệ' UNION 
SELECT 'SoMonHoc','15' UNION 
SELECT 'TuoiCanDuoi','15' UNION 
SELECT 'TuoiCanTren','18'

-- Bảng điểm
INSERT INTO BANGDIEM (MaHocSinh,MaMonHoc,DM_1,DM_2,D15_1,D15_2,D15_3,
					D15_4,D1T_1.D1T_2,DThi,MaLop,MaHocKy)
SELECT 'HS00000001','daoduc',6,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','dia',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','hoa',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','ly',8,7,7,7.5,8,7,9,10,'10A01NH1112',1 UNION 
SELECT 'HS00000001','sinh',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','su',8,7,6.5,7.5,8,8,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','theduc',8,7,6.5,7.5,8,4,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','toan',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000001','van',8,7,6.5,7.5,8,4,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','daoduc',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','dia',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','hoa',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','ly',6,7,7,7.5,8,7,9,10,'10A01NH1112',1 UNION 
SELECT 'HS00000002','sinh',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','su',4,7,6.5,7.5,8,8,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','theduc',8,7,6.5,7.5,8,9,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','toan',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000002','van',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','daoduc',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','dia',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','hoa',4,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','ly',8,7,7,7.5,8,7,9,10,'10A01NH1112',1 UNION 
SELECT 'HS00000003','sinh',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','su',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','theduc',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','toan',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000003','van',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','daoduc',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','dia',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','hoa',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','ly',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','sinh',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','su',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','theduc',9,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','toan',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1 UNION 
SELECT 'HS00000004','van',8,7,6.5,7.5,8,7,8,9,'10A01NH1112',1

--Function chuyển có dấu thành không dấu
GO
if exists
(
    select name from sysobjects
    where name = 'fnChuyenKhongDau' and type = 'fn'
)
begin
 drop function fnChuyenKhongDau
end;
GO
CREATE FUNCTION dbo.fnChuyenKhongDau(@strInput NVARCHAR(50)) 
RETURNS NVARCHAR(50)
AS
BEGIN     
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
    DECLARE @RT NVARCHAR(50)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS       = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS =     N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
 
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN   
      SET @COUNTER1 = 1
      --Tim trong chuoi mau
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN           
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)    
              BREAK         
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tim tiep
       SET @COUNTER = @COUNTER +1
    END
    RETURN @strInput
END
 

