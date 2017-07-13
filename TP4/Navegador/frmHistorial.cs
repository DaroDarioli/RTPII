using Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lee el archivo con historial de páginas visitadas y las carga al presente formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            ((IArchivo<string>)archivos).leer(out lista);
            CargarLista(lista);
        }   
        /// <summary>
        /// Recibe la lista de páginas webs visitas y las agrega al formulario historial
        /// </summary>
        /// <param name="lista"></param>
        public void CargarLista(List<string> lista)
        {
            foreach(string s in lista)
            {
                lstHistorial.Items.Add(s);
            }
            
        }           

     
    }
}
