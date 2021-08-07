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

CREATE PROCEDURE [dbo].[deleteKamar]
	@pKodeKamar int
AS
	DELETE Kamar
	WHERE KodeKamar = @pKodeKamar;

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
	SET KodeKamar = @pKodeKamar, Tipe = @pTipe, Lokasi = @pLokasi, Fasilitas = @pFasilitas, Status = @pStatus, KodeKos = @pKodeKos 
	WHERE KodeKamar = @pKodeKamar;

go