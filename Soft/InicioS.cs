using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Capa_Entidad;
using Capa_Negocio;

namespace Soft
{
    public partial class InicioS : Form
    {
        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        Principal frm1 = new Principal();

        public static string usuario_nombre;
        public static string area;

        void p_logueo()
        {
            DataTable dt = new DataTable();
            objeuser.usurio = txtUsuario.Text;
            objeuser.clave = txtContrasena.Text;

            dt = objnuser.N_user(objeuser);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido" + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][1].ToString();
                area = dt.Rows[0][0].ToString();

                frm1.ShowDialog();

                InicioS login = new InicioS();
                login.ShowDialog();

                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new Principal());

                txtUsuario.Clear();
                txtContrasena.Clear();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos, Verifique", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public InicioS()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            p_logueo();
        }
    }
}
