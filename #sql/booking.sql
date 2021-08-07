CREATE PROCEDURE [dbo].[addBooking]
	@pKodeKamar int,
	@pTglBooking VARCHAR(30),
	@pTglHabis varchar(30),
	@pNIK varchar (10),
	@pKodeBayar varchar (20)

AS
	INSERT INTO Booking(KodeKamar, TglBooking, TglHabis, NIK, KodeBayar) VALUES (@pKodeKamar,@pTglBooking,@pTglHabis,@pNIK,@pKodeBayar);

GO

CREATE PROCEDURE [dbo].[deleteBooking]
	@pKodeBooking int
AS
	DELETE Booking
	WHERE KodeBooking = @pKodeBooking;

GO

CREATE PROCEDURE [dbo].[updateBooking]
	@pKodeBooking int,
	@pKodeKamar int,
	@pTglBooking VARCHAR(30),
	@pTglHabis varchar(30),
	@pNIK varchar (10),
	@pKodeBayar varchar (20)
AS
	UPDATE Booking
	SET KodeKamar = @pKodeKamar, TglBooking = @pTglBooking, TglHabis = @pTglHabis, NIK = @pNIK, KodeBayar = @pKodeBayar 
	WHERE KodeBooking = @pKodeBooking;

go