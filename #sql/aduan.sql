CREATE PROCEDURE [dbo].[addAduan]
	@pJudul varchar(50),
	@pKet varchar(50),
	@pTglAduan VARCHAR(30),
	@pKategori varchar (20),
	@pNIK varchar (10)
AS
	INSERT INTO Aduan(Judul, Ket, TglAduan, Kategori, NIK) VALUES (@pJudul,@pKet,@pTglAduan,@pKategori,@pNIK);

GO

CREATE PROCEDURE [dbo].[deleteAduan]
	@pKodeAduan int
AS
	DELETE Aduan
	WHERE KodeAduan = @pKodeAduan;

GO

CREATE PROCEDURE [dbo].[updateAduan]
	@pKodeAduan int,
	@pJudul varchar(50),
	@pKet varchar(50),
	@pTglAduan VARCHAR(30),
	@pKategori varchar (20),
	@pNIK varchar (10)
AS
	UPDATE Aduan
	SET Judul = @pJudul, Ket = @pKet, TglAduan = @pTglAduan, Kategori = @pKategori, NIK = @pNIK 
	WHERE KodeAduan = @pKodeAduan;

go