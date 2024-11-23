using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace clsStampa_ns
{
    internal class clsStampa
    {
        //oggetto  principale per la gestione della classe
        private PrintDocument prn=new PrintDocument();
        //3 finestre di dialog per la configurazione/gestione
        //dell'oggetto printDocument
        private PageSetupDialog dlgSetup=new PageSetupDialog();
        private PrintDialog dlgPrint=new PrintDialog();
        private PrintPreviewDialog dlgPreviw=new PrintPreviewDialog();
        private string userText;
        private Font userFont;

        public string UserText { get => userText; set => userText = value; }
        public Font UserFont { get => userFont; set => userFont = value; }

        public clsStampa()
        {
            //parametri relativi all'impostazione della pagina
            //le misure sono in unit(=pollice/10) 0,0254mm
            prn.DefaultPageSettings.Margins.Left = 79;  //2cm
            prn.DefaultPageSettings.Margins.Right = 79;  //2cm
            prn.DefaultPageSettings.Margins.Bottom = 100; //2,54 cm
            prn.DefaultPageSettings.Margins.Top = 100; //2,54 cm
            prn.DefaultPageSettings.Landscape = false;  //orientamento false=verticale true=orizzontale

            //parametri relativi alla stanza
            prn.PrinterSettings.Copies = 1;
            //collego le finestre di dialogo all'oggetto printDocument
            dlgSetup.Document=prn;
            dlgPreviw.Document=prn;
            dlgPrint.Document=prn;
            dlgSetup.EnableMetric = true;   //dovrebbe attivare le misure in sistema decimale

            //evento di stampa
            prn.PrintPage += new PrintPageEventHandler(prn_PrintPage);

        }

        private void prn_PrintPage(object sender, PrintPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImpostaPagina()
        {
            dlgSetup.ShowDialog();
            //all'ok i valori impostati sono automaticamente salvati nell'oggetto prn
        }
        public void Stampa(string testo, Font carattere)
        {
            UserText = testo;
            UserFont = carattere;
            if (dlgPrint.ShowDialog() == DialogResult.OK)
                prn.Print();
        }
        public void Anteprima(string testo, Font carattere)
        {
            UserText = testo;
            UserFont = carattere;
            dlgPreviw.ShowDialog();

        }
    }
}
