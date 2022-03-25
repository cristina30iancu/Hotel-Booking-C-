using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class MeniuForm : Form
    {
        public VizualizareCamere vizCam=null;
        public RezervaForm rez=null;
        public VizRezervariForm vizRez=null;
        public MeniuForm()
        {
            InitializeComponent();
        }

        private void buttonCamere_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (vizCam == null)
            {
                VizualizareCamere vzc = new VizualizareCamere(this);
                vizCam = vzc;
            }
            vizCam.ContextMenuStrip = vizCam.contextMenuStrip1;
            vizCam.Show();
        }

        private void buttonRezerva_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (rez == null)
            {
                RezervaForm fm = new RezervaForm(this);
                rez = fm;
            }
            rez.CurataControale();
            rez.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (vizRez == null)
            {
                VizRezervariForm vz = new VizRezervariForm(this);
                vizRez = vz;
            }
            vizRez.Show();
        }

        private void MeniuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                this.Hide();
                if (rez == null)
                {
                    RezervaForm fm = new RezervaForm(this);
                    rez = fm;
                }
                rez.Show();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                this.Hide();
                if (vizCam == null)
                {
                    VizualizareCamere vzc = new VizualizareCamere(this);
                    vizCam = vzc;
                }
                vizCam.ContextMenuStrip = vizCam.contextMenuStrip1;
                vizCam.Show();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
            {
                this.Hide();
                if (vizRez == null)
                {
                    VizRezervariForm vz = new VizRezervariForm(this);
                    vizRez = vz;
                }
                vizRez.Show();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                this.Close();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        Point loc;
        bool mouseDown;

        private void MeniuForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; loc = e.Location;
        }

        private void MeniuForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MeniuForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
                this.Location = new Point((this.Location.X - loc.X) + e.X, (this.Location.Y - loc.Y) + e.Y);

        }
    }
}
