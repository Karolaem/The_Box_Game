using System;
using System.Drawing;
using System.Windows.Forms;
using Intento_de_Videojuego.Presentacion;

namespace Intento_de_Videojuego
{
    public partial class FormPrincipal : Form
    {
        GameController gameController;
        private static FormPrincipal formPrincipal;
        private int _nivel;
        public int nivel
        {
            get { return _nivel; }
            set { _nivel = value; CambiarNivel(value); }
        }
        private Form formHijo;
        public static FormPrincipal GetFormPrincipal()
        {
            if (formPrincipal == null)
                formPrincipal = new FormPrincipal();
            return formPrincipal;
        }

        Timer timer;

        private FormPrincipal()
        {
            InitializeComponent();
            gameController = GameController.getInstance();
            this.Focus();
        }

        public void AbrirFormEnPanel(Form nuevoFormhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.Clear();
            nuevoFormhijo.TopLevel = false;
            nuevoFormhijo.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(nuevoFormhijo);
            nuevoFormhijo.Show();
            formHijo = nuevoFormhijo;
            formHijo.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //player1.KeyDown(e
            MessageBox.Show("Down Principal");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //player1.KeyPress(e);
            MessageBox.Show("Press Principal");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //player1.KeyUp(e);
            MessageBox.Show("Up Principal");
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            if (formHijo!=null)
            gameController.Fisicas(formHijo);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Nivel1());

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            TitleScreen.GetTitleScreen().Close();
        }

        private void btnTitleScreen_Click(object sender, EventArgs e)
        {
            TitleScreen.GetTitleScreen().Show();
            this.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CambiarNivel(nivel);
        }

        public void CambiarNivel(int lvl)
        {
            lblNivel.Text = "Nivel " + lvl.ToString() + " de 3";
            switch (lvl) {
                case 1:
                    AbrirFormEnPanel(new Nivel1());
                break;
                case 2:
                    AbrirFormEnPanel(new Nivel2());
                break;
                case 3:
                    AbrirFormEnPanel(new Nivel3());
                break;
                case 4:
                    Creditos creditos = new Creditos();
                    creditos.Show();
                    this.Visible = false;
                    break;

            }
        }

        private void FormPrincipal_Activated(object sender, EventArgs e)
        {
            formHijo.Focus();
        }
    }
}
