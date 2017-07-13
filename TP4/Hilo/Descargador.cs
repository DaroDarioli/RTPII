using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;       
         
        public delegate void DelegateProgreso(int progreso);
        public delegate void DelegateDescarga(string descarga);
        public event DelegateProgreso ProgresoEvent;
        public event DelegateDescarga DescargaEvent;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            
            try
            {
                // ejemplo VideoEncoder; declarar delegados y eventos antes de este método 
                WebClient cliente = new WebClient();                
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {   
            ProgresoEvent(e.ProgressPercentage);
        }


        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {           
            this.html = e.Result;
            DescargaEvent(this.html);
           
        }

    }
}
