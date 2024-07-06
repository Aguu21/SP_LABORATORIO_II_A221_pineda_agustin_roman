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
        public Barco Barco { get; set; }
        public XmlManager Xml {  get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
            Taller = new Taller();
            Xml = new XmlManager();
        }

        //Agrega un barco a la lista dado un result ok
        public void AgregarBarco(DialogResult result)
        {
            if (!Taller.EncontrarBarco(Barco) && result == DialogResult.OK)
            {
                Taller.Barcos.Add(Barco);
            }
            
        }

        //Muestra el fomrulario de cargar barco.
        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco f = new FrmBarco(this);
            f.Show();
        }

        //Muestra el formulario de taller.
        private void btnReparar_Click(object sender, EventArgs e)
        {
            FrmReparacion f = new FrmReparacion(Taller);
            f.Show();
        }

        //Consulta antes de cerrar.
        private void FrmPrincipal_FormClosing(object sender, 
            FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir?", "Salir",
                MessageBoxButtons.YesNo);
            e.Cancel = result == DialogResult.No ? true : false;
        }

        //Guarda la lista en un archivo XML.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Taller.Barcos != null)
            {
                Xml.Guardar(Taller.Barcos, "../../../barcos.xml");
            }
            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //Carga la lista por archivo XML.
            string path = "../../../barcos.xml";
            if (File.Exists(path))
            {
                Taller.Barcos = Xml.Leer(path);
            }
        }
    }
}
