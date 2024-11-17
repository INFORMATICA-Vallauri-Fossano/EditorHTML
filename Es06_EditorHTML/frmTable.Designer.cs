namespace Es06_EditorHTML
{
    partial class frmTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudColonne = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRighe = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudColonne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRighe)).BeginInit();
            this.SuspendLayout();
            // 
            // nudColonne
            // 
            this.nudColonne.Location = new System.Drawing.Point(93, 89);
            this.nudColonne.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColonne.Name = "nudColonne";
            this.nudColonne.Size = new System.Drawing.Size(197, 22);
            this.nudColonne.TabIndex = 0;
            this.nudColonne.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColonne.ValueChanged += new System.EventHandler(this.nudColonne_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Immettere il numero di Colonne e Righe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "COLONNE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "RIGHE";
            // 
            // nudRighe
            // 
            this.nudRighe.Location = new System.Drawing.Point(93, 133);
            this.nudRighe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRighe.Name = "nudRighe";
            this.nudRighe.Size = new System.Drawing.Size(197, 22);
            this.nudRighe.TabIndex = 3;
            this.nudRighe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRighe.ValueChanged += new System.EventHandler(this.nudRighe_ValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(93, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(196, 200);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(94, 23);
            this.btnAnnulla.TabIndex = 6;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 244);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRighe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudColonne);
            this.Name = "frmTable";
            this.Text = "frmTable";
            ((System.ComponentModel.ISupportInitialize)(this.nudColonne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRighe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudColonne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRighe;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
    }
}