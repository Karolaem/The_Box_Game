using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Intento_de_Videojuego
{
    internal class GameController
    {
        private const float aceleracionGravedad = 0.30f;
        internal float GetAceleracionGravedad() => aceleracionGravedad;
        private static GameController gameController = new GameController();
        private GameController() { }
        internal static GameController getInstance() { return gameController; }

        /// <summary>
        /// Calcula la velocidad final a partir de la velocidad inicial, el tiempo y la aceleracion del objeto
        /// </summary>
        /// <param name="velocidadInicial">Velocidad actual del GameObject</param>
        /// <param name="tiempo">Tiempo Final</param>
        /// <param name="factorAceleracion">Aceleracion</param>
        /// <returns>Velocidad Final</returns>
        internal int Aceleracion(int velocidadInicial, int tiempo, float factorAceleracion)
        {
            return (int)Math.Truncate(velocidadInicial + (Math.Sqrt(tiempo) * factorAceleracion));
        }

        ///<summary>
        ///Esta funcion indica si hay alguna colision directa entre el objeto "a" y "b".
        /// </summary>
        internal bool VerificarColision(GameObject a, GameObject b)
        {
            bool colision = true;
            if (a.Location.X - 1 > b.Location.X + b.Size.Width)
                colision = false;

            if (a.Location.X + b.Size.Width + 1 < b.Location.X)
                colision = false;

            if (a.Location.Y - 1 > b.Location.Y + b.Size.Height)
                colision = false;

            if (a.Location.Y + a.Size.Height + 1 < b.Location.Y)
                colision = false;

            return colision;
        }

        /// <summary>
        /// Esta funcion indica si el objeto "a", colisiona con el objeto "b" a una distancia de "point" pixeles.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="point">Si es 0,0 verifica directo hacia abajo.</param>
        /// <returns></returns>
        internal bool VerificarColision(GameObject a, GameObject b, Point point)
        {
            if (a.EsFisico == false || b.EsFisico == false)
                return false;
            if (point.X > 0)
            {
                if (((a.Location.Y > b.Location.Y &&
                    a.Location.Y < b.Location.Y + b.Size.Height) ||
                    (a.Location.Y + a.Size.Height > b.Location.Y &&
                    a.Location.Y + a.Size.Height < b.Location.Y + b.Size.Height) ||
                    (a.Location.Y < b.Location.Y &&
                    a.Location.Y + a.Size.Height > b.Location.Y + b.Size.Height) ||
                    (a.Location.Y == b.Location.Y &&
                    a.Location.Y + a.Size.Height == b.Location.Y + b.Size.Height)) &&
                    a.Location.X + a.Size.Width + point.X > b.Location.X &&
                    a.Location.X + a.Size.Width + point.X < b.Location.X + b.Size.Width)
                    return true;
                else
                    return false;
            }
            if (point.X < 0)
            {
                if (((a.Location.Y > b.Location.Y &&
                    a.Location.Y < b.Location.Y + b.Size.Height) ||
                    (a.Location.Y + a.Size.Height > b.Location.Y &&
                    a.Location.Y + a.Size.Height < b.Location.Y + b.Size.Height) ||
                    (a.Location.Y < b.Location.Y &&
                    a.Location.Y + a.Size.Height > b.Location.Y + b.Size.Height) ||
                    (a.Location.Y == b.Location.Y &&
                    a.Location.Y + a.Size.Height == b.Location.Y + b.Size.Height)) &&
                    a.Location.X + point.X < b.Location.X + b.Size.Width &&
                    a.Location.X + point.X > b.Location.X)
                    return true;
                else
                    return false;
            }
            if (point.Y > 0)
            {
                if (a.Location.Y + a.Size.Height + point.Y > b.Location.Y &&
                    a.Location.Y + a.Size.Height + point.Y < b.Location.Y + b.Size.Height &&
                    a.Location.X + a.Size.Width > b.Location.X &&
                    a.Location.X < b.Location.X + b.Size.Width)
                    return true;
                else
                    return false;
            }

            if (point.Y < 0)
            {
                if (a.Location.Y + point.Y >= b.Location.Y &&
                    a.Location.Y + point.Y <= b.Location.Y + b.Size.Height &&
                    a.Location.X + a.Size.Width > b.Location.X &&
                    a.Location.X < b.Location.X + b.Size.Width)
                    return true;
                else
                    return false;
            }
            return false;

        }

        //Agregar condiciones si el objeto es estatico para que no se mueva.
        /// <summary>
        /// Calcula las nuevas posiciones de los GameObjects
        /// </summary>
        /// <param name="form">Form donde se encuentran los GameObjects </param>
        internal void Fisicas(Form form)
        {
            GameObject[] gameObjects = GameObject.GetGameObjects(form);
            foreach (GameObject gameObject in gameObjects)
            {
                bool colision = false;
                foreach (GameObject gameObjectAux in gameObjects)
                {

                    if (gameObject != gameObjectAux && gameObject.AfectaGravedad)
                    {
                        //verifica la colision debajo del personaje si está quieto en la coordenada Y (No sube ni baja)
                        if (gameObject.VelocidadVertical == 0)
                        {
                            if (gameController.VerificarColision(gameObject, gameObjectAux, new Point(0, 1)))
                            {
                                colision = true;
                                gameObject.Location = new Point(gameObject.Location.X, gameObjectAux.Location.Y - gameObject.Size.Height);
                                gameObject.OnColision(gameObject, gameObjectAux);
                                gameObjectAux.OnColision(gameObjectAux, gameObject);

                            }
                        }
                        //Si está callendo verificará la colision hacia abajo
                        else if (gameObject.VelocidadVertical > 0)
                        {
                            if (gameController.VerificarColision(gameObject, gameObjectAux, new Point(0, gameObject.VelocidadVertical)))
                            {
                                colision = true;
                                gameObject.Location = new Point(gameObject.Location.X, gameObjectAux.Location.Y - gameObject.Size.Height);
                                gameObject.OnColision(gameObject, gameObjectAux);
                                gameObjectAux.OnColision(gameObjectAux, gameObject);
                            }
                        }
                        //Si esta subiendo verificará la colision hacia arriba
                        else if (gameObject.VelocidadVertical < 0)
                        {
                            if (gameController.VerificarColision(gameObject, gameObjectAux, new Point(0, gameObject.VelocidadVertical)))
                            {
                                gameObject.OnColision(gameObject, gameObjectAux);
                                gameObjectAux.OnColision(gameObjectAux, gameObject);
                                gameObject.VelocidadVertical = 1;
                                //pongo el tiempo de caida a 7 para que caiga a una velocidad aceptable luego de golpear un objeto arriba
                                gameObject.TiempoDeCaida = 7;
                                gameObject.Location = new Point(gameObject.Location.X, gameObjectAux.Location.Y + gameObjectAux.Size.Height);
                            }
                        }
                        //verifica la colision en el eje X
                        if (gameController.VerificarColision(gameObject, gameObjectAux, new Point(gameObject.VelocidadHorizontal, 0)))
                        {
                            if (gameObject.VelocidadHorizontal > 0)
                            {
                                gameObject.OnColision(gameObject, gameObjectAux);
                                gameObjectAux.OnColision(gameObjectAux, gameObject);
                                gameObject.Location = new Point(gameObjectAux.Location.X - gameObject.Size.Width, gameObject.Location.Y);
                            }
                            else if (gameObject.VelocidadHorizontal < 0)
                            {
                                gameObject.OnColision(gameObject, gameObjectAux);
                                gameObjectAux.OnColision(gameObjectAux, gameObject);
                                gameObject.Location = new Point(gameObjectAux.Location.X + gameObjectAux.Size.Width, gameObject.Location.Y);
                            }

                            gameObject.VelocidadHorizontal = 0;
                        }
                        
                    }
                }
                if (!colision && gameObject.AfectaGravedad)
                    gameObject.TiempoDeCaida++;
                else
                {
                    gameObject.TiempoDeCaida = 0;
                    gameObject.VelocidadVertical = 0;

                }
                //Esto es para que no sea tan lenta la caida cuando haya caido sin saltar.
                if (!colision && gameObject.VelocidadVertical == 0 && gameObject.TiempoDeCaida == 1 && gameObject.AfectaGravedad)
                {
                    gameObject.VelocidadVertical = 1;
                    gameObject.TiempoDeCaida = 11;
                }
                gameObject.VelocidadVertical = gameController.Aceleracion(gameObject.VelocidadVertical, gameObject.TiempoDeCaida, gameController.GetAceleracionGravedad());
                gameObject.Location = new Point(gameObject.Location.X + gameObject.VelocidadHorizontal, gameObject.Location.Y + gameObject.VelocidadVertical);
                gameObject.Update();
            }
        }

    
    /// <summary>
    /// Verifica si el GameObject "other" esta en una posicion relativa a "me"
    /// </summary>
    /// <param name="me">Es el GameObject que se usara como origen</param>
    /// <param name="other">Es el GameObject al que se verificara si se encuentra en la posicion indicada</param>
    /// <param name="posicion">Es la posicion relativa a "me" donde se verificara si se encuentra el GameObject "other"</param>
    /// <returns>Retorna verdadero si encuentra al GameObject en la posicion indicada, de lo contrario es falso</returns>
        internal bool VerificarPosicionRelativa(GameObject me, GameObject other, Point posicion)
        {
            if (me.Location.X + posicion.X >= other.Location.X &&
                me.Location.X + posicion.X <= other.Location.X + other.Image.Width &&
                me.Location.Y + posicion.Y >= other.Location.Y &&
                me.Location.Y + posicion.Y <= other.Location.Y + other.Image.Height)
                return true;
            else
                return false;
        }
    }
}
