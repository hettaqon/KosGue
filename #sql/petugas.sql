CREATE PROCEDURE [dbo].[addPetugas]
	@pNama varchar(50),
	@pNoHP varchar(15),
	@pJob VARCHAR(20),
	@pShift varchar (20)
AS
	INSERT INTO Petugas(Nama, NoHP, Job, Shift) VALUES (@pNama,@pNoHP,@pJob,@pShift);

GO

CREATE PROCEDURE [dbo].[deletePetugas]
	@pKodePetugas int
AS
	DELETE Petugas
	WHERE KodePetugas = @pKodePetugas;

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

go

