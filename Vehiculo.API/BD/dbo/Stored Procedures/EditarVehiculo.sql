-- =============================================
-- Author:		@Author,,Name
-- Create date: @Create Date,,
-- Description:	@Description,,
-- =============================================
CREATE PROCEDURE EditarVehiculo
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

	begin transaction
    -- Insert statements for procedure here
	UPDATE [dbo].[Vehiculo]
   SET [Id] = @Id
      ,[IdModelo] = @IdModelo
      ,[Placa] = @Placa
      ,[Color] = @Color
      ,[Anio] = @Anio
      ,[Precio] = @Precio
      ,[CorreoPropietario] = @CorreoPropietario
      ,[TelefonoPropietario] = @TelefonoPropietario
	WHERE Id = @Id
	select @Id
	commit transaction
END