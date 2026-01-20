using AdoNetPracticaMartes.Models;
using AdoNetPracticaMartes.Repositories;

namespace AdoNetPracticaMartes
{
    public partial class Form1 : Form
    {
        RepositoryHospitales repo;

        public Form1()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitales();
            this.LoadHospitales();
        }

        private async void LoadHospitales()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();

            foreach (Hospital hospital in hospitales)
            {
                this.cmbHospitales.Items.Add(hospital.Nombre);
            }

        }

        private async void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.cmbHospitales.Text;
            EmpleadosModel model = await this.repo.GetEmpleadosModelAsync(nombre);

            lstEmpleados.Items.Clear();

            foreach (Empleado empleado in model.Empleados)
            {
                this.lstEmpleados.Items.Add(empleado.Apellido + " - " + empleado.Oficio + " - " + empleado.Salario);
            }

            this.txtSuma.Text = model.Suma.ToString();
            this.txtMedia.Text = model.Media.ToString();
            this.txtPersonas.Text = model.Personas.ToString();
        }
    }
}