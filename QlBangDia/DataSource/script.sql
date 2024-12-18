USE [master]
GO
/****** Object:  Database [QLBangDia]    Script Date: 12/2/2024 2:50:13 PM ******/
CREATE DATABASE [QLBangDia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBangDia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBangDia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBangDia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLBangDia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLBangDia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBangDia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBangDia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBangDia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBangDia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBangDia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBangDia] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBangDia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBangDia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBangDia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBangDia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBangDia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBangDia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBangDia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBangDia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBangDia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBangDia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBangDia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBangDia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBangDia] SET TRUSTWORTHY ON 
GO
ALTER DATABASE [QLBangDia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBangDia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBangDia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBangDia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBangDia] SET RECOVERY FULL 
GO
ALTER DATABASE [QLBangDia] SET  MULTI_USER 
GO
ALTER DATABASE [QLBangDia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBangDia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBangDia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBangDia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBangDia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLBangDia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLBangDia', N'ON'
GO
ALTER DATABASE [QLBangDia] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLBangDia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLBangDia]
GO
/****** Object:  Table [dbo].[BangDia]    Script Date: 12/2/2024 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDia](
	[MaBangDia] [int] IDENTITY(1,1) NOT NULL,
	[TenBangDia] [nvarchar](200) NOT NULL,
	[TheLoai] [nvarchar](100) NULL,
	[GiaMoiNgay] [decimal](10, 2) NOT NULL,
	[TienCoc] [decimal](10, 2) NOT NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__BangDia__5A6C603DBCDD1253] PRIMARY KEY CLUSTERED 
(
	[MaBangDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuMuon]    Script Date: 12/2/2024 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[MaChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuMuon] [int] NOT NULL,
	[MaBangDia] [int] NOT NULL,
	[SoNgayMuon] [int] NOT NULL,
	[GiaThue] [decimal](10, 2) NOT NULL,
	[TienCoc] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 12/2/2024 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](100) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[SoDienThoai] [varchar](15) NULL,
	[VaiTro] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 12/2/2024 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[MaPhieuMuon] [int] IDENTITY(1,1) NOT NULL,
	[TenNguoiMuon] [nvarchar](150) NOT NULL,
	[NgayMuon] [datetime] NOT NULL,
	[TongTienCoc] [decimal](10, 2) NULL,
	[TongTienThue] [decimal](10, 2) NULL,
	[NgayTra] [datetime] NULL,
	[TrangThai] [nvarchar](50) NOT NULL,
	[MaBangDia] [int] NOT NULL,
 CONSTRAINT [PK__PhieuMuo__C4C82222EFF2C2BE] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTra]    Script Date: 12/2/2024 2:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTra](
	[MaPhieuTra] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuMuon] [int] NOT NULL,
	[NgayTra] [datetime] NOT NULL,
	[TongTien] [decimal](10, 2) NOT NULL,
	[PhiTraMuon] [decimal](10, 2) NULL,
 CONSTRAINT [PK__PhieuTra__1D880A468C0F6765] PRIMARY KEY CLUSTERED 
(
	[MaPhieuTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BangDia] ON 

INSERT [dbo].[BangDia] ([MaBangDia], [TenBangDia], [TheLoai], [GiaMoiNgay], [TienCoc], [TrangThai]) VALUES (1, N'Băng lậu', N'Hoạt hình', CAST(10000.00 AS Decimal(10, 2)), CAST(5000.00 AS Decimal(10, 2)), N'Hoạt động')
INSERT [dbo].[BangDia] ([MaBangDia], [TenBangDia], [TheLoai], [GiaMoiNgay], [TienCoc], [TrangThai]) VALUES (2, N'ưdwdw3r3r3', N'Hoạt hình', CAST(232.00 AS Decimal(10, 2)), CAST(23.00 AS Decimal(10, 2)), N'Hoạt động')
INSERT [dbo].[BangDia] ([MaBangDia], [TenBangDia], [TheLoai], [GiaMoiNgay], [TienCoc], [TrangThai]) VALUES (4, N'Đĩa mới 1', N'Phim ảnh', CAST(10000.00 AS Decimal(10, 2)), CAST(2000.00 AS Decimal(10, 2)), N'Hoạt động')
SET IDENTITY_INSERT [dbo].[BangDia] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [HoTen], [SoDienThoai], [VaiTro]) VALUES (1, N'Admin', N'123', N'Admin', N'113', N'Admin')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuMuon] ON 

INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [TenNguoiMuon], [NgayMuon], [TongTienCoc], [TongTienThue], [NgayTra], [TrangThai], [MaBangDia]) VALUES (1, N'e2e2e2rgrgrg', CAST(N'2024-12-02T12:49:53.000' AS DateTime), CAST(24344.00 AS Decimal(10, 2)), CAST(342442.00 AS Decimal(10, 2)), CAST(N'2024-12-12T12:49:53.000' AS DateTime), N'Đã mượn', 1)
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [TenNguoiMuon], [NgayMuon], [TongTienCoc], [TongTienThue], [NgayTra], [TrangThai], [MaBangDia]) VALUES (3, N'Nguyễn Văn A', CAST(N'2024-12-10T14:06:53.000' AS DateTime), CAST(2000.00 AS Decimal(10, 2)), CAST(20000.00 AS Decimal(10, 2)), CAST(N'2024-12-21T14:06:53.000' AS DateTime), N'Đã mượn', 4)
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [TenNguoiMuon], [NgayMuon], [TongTienCoc], [TongTienThue], [NgayTra], [TrangThai], [MaBangDia]) VALUES (4, N'vềwfwe', CAST(N'2024-12-02T14:09:21.457' AS DateTime), CAST(232.00 AS Decimal(10, 2)), CAST(2323.00 AS Decimal(10, 2)), CAST(N'2024-12-02T14:09:21.440' AS DateTime), N'Đã mượn', 1)
SET IDENTITY_INSERT [dbo].[PhieuMuon] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuTra] ON 

INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuMuon], [NgayTra], [TongTien], [PhiTraMuon]) VALUES (2, 1, CAST(N'2024-12-03T13:27:08.000' AS DateTime), CAST(34343.00 AS Decimal(10, 2)), CAST(9.00 AS Decimal(10, 2)))
INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuMuon], [NgayTra], [TongTien], [PhiTraMuon]) VALUES (3, 1, CAST(N'2024-12-02T13:46:44.833' AS DateTime), CAST(3434.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[PhieuTra] ([MaPhieuTra], [MaPhieuMuon], [NgayTra], [TongTien], [PhiTraMuon]) VALUES (4, 3, CAST(N'2024-12-10T14:07:58.000' AS DateTime), CAST(21000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[PhieuTra] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NguoiDun__55F68FC04C02E2F3]    Script Date: 12/2/2024 2:50:13 PM ******/
ALTER TABLE [dbo].[NguoiDung] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BangDia] ADD  CONSTRAINT [DF__BangDia__TrangTh__5812160E]  DEFAULT ('CoSan') FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuMuon] ADD  CONSTRAINT [DF__PhieuMuon__NgayM__5BE2A6F2]  DEFAULT (getdate()) FOR [NgayMuon]
GO
ALTER TABLE [dbo].[PhieuMuon] ADD  CONSTRAINT [DF__PhieuMuon__Trang__5CD6CB2B]  DEFAULT ('DangMuon') FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuTra] ADD  CONSTRAINT [DF__PhieuTra__NgayTr__5165187F]  DEFAULT (getdate()) FOR [NgayTra]
GO
ALTER TABLE [dbo].[PhieuTra] ADD  CONSTRAINT [DF__PhieuTra__PhiTra__52593CB8]  DEFAULT ((0)) FOR [PhiTraMuon]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__MaBan__60A75C0F] FOREIGN KEY([MaBangDia])
REFERENCES [dbo].[BangDia] ([MaBangDia])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK__ChiTietPh__MaBan__60A75C0F]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__MaPhi__5FB337D6] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK__ChiTietPh__MaPhi__5FB337D6]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_BangDia] FOREIGN KEY([MaBangDia])
REFERENCES [dbo].[BangDia] ([MaBangDia])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_BangDia]
GO
ALTER TABLE [dbo].[PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK__PhieuTra__MaPhie__6383C8BA] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[PhieuTra] CHECK CONSTRAINT [FK__PhieuTra__MaPhie__6383C8BA]
GO
USE [master]
GO
ALTER DATABASE [QLBangDia] SET  READ_WRITE 
GO
USE QLBangDia 
GO 
ALTER DATABASE QLBangDia set TRUSTWORTHY ON; 
GO 
EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false 
GO 
sp_configure 'show advanced options', 1; 
GO 
RECONFIGURE; 
GO 
sp_configure 'clr enabled', 1; 
GO 
RECONFIGURE; 
GO