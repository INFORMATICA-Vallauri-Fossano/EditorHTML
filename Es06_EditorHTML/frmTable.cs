using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Es06_EditorHTML
{
    public partial class frmTable : Form
    {
        private int colonne=1;
        private int righe=1;
        public frmTable()
        {
            InitializeComponent();
        }
        private bool annulla=false;

        public int Colonne { get => colonne; }
        public int Righe { get => righe; }
        public bool Annulla { get => annulla; }

        private void nudColonne_ValueChanged(object sender, EventArgs e)
        {
            colonne = (int)nudColonne.Value;
        }

        private void nudRighe_ValueChanged(object sender, EventArgs e)
        {
            righe = (int)nudRighe.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            annulla = true;
            this.Close();
        }
    }
}
