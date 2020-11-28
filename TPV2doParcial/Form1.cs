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

namespace TPV2doParcial
{
    public partial class Form1 : Form
    {
        //VARIABLES
            public string LOCALIDADINVENTARIO;
            public string installoption;
            public string LOCALIDADBASE;
            public string installport;
            public string installaddress;
            public string installpassword;
            public string installredundancia;
            public bool val = false;

        public Form1()
        {
            InitializeComponent();
            //LOCALIDAD DEL INVENTARIO POR DEFAULT
            txtLI.Text = "/var/tmp";
            //AGREGAR OPCIONES EN EL COMBOBOX DE OPCIONES DE INSTALACION
            cbxOpc.Items.Add("FULL");//instalacion total(por defecto)
            cbxOpc.Items.Add("PART");//instalcion parcial
            cbxOpc.Items.Add("MIN");//instalcion minima
            cbxOpc.Text = "FULL";
            //LOCALIDAD BASE 
            txtLB.Text = "/opt/base";
            //puesto 8080
            txtPC.Text = "8080";
            //direccion IP 34.83.79.239
            txtIP.Text = "34.83.79.79.239";
            //AGREGAR OPCIONES EN EL COMBOBOX DE SISTEMA DE REDUNDANCIA
            cbxSisR.Items.Add("NORMAL");
            cbxSisR.Items.Add("HIGH");
            cbxSisR.Items.Add("LOW");
            cbxSisR.Text = "NORMAL";

        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Crear Cuadro de Seleccionar Carpeta
            FolderBrowserDialog Carpeta = new FolderBrowserDialog();

            //Si la carpeta ha sido elegida
            if (Carpeta.ShowDialog() == DialogResult.OK)
            {
                //Carpeta que hemos seleccionado
                txtLI.Text = Carpeta.SelectedPath;
                LOCALIDADINVENTARIO = txtLI.Text;
                //Mostrar
                MessageBox.Show("La ruta seleccionada es: " + LOCALIDADINVENTARIO);
            }
        }

        private void btnBrowseB_Click(object sender, EventArgs e)
        {

            //Crear Cuadro de Seleccionar Carpeta
            FolderBrowserDialog Carpeta = new FolderBrowserDialog();

            //Si la carpeta ha sido elegida
            if (Carpeta.ShowDialog() == DialogResult.OK)
            {
                //Carpeta que hemos seleccionado
                txtLB.Text = Carpeta.SelectedPath;
                LOCALIDADBASE = txtLB.Text;
                //Verificar si es correcto
                MessageBox.Show("La ruta seleccionada es: " + LOCALIDADBASE);
            }
        }

        private void btnInstalacion_Click(object sender, EventArgs e)
        {
            if (txtLI.Text == "")
            {
                errorProvider1.SetError(txtLI, "Favor de seleccionar una rura de inventario.");
            }
            else if(cbxOpc.Text==""){
                errorProvider1.SetError(cbxOpc, "Favor de seleccionar una opcion de descarga.");
            }
            else if (txtLB.Text == "")
            {
                errorProvider1.SetError(txtLB, "Favor de seleccionar una rura base.");
            }
            else if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Favor de ingresar el password.");
            }
            else if (cbxSisR.Text == "")
            {
                errorProvider1.SetError(cbxSisR, "Favor de seleccionar una opcion de descarga.");
            }
            else
            {
                LOCALIDADINVENTARIO = txtLI.Text;
                installoption = cbxOpc.Text;
                LOCALIDADBASE = txtLB.Text;
                installport = txtPC.Text;
                installaddress = txtIP.Text;
                installpassword = txtPassword.Text;
                installredundancia = cbxSisR.Text;
                TextWriter archivo;
                archivo = new StreamWriter("DatosInstalacion.txt");
                archivo.WriteLine("LOCALIDADINVENTARIO: " + LOCALIDADINVENTARIO);
                archivo.WriteLine("install.option: " + installoption);
                archivo.WriteLine("LOCALIDADBASE: " + LOCALIDADBASE);
                archivo.WriteLine("install.port: " + installport);
                archivo.WriteLine("install.address: " + installaddress);
                archivo.WriteLine("install.password: " + installpassword);
                archivo.WriteLine("install.redundancia: " + installredundancia);
                archivo.Close();
                MessageBox.Show("El archivo DatosInstalacion.txt ha sido creado.");
                val = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (val == false)
            {
                errorProvider1.SetError(btnInstalacion, "No se a creado ningun archivo de instalacion aun.");
            }
            else
            {
                lstDatosI.Items.Add("*********************************************");
                lstDatosI.Items.Add("LOCALIDADINVENTARIO: " + LOCALIDADINVENTARIO);
                lstDatosI.Items.Add("install.option: " + installoption);
                lstDatosI.Items.Add("LOCALIDADBASE: " + LOCALIDADBASE);
                lstDatosI.Items.Add("install.port: " + installport);
                lstDatosI.Items.Add("install.address: " + installaddress);
                lstDatosI.Items.Add("install.password: " + installpassword);
                lstDatosI.Items.Add("install.redundancia: " + installredundancia);
                MessageBox.Show("Datos Mostrados");
            }
        }
    }
}
