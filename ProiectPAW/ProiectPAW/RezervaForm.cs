using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class RezervaForm : Form
    {
        public VizualizareCamere parinte;
        public Camera camera;
        public Rezervare rezervare;
        public MeniuForm menu=null;

        public RezervaForm(MeniuForm menu)
        {
            InitializeComponent();
            this.menu = menu;
            grupPret.Visible = false;
            if (camera == null) { dateTimeIn.Enabled = false; dateTimeOut.Enabled = false; }
            
        }
        public RezervaForm(MeniuForm menu,VizualizareCamere par,Camera c)
        {
            InitializeComponent();
            this.menu = menu;
            parinte = par;
            camera = c;
            grupPret.Visible = false;
            if (camera == null) { dateTimeIn.Enabled = false; dateTimeOut.Enabled = false; }
        }
       
        public void CurataControale()
        {
            textBoxNume.Text = "";
            textBoxPrenume.Text = "";
            textBoxCNP.Text = "";
            textBoxTelefon.Text = "";
            textBoxEmail.Text="";
            domainUpDown1.Text = "";
            textBoxCamera.Text = "";
            button1.Text = "Adauga camera";
            grupPret.Visible = false;
            if (camera == null) { dateTimeIn.Enabled = false; dateTimeOut.Enabled = false; }

        }
        public void ActualizeazaControale(object sender, EventArgs e)
        {
            ListView listaMea = (ListView)sender;
            camera = null;
            if (listaMea.SelectedItems.Count > 0)
                camera = (Camera)listaMea.SelectedItems[0].Tag;
            if (camera != null)
            {
                textBoxCamera.Text = camera.ToString();
                button1.Text = "Schimba camera";
                rezervare = new Rezervare(camera,null,0, DateTime.Now, DateTime.Now);
               
            }
        }
        internal bool bdCamere = false;
        private void buttonRezerva_Click(object sender, EventArgs e)
        {
            bool bd = false; 
            if (this.buttonRezerva.Text == "Insert" && rezervare != null)
            {
                bd = true;
            }
            if (ValidateChildren() == false) errorProvider1.SetError(this, "");
            else
            {
                if (this.buttonRezerva.Text == "Modifica" && rezervare != null)
                {
                    menu.vizRez.SadesteArbore(); 
                }
                else if (this.buttonRezerva.Text == "Update" && rezervare != null)
                {
                    menu.vizRez.UpdateRezervare();
                    menu.vizRez.SadesteArbore();
                }
                else 
                {
                    errorProvider1.SetError(this, "");
                    if (rezervare != null)
                    {
                        Client cl = new Client();
                        cl.Nume = textBoxNume.Text;
                        cl.Prenume = textBoxPrenume.Text;
                        cl.Telefon = textBoxTelefon.Text;
                        cl.Email = textBoxEmail.Text;
                        cl.Cnp = textBoxCNP.Text;
                        rezervare.Client = cl;
                        rezervare.Camera = camera;
                        rezervare.NrPersoane = Int32.Parse(domainUpDown1.Text);
                    }
                    if (menu.vizRez == null)
                    {
                        VizRezervariForm vzf = new VizRezervariForm(menu);
                        menu.vizRez = vzf;
                    }
                    menu.vizRez.IncarcaDate();
                     menu.vizRez.AdaugaNod(rezervare,bd);
                }
                this.Hide();
                menu.vizRez.Show();
                this.DialogResult = DialogResult.OK;
                this.buttonRezerva.Text = "Adauga";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (menu == null)
            {
                MeniuForm mf = new MeniuForm();
                mf.ShowDialog();
            }
            else
            {
                menu.Show();
            }
        }

        private void dateTimeIn_ValueChanged(object sender, EventArgs e)
        {
            if (this.Text != "Modifica")
            {
                rezervare.CheckIn = dateTimeIn.Value;
              //  rezervare.CheckOut = dateTimeOut.Value;
                rezervare.calculeazaPret();
                grupPret.Visible = true;
                textBoxPret.Text = rezervare.Pret.ToString();
            }
        }

        private void dateTimeOut_ValueChanged(object sender, EventArgs e)
        {
            if (this.Text != "Modifica")
            {
                rezervare.CheckIn = dateTimeIn.Value;
                rezervare.CheckOut = dateTimeOut.Value;
                rezervare.calculeazaPret();
                grupPret.Visible = true;
                textBoxPret.Text = rezervare.Pret.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.parinte == null)
            {
                if (this.menu.vizCam == null)
                {
                    VizualizareCamere vz = new VizualizareCamere(menu);
                    parinte = vz;
                }
                else
                {
                    parinte = menu.vizCam;
                }
                
            }
            parinte.contextMenuStrip1.Enabled = false;
            parinte.toolStripButton1.Enabled = false;
            parinte.exitBtn.Visible = true;
            parinte.Show();
        }
       
        private void textBoxCamera_DragDrop(object sender, DragEventArgs e)
        {
            Camera p = (Camera)((ListViewItem)e.Data.GetData(typeof(ListViewItem))).Tag;
            this.camera = p;
            textBoxCamera.Text = camera.ToString();
            button1.Text = "Schimba camera";
            rezervare = new Rezervare(p, null, 0, DateTime.Now, DateTime.Now);
            parinte.Hide();
        }

        private void textBoxCamera_DragOver(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                
                e.Effect = DragDropEffects.None;
                return;
            }
        }

        private void RezervaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Back)
            {
                this.Hide();
                MeniuForm mf = new MeniuForm();
                mf.ShowDialog();
            }
        }

        private void textBoxNume_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNume.Text == "")
            {
                errorProvider1.SetError(textBoxNume, "Campul nu poate fi gol!");
                textBoxNume.Focus();
            }
            else if (!Regex.IsMatch(textBoxNume.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*\\s*$"))
            {
                errorProvider1.SetError(textBoxNume, "Numele incepe cu litera mare si nu poate contine cifre!");
                textBoxNume.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxNume, "");
            }
        }

        private void textBoxPrenume_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPrenume.Text == "")
            {
                errorProvider1.SetError(textBoxPrenume, "Campul nu poate fi gol!");
                textBoxPrenume.Focus();
            }
            else if (!Regex.IsMatch(textBoxPrenume.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*\\s*$"))
            {
                errorProvider1.SetError(textBoxPrenume, "Preumele incepe cu litera mare si nu poate contine cifre!");
                textBoxPrenume.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxPrenume, "");
            }
        }

        private void textBoxTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxTelefon.Text == "")
            {
                errorProvider1.SetError(textBoxTelefon, "Campul nu poate fi gol!");
                textBoxTelefon.Focus();
            }
            else if (textBoxTelefon.Text.Length<10)
            {
                errorProvider1.SetError(textBoxTelefon, "Telefonul trebuie sa respecte numarul de cifre!");
                textBoxTelefon.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxTelefon, "");
            }
        }
        
        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                errorProvider1.SetError(textBoxEmail, "Campul nu poate fi gol!");
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, "[a-zA-Z0-9_\\.-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9\\.]{2,5}\\s*$"))
            {
                errorProvider1.SetError(textBoxEmail, "Email-ul trebuie sa respecte formatul!");
                textBoxEmail.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxEmail, "");
            }
        }

        private void textBoxCNP_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCNP.Text == "")
            {
                errorProvider1.SetError(textBoxCNP, "Campul nu poate fi gol!");
                textBoxCNP.Focus();
            }
            else if (textBoxCNP.Text.Length!=13)
            {
                errorProvider1.SetError(textBoxCNP, "CNP-ul trebuie sa aiba 13 cifre!");
                textBoxCNP.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxCNP, "");
            }
        }

        private void domainUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(domainUpDown1.Text, out int rez) == false)
            {
                errorProvider1.SetError(domainUpDown1, "Numar de persoane invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(domainUpDown1.Text) < 1|| Convert.ToInt32(domainUpDown1.Text)>4)
                {
                    errorProvider1.SetError(domainUpDown1, "Pot fi intre 1 si 4 persoane.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(domainUpDown1, ""); 
                }
            }
        }
        
        Point loc;
        bool mouseDown;
        
        private void RezervaForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            loc = e.Location;
        }

        private void RezervaForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void textBoxCamera_TextChanged(object sender, EventArgs e)
        {
            if (camera != null) 
            { dateTimeIn.Enabled = true; 
                dateTimeOut.Enabled = true;
                if(rezervare!=null) 
                    rezervare.Camera = camera; }
        }

        private void RezervaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) 
                this.Location = new Point((this.Location.X - loc.X) + e.X, (this.Location.Y - loc.Y) + e.Y);
        }

        private void dateTimeOut_Validating(object sender, CancelEventArgs e)
        {
           if(dateTimeOut.Value.Month==DateTime.Now.Month&&dateTimeOut.Value.Day==DateTime.Now.Day)
            {
                errorProvider1.SetError(dateTimeOut, "Adaugati o data de plecare valida!");
                e.Cancel = true;
            }
           else errorProvider1.SetError(dateTimeOut, "");
        }

        internal void ActualizeazaControaleTreeView()
        {
            if (camera != null)
            {
                textBoxCamera.Text = camera.ToString();
                dateTimeIn.Value = rezervare.CheckIn.Date;
                dateTimeOut.Value = rezervare.CheckOut.Date;
                textBoxNume.Text = rezervare.Client.Nume;
                textBoxPrenume.Text = rezervare.Client.Prenume;
                textBoxCNP.Text = rezervare.Client.Cnp;
                textBoxEmail.Text = rezervare.Client.Email;
                textBoxTelefon.Text = rezervare.Client.Telefon;
                textBoxPret.Text = rezervare.Pret.ToString();
                domainUpDown1.Text = rezervare.NrPersoane.ToString();
                rezervare.calculeazaPret();
                grupPret.Visible = true;
                textBoxPret.Text = rezervare.Pret.ToString();
                this.Text = "Modifica ";
            }
        }
        internal Form back = null;
        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (back == null) menu.Show();
             else   back.Show(); 
            this.Hide();
        }

        private void textBoxNume_TextChanged(object sender, EventArgs e)
        {
            if(rezervare!=null)
            {
                if (rezervare.Client != null)
                    rezervare.Client.Nume = textBoxNume.Text;
            }
        }

        private void textBoxPrenume_TextChanged(object sender, EventArgs e)
        {
            if (rezervare != null)
            {
                if(rezervare.Client!=null)
                rezervare.Client.Prenume = textBoxPrenume.Text;
            }
        }

        private void textBoxTelefon_TextChanged(object sender, EventArgs e)
        {
            if (rezervare != null)
            {
                if (rezervare.Client != null)
                    rezervare.Client.Telefon = textBoxTelefon.Text;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (rezervare != null)
            {
                if (rezervare.Client != null)
                    rezervare.Client.Email = textBoxEmail.Text;
            }
        }

        private void textBoxCNP_TextChanged(object sender, EventArgs e)
        {
            if (rezervare != null)
            {
                if (rezervare.Client != null)
                    rezervare.Client.Cnp = textBoxCNP.Text;
            }
        }

        private void RezervaForm_Load(object sender, EventArgs e)
        {
            if (buttonRezerva.Text == "Modifica" || buttonRezerva.Text == "Update")
            { textBoxCNP.ReadOnly = true; textBoxCNP.Enabled = false; }
            else { 
            textBoxCNP.ReadOnly = false; textBoxCNP.Enabled = true;
        }
        }
    }
}
