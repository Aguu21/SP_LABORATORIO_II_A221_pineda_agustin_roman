using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Parcial.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    //Permite instanciar barcos y hacer que el FrmPrincipal los agregue.
    public partial class FrmBarco : Form
    {
        FrmPrincipal Principal { get; set; }
        bool Cargar { get; set; }
        Barco Barco { get; set; }

        public FrmBarco(FrmPrincipal principal)
        {
            InitializeComponent();
            Principal = principal;
            Cargar = true;
            Barco = null;
        }

        public FrmBarco(FrmPrincipal principal, Barco b)
        {
            InitializeComponent ();
            Principal = principal;
            Barco = b;
            Cargar = false;
        }

        //Cargar los ComboBox con los datos de los Enum
        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(ETipoBarco));
            cmbOperacion.DataSource = Enum.GetValues(typeof(EOperacion));
            if (!Cargar)
            {
                cmbOperacion.SelectedItem = Barco.Operacion;

                if (Barco is Pirata p)
                {
                    cmbTipo.SelectedItem = ETipoBarco.Pirata;
                }
                else if (Barco is Marina m)
                {
                    cmbTipo.SelectedItem = ETipoBarco.Marina;
                }
                txtNombre.Text = Barco.Nombre;
            }
        }


        //Envia una señal al FrmPrincipal para que agregue el barco instanciado
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (Cargar)
            {
                CargarBarco();
            }
            else
            {
                ActualizarBarco();
                this.Close();
            }
        }

        //Carga el barco.
        private void CargarBarco()
        {
            DialogResult result = DialogResult.None;
            if((ETipoBarco) cmbTipo.SelectedItem == ETipoBarco.Pirata)
            {
                Pirata p = new Pirata
                {
                    Costo = 0,
                    EstadoReparado = false,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = 0
                };
                Principal.Barco = p;
                Principal.AgregarBarco(result);
            }
            else if ((ETipoBarco) cmbTipo.SelectedItem == ETipoBarco.Marina)
            {
                Marina m = new Marina
                {
                    Costo = 0,
                    EstadoReparado = false,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = 0
                };
                Principal.Barco = m;
            }
            result = MessageBox.Show("¿Estás seguro?",
                    "Confirmación Barco", MessageBoxButtons.OKCancel);
            Principal.AgregarBarco(result);

            txtNombre.Text = "";
            cmbOperacion.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
        }

        //Actualiza el barco.
        private void ActualizarBarco()
        {
            DialogResult result = DialogResult.None;
            if ((ETipoBarco)cmbTipo.SelectedItem == ETipoBarco.Pirata)
            {
                Pirata p = new Pirata
                {
                    Costo = Barco.Costo,
                    EstadoReparado = Barco.EstadoReparado,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = Barco.Tripulacion
                };
                Principal.Barco = p;
            }
            else if ((ETipoBarco)cmbTipo.SelectedItem == ETipoBarco.Marina)
            {
                Marina m = new Marina
                {
                    Costo = Barco.Costo,
                    EstadoReparado = Barco.EstadoReparado,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = Barco.Tripulacion
                };
                Principal.Barco = m;
            }

            result = MessageBox.Show("¿Estás seguro?",
                    "Confirmación Barco", MessageBoxButtons.OKCancel);

            Principal.ActualizarBarco(result, Barco.Nombre);
        }
    }
}
