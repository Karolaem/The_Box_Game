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
    internal partial class Caja : GameObject
    {
        GameController gameController;
        private Player player = null;
        Form form;
        internal Caja()
        {
            InitializeComponent();
            this.AfectaGravedad = true;
            this.EsEstatico = false;
            this.EsFisico = true;
            this.Etiqueta = "Caja";
            this.Image = Properties.Resources.Caja;
            gameController = GameController.getInstance();
            form = this.FindForm();
        }

        internal override void OnColision(GameObject me, GameObject other)
        {
            form = this.FindForm();
            player = (Player)GetGameObjectsWithTag("Player", form)[0];

            //Se verifica si el jugador esta cerca de esta caja
            if (
                //Primero se verifica por la izquierda
                gameController.VerificarPosicionRelativa(me, player, new Point(0, 1)) ||
                gameController.VerificarPosicionRelativa(me, player, new Point(0, me.Image.Height-1)) ||
                //Luego se verifica por la derecha
                gameController.VerificarPosicionRelativa(me, player, new Point(me.Image.Width , 1)) ||
                gameController.VerificarPosicionRelativa(me, player, new Point(me.Image.Width , me.Image.Height-1))
                )
            {
                //En caso de que la velocidad del jugador sea 0 la velocidad de la caja no se vera afectada
                if (player.VelocidadHorizontal == 0)
                    return;

                //de lo contrario la caja tomara su velocidad
                else
                    me.VelocidadHorizontal = player.VelocidadHorizontal;
            }
            //La caja tomara la velocidad de cualquier otro objeto con el que este en colision
            else
                me.VelocidadHorizontal = other.VelocidadHorizontal;
        }

        internal override void Update()
        {

        }
    }
}
