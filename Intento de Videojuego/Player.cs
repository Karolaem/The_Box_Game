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
    internal partial class Player : GameObject
    {
        //Imagen del jugador girada a la izquierda
        Bitmap PlayerIzquierda;

        //Imagen del jugador girada a la derecha
        Bitmap PlayerDerecha;

        GameController gameController;
        //Pasa saber que tecla de movimiento pulsé
        private enum Direccion
        {
            Arriba,
            Abajo,
            Derecha,
            Izquierda,
            Ninguna
        }
        Direccion direccion;

        //Para sumar la velocidad de una plataforma movil en caso de estar en una.
        private int AjusteVelocidad = 0;

        internal Player()
        {
            InitializeComponent();
            this.AfectaGravedad = true;
            this.EsFisico = true;
            this.Etiqueta = "Player";
            this.Image = Properties.Resources.Player;
            this.PlayerDerecha = Properties.Resources.Player;
            this.PlayerIzquierda = Properties.Resources.Player;
            this.PlayerIzquierda.RotateFlip(RotateFlipType.RotateNoneFlipX);
            gameController = GameController.getInstance();

        }

        internal override void OnColision(GameObject me, GameObject other)
        {

            if (other.Etiqueta == "Plataforma"||
                (other.Etiqueta == "Caja" && (gameController.VerificarPosicionRelativa(me, other, new Point(3, me.Image.Height)) ||
                gameController.VerificarPosicionRelativa(me, other, new Point(me.Image.Width-3, me.Image.Height)))))
                AjusteVelocidad = other.VelocidadHorizontal;
            else
                AjusteVelocidad = 0;

            if (other.Etiqueta == "Meta")
            {
                FormPrincipal formPrincipal = FormPrincipal.GetFormPrincipal();
                formPrincipal.nivel++;
            }

        }

        internal void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && this.VelocidadVertical == 0 && this.TiempoDeCaida == 0)
            {
                this.VelocidadVertical = -8;
                this.TiempoDeCaida = 0;
            }
            if (e.KeyCode == Keys.A)
            {
                direccion = Direccion.Izquierda;
                Image = PlayerIzquierda;
            }
            if (e.KeyCode == Keys.D)
            {
                direccion = Direccion.Derecha;
                Image = PlayerDerecha;
            }

            if (e.KeyCode == Keys.Q)
            {
                MessageBox.Show(this.VelocidadHorizontal.ToString());
            }
        }

        internal void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && this.VelocidadHorizontal <= 0)
            {
                direccion = Direccion.Ninguna;
            }
            if (e.KeyCode == Keys.D && this.VelocidadHorizontal >= 0)
            {
                direccion = Direccion.Ninguna;
            }
        }

        internal override void Update()
        {
            switch (direccion)
            {
                case Direccion.Izquierda:
                    this.VelocidadHorizontal = -2 + AjusteVelocidad;
                    break;
                case Direccion.Derecha:
                    this.VelocidadHorizontal = 2 + AjusteVelocidad;
                    break;
                case Direccion.Ninguna:
                    this.VelocidadHorizontal = 0 + AjusteVelocidad;
                    break;
            }
        }
    }
}
