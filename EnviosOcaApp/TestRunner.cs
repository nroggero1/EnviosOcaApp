using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnviosOcaApp.Models;
using EnviosOcaApp.Services;

namespace EnviosOcaApp
{
    public class TestRunner
    {
        public static async Task RunTest()
        {
            var settings = new AppSettings { OcaApiUrl = "https://webservice.oca.com.ar/epak_tracking/Oep_TrackEPak.asmx" };
            var service = new OcaRestService(settings);
            
            var empresa = new EmpresaConfig {
                Nombre = "Sancor",
                NroCuenta = "111757/001",
                CalleOrigen = "La Rioja",
                NumeroOrigen = "300",
                CpOrigen = "1215",
                LocalidadOrigen = "CAPITAL FEDERAL",
                ProvinciaOrigen = "CAPITAL FEDERAL",
                CentroCosto = "1"
            };

            var envios = new List<EnvioModel> {
                new EnvioModel {
                    IdOperativa = "283228",
                    Remito = "EnvioTest01",
                    NombreDestinatario = "Fernandez",
                    Calle = "BALCARCE",
                    Numero = "50",
                    Piso = "",
                    Localidad = "CAPITAL FEDERAL",
                    Provincia = "CAPITAL FEDERAL",
                    CP = "1214",
                    Email = "test@test.com",
                    Telefono = "123456",
                    Paquetes = new List<PaqueteModel> {
                        new PaqueteModel { Alto = 10, Ancho = 10, Largo = 10, Peso = 1, Valor = 0 }
                    }
                }
            };

            try {
                var res = await service.GenerarEnvioAsync(empresa, envios);
                Console.WriteLine("SUCCESS: " + res);
            } catch(Exception e) {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
