using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public string Archivo
        {
            get { return _archivo; }
            set { _archivo = value ; }
        }


        public Texto(string archivo)
        {
            this._archivo = archivo;

        }

        /// <summary>
        /// Guarda en un archivo de texto la cadena de caracteres recibida como parámetro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.guardar(string datos)
        {
            try
            {
                using (StreamWriter sw1 = new StreamWriter(this._archivo,true)) // bloque using me asegurar liberar recursos
                {
                    sw1.WriteLine(datos);
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Lee el historial cargaado en un archivo de texto y lo carga a la lista recibida como parámetro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.leer(out List<string> datos)
        {
            datos = new List<string>();
            bool auxRetorno = true;
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(this._archivo))
                {
                    string linea;

                    while((linea = sr.ReadLine()) != null)
                    {
                        datos.Add(linea);
                    }      
                }
            }
            catch
            {
                auxRetorno = false;
            }
            return auxRetorno;
        }
    }
}
