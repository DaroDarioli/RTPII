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
    public class Dulce : Producto
    {

        #region Constructores

        /// <summary>
        /// Genera un espacio en memoria para un objeto del tipo Dulce y le carga los valores pasados como parámetros
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigodebarras"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string codigodebarras, ConsoleColor color): base(marca,codigodebarras, color)
        {
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        /// 

        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve un string con los atributos del Producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
