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
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TitleScreen titleScreen = TitleScreen.GetTitleScreen();
            titleScreen.Show();
            this.Close();
        }
    }
}
