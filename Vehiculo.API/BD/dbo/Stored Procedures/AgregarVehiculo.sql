-- =============================================
-- Author:		@Author,,Name
-- Create date: @Create Date,,
-- Description:	@Description,,
-- =============================================
CREATE PROCEDURE AgregarVehiculo
	@Id as uniqueidentifier
	,@IdModelo as uniqueidentifier
	,@Placa as varchar(max)
	,@Color as varchar(max)
	,@Anio as int
	,@Precio as decimal
	,@CorreoPropietario as varchar(max)
	,@TelefonoPropietario as varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Begin Transaction
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Vehiculo]
           ([Id]
           ,[IdModelo]
           ,[Placa]
           ,[Color]
           ,[Anio]
           ,[Precio]
           ,[CorreoPropietario]
           ,[TelefonoPropietario])
     VALUES
           (@Id
           ,@IdModelo
           ,@Placa
           ,@Color
           ,@Anio
           ,@Precio
           ,@CorreoPropietario
           ,@TelefonoPropietario)
    SELECT @Id
    commit Transaction
END