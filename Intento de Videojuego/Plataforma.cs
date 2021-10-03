using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intento_de_Videojuego
{
    internal partial class Plataforma : GameObject
    {
        private int distanciaARecorrer;
        internal int posicionOriginalX;
        bool ya = false;
        internal int DistanciaARecorrer { get => distanciaARecorrer; set => distanciaARecorrer = value; }

        internal Plataforma()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.EsFisico = true;
            this.Etiqueta = "Plataforma";
            this.Image = Properties.Resources.Plataforma;

            //No funciona, por eso tuve que usar la artimaña del valor booleano ya;
            //posicionOriginalX = this.Location.X;
        }

        internal override void Update()
        {
            //artimaña ya
            #region artimaña
            if (!ya)
            {
                posicionOriginalX = this.Location.X;
                ya = true;
            }
            #endregion

            if (this.Location.X > posicionOriginalX + distanciaARecorrer && DistanciaARecorrer>0)
            {
                VelocidadHorizontal = Math.Abs(VelocidadHorizontal) * -1;
            }
            else if (this.Location.X < posicionOriginalX && DistanciaARecorrer > 0)
            {
                VelocidadHorizontal = Math.Abs(VelocidadHorizontal);
            }

            if (this.Location.X < posicionOriginalX + distanciaARecorrer && DistanciaARecorrer < 0)
            {
                VelocidadHorizontal = Math.Abs(VelocidadHorizontal);
            }
            else if (this.Location.X > posicionOriginalX && DistanciaARecorrer < 0)
            {
                VelocidadHorizontal = Math.Abs(VelocidadHorizontal) * -1;
            }
        }
    }
}
