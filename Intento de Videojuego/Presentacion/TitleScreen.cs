using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intento_de_Videojuego.Presentacion
{
    public partial class TitleScreen : Form
    {
        private static TitleScreen titleScreen;
        private TitleScreen()
        {
            InitializeComponent();
        }

        public static TitleScreen GetTitleScreen()
        {
            if (titleScreen != null)
                return titleScreen;
            else
                titleScreen = new TitleScreen();
            return titleScreen;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = FormPrincipal.GetFormPrincipal();
            formPrincipal.nivel = 1;
            formPrincipal.Show();
            this.Visible = false;
        }
    }
}
