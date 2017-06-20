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
    public class Snacks : Producto
    {

        #region Constructores

        /// <summary>
        /// Genera espacio en memoria para un Snack y carga al producto con los valores recibidos como parámetro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigodebarras"></param>
        /// <param name="color"></param>

        public Snacks(EMarca marca, string codigodebarras, ConsoleColor color)
            : base(marca, codigodebarras, color)
        {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve un string con los atributos del objeto Snack
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
