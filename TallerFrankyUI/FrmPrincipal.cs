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
    //El form con todas las funciones principales.
    public partial class FrmPrincipal : Form
    {
        public Taller Taller { get; set; }
        public Barco Barco { get; set; }
        public XmlManager Xml { get; set; }

        List<FrmReparacion> Formularios {get; set;}

        public EModo Modo { get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
            Taller = new Taller();
            Xml = new XmlManager();
            Modo = new EModo();
            Formularios = new List<FrmReparacion>();
        }

        //Actualiza los forms que haya abiertos.
        private void ActualizarForms()
        {
            foreach (FrmReparacion form in Formularios)
            {
                form.ActualizarLista();
            }
            MessageBox.Show("Datos actualizados correctamente", "Datos",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Elimina un FrmReparacion de la lista.
        public void SacarForm(FrmReparacion form)
        {
            Formularios.Remove(form);
        }

        //Agrega un barco a la lista dado un result ok.
        public void AgregarBarco(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                if (Modo == EModo.Sql && !Taller.EncontrarBarco(Barco))
                {
                    AccesoDatos.GuardarBarco(Barco);
                }
                Taller.IngresarBarco(Barco);
                ActualizarForms();
            }
        }

        //Actualiza un barco en la lista dado un result ok.
        public void ActualizarBarco(DialogResult result, string nombreViejo)
        {
            if (result == DialogResult.OK)
            {
                if (Modo == EModo.Sql)
                {
                    AccesoDatos.ActualizarBarco(Barco, nombreViejo);
                }
                Taller.ActualizarBarco(Barco, nombreViejo);
                ActualizarForms();
            }
        }

        //Borra un barco en la lista dado un result yes.
        public void BorrarBarco(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                if (Modo == EModo.Sql)
                {
                    AccesoDatos.BorrarBarco(Barco.Nombre);
                }
                Taller.BorrarBarco(Barco);
                ActualizarForms();
            }
        }

        //Muestra el formulario de cargar barco.
        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco f = new FrmBarco(this);
            f.Show();
        }

        //Muestra el formulario de taller.
        private void btnReparar_Click(object sender, EventArgs e)
        {
            FrmReparacion f = new FrmReparacion(this, Taller, Modo);
            Formularios.Add(f);
            f.Show();
        }

        //Consulta antes de cerrar.
        private void FrmPrincipal_FormClosing(object sender, 
            FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = result == DialogResult.No ? true : false;
        }

        //Guarda la lista en un archivo XML.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Taller.Barcos != null)
                {
                    Xml.Guardar(Taller.Barcos, "../../../barcos.xml");
                }
                MessageBox.Show("Se guardó con éxito la lista.", 
                    "Guardar Lista", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //Se determina en que modo se inciará el programa.
            DialogResult result = MessageBox.Show("¿Desea iniciar en el " +
                "modo SQL? Si presiona 'No' se utilizará el modo XML", "Modo",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (AccesoDatos.IntentarConexion())
                {
                    Modo = EModo.Sql;
                }
                else
                {
                    MessageBox.Show($"La base de datos es inaccesible, " +
                        $"se inició en modo XML", "Modo",MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    Modo = EModo.Xml;
                }
            }
            else { Modo = EModo.Xml; }

            //Determina como se debe llenar la lista.
            if (Modo == EModo.Xml)
            {
                string path = "../../../barcos.xml";
                if (File.Exists(path))
                {
                    Taller.Barcos = Xml.Leer(path);
                }
            }
            else if (Modo == EModo.Sql)
            {    
                Taller.Barcos = AccesoDatos.LeerBarcos();   
            }
            
        }
    }
}
