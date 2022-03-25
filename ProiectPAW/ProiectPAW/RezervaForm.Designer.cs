
namespace ProiectPAW
{
    partial class RezervaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervaForm));
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimeIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimeOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRezerva = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelClient = new System.Windows.Forms.Panel();
            this.textBoxCNP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCamera = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPret = new System.Windows.Forms.TextBox();
            this.labelPRet = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grupPret = new System.Windows.Forms.GroupBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panelClient.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grupPret.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(571, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Alege camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimeIn
            // 
            this.dateTimeIn.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimeIn.Location = new System.Drawing.Point(187, 96);
            this.dateTimeIn.Name = "dateTimeIn";
            this.dateTimeIn.Size = new System.Drawing.Size(200, 26);
            this.dateTimeIn.TabIndex = 6;
            this.dateTimeIn.ValueChanged += new System.EventHandler(this.dateTimeIn_ValueChanged);
            // 
            // dateTimeOut
            // 
            this.dateTimeOut.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimeOut.Location = new System.Drawing.Point(532, 96);
            this.dateTimeOut.Name = "dateTimeOut";
            this.dateTimeOut.Size = new System.Drawing.Size(200, 26);
            this.dateTimeOut.TabIndex = 7;
            this.dateTimeOut.ValueChanged += new System.EventHandler(this.dateTimeOut_ValueChanged);
            this.dateTimeOut.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimeOut_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(282, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rezerva-ti vacanta la mare!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(76, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Check-in";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(404, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Check-out";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Blue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(37, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nume";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Blue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(37, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Prenume";
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(152, 36);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(190, 26);
            this.textBoxNume.TabIndex = 8;
            this.textBoxNume.TextChanged += new System.EventHandler(this.textBoxNume_TextChanged);
            this.textBoxNume.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNume_Validating);
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Location = new System.Drawing.Point(152, 78);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(190, 26);
            this.textBoxPrenume.TabIndex = 9;
            this.textBoxPrenume.TextChanged += new System.EventHandler(this.textBoxPrenume_TextChanged);
            this.textBoxPrenume.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPrenume_Validating);
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(152, 120);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(190, 26);
            this.textBoxTelefon.TabIndex = 10;
            this.textBoxTelefon.TextChanged += new System.EventHandler(this.textBoxTelefon_TextChanged);
            this.textBoxTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTelefon_Validating);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(152, 162);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(190, 26);
            this.textBoxEmail.TabIndex = 11;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            this.textBoxEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmail_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Blue;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(37, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Telefon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Blue;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(37, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Email";
            // 
            // buttonRezerva
            // 
            this.buttonRezerva.BackColor = System.Drawing.Color.Blue;
            this.buttonRezerva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRezerva.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRezerva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonRezerva.Location = new System.Drawing.Point(35, 486);
            this.buttonRezerva.Name = "buttonRezerva";
            this.buttonRezerva.Size = new System.Drawing.Size(163, 43);
            this.buttonRezerva.TabIndex = 14;
            this.buttonRezerva.Text = "Rezerva";
            this.buttonRezerva.UseVisualStyleBackColor = false;
            this.buttonRezerva.Click += new System.EventHandler(this.buttonRezerva_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(613, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Camera";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(56, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Date rezervare";
            // 
            // panelClient
            // 
            this.panelClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelClient.BackgroundImage")));
            this.panelClient.Controls.Add(this.textBoxCNP);
            this.panelClient.Controls.Add(this.label12);
            this.panelClient.Controls.Add(this.domainUpDown1);
            this.panelClient.Controls.Add(this.label11);
            this.panelClient.Controls.Add(this.textBoxNume);
            this.panelClient.Controls.Add(this.textBoxTelefon);
            this.panelClient.Controls.Add(this.textBoxPrenume);
            this.panelClient.Controls.Add(this.textBoxEmail);
            this.panelClient.Controls.Add(this.label5);
            this.panelClient.Controls.Add(this.label7);
            this.panelClient.Controls.Add(this.label4);
            this.panelClient.Controls.Add(this.label6);
            this.panelClient.Location = new System.Drawing.Point(35, 183);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(391, 286);
            this.panelClient.TabIndex = 18;
            // 
            // textBoxCNP
            // 
            this.textBoxCNP.Location = new System.Drawing.Point(152, 204);
            this.textBoxCNP.Name = "textBoxCNP";
            this.textBoxCNP.Size = new System.Drawing.Size(190, 26);
            this.textBoxCNP.TabIndex = 12;
            this.textBoxCNP.TextChanged += new System.EventHandler(this.textBoxCNP_TextChanged);
            this.textBoxCNP.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCNP_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Blue;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(37, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "CNP";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("2");
            this.domainUpDown1.Items.Add("3");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Location = new System.Drawing.Point(216, 243);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(135, 26);
            this.domainUpDown1.TabIndex = 13;
            this.domainUpDown1.Validating += new System.ComponentModel.CancelEventHandler(this.domainUpDown1_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Blue;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(37, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Numar persoane";
            // 
            // textBoxCamera
            // 
            this.textBoxCamera.AllowDrop = true;
            this.textBoxCamera.Location = new System.Drawing.Point(571, 230);
            this.textBoxCamera.Multiline = true;
            this.textBoxCamera.Name = "textBoxCamera";
            this.textBoxCamera.ReadOnly = true;
            this.textBoxCamera.Size = new System.Drawing.Size(161, 118);
            this.textBoxCamera.TabIndex = 19;
            this.textBoxCamera.TextChanged += new System.EventHandler(this.textBoxCamera_TextChanged);
            this.textBoxCamera.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCamera_DragDrop);
            this.textBoxCamera.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxCamera_DragOver);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Blue;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Pret total";
            // 
            // textBoxPret
            // 
            this.textBoxPret.Location = new System.Drawing.Point(125, 20);
            this.textBoxPret.Name = "textBoxPret";
            this.textBoxPret.Size = new System.Drawing.Size(100, 26);
            this.textBoxPret.TabIndex = 21;
            // 
            // labelPRet
            // 
            this.labelPRet.AutoSize = true;
            this.labelPRet.BackColor = System.Drawing.Color.Blue;
            this.labelPRet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPRet.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPRet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelPRet.Location = new System.Drawing.Point(231, 22);
            this.labelPRet.Name = "labelPRet";
            this.labelPRet.Size = new System.Drawing.Size(46, 20);
            this.labelPRet.TabIndex = 22;
            this.labelPRet.Text = "RON";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(823, 33);
            this.toolStrip2.TabIndex = 24;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton3.Text = "Inapoi";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grupPret
            // 
            this.grupPret.BackColor = System.Drawing.Color.Transparent;
            this.grupPret.Controls.Add(this.label10);
            this.grupPret.Controls.Add(this.textBoxPret);
            this.grupPret.Controls.Add(this.labelPRet);
            this.grupPret.Location = new System.Drawing.Point(435, 465);
            this.grupPret.Name = "grupPret";
            this.grupPret.Size = new System.Drawing.Size(318, 64);
            this.grupPret.TabIndex = 25;
            this.grupPret.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Image = global::ProiectPAW.Properties.Resources.exit;
            this.exitBtn.Location = new System.Drawing.Point(740, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(83, 56);
            this.exitBtn.TabIndex = 26;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // RezervaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 565);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.grupPret);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.textBoxCamera);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonRezerva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimeOut);
            this.Controls.Add(this.dateTimeIn);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "RezervaForm";
            this.Text = "RezervaForm";
            this.Load += new System.EventHandler(this.RezervaForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RezervaForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RezervaForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RezervaForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RezervaForm_MouseUp);
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grupPret.ResumeLayout(false);
            this.grupPret.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimeIn;
        private System.Windows.Forms.DateTimePicker dateTimeOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.TextBox textBoxPrenume;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPret;
        private System.Windows.Forms.Label labelPRet;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        public System.Windows.Forms.TextBox textBoxCamera;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grupPret;
        internal System.Windows.Forms.Button buttonRezerva;
        private System.Windows.Forms.Button exitBtn;
        public System.Windows.Forms.TextBox textBoxCNP;
    }
}