CREATE PROCEDURE [dbo].[addPenyewa]
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pNoHP varchar(15)

AS
	INSERT INTO Penyewa(Nama, Alamat, NoHP) VALUES (@pNama,@pAlamat,@pNoHP);

GO

CREATE PROCEDURE [dbo].[deletePenyewa]
	@pNIK int
AS
	DELETE Penyewa
	WHERE NIK = @pNIK;

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

go