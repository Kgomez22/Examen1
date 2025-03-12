using Examen1.clases;
using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Examen1.Controllers
{
    [RoutePrefix("api/vehiculo")]
    public class VehiculoController : ApiController
    {
        [HttpGet]
        public async Task<List<VEHICULO>> GetAll()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            var result = new List<VEHICULO>();
            return await vehiculo.ConsultarTodos();
        }

        [HttpGet]
        [Route("consultar/{id}")]
        public VEHICULO Get(int id) 
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(id);
        }

        [HttpPost]
        [Route("crear")]
        public string Post([FromBody]VEHICULO vh) 
        {
            clsVehiculo vehiculo = new clsVehiculo();
            vehiculo.vehiculo = vh;
            return vehiculo.Insertar();
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public string Delete(int id)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            vehiculo.vehiculo = new VEHICULO();
            vehiculo.vehiculo.NUMERO_MOTOR = id;
            return vehiculo.Eliminar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string Update([FromBody] VEHICULO vh)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            vehiculo.vehiculo = vh;
            return vehiculo.Actualizar();
        }
    }
}
