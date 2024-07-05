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
    public partial class FrmBarco : Form
    {
        FrmPrincipal principal { get; set; }
        public FrmBarco(FrmPrincipal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            List<string> items = new List<string> { "Pirata", "Marina"};
            cmbTipo.DataSource = items;
            List<string> items2 = new List<string> { "Reparar_Mastil", 
                "Pintar", "Cambiar_Velas", "Reparar_Mascaron", "Repara_Casco",
                "Recargar_Cañones"};
            cmbOperacion.DataSource = items2;
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            if((string)cmbTipo.SelectedValue == "Pirata") 
            {
                Pirata p = new Pirata(0, false, (string)txtNombre.Text, EOperacion.Pintar, 0);
                DialogResult result = MessageBox.Show("Estas seguro?", "Asegurar", MessageBoxButtons.OK);
                principal.AñadirBarco(p, result);
            }
            else if((string)cmbTipo.SelectedValue == "Marina")
            {
                Marina m = new Marina(0, true, (string)txtNombre.Text, EOperacion.Pintar, 0);
                DialogResult result = MessageBox.Show("Estas seguro?", "Asegurar", MessageBoxButtons.OK);
                principal.AñadirBarco(m, result);
            }
            
        }
     
    }
}
