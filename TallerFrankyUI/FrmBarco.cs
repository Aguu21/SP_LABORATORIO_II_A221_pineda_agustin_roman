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
        public FrmBarco(FrmPrincipal principal)
        {
            InitializeComponent();
            this.Principal = principal;
        }

        //Cargar los ComboBox con los datos de los Enum
        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(ETipoBarco));
            cmbOperacion.DataSource = Enum.GetValues(typeof(EOperacion));
        }


        //Envia una señal al FrmPrincipal para que agregue el barco instanciado
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if((ETipoBarco)cmbTipo.SelectedItem == ETipoBarco.Pirata)
            {
                Pirata p = new Pirata
                {
                    Costo = 0,
                    EstadoReparado = false,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = 0
                };
                DialogResult result = MessageBox.Show("¿Estás seguro?",
                    "Confirmación Barco", MessageBoxButtons.OK);
                Principal.Barco = p;
                Principal.AgregarBarco(result);
            }
            else if ((ETipoBarco)cmbTipo.SelectedItem == ETipoBarco.Marina)
            {
                Marina m = new Marina
                {
                    Costo = 0,
                    EstadoReparado = false,
                    Nombre = txtNombre.Text,
                    Operacion = (EOperacion)cmbOperacion.SelectedItem,
                    Tripulacion = 0
                };
                DialogResult result = MessageBox.Show("¿Estás seguro?",
                    "Confirmación Barco", MessageBoxButtons.OK);
                Principal.Barco = m;
                Principal.AgregarBarco(result);
            }
        }
     
    }
}
