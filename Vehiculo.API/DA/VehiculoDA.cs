using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class VehiculoDA : IVehiculoDa
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones

        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await VerificarVehiculoExistente(Id);

            string query = @"EditarVehiculo";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });

            return resultadoConsulta;
        }


        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarVehiculoExistente(Id);

            string query = @"EliminarVehiculo";
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                return Guid.Empty;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid()
            });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultadoConsulta;
        }

        public async Task<VehiculoDetalle> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculo";
            var resultadoConsulta = await _sqlConnection.QueryAsync<VehiculoDetalle>(query, new
            {
                Id = Id
            });
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task VerificarVehiculoExistente(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontro el vehiculo");
        }
        #endregion
    }
}
