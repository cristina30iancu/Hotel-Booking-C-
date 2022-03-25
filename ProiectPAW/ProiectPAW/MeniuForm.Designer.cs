
namespace ProiectPAW
{
    partial class MeniuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeniuForm));
            this.buttonCamere = new System.Windows.Forms.Button();
            this.buttonRezerva = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCamere
            // 
            this.buttonCamere.BackColor = System.Drawing.Color.Navy;
            this.buttonCamere.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCamere.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCamere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonCamere.Location = new System.Drawing.Point(1, 303);
            this.buttonCamere.Name = "buttonCamere";
            this.buttonCamere.Size = new System.Drawing.Size(376, 47);
            this.buttonCamere.TabIndex = 0;
            this.buttonCamere.Text = "Afiseaza camere";
            this.buttonCamere.UseVisualStyleBackColor = false;
            this.buttonCamere.Click += new System.EventHandler(this.buttonCamere_Click);
            // 
            // buttonRezerva
            // 
            this.buttonRezerva.BackColor = System.Drawing.Color.Transparent;
            this.buttonRezerva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRezerva.BackgroundImage")));
            this.buttonRezerva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRezerva.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRezerva.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRezerva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonRezerva.Location = new System.Drawing.Point(12, 13);
            this.buttonRezerva.Name = "buttonRezerva";
            this.buttonRezerva.Size = new System.Drawing.Size(227, 203);
            this.buttonRezerva.TabIndex = 1;
            this.buttonRezerva.UseVisualStyleBackColor = false;
            this.buttonRezerva.Click += new System.EventHandler(this.buttonRezerva_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(1, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(376, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Afiseaza rezervari";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Image = global::ProiectPAW.Properties.Resources.exit;
            this.exitBtn.Location = new System.Drawing.Point(714, 13);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(83, 56);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MeniuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ProiectPAW.Properties.Resources.appBg;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRezerva);
            this.Controls.Add(this.buttonCamere);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MeniuForm";
            this.Text = "MeniuForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MeniuForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MeniuForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MeniuForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MeniuForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCamere;
        private System.Windows.Forms.Button buttonRezerva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exitBtn;
    }
}