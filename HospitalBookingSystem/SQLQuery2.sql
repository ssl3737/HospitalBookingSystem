USE [HBS]
GO

/****** Object: SqlProcedure [dbo].[stp_GetDoctorCategory] Script Date: 4/3/2017 9:29:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE dbo.stp_GetBooking @BookingDate DateTime, @BookingTime INT, @DoctorId output 
AS
SELECT *
FROM Booking AS b

EXCEPT

SELECT * 
FROM TemporaryBooking AS tb
WHERE tb.BookingDate = @BookingDate AND tb.BookingTime = @BookingTime AND b.DoctorId = @DoctorId


EXCEPT

SELECT d.FullName, d.Workingdays, c.FullName, cl.FullName, b.DoctorId
FROM Booking AS b
INNER JOIN Doctors AS d ON b.DoctorId = d.Id
INNER JOIN DoctorCategory AS dc ON dc.DoctorId = d.Id
INNER JOIN Categories AS c ON c.Id = dc.CategoryId
INNER JOIN Clinic AS cl ON cl.Id = d.ClinicId 
WHERE b.BookingDate = @BookingDate AND b.BookingTime = @BookingTime AND b.DoctorId = @DoctorId
