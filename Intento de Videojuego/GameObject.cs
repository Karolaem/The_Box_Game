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
    internal partial class GameObject : PictureBox
    {
        private string etiqueta;
        private bool esEstatico;
        private bool esFisico;
        private int velocidadHorizontal;
        private int velocidadVertical;
        private int velocidadVerticalMaxima = 6;
        private int tiempoDeCaida = 0;
        private bool afectaGravedad;

        #region Propiedades
        internal string Etiqueta { get => etiqueta;  set => etiqueta = value; }
        internal bool EsEstatico { get => esEstatico; set => esEstatico = value; }
        internal bool EsFisico { get => esFisico; set => esFisico = value; }
        internal int VelocidadHorizontal { get => velocidadHorizontal; set => velocidadHorizontal = value; }
        internal int VelocidadVertical
        {
            get => velocidadVertical;
            set
            {
                if (value > velocidadVerticalMaxima)
                    velocidadVertical = velocidadVerticalMaxima;
                else velocidadVertical = value;
            }
        }
        internal int TiempoDeCaida { get => tiempoDeCaida; set => tiempoDeCaida = value; }
        internal bool AfectaGravedad { get => afectaGravedad; set => afectaGravedad = value; }
        #endregion

        internal GameObject()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        /// <summary>
        /// Cambia la imagen del GameObject por la imagen especificada.
        /// </summary>
        /// <param name="spriteDirection">Direccion de la imagen.</param>
        /// <returns>Retorna falso si no encuentra imagen y verdadero si la encuentra.</returns>
        internal bool ChangeSprite(string spriteDirection)
        {
            Image image = Image.FromFile(spriteDirection);
            if (image == null) return false;
            else {
                this.Image = image;
                return true;
            }
        }

        /// <summary>
        /// Obtiene la lista de todos los GameObject y sus hijos (subclases de GameObject) de un Form
        /// </summary>
        /// <param name="form">Formulario que contiene los GameObject</param>
        /// <returns>Arreglo de GameObject</returns>
        internal static GameObject[] GetGameObjects(Form form)
        {
            GameObject[] auxiliar = new GameObject[form.Controls.Count];
            int cantidadGameObjects = 0;
            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (form.Controls[i].GetType() == GameObjectType()|| form.Controls[i].GetType().IsSubclassOf(GameObjectType()))
                {
                    auxiliar[cantidadGameObjects] = (GameObject)form.Controls[i];
                    cantidadGameObjects++;
                }
            }
            GameObject[] gameObjects = new GameObject[cantidadGameObjects];
            for (int i = 0; i < cantidadGameObjects; i++)
            {
                gameObjects[i] = auxiliar[i];
            }
            return gameObjects;
        }

        private static Type GameObjectType()
        {
            GameObject gameObject = new GameObject();
            return gameObject.GetType();
        }

        /// <summary>
        /// Retorna al primer GameObject encontrado que contenga el nombre especificado
        /// </summary>
        /// <param name="name">Nombre del GameObject que se desea encontrar</param>
        /// <param name="form">Formulario que contiene los GameObject</param>
        internal static GameObject GetGameObjectWithName(string name,Form form)
        {
            GameObject[] gameObjects = GetGameObjects(form);
            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.Name == name)
                    return gameObject;
                else
                    continue;
            }
            return null;
        }


        //la idea es que los GameObjects puedan llamar estas funciones al colisionar.
        #region Colisiones
        internal virtual void OnColision(GameObject me, GameObject other)
        {

        }

        internal void OnColision() { }
        #endregion

        //Funciona parecido a GetGameObjects (Se pueden optimizar)
        /// <summary>
        /// Obtiene una lista de los GameObject que contengan la etiqueta especificada
        /// </summary>
        /// <param name="etiqueta">Tag o Etiqueta de los GameObject a buscar</param>
        /// <param name="form">Formulario donde se encuentran los GameObject</param>
        /// <returns></returns>
        internal static GameObject[] GetGameObjectsWithTag(string etiqueta, Form form)
        {
            {
                GameObject[] gameObjects = GetGameObjects(form);
                GameObject[] gameObjectAuxiliar = new GameObject[gameObjects.Length];
                int CantidadGameObjects = 0;

                for (int i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i].Etiqueta == etiqueta)
                    {
                        gameObjectAuxiliar[CantidadGameObjects] = gameObjects[i];
                        CantidadGameObjects++;
                    }
                    else
                        continue;
                }

                //Eliminar Excedente de GameObjects
                GameObject[] final = new GameObject[CantidadGameObjects];
                for (int i = 0; i < final.Length; i++)
                {
                    final[i] = gameObjectAuxiliar[i];
                }
                return final;
            }
        }


        internal new virtual void Update()
        {

        }
    }
}
