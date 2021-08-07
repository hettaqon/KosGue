CREATE PROCEDURE [dbo].[addPembayaran]
	@pTglBayar varchar(30),
	@pJmlBayar varchar(50),
	@pBukti VARCHAR(20),
	@pStatus varchar (20)
AS
	INSERT INTO Pembayaran(TglBayar, JmlBayar, Bukti, Status) VALUES (@pTglBayar,@pJmlBayar,@pBukti,@pStatus);

GO

CREATE PROCEDURE [dbo].[deletePembayaran]
	@pKodeBayar int
AS
	DELETE Pembayaran
	WHERE KodeBayar = @pKodeBayar;

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

go

