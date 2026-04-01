using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class VehiculoFlujo : IVehiculoFlujo
    {
        private IVehiculoDa _vehiculoDa;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;

        public VehiculoFlujo(IVehiculoDa vehiculoDa, IRegistroReglas registroReglas, IRevisionReglas revisionReglas)
        {
            _vehiculoDa = vehiculoDa;
            _registroReglas = registroReglas;
            _revisionReglas = revisionReglas;
        }

        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            return await _vehiculoDa.Agregar(vehiculo);
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            return await _vehiculoDa.Editar(Id, vehiculo);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _vehiculoDa.Eliminar(Id);
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            return await _vehiculoDa.Obtener();
        }

        public async Task<VehiculoResponse> Obtener(Guid Id)
        {
            var vehiculo = await _vehiculoDa.Obtener(Id);
            vehiculo.RegistroValido = await _registroReglas.VehiculoEstaRegistrado(vehiculo.Placa, vehiculo.CorreoPropietario);
            vehiculo.RevisionValida = await _revisionReglas.RevisionEsValida(vehiculo.Placa);
            return vehiculo;
        }
    }
}
