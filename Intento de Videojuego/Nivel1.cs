using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intento_de_Videojuego
{
    public partial class Nivel1 : Form
    {
        public Nivel1()
        {
            InitializeComponent();
            FormPrincipal fp = FormPrincipal.GetFormPrincipal();
            //Form a = fp.PanelContenedor.
        }

        private void Nivel1_KeyDown(object sender, KeyEventArgs e)
        {
            player1.KeyDown(e);
        }

        private void Nivel1_KeyUp(object sender, KeyEventArgs e)
        {
            player1.KeyUp(e);
        }
    }
}
