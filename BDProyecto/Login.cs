using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;
namespace BDProyecto
{
    public partial class Login : Form
    {
        static Conexion conexionQuito = new Conexion("BD-QUITO", "QuitoTaller", "sa", "P@ssw0rd");

        static Conexion conexionGuayaquil = new Conexion("BD-GUAYAQUIL", "GuayaquilTaller", "sa", "P@ssw0rd");
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll",EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("USUARIO"))
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals(""))
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals("CONTRASEÑA"))
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals(""))
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    if (comboBoxBD.Text != "")
                    {
                        if (comboBoxBD.Text.Equals("QUITO"))
                        {
                            conexionQuito.abrir_Conexion();
                            FormPrincipal formPrincipal = new FormPrincipal(conexionQuito);
                            formPrincipal.Show();
                            conexionQuito.cerrar_Conexion();
                        }
                        if (comboBoxBD.Text.Equals("GUAYAQUIL"))
                        {
                            conexionGuayaquil.abrir_Conexion();
                            FormPrincipal formPrincipal = new FormPrincipal(conexionGuayaquil);
                            formPrincipal.Show();
                            conexionGuayaquil.cerrar_Conexion();
                        } 
                        this.Hide();
                        MessageBox.Show("Conexion a SQL Exitosa");
                    }
                    else
                    {
                        msgError("Selecciona una localidad");
                    }
                }
                else
                {
                    msgError("Ingresa la Contraseña");
                }
            }
            else
            {
                msgError("Ingresa el Usuario");
            }
            
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "     " + msg;
            lblErrorMessage.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
