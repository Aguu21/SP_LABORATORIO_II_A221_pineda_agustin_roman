using Parcial.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    public partial class FrmReparacion : Form
    {
        Taller Taller { get; set; }
        public FrmReparacion(Taller taller)
        {
            this.Taller = taller;
            InitializeComponent();
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            //TODO: Asocio el evento que va a imprimir el ticket
            //TODO: Instanciar y comenzar el hilo que se va a encargar de reparar los barcos del taller
            List<string> lista = new List<string>();
            foreach(Barco b in Taller.Barcos)
            {
                lista.Add(b.ToString());
            }
            
            lstTaller.Items.AddRange(lista.ToArray());
           
        }

        private void FrmReparacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir?", "Salir",
                MessageBoxButtons.YesNo);
            e.Cancel = result == DialogResult.No ? true : false;
        }

        private void lblBarcoTipo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola", "Que haces", MessageBoxButtons.OK);
        }
    }
}
