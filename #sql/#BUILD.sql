USE [master]
GO
/****** Object:  Database [KosGuev2_1]    Script Date: 09/01/2020 02:54:48 ******/
CREATE DATABASE [KosGuev2_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KosGuev2_1', FILENAME = N'E:\Db\KosGuev2_1.mdf' , SIZE = 10240KB , MAXSIZE = 61440KB , FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'KosGuev2_1_log', FILENAME = N'E:\Db\KosGuev2_1_log.ldf' , SIZE = 3072KB , MAXSIZE = 20480KB , FILEGROWTH = 1024KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KosGuev2_1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KosGuev2_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KosGuev2_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KosGuev2_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KosGuev2_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KosGuev2_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KosGuev2_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [KosGuev2_1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KosGuev2_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KosGuev2_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KosGuev2_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KosGuev2_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KosGuev2_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KosGuev2_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KosGuev2_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KosGuev2_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KosGuev2_1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KosGuev2_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KosGuev2_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KosGuev2_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KosGuev2_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KosGuev2_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KosGuev2_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KosGuev2_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KosGuev2_1] SET RECOVERY FULL 
GO
ALTER DATABASE [KosGuev2_1] SET  MULTI_USER 
GO
ALTER DATABASE [KosGuev2_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KosGuev2_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KosGuev2_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KosGuev2_1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KosGuev2_1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'KosGuev2_1', N'ON'
GO
ALTER DATABASE [KosGuev2_1] SET QUERY_STORE = OFF
GO
USE [KosGuev2_1]
GO
/****** Object:  Table [dbo].[Aduan]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aduan](
	[KodeAduan] [int] NOT NULL,
	[Judul] [varchar](50) NOT NULL,
	[Ket] [varchar](50) NULL,
	[TglAduan] [varchar](30) NOT NULL,
	[Kategori] [varchar](20) NULL,
	[NIK] [int] NOT NULL,
 CONSTRAINT [PK_Aduan] PRIMARY KEY CLUSTERED 
(
	[KodeAduan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[KodeBooking] [int] NOT NULL,
	[KodeKamar] [int] NOT NULL,
	[TglBooking] [varchar](30) NOT NULL,
	[TglHabis] [varchar](30) NOT NULL,
	[NIK] [int] NOT NULL,
	[KodeBayar] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[KodeBooking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kamar]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kamar](
	[KodeKamar] [int] NOT NULL,
	[Tipe] [varchar](10) NOT NULL,
	[Lokasi] [varchar](50) NOT NULL,
	[Fasilitas] [varchar](50) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[KodeKos] [int] NOT NULL,
 CONSTRAINT [PK_Kamar] PRIMARY KEY CLUSTERED 
(
	[KodeKamar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kos]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kos](
	[KodeKos] [int] NOT NULL,
	[Nama] [varchar](50) NOT NULL,
	[Alamat] [varchar](50) NOT NULL,
	[JmlKamar] [int] NOT NULL,
	[Fasilitas] [varchar](50) NULL,
	[KodePetugas] [int] NOT NULL,
	[Kontak] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Kos] PRIMARY KEY CLUSTERED 
(
	[KodeKos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pembayaran]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pembayaran](
	[KodeBayar] [int] NOT NULL,
	[TglBayar] [varchar](30) NOT NULL,
	[JmlBayar] [varchar](50) NOT NULL,
	[Bukti] [varchar](20) NULL,
	[Status] [varchar](20) NULL,
 CONSTRAINT [PK_Pembayaran] PRIMARY KEY CLUSTERED 
(
	[KodeBayar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penyewa]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penyewa](
	[NIK] [int] NOT NULL,
	[Nama] [varchar](50) NOT NULL,
	[Alamat] [varchar](50) NOT NULL,
	[NoHP] [varchar](15) NULL,
 CONSTRAINT [PK_Penyewa] PRIMARY KEY CLUSTERED 
(
	[NIK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Petugas]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Petugas](
	[KodePetugas] [int] NOT NULL,
	[Nama] [varchar](50) NOT NULL,
	[NoHP] [varchar](15) NOT NULL,
	[Job] [varchar](20) NOT NULL,
	[Shift] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Petugas] PRIMARY KEY CLUSTERED 
(
	[KodePetugas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aduan]  WITH CHECK ADD  CONSTRAINT [FK_Aduan_Penyewa] FOREIGN KEY([NIK])
REFERENCES [dbo].[Penyewa] ([NIK])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Aduan] CHECK CONSTRAINT [FK_Aduan_Penyewa]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Kamar] FOREIGN KEY([KodeKamar])
REFERENCES [dbo].[Kamar] ([KodeKamar])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Kamar]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Pembayaran] FOREIGN KEY([KodeBayar])
REFERENCES [dbo].[Pembayaran] ([KodeBayar])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Pembayaran]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Penyewa] FOREIGN KEY([NIK])
REFERENCES [dbo].[Penyewa] ([NIK])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Penyewa]
GO
ALTER TABLE [dbo].[Kamar]  WITH CHECK ADD  CONSTRAINT [FK_Kamar_Kos] FOREIGN KEY([KodeKos])
REFERENCES [dbo].[Kos] ([KodeKos])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kamar] CHECK CONSTRAINT [FK_Kamar_Kos]
GO
ALTER TABLE [dbo].[Kos]  WITH CHECK ADD  CONSTRAINT [FK_Kos_Petugas] FOREIGN KEY([KodePetugas])
REFERENCES [dbo].[Petugas] ([KodePetugas])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kos] CHECK CONSTRAINT [FK_Kos_Petugas]
GO
/****** Object:  StoredProcedure [dbo].[addAduan]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addAduan]
	@pKodeAduan int,
	@pJudul varchar(50),
	@pKet varchar(50),
	@pTglAduan VARCHAR(30),
	@pKategori varchar (20),
	@pNIK int
AS
	INSERT INTO Aduan(KodeAduan, Judul, Ket, TglAduan, Kategori, NIK) VALUES (@pKodeAduan,@pJudul,@pKet,@pTglAduan,@pKategori,@pNIK);

GO
/****** Object:  StoredProcedure [dbo].[addBooking]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addBooking]
	@pKodeBooking int,
	@pKodeKamar int,
	@pTglBooking VARCHAR(30),
	@pTglHabis varchar(30),
	@pNIK int,
	@pKodeBayar int

AS
	INSERT INTO Booking(KodeBooking, KodeKamar, TglBooking, TglHabis, NIK, KodeBayar) VALUES (@pKodeBooking,@pKodeKamar,@pTglBooking,@pTglHabis,@pNIK,@pKodeBayar);

GO
/****** Object:  StoredProcedure [dbo].[addKamar]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addKamar]
	@pKodeKamar int,
	@pTipe VARCHAR(10),
	@pLokasi varchar(50),
	@pFasilitas varchar (50),
	@pStatus varchar (20),
	@pKodeKos int

AS
	INSERT INTO Kamar(KodeKamar, Tipe, Lokasi, Fasilitas, Status, KodeKos) VALUES (@pKodeKamar,@pTipe,@pLokasi,@pFasilitas,@pStatus,@pKodeKos);

GO
/****** Object:  StoredProcedure [dbo].[addKos]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addKos]
	@pKodeKos int,
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pJmlKamar int,
	@pFasilitas varchar(50),
	@pKodePetugas int,
	@pKontak varchar(15)

AS
	INSERT INTO Kos(KodeKos, Nama, Alamat, JmlKamar, Fasilitas, KodePetugas, Kontak) VALUES (@pKodeKos,@pNama,@pAlamat,@pJmlKamar,@pFasilitas,@pKodePetugas,@pKontak);

GO
/****** Object:  StoredProcedure [dbo].[addPembayaran]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addPembayaran]
	@pKodeBayar int,
	@pTglBayar varchar(30),
	@pJmlBayar varchar(50),
	@pBukti VARCHAR(20),
	@pStatus varchar (20)
AS
	INSERT INTO Pembayaran(KodeBayar, TglBayar, JmlBayar, Bukti, Status) VALUES (@pKodeBayar,@pTglBayar,@pJmlBayar,@pBukti,@pStatus);

GO
/****** Object:  StoredProcedure [dbo].[addPenyewa]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addPenyewa]
	@pNIK int,
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pNoHP varchar(15)

AS
	INSERT INTO Penyewa(NIK, Nama, Alamat, NoHP) VALUES (@pNIK,@pNama,@pAlamat,@pNoHP);

GO
/****** Object:  StoredProcedure [dbo].[addPetugas]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addPetugas]
	@pKodePetugas int,
	@pNama varchar(50),
	@pNoHP varchar(15),
	@pJob VARCHAR(20),
	@pShift varchar (20)
AS
	INSERT INTO Petugas(KodePetugas,Nama, NoHP, Job, Shift) VALUES (@pKodePetugas,@pNama,@pNoHP,@pJob,@pShift);

GO
/****** Object:  StoredProcedure [dbo].[deleteAduan]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteAduan]
	@pKodeAduan int
AS
	DELETE Aduan
	WHERE KodeAduan = @pKodeAduan;

GO
/****** Object:  StoredProcedure [dbo].[deleteBooking]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteBooking]
	@pKodeBooking int
AS
	DELETE Booking
	WHERE KodeBooking = @pKodeBooking;

GO
/****** Object:  StoredProcedure [dbo].[deleteKamar]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteKamar]
	@pKodeKamar int
AS
	DELETE Kamar
	WHERE KodeKamar = @pKodeKamar;

GO
/****** Object:  StoredProcedure [dbo].[deleteKos]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteKos]
	@pKodeKos int
AS
	DELETE Kos
	WHERE KodeKos = @pKodeKos;

GO
/****** Object:  StoredProcedure [dbo].[deletePembayaran]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deletePembayaran]
	@pKodeBayar int
AS
	DELETE Pembayaran
	WHERE KodeBayar = @pKodeBayar;

GO
/****** Object:  StoredProcedure [dbo].[deletePenyewa]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deletePenyewa]
	@pNIK int
AS
	DELETE Penyewa
	WHERE NIK = @pNIK;

GO
/****** Object:  StoredProcedure [dbo].[deletePetugas]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deletePetugas]
	@pKodePetugas int
AS
	DELETE Petugas
	WHERE KodePetugas = @pKodePetugas;

GO
/****** Object:  StoredProcedure [dbo].[updateAduan]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updateAduan]
	@pKodeAduan int,
	@pJudul varchar(50),
	@pKet varchar(50),
	@pTglAduan VARCHAR(30),
	@pKategori varchar (20),
	@pNIK int
AS
	UPDATE Aduan
	SET Judul = @pJudul, Ket = @pKet, TglAduan = @pTglAduan, Kategori = @pKategori, NIK = @pNIK 
	WHERE KodeAduan = @pKodeAduan;

GO
/****** Object:  StoredProcedure [dbo].[updateBooking]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updateBooking]
	@pKodeBooking int,
	@pKodeKamar int,
	@pTglBooking VARCHAR(30),
	@pTglHabis varchar(30),
	@pNIK int,
	@pKodeBayar int
AS
	UPDATE Booking
	SET KodeKamar = @pKodeKamar, TglBooking = @pTglBooking, TglHabis = @pTglHabis, NIK = @pNIK, KodeBayar = @pKodeBayar 
	WHERE KodeBooking = @pKodeBooking;

GO
/****** Object:  StoredProcedure [dbo].[updateKamar]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updateKamar]
	@pKodeKamar int,
	@pTipe VARCHAR(10),
	@pLokasi varchar(50),
	@pFasilitas varchar (50),
	@pStatus varchar (20),
	@pKodeKos int
AS
	UPDATE Kamar
	SET Tipe = @pTipe, Lokasi = @pLokasi, Fasilitas = @pFasilitas, Status = @pStatus, KodeKos = @pKodeKos 
	WHERE KodeKamar = @pKodeKamar;

GO
/****** Object:  StoredProcedure [dbo].[updateKos]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updateKos]
	@pKodeKos int,
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pJmlKamar int,
	@pFasilitas varchar(50),
	@pKodePetugas int,
	@pKontak varchar(15)
AS
	UPDATE Kos
	SET Nama = @pNama, Alamat = @pAlamat, JmlKamar = @pJmlKamar, Fasilitas = @pFasilitas, KodePetugas = @pKodePetugas, Kontak = @pKontak 
	WHERE KodeKos = @pKodeKos;

GO
/****** Object:  StoredProcedure [dbo].[updatePembayaran]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updatePembayaran]
	@pKodeBayar int,
	@pTglBayar varchar(30),
	@pJmlBayar varchar(50),
	@pBukti VARCHAR(20),
	@pStatus varchar (20)
AS
	UPDATE Pembayaran
	SET TglBayar = @pTglBayar, JmlBayar = @pJmlBayar, Bukti = @pBukti, Status = @pStatus 
	WHERE KodeBayar = @pKodeBayar;

GO
/****** Object:  StoredProcedure [dbo].[updatePenyewa]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updatePenyewa]
	@pNIK int,
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pNoHP varchar(15)
AS
	UPDATE Penyewa
	SET Nama = @pNama, Alamat = @pAlamat, NoHP = @pNoHP 
	WHERE NIK = @pNIK;

GO
/****** Object:  StoredProcedure [dbo].[updatePetugas]    Script Date: 09/01/2020 02:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updatePetugas]
	@pKodePetugas int,
	@pNama varchar(50),
	@pNoHP varchar(15),
	@pJob VARCHAR(20),
	@pShift varchar (20)
AS
	UPDATE Petugas
	SET Nama = @pNama, NoHP = @pNoHP, Job = @pJob, Shift = @pShift 
	WHERE KodePetugas = @pKodePetugas;

GO
USE [master]
GO
ALTER DATABASE [KosGuev2_1] SET  READ_WRITE 
GO
