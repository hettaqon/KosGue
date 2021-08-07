CREATE PROCEDURE [dbo].[addKos]
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pJmlKamar int,
	@pFasilitas varchar(50),
	@pKodePetugas varchar int,
	@pKontak varchar(15)

AS
	INSERT INTO Kos(Nama, Alamat, JmlKamar, Fasilitas, KodePetugas, Kontak) VALUES (@pNama,@pAlamat,@pJmlKamar,@pFasilitas,@pKodePetugas,@pKontak);

GO

CREATE PROCEDURE [dbo].[deleteKos]
	@pKodeKos int
AS
	DELETE Kos
	WHERE KodeKos = @pKodeKos;

GO

CREATE PROCEDURE [dbo].[updateKos]
	@pKodeKos int,
	@pNama varchar(50),
	@pAlamat VARCHAR(50),
	@pJmlKamar int,
	@pFasilitas varchar(50),
	@pKodePetugas varchar int,
	@pKontak varchar(15)
AS
	UPDATE Kos
	SET Nama = @pNama, Alamat = @pAlamat, JmlKamar = @pJmlKamar, Fasilitas = @pFasilitas, KodePetugas = @pKodePetugas, Kontak = @pKontak 
	WHERE KodeKos = @pKodeKos;

go