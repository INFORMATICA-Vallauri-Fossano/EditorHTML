using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsFile_ns
{
    public class clsFile
    {
        //
        public delegate void FileModificatoUIUpdate(bool modificato);

        public event FileModificatoUIUpdate ev;

        //campi privati
        private string fileName;
        private bool modificato;
        //property
        public string FileName
        { 
            get 
            { 
                return fileName; 
            } 
            set 
            {  
                fileName = value; 
            } 
        }
        public bool Modificato
        {
            get
            {
                return modificato;
            }
            set
            {
                modificato = value;
                aggiornaUI(modificato);
            }
        }

        private void aggiornaUI(bool modificato)
        {
            if (ev != null)
            {
                ev(modificato);
            }
        }

        public enum ync
        {
            si,
            no,
            annulla
        }
        //costruttore
        public clsFile()
        {
            FileName = "";
            Modificato = false;
        }
        //metodi privati
        private string leggiFile() 
        {
            string testo="";
            if (FileName!="")
            {
                StreamReader sr = new StreamReader(FileName);
                testo = sr.ReadToEnd();
                sr.Close();
                Modificato=false;
            }
            return testo;
        }
        private void scriviFile(string testo)
        {
            if (FileName != "")
            {
                StreamWriter sw = new StreamWriter(FileName);
                sw.Write(testo);
                sw.Close();
                Modificato = false;
            }
        }
        //metodi pubblici
        public string apri()
        {
            string testo="";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog dlgApri = new OpenFileDialog();
            dlgApri.InitialDirectory = path;
            dlgApri.Multiselect = false;
            dlgApri.RestoreDirectory = true;
            dlgApri.Title = "EditorHTML - Seleziona un file";
            dlgApri.Filter = "Pagina HTML (*.html;*.htm)|*.html;*.htm"+
                "|Tutti i file (*.*)|*.*";
            dlgApri.FileName = "*.html";
            DialogResult ris=dlgApri.ShowDialog();
            if(ris == DialogResult.OK)
            {
                FileName = dlgApri.FileName;
                testo = leggiFile();
            }
            return testo;
        }
        public void salvaConNome(string testo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveFileDialog dlgsalva = new SaveFileDialog();
            dlgsalva.InitialDirectory = path;
            dlgsalva.RestoreDirectory = true;
            dlgsalva.Title = "EditorHTML - Salva file";
            dlgsalva.Filter = "Pagina HTML (*.html;*.htm)|*.html;*.htm" +
                "|Tutti i file (*.*)|*.*";
            dlgsalva.FileName = "*.html";
            DialogResult ris = dlgsalva.ShowDialog();
            if (ris == DialogResult.OK)
            {
                FileName = dlgsalva.FileName;
                scriviFile(testo);
            }
        }
        public void salva(string testo)
        {
                if (fileName != "")
                    scriviFile(testo);
                else
                    salvaConNome(testo);
        }
        public string getFileNameRelativo()
        {
            //restituisce solo nome file
            string s = "";
            if (fileName != "")
            {
                //s = Path.GetFileName(fileName);
                //oppure
                int pos = fileName.LastIndexOf('\\');
                s=fileName.Substring(pos + 1);
            }
            return s;
        }
        public string getFileName()
        {
            //restituisce il percorso completo
            string s = "";
            if (fileName != "")
                s = fileName;
            else
                s = "**NOT EXISTING FILE**";
            return s;
        }
        public ync chiediSeSalvare() {
            ync risposta= ync.annulla;
            string nomeFile=getFileName();
            DialogResult ris;
            ris = MessageBox.Show("Vuoi salvare le modifiche al codice HTML?\n(FILE path corrente: " + nomeFile+")\n\n*Se il file corrente non esiste e si vuole salvare scegliere o scrivere un file nella finestra di dialogo", "Editor HTML", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (ris)
            {
                case DialogResult.Yes:
                    risposta = ync.si;
                    break;
                case DialogResult.No:
                    risposta = ync.no;
                    break;
                case DialogResult.Cancel:
                    risposta = ync.annulla;
                    break;
            }
            return risposta;
        }
    }
}
