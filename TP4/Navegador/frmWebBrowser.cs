using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Texto archivos;
       
       
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Descarga en código fuente del sitio web ingresado y guarda la dirección ingresada en un archivo de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {

            if (txtUrl.Text.StartsWith("https://"))
            {
                MessageBox.Show("No se puede leer páginas que comienzan con \"https\"");
              
            }
            else 
            {
                if (!txtUrl.Text.StartsWith("http://"))
                    txtUrl.Text = "http://" + txtUrl.Text;

                Descargador d1 = new Descargador(new Uri(txtUrl.Text));
                d1.ProgresoEvent += ProgresoDescarga;
                d1.DescargaEvent += FinDescarga;
                Thread thread = new Thread(d1.IniciarDescarga);
                thread.Start();
                ((IArchivo<string>)archivos).guardar(txtUrl.Text);

            }


        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Abre un formulario nuevo que muestra el historial de sitios web ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {          

            frmHistorial histo = new frmHistorial();
            histo.Show();
        
        }
    }
}
