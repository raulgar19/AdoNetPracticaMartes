using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetPracticaMartes.Models
{
    public class EmpleadosModel
    {
        public List<Empleado> Empleados { get; set; }
        public int Suma { get; set; }
        public int Media { get; set; }
        public int Personas { get; set; }

        public EmpleadosModel()
        {
            this.Empleados = new List<Empleado>();
        }
    }
}