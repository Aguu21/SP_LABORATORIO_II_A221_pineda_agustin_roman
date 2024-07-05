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

        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
               
        }

        private void btnReparar_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: Preguntarle al usuario si esta seguro de salir del formulario
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Xml
            //TODO: Utilizar la clase XmlManager para guardar el archivo xml
           
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
