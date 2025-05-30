﻿using Parcial.WindowsForm;
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
        FrmPrincipal Principal { get; set; }
        Taller Taller { get; set; }
        public FrmReparacion(FrmPrincipal principal, Taller taller)
        {
            Principal = principal;
            Taller = taller;
            InitializeComponent();
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
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
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = result == DialogResult.No ? true : false;
            Principal.SacarForm(this);
        }

        //Boton implementado para ver en tiempo real el cambio de
        //las reparaciones. Los comentarios pedian el uso de hilos.
        private void btnReparar_Click(object sender, EventArgs e)
        {
            if (!AccesoDatos.IntentarConexion())
            {
                MessageBox.Show("La base de datos está " +
                    "cerrada", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

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

        //Intenta modificar un barco.
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = lstTaller.SelectedIndex;
            if (IndexVacio(index))
            {
                return;
            }
            FrmBarco f = new FrmBarco(Principal, Taller.Barcos[index]);
            f.Show();
        }

        //Intenta modificar un barco.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = lstTaller.SelectedIndex;
            if (IndexVacio(index))
            {
                return;
            }
            Principal.Barco = Taller.Barcos[index];
            DialogResult result = MessageBox.Show("¿Está seguro que desea " +
                "eliminar el barco seleccionado?", "Borrar", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Principal.BorrarBarco(result);
        }

        //Revisa si el index tiene valor de no seleccionado.
        private bool IndexVacio(int index)
        {
            if (index == -1)
            {
                MessageBox.Show("Por favor seleccione un barco", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
