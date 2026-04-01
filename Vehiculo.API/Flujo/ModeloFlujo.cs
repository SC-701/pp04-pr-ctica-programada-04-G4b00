using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private IModeloDA _modeloDA;

        public ModeloFlujo(IModeloDA modeloDA)
        {
            _modeloDA = modeloDA;
        }

        public Task<IEnumerable<Modelo>> Obtener(Guid IdMarca)
        {
            return _modeloDA.Obtener(IdMarca);
        }
    }
}
