using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*Olinuck Dario Esteban
TP02 Programación II
UTN FRA 2017*/


namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>   

    public abstract class Producto
    {
        #region atributos

        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve la cantidad de calorías del Producto
        /// </summary>
        public abstract short CantidadCalorias
        {
            get;          
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Genera un espacio en memoria para Producto y le carga los valores pasados como parámetros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigodebarras"></param>
        /// <param name="color"></param>
        public Producto(EMarca marca, string codigodebarras,ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigodebarras;
            this._colorPrimarioEmpaque = color;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve un string con los atributos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {          
            return (string)this;
        }

        /// <summary>
        /// Override de GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        #endregion

        #region Operadores

        /// <summary>
        /// Recibe un objeto del tipo Producto y devuelve sus atributos en formato string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: \r\n" + p._codigoDeBarras);
            sb.AppendLine("MARCA:  \r\n" + p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE: \r\n" + p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si su código de barra es igual 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras)? true : false;
        }


        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1 == v2);
        }


        /// <summary>
        /// Evalua si el objeto recibido como parámetro es un Producto y si es igual a Producto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Producto)
            {
                return ((Producto)this == (Producto)obj);
            }

            return false;
        }

        #endregion

        #region enumeradores

        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        #endregion
    }
}
