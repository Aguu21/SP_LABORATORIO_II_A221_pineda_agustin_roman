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
    //Muestra los barcos y permite repararlos a un costo.
    public partial class FrmReparacion : Form
    {
        Taller Taller { get; set; }
        public FrmReparacion(Taller taller)
        {
            Taller = taller;
            InitializeComponent();
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            //TODO: Asocio el evento que va a imprimir el ticket
            //TODO: Instanciar y comenzar el hilo que se va a encargar de reparar los barcos del taller
            ActualizarLista();
           
        }

        //Vacia y llena la lista con los barcos de Taller.
        public void ActualizarLista()
        {
            lstTaller.Items.Clear();
            List<string> lista = new List<string>();
            foreach (Barco b in Taller.Barcos)
            {
                lista.Add(b.ToString());
            }

            lstTaller.Items.AddRange(lista.ToArray());
        }

        //Emite un mensaje antes de salir que evita salir.
        private void FrmReparacion_FormClosing(object sender,
            FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir?", "Salir",
                MessageBoxButtons.YesNo);
            e.Cancel = result == DialogResult.No ? true : false;
        }

        private void lblBarcoTipo_Click(object sender, EventArgs e)
        {
            
        }

        //Boton implementado para ver en tiempo real el cambio de
        //las reparaciones. Los comentarios pedian el uso de hilos.
        private void btnReparar_Click(object sender, EventArgs e)
        {
            if (Taller.Reparar(Taller))
            {
                MessageBox.Show($"Si había barcos para reparar, " +
                    $"fueron reparados", "Reparar",
                    MessageBoxButtons.OK);
                ActualizarLista();
            }
            else
            {
                MessageBox.Show($"Un error impidió reparar los barcos",
                    "Error", MessageBoxButtons.OK);
            }
        }
    }
}
