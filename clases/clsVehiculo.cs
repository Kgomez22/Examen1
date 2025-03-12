using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Examen1.clases
{
    public class clsVehiculo
    {
        public ITM_VentasEntities Ventas = new ITM_VentasEntities();

        public VEHICULO vehiculo { get; set; }

        public string insertar()
        {
            Ventas.VEHICULOes.Add(vehiculo);
            Ventas.SaveChanges();
            return "vehiculo agregado correctamente";
        }


        public  string Insertar()
        {
            try
            {
                Ventas.VEHICULOes.Add(vehiculo);
                Ventas.SaveChanges();
                return "vehiculo agregado correctamente";
            }
            catch (Exception ex) 
            {
                return "Error al insertar el Vehiculo ";
            }
        }


        public string Actualizar()
        {
            VEHICULO vEHICULO = new VEHICULO();
            if (vEHICULO == null) 
            {
                return "El Vehiculo no es valido";
            }
            Ventas.VEHICULOes.AddOrUpdate(vehiculo);// actualiza un empleado en la tabla empleado
            Ventas.SaveChanges(); //guarda los cambios en la base de datos
            return " Se actualizao el Vehiculo correctamente"; //mensaje de confirmacion
        }

        public VEHICULO Consultar(int NUMERO_MOTOR)
        {
            VEHICULO Veh = Ventas.VEHICULOes.FirstOrDefault(e => e.NUMERO_MOTOR == NUMERO_MOTOR);
            return Veh; 
        }

        public async Task<List<VEHICULO>> ConsultarTodos() 
        {
            var list = await Ventas.VEHICULOes.ToListAsync();
            return list;

        }

        public string Eliminar()
        {
            try
            {
                //se debe consultar si exite el empleado
                var ve = Consultar(vehiculo.NUMERO_MOTOR); //consultamos
                if (ve == null)
                {
                    return "El vehiculo no existe";
                }
                Ventas.VEHICULOes.Remove(ve);
                Ventas.SaveChanges();
                return "Se elimino correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}