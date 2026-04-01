using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IVehiculoDa
    {
        Task<IEnumerable<VehiculoResponse>> Obtener();
        Task<VehiculoDetalle> Obtener(Guid Id);
        Task<Guid> Agregar(VehiculoRequest vehiculo);
        Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo);
        Task<Guid> Eliminar(Guid Id);
    }
}
