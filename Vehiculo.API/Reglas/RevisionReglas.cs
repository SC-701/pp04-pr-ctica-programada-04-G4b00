using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class RevisionReglas : IRevisionReglas
    {
        private readonly IRevisionServicio _revisionServicio;
        private readonly IConfiguracion _configuracion;

        public RevisionReglas(IRevisionServicio revisionServicio, IConfiguracion configuracion)
        {
            _revisionServicio = revisionServicio;
            _configuracion = configuracion;
        }

        public async Task<bool> RevisionEsValida(string placa)
        {
            var resultadoRevision = await _revisionServicio.Obtener(placa);
            return (ValidarEstado(resultadoRevision) && ValidarPeriodo(resultadoRevision.Periodo));
        }

        private bool ValidarEstado(Revision resultadoRevision)
        {
            string estadoRevision = _configuracion.ObtenerValor("EstadoRevisionSatisfactorio");
            return resultadoRevision.Resultado == estadoRevision;
        }


        private static bool ValidarPeriodo(string periodo)
        {
            var periodoActual = ObtenerPeriodoActual();
            return periodo == periodoActual;
        }

        private static string ObtenerPeriodoActual()
        {
            return $"{DateTime.Now.Month}-{DateTime.Now.Year}";
        }
    }
}
