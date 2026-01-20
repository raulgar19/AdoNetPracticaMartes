using AdoNetPracticaMartes.Helpers;
using AdoNetPracticaMartes.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

#region PROCEDURES
//create procedure SP_ALL_HOSPITALES
//as
//	select * from HOSPITAL
//go

//CREATE PROCEDURE SP_ALL_EMPLEADOS_HOSPITAL
//    @nombreHospital nvarchar(50),
//    @totalEmpleados int OUTPUT,
//    @sumaSalarios int OUTPUT,
//    @mediaSalarios int OUTPUT
//AS
//BEGIN
//    SET NOCOUNT ON;

//DECLARE @hospitalCod int;

//SELECT @hospitalCod = HOSPITAL_COD 
//    FROM HOSPITAL 
//    WHERE NOMBRE = @nombreHospital;

//DECLARE @DatosEmpleados TABLE (
//        APELLIDO nvarchar(50),
//    OFICIO nvarchar(50),
//    SALARIO int,
//    TIPO nvarchar(20)
//    );

//INSERT INTO @DatosEmpleados
//    SELECT APELLIDO, ESPECIALIDAD, SALARIO, 'DOCTOR'
//    FROM DOCTOR WHERE HOSPITAL_COD = @hospitalCod
//    UNION ALL
//    SELECT APELLIDO, FUNCION, SALARIO, 'PLANTILLA'
//    FROM PLANTILLA WHERE HOSPITAL_COD = @hospitalCod;

//SELECT
//    @totalEmpleados = COUNT(*),
//    @sumaSalarios = ISNULL(SUM(SALARIO), 0),
//    @mediaSalarios = ISNULL(AVG(SALARIO), 0)
//    FROM @DatosEmpleados;

//SELECT* FROM @DatosEmpleados;
//END
//GO
#endregion

namespace AdoNetPracticaMartes.Repositories
{
    public class RepositoryHospitales
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospitales() 
        {
            IConfigurationRoot configuration =  HelperConfiguration.GetConfiguration();
            this.cn = new SqlConnection(configuration.GetConnectionString("SqlLocal"));
            this.com = new SqlCommand();
            this.com.Connection = cn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "SP_ALL_HOSPITALES";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            
            this.reader = await this.com.ExecuteReaderAsync();

            List<Hospital> hospitales = new List<Hospital>();

            while(await this.reader.ReadAsync())
            {
                Hospital hospital = new Hospital();
                hospital.HospitalCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre= this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());

                hospitales.Add(hospital);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return hospitales;
        }

        public async Task<EmpleadosModel> GetEmpleadosModelAsync(string nombre)
        {
            string sql = "SP_ALL_EMPLEADOS_HOSPITAL";
            SqlParameter pamNombre = new SqlParameter("@nombreHospital", nombre);
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@sumaSalarios";
            pamSuma.Direction = ParameterDirection.Output;
            pamSuma.SqlDbType = SqlDbType.Int;
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@mediaSalarios";
            pamMedia.Direction = ParameterDirection.Output;
            pamMedia.SqlDbType = SqlDbType.Int;
            SqlParameter pamEmpleados = new SqlParameter();
            pamEmpleados.ParameterName = "@totalEmpleados";
            pamEmpleados.Direction = ParameterDirection.Output;
            pamEmpleados.SqlDbType = SqlDbType.Int;

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamSuma);
            this.com.Parameters.Add(pamMedia);
            this.com.Parameters.Add(pamEmpleados);

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            EmpleadosModel model = new EmpleadosModel();
            List<Empleado> empleados = new List<Empleado>();

            while (await this.reader.ReadAsync())
            {
                Empleado empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = int.Parse(this.reader["SALARIO"].ToString());
                empleado.Tipo = this.reader["TIPO"].ToString();

                empleados.Add(empleado);
            }

            await this.reader.CloseAsync();

            model.Empleados = empleados;
            model.Suma = int.Parse(pamSuma.Value.ToString());
            model.Media = int.Parse(pamMedia.Value.ToString());
            model.Personas = int.Parse(pamEmpleados.Value.ToString());

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return model;
        }
    }
}
