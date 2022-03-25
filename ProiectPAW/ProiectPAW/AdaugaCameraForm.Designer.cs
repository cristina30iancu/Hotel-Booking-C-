
namespace ProiectPAW
{
    partial class AdaugaCameraForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaugaCameraForm));
            this.tbNr = new System.Windows.Forms.TextBox();
            this.tbEtaj = new System.Windows.Forms.TextBox();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.comboBoxTip = new System.Windows.Forms.ComboBox();
            this.labelTip = new System.Windows.Forms.Label();
            this.labelNr = new System.Windows.Forms.Label();
            this.labelEtaj = new System.Windows.Forms.Label();
            this.labelPret = new System.Windows.Forms.Label();
            this.checkBoxVedere = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCapacitate = new System.Windows.Forms.ComboBox();
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNr
            // 
            this.tbNr.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNr.Location = new System.Drawing.Point(281, 101);
            this.tbNr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNr.Name = "tbNr";
            this.tbNr.ReadOnly = true;
            this.tbNr.Size = new System.Drawing.Size(229, 27);
            this.tbNr.TabIndex = 2;
            this.tbNr.Validating += new System.ComponentModel.CancelEventHandler(this.tbNr_Validating);
            // 
            // tbEtaj
            // 
            this.tbEtaj.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEtaj.Location = new System.Drawing.Point(281, 171);
            this.tbEtaj.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbEtaj.Name = "tbEtaj";
            this.tbEtaj.Size = new System.Drawing.Size(229, 27);
            this.tbEtaj.TabIndex = 3;
            this.tbEtaj.Validating += new System.ComponentModel.CancelEventHandler(this.tbEtaj_Validating);
            // 
            // tbPret
            // 
            this.tbPret.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPret.Location = new System.Drawing.Point(281, 241);
            this.tbPret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(229, 27);
            this.tbPret.TabIndex = 4;
            this.tbPret.Validating += new System.ComponentModel.CancelEventHandler(this.tbPret_Validating);
            // 
            // comboBoxTip
            // 
            this.comboBoxTip.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTip.FormattingEnabled = true;
            this.comboBoxTip.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Triple",
            "Family"});
            this.comboBoxTip.Location = new System.Drawing.Point(281, 29);
            this.comboBoxTip.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxTip.Name = "comboBoxTip";
            this.comboBoxTip.Size = new System.Drawing.Size(229, 27);
            this.comboBoxTip.TabIndex = 1;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.BackColor = System.Drawing.Color.Blue;
            this.labelTip.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelTip.Location = new System.Drawing.Point(31, 29);
            this.labelTip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(114, 20);
            this.labelTip.TabIndex = 5;
            this.labelTip.Text = "Tip camera";
            // 
            // labelNr
            // 
            this.labelNr.AutoSize = true;
            this.labelNr.BackColor = System.Drawing.Color.Blue;
            this.labelNr.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelNr.Location = new System.Drawing.Point(31, 99);
            this.labelNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNr.Name = "labelNr";
            this.labelNr.Size = new System.Drawing.Size(147, 20);
            this.labelNr.TabIndex = 6;
            this.labelNr.Text = "Numar camera";
            // 
            // labelEtaj
            // 
            this.labelEtaj.AutoSize = true;
            this.labelEtaj.BackColor = System.Drawing.Color.Blue;
            this.labelEtaj.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelEtaj.Location = new System.Drawing.Point(31, 169);
            this.labelEtaj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEtaj.Name = "labelEtaj";
            this.labelEtaj.Size = new System.Drawing.Size(49, 20);
            this.labelEtaj.TabIndex = 7;
            this.labelEtaj.Text = "Etaj";
            // 
            // labelPret
            // 
            this.labelPret.AutoSize = true;
            this.labelPret.BackColor = System.Drawing.Color.Blue;
            this.labelPret.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPret.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelPret.Location = new System.Drawing.Point(31, 239);
            this.labelPret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPret.Name = "labelPret";
            this.labelPret.Size = new System.Drawing.Size(153, 20);
            this.labelPret.TabIndex = 8;
            this.labelPret.Text = "Pret pe noapte";
            // 
            // checkBoxVedere
            // 
            this.checkBoxVedere.AutoSize = true;
            this.checkBoxVedere.BackColor = System.Drawing.Color.Blue;
            this.checkBoxVedere.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVedere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxVedere.Location = new System.Drawing.Point(321, 311);
            this.checkBoxVedere.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxVedere.Name = "checkBoxVedere";
            this.checkBoxVedere.Size = new System.Drawing.Size(179, 24);
            this.checkBoxVedere.TabIndex = 6;
            this.checkBoxVedere.Text = "Vedere la mare";
            this.checkBoxVedere.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(29, 311);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Capacitate";
            // 
            // comboBoxCapacitate
            // 
            this.comboBoxCapacitate.FormattingEnabled = true;
            this.comboBoxCapacitate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxCapacitate.Location = new System.Drawing.Point(193, 309);
            this.comboBoxCapacitate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxCapacitate.Name = "comboBoxCapacitate";
            this.comboBoxCapacitate.Size = new System.Drawing.Size(83, 28);
            this.comboBoxCapacitate.TabIndex = 5;
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.BackColor = System.Drawing.Color.Blue;
            this.buttonAdauga.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdauga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAdauga.Location = new System.Drawing.Point(202, 374);
            this.buttonAdauga.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(149, 54);
            this.buttonAdauga.TabIndex = 7;
            this.buttonAdauga.Text = "Adauga";
            this.buttonAdauga.UseVisualStyleBackColor = false;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AdaugaCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(546, 470);
            this.Controls.Add(this.buttonAdauga);
            this.Controls.Add(this.comboBoxCapacitate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxVedere);
            this.Controls.Add(this.labelPret);
            this.Controls.Add(this.labelEtaj);
            this.Controls.Add(this.labelNr);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.comboBoxTip);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbEtaj);
            this.Controls.Add(this.tbNr);
            this.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AdaugaCameraForm";
            this.Text = "AdaugaCameraForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNr;
        private System.Windows.Forms.TextBox tbEtaj;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.ComboBox comboBoxTip;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Label labelNr;
        private System.Windows.Forms.Label labelEtaj;
        private System.Windows.Forms.Label labelPret;
        private System.Windows.Forms.CheckBox checkBoxVedere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCapacitate;
        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}