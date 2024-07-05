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
using System.IO;
using MySqlX.XDevAPI.Common;

namespace TallerFrankyUi
{
    public partial class FrmPrincipal : Form
    {
        public Taller Taller { get; set; }
        public XmlManager Xml {  get; set; }
        public FrmPrincipal()
        {
            InitializeComponent();
            Taller = new Taller();
        }

        public void AñadirBarco(Barco barco, DialogResult result)
        {
            if (!Taller.EncontrarBarco(barco) && result == DialogResult.OK) 
            {
                Taller.Barcos.Add(barco);
            }
            
        }
        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco f = new FrmBarco(this);
            f.Show();

        }

        private void btnReparar_Click(object sender, EventArgs e)
        {
            FrmReparacion f = new FrmReparacion(Taller);
            f.Show();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea salir?", "Salir", MessageBoxButtons.YesNo);
           if(result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Xml.Guardar(Taller.Barcos, "prueba.xml");           
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string path = "archivo.xml";
            if (File.Exists(path))
            {
                Taller.Barcos = Xml.Leer(path);
            }
        }
    }
}
