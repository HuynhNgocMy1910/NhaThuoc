USE [master]
GO
/****** Object:  Database [QLThuoc]    Script Date: 12/17/2024 9:50:22 PM ******/
CREATE DATABASE [QLThuoc]

ALTER DATABASE [QLThuoc] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLThuoc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLThuoc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLThuoc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLThuoc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLThuoc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLThuoc] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLThuoc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLThuoc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLThuoc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLThuoc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLThuoc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLThuoc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLThuoc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLThuoc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLThuoc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLThuoc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLThuoc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLThuoc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLThuoc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLThuoc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLThuoc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLThuoc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLThuoc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLThuoc] SET RECOVERY FULL 
GO
ALTER DATABASE [QLThuoc] SET  MULTI_USER 
GO
ALTER DATABASE [QLThuoc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLThuoc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLThuoc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLThuoc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLThuoc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLThuoc] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLThuoc', N'ON'
GO
ALTER DATABASE [QLThuoc] SET QUERY_STORE = OFF
GO
USE [QLThuoc]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[TaiKhoan] [varchar](250) NOT NULL,
	[MatKhau] [varchar](250) NOT NULL,
 CONSTRAINT [PK__Admin__D5B8C7F15E9B2134] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaThuoc] [char](50) NOT NULL,
	[MaHD] [char](50) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NULL,
	[GiamGia] [float] NULL,
	[ThanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC,
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[MaHD] [char](50) NOT NULL,
	[MaKH] [char](50) NOT NULL,
	[MaNV] [char](50) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[TongTien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](50) NOT NULL,
	[TenKH] [nvarchar](200) NOT NULL,
	[SDT_KH] [char](10) NOT NULL,
	[DiaChi_KH] [nvarchar](200) NULL,
	[GioiTinh_KH] [nvarchar](10) NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E59605A3D] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [char](50) NOT NULL,
	[TenNCC] [nvarchar](200) NOT NULL,
	[SDT_NCC] [char](10) NOT NULL,
	[DiaChi_NCC] [nvarchar](200) NOT NULL,
	[GhiChu_NCC] [nvarchar](200) NULL,
 CONSTRAINT [PK__NhaCungC__3A185DEBA1543EF6] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](50) NOT NULL,
	[TenNV] [nvarchar](200) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi_NV] [nvarchar](200) NULL,
	[SDT_NV] [char](10) NULL,
	[ChucVu] [nvarchar](200) NULL,
	[NgayVaoLam] [datetime] NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[HinhAnh_NV] [nvarchar](200) NULL,
 CONSTRAINT [PK__NhanVien__2725D70AD3FA6D29] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomThuoc]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomThuoc](
	[MaNhomThuoc] [char](50) NOT NULL,
	[TenNhomThuoc] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhomThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLKho]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLKho](
	[MaKho] [char](50) NOT NULL,
	[TenKho] [nvarchar](200) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[NgayXuat] [datetime] NULL,
	[GhiChu_Kho] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thuoc]    Script Date: 12/17/2024 9:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[MaThuoc] [char](50) NOT NULL,
	[MaNCC] [char](50) NOT NULL,
	[MaNhomThuoc] [char](50) NOT NULL,
	[MaKho] [char](50) NOT NULL,
	[TenThuoc] [nvarchar](200) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NuocSX] [nvarchar](200) NULL,
	[DVT] [nvarchar](200) NULL,
	[DonGiaNhap] [float] NULL,
	[DonGiaBan] [float] NULL,
	[GhiChu_Thuoc] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([TaiKhoan], [MatKhau]) VALUES (N'1bee03396cc6c1c645b61c6ac87a941e7abf5e42ce5b6ca5927b2013362756ffb4934326eba570ca34cd4521e5ac02a31dd9fcd1bd11268a7345ded443da1dd6', N'3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2')
INSERT [dbo].[Admin] ([TaiKhoan], [MatKhau]) VALUES (N'58b5444cf1b6253a4317fe12daff411a78bda0a95279b1d5768ebf5ca60829e78da944e8a9160a0b6d428cb213e813525a72650dac67b88879394ff624da482f', N'3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2')
INSERT [dbo].[Admin] ([TaiKhoan], [MatKhau]) VALUES (N'661bb43140229ad4dc3e762e7bdd68cc14bb9093c158c386bd989fea807acd9bd7f805ca4736b870b6571594d0d8fcfc57b98431143dfb770e083fa9be89bc72', N'3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2')
INSERT [dbo].[Admin] ([TaiKhoan], [MatKhau]) VALUES (N'89bc1887e657da3de01f02d7c4475a4731e1d41e1fbcb4f47151e8e129285db073048b17532cd9aa4c8f56b94d3ce1e104f4c2a5b1139440af518461729eb430', N'3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2')
INSERT [dbo].[Admin] ([TaiKhoan], [MatKhau]) VALUES (N'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', N'3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2')
GO
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203116                                 ', N'HDB11252024_203901                                ', 5, 60000, 5, 285000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203116                                 ', N'HDB12122024_141315                                ', 7, 60000, 0, 420000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203238                                 ', N'HDB11252024_203901                                ', 2, 15000, 0, 30000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203238                                 ', N'HDB12122024_141315                                ', 5, 15000, 0, 75000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203515                                 ', N'HDB11252024_203901                                ', 1, 120000, 0, 120000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203515                                 ', N'HDB12112024_212207                                ', 1, 120000, 0, 120000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203515                                 ', N'HDB12122024_141315                                ', 2, 120000, 0, 240000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203654                                 ', N'HDB11252024_203901                                ', 4, 150000, 10, 540000)
INSERT [dbo].[ChiTietHoaDon] ([MaThuoc], [MaHD], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'T_11252024_203654                                 ', N'HDB12122024_141315                                ', 2, 150000, 10, 270000)
GO
INSERT [dbo].[HoaDonBan] ([MaHD], [MaKH], [MaNV], [NgayBan], [TongTien]) VALUES (N'HDB11252024_203901                                ', N'KH_11252024_195817                                ', N'NV_11252024_194924                                ', CAST(N'2024-11-25T00:00:00.000' AS DateTime), 975000)
INSERT [dbo].[HoaDonBan] ([MaHD], [MaKH], [MaNV], [NgayBan], [TongTien]) VALUES (N'HDB12112024_212207                                ', N'KH_11252024_195736                                ', N'NV_11252024_195529                                ', CAST(N'2024-10-16T00:00:00.000' AS DateTime), 120000)
INSERT [dbo].[HoaDonBan] ([MaHD], [MaKH], [MaNV], [NgayBan], [TongTien]) VALUES (N'HDB12122024_141315                                ', N'KH_11252024_195736                                ', N'NV_11252024_194924                                ', CAST(N'2024-11-26T00:00:00.000' AS DateTime), 1005000)
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT_KH], [DiaChi_KH], [GioiTinh_KH]) VALUES (N'KH_11252024_195736                                ', N'Trần Thị D', N'1234325689', N'Cần Thơ', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT_KH], [DiaChi_KH], [GioiTinh_KH]) VALUES (N'KH_11252024_195817                                ', N'Thái Văn E', N'1534728283', N'Cần Thơ', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT_KH], [DiaChi_KH], [GioiTinh_KH]) VALUES (N'KH_11252024_200125                                ', N'Huỳnh Thị N', N'1465432678', N'Sóc Trăng', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT_KH], [DiaChi_KH], [GioiTinh_KH]) VALUES (N'KH_11262024_195733                                ', N'Hồ Văn E', N'4455667788', N'Hậu Giang', N'Nam')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT_NCC], [DiaChi_NCC], [GhiChu_NCC]) VALUES (N'NCC_11252024_202731                               ', N'Nhà cung cấp 1', N'1345678322', N'Cần Thơ', N'Nhập 2 thùng thuốc panadol')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT_NCC], [DiaChi_NCC], [GhiChu_NCC]) VALUES (N'NCC_11252024_202812                               ', N'Nhà cung cấp 2', N'1456273456', N'Cần Thơ', N'Nhập 20 hộp kẹo ngậm vitaminC')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT_NCC], [DiaChi_NCC], [GhiChu_NCC]) VALUES (N'NCC_11262024_195815                               ', N'Nhà cung cấp 3', N'2233445566', N'Hậu Giang', N'aa')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi_NV], [SDT_NV], [ChucVu], [NgayVaoLam], [GioiTinh], [HinhAnh_NV]) VALUES (N'NV_11252024_194924                                ', N'Nguyễn Văn A', CAST(N'2024-11-25T00:00:00.000' AS DateTime), N'Cần Thơ', N'1233444433', N'Nhân viên', CAST(N'2024-10-27T00:00:00.000' AS DateTime), N'Nam', N'\Data\PicNV\NV_11252024_194924.jpg')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi_NV], [SDT_NV], [ChucVu], [NgayVaoLam], [GioiTinh], [HinhAnh_NV]) VALUES (N'NV_11252024_195011                                ', N'Trần Văn B', CAST(N'2000-05-30T00:00:00.000' AS DateTime), N'Hậu Giang', N'1235678896', N'Quản lý', CAST(N'2020-02-26T00:00:00.000' AS DateTime), N'Nam', N'\Data\PicNV\NV_11252024_195011.jpg')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi_NV], [SDT_NV], [ChucVu], [NgayVaoLam], [GioiTinh], [HinhAnh_NV]) VALUES (N'NV_11252024_195529                                ', N'Lê Thị C', CAST(N'2003-12-30T00:00:00.000' AS DateTime), N'Sóc Trăng', N'1234567864', N'Nhân viên', CAST(N'2024-11-25T00:00:00.000' AS DateTime), N'Nữ', N'\Data\PicNV\NV_11252024_195529.jpg')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi_NV], [SDT_NV], [ChucVu], [NgayVaoLam], [GioiTinh], [HinhAnh_NV]) VALUES (N'NV_11262024_195631                                ', N'Võ Thị D', CAST(N'2024-11-26T00:00:00.000' AS DateTime), N'Vĩnh Long', N'6677558899', N'Nhân viên', CAST(N'2024-11-26T00:00:00.000' AS DateTime), N'N?', N'\Data\PicNV\NV_11262024_195631.jpg')
GO
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_202903                                ', N'Nhóm thuốc ho')
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_202911                                ', N'Nhóm thuốc theo toa bác sĩ')
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_202924                                ', N'Nhóm thuốc cảm ')
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_203101                                ', N'Nhóm kẹo ngậm vitaminC')
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_203438                                ', N'Nhóm thuốc da liễu')
INSERT [dbo].[NhomThuoc] ([MaNhomThuoc], [TenNhomThuoc]) VALUES (N'NT_11252024_203455                                ', N'Thuốc dị ứng')
GO
INSERT [dbo].[QLKho] ([MaKho], [TenKho], [NgayNhap], [NgayXuat], [GhiChu_Kho]) VALUES (N'QLK_11252024_200210                               ', N'Kho I', CAST(N'2024-02-25T00:00:00.000' AS DateTime), CAST(N'2024-11-25T00:00:00.000' AS DateTime), N'Nhập 2 thùng thuốc')
INSERT [dbo].[QLKho] ([MaKho], [TenKho], [NgayNhap], [NgayXuat], [GhiChu_Kho]) VALUES (N'QLK_11252024_200239                               ', N'Kho II', CAST(N'2024-07-28T00:00:00.000' AS DateTime), CAST(N'2024-10-29T00:00:00.000' AS DateTime), N'Nhập 2 lô thuốc')
GO
INSERT [dbo].[Thuoc] ([MaThuoc], [MaNCC], [MaNhomThuoc], [MaKho], [TenThuoc], [SoLuong], [NuocSX], [DVT], [DonGiaNhap], [DonGiaBan], [GhiChu_Thuoc]) VALUES (N'T_11252024_203116                                 ', N'NCC_11252024_202812                               ', N'NT_11252024_202924                                ', N'QLK_11252024_200239                               ', N'Panadol', 88, N'Việt Nam', N'Hộp', 50000, 60000, N'Bán theo hộp, vĩ')
INSERT [dbo].[Thuoc] ([MaThuoc], [MaNCC], [MaNhomThuoc], [MaKho], [TenThuoc], [SoLuong], [NuocSX], [DVT], [DonGiaNhap], [DonGiaBan], [GhiChu_Thuoc]) VALUES (N'T_11252024_203238                                 ', N'NCC_11252024_202731                               ', N'NT_11252024_203101                                ', N'QLK_11252024_200239                               ', N'Kẹo ngậm VitaminC', 5, N'Việt Nam', N'Bịch', 10000, 15000, N'')
INSERT [dbo].[Thuoc] ([MaThuoc], [MaNCC], [MaNhomThuoc], [MaKho], [TenThuoc], [SoLuong], [NuocSX], [DVT], [DonGiaNhap], [DonGiaBan], [GhiChu_Thuoc]) VALUES (N'T_11252024_203515                                 ', N'NCC_11252024_202731                               ', N'NT_11252024_203455                                ', N'QLK_11252024_200210                               ', N'Thuốc chống say tàu xe', 16, N'Hàn Quốc', N'Hộp', 100000, 120000, N'')
INSERT [dbo].[Thuoc] ([MaThuoc], [MaNCC], [MaNhomThuoc], [MaKho], [TenThuoc], [SoLuong], [NuocSX], [DVT], [DonGiaNhap], [DonGiaBan], [GhiChu_Thuoc]) VALUES (N'T_11252024_203654                                 ', N'NCC_11252024_202731                               ', N'NT_11252024_203438                                ', N'QLK_11252024_200210                               ', N'Kem bôi trị mụn', 994, N'Nhật Bản', N'Tuýt', 120000, 150000, N'')
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[Thuoc] ([MaThuoc])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDonBan] ([MaHD])
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK__HoaDonBan__MaKH__46E78A0C] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK__HoaDonBan__MaKH__46E78A0C]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK__HoaDonBan__MaNV__47DBAE45] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK__HoaDonBan__MaNV__47DBAE45]
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD  CONSTRAINT [FK__Thuoc__MaNCC__3D5E1FD2] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[Thuoc] CHECK CONSTRAINT [FK__Thuoc__MaNCC__3D5E1FD2]
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD FOREIGN KEY([MaNhomThuoc])
REFERENCES [dbo].[NhomThuoc] ([MaNhomThuoc])
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD  CONSTRAINT [FK_Thuoc_QLKho] FOREIGN KEY([MaKho])
REFERENCES [dbo].[QLKho] ([MaKho])
GO
ALTER TABLE [dbo].[Thuoc] CHECK CONSTRAINT [FK_Thuoc_QLKho]
GO
USE [master]
GO
ALTER DATABASE [QLThuoc] SET  READ_WRITE 
GO
