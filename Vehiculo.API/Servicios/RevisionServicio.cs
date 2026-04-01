using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;
using System.Text.Json;
using System.Net.Http;


namespace Servicios
{
    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RevisionServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Revision> Obtener(string placa)
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointRevision", "ObtenerRevision");
            var servicioRegistro = _httpClient.CreateClient("ServicioRevision");
            var respuesta = await servicioRegistro.GetAsync(string.Format(endpoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
