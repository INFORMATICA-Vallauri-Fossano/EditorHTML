using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
//
using clsFile_ns;
using clsStampa_ns;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Es06_EditorHTML
{
    public partial class frmEditorHTML : Form
    {
        const string ACAPO = "\r\n\t"; 
        clsFile fileManager;
        public frmEditorHTML()
        {
            InitializeComponent();
        }
        private void frmEditorHTML_Load(object sender, EventArgs e)
        {
            fileManager = new clsFile();
            fileManager.ev += mostraCambiamentoFile;
            txtHTML.MaxLength = 2000;//32767;
            pgbChar.Maximum = txtHTML.MaxLength;
            txtHTML.AutoCompleteMode = AutoCompleteMode.Suggest;
            scriviTag(nuovo(), 52);
            visualizzaNchar();
        }

        private void mostraCambiamentoFile(bool modificato)
        {
            string output="";
            if (modificato) output += "*";
            output += fileManager.getFileNameRelativo();
            this.Text =  output+ " - Editor HTML";
        }

        private void visualizzaNchar()
        {
            lblChar.Text = "Numero Caratteri " + txtHTML.TextLength +
                "/" + txtHTML.MaxLength;
        }
        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            clsFile.ync risposta = fileManager.chiediSeSalvare();
            if (risposta != clsFile.ync.annulla)
            {
                if (risposta == clsFile.ync.si)
                    fileManager.salva(txtHTML.Text);
                 
                    fileManager.FileName = "";
                    this.Text = "EDITOR HTML";
                    
                    txtHTML.Clear();
                    scriviTag(nuovo(), 52);
            }
        }

        private void txtHTML_TextChanged(object sender, EventArgs e)
        {
            if (txtHTML.TextLength > 0 && txtHTML.TextLength <= pgbChar.Maximum)
            {
                fileManager.Modificato = true;
                pgbChar.Value = txtHTML.TextLength;
                visualizzaNchar();
            }
            else
                txtHTML.Undo();
        }

        private void tabControlHTML_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage.Name=="tabPageWeb")
                webBrowserHTML.DocumentText = txtHTML.Text;
        }

        private string nuovo()
        {
            string s = "";
            s = IndentTag("<HTML><HEAD><TITLE>Nuova Pagina</TITLE></HEAD><BODY></BODY></HTML>");
            return s;
        }
        private void scriviTag(string tag, int len)
        {
            int posCorrente;
            posCorrente = txtHTML.SelectionStart;
            txtHTML.Paste(tag);
            txtHTML.SelectionStart = posCorrente + len;
        }

        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            clsFile.ync risposta = clsFile.ync.no;
            if (fileManager.Modificato)
            {
                //chiedo se si vogliono salvare le modifiche o ignorarle
                risposta = fileManager.chiediSeSalvare();
                if (risposta == clsFile.ync.si)
                    fileManager.salva(txtHTML.Text);
            }
            if (risposta != clsFile.ync.annulla)
            {
                txtHTML.Text = fileManager.apri();
                fileManager.Modificato = false;
            }
        }
        
        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            fileManager.salva(txtHTML.Text);
        }

        private void tagliaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Cut();
        }

        private void copiaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Copy();
        }

        private void incollaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Paste();
        }

        private void annullaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Undo();
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 f=new AboutBox1();
            f.ShowDialog();
        }

        private void frmEditorHTML_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsFile.ync risposta = clsFile.ync.no;
            if (fileManager.Modificato)
            {
                //chiedo se si vogliono salvare le modifiche o ignorarle
                risposta = fileManager.chiediSeSalvare();
                if (risposta == clsFile.ync.si)
                    fileManager.salva(txtHTML.Text);
            }
            if (risposta == clsFile.ync.annulla)
            {
                e.Cancel = true;
            }
        }
        private void pToolStripButton_Click(object sender, EventArgs e)
        {
            scriviTag("<P></P>", 3);
        }
        private void bToolStripButton_Click(object sender, EventArgs e)
        {
            scriviTag("<BR>", 4);
        }

        private void hrToolStripButton_Click(object sender, EventArgs e)
        {
            scriviTag("<HR>", 4);
        }

        private void H1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H1></H1>", 4);
        }

        private void H2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H2></H2>", 4);
        }

        private void H3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H3></H3>", 4);
        }

        private void H4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H4></H4>", 4);
        }

        private void H5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H5></H5>", 4);
        }

        private void H6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriviTag("<H6></H6>", 4);
        }

        private void tsbLink_Click(object sender, EventArgs e)
        {
            scriviTag("<a href=\"\"></a>", 9);
        }
        private int GetCursorPositionInLine()
        {
            int cursorPosition = txtHTML.SelectionStart;
            int lineIndex = txtHTML.GetLineFromCharIndex(cursorPosition);
            int lineStart = txtHTML.GetFirstCharIndexFromLine(lineIndex);
            return cursorPosition - lineStart;
        }

        private string IndentTag(string tag)
        {
            int i = 1,indentLevel=0;
            int cursorPosition = GetCursorPositionInLine();
            string indented = "";
            //bool inTag = false;
            while (i < tag.Length)
            {
                i--;
                //indented += "|"+tag[i]+"|";
                if (tag[i] == '<' && tag[i+1]!='/')
                {
                    //indenta(indentLevel,false);
                    indentLevel++;
                    copiaFinoA('>');
                }else if (tag[i] == '>')
                {
                    indenta(indentLevel,true);
                    copiaFinoA('<');
                    i++;
                }
                else
                {

                    indentLevel--;
                    indenta(indentLevel,true);
                    copiaFinoA('>');
                }
            }
            return indented;

            void copiaFinoA(char c)
            {
                int j=i;
                while (tag[i] != c) i++;
                if (c == '>') i++;
                else j++;
                indented += tag.Substring(j, i-j);
            }
            void indenta(int indL, bool acapo)
            {
                indented += "\r";
                if (acapo)
                {
                    indented += "\n";
                    for (int j = 0; j < cursorPosition; j++) indented += "\t";
                }
                for (int j = 0; j < indL; j++) indented += "\t";
            }
        }


        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileManager.salvaConNome(txtHTML.Text);

        }

        private void tsbImg_Click(object sender, EventArgs e)
        {
            scriviTag("<img src=\"\" alt=\"\">", 10);
        }

        private void tsbForm_Click(object sender, EventArgs e)
        {
            
            scriviTag(IndentTag("<FORM ACTION=\"SUBMIT\" METHOD=\"POST\"><H3></H3><INPUT TYPE=\"TEXT\" NAME=\"DATA\" PLACEHOLDER=\"NOME\" REQUIRED><BUTTON>INVIA</BUTTON></FORM>"),44);
        }

        private void tsbTable_Click(object sender, EventArgs e)
        {
            frmTable f=new frmTable();
            f.ShowDialog();
            if (!f.Annulla)
            {
                scriviTag(IndentTag(creaTable(f.Righe, f.Colonne)),0);
            }
        }

        private string creaTable(int righe, int colonne)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<table style=\"border: 1px black solid\">");

            for (int i = 0; i < righe; i++)
            {
                html.Append("<tr>");
                for (int j = 0; j < colonne; j++)
                {
                    html.Append("<td></td>");
                }
                html.Append("</tr>");
            }

            html.Append("</table>");
            return html.ToString();
        }
        
        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
