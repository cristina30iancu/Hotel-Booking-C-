using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class VizualizareCamere : Form
    {
        MeniuForm menu=null;
        List<Camera> camere = null;
        bool isBd = false;
        string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cazari;Integrated Security=True";
        DataSet dsCamere = new DataSet();
        string SelectCommand = "Select * from dbo.Camere";
        public VizualizareCamere(MeniuForm menu)
        {
            InitializeComponent();
            exitBtn.Visible = false;
            this.menu = menu;
            camere = new List<Camera>();
            citesteCamere();
            Adauga();
            grupBD.Visible = false;
        }
        private void AdaugaCamere()
        {
            Camera m = new Camera("Single", 23, 2, 45.6, true, 1);
            ListViewItem lvi1 = new ListViewItem(m.Numar.ToString());
            lvi1.SubItems.Add(m.Tip);
            lvi1.SubItems.Add(m.Etaj.ToString());
            lvi1.SubItems.Add(m.Capacitate.ToString());
            if (m.VedereLaMare) lvi1.SubItems.Add("Da");
            else lvi1.SubItems.Add("Nu");
            lvi1.SubItems.Add(m.PretPeNoapte.ToString());
            lvi1.UseItemStyleForSubItems = false;
            lvi1.Tag = m;
            listViewCamere.Items.Add(lvi1);
            camere.Add(m);
        }
        public void UpdateItems()
        {
            foreach (ListViewItem lvi in listViewCamere.Items)
            {
                Camera m = (Camera)lvi.Tag;
                lvi.Text = m.Numar.ToString();
                lvi.SubItems[1].Text = m.Tip;
                lvi.SubItems[2].Text = m.Etaj.ToString();
                lvi.SubItems[3].Text = m.Capacitate.ToString();
                if (m.VedereLaMare) lvi.SubItems[4].Text = "Da";
                else lvi.SubItems[4].Text = "Nu";
                lvi.SubItems[5].Text = m.PretPeNoapte.ToString();
            }
        }
        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new
               ListViewItem(new string[] { "", "", "", "" ,"",""});
            listViewCamere.Items.Add(lvi);
            Camera m = new Camera("", 0, 0, 0, false, 0);
            lvi.Tag = m;

            AdaugaCameraForm fm = new AdaugaCameraForm(this,m);

            fm.Text = "Adaugare Camera";
            
            fm.ShowDialog();
            camere.Add(m);
            if (fm.DialogResult != DialogResult.OK)
            {
                lvi.Remove();
            }
            Adauga();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                Camera c = (Camera)listViewCamere.SelectedItems[0].Tag;
                AdaugaCameraForm fm = new AdaugaCameraForm(this, c);

                fm.Text = "Modificare camera";
                string btntext = "Modifica camera";
                fm.ActualizeazaControale(listViewCamere, e,btntext);
                fm.parinte = this;
                fm.ShowDialog();
                Adauga();
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                Camera c = (Camera)listViewCamere.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti camera numarul " + c.Numar + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes) 
                { 
                    listViewCamere.SelectedItems[0].Remove();
                    camere.Remove(c);
                    Adauga();
                }
                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                rezervaToolStripMenuItem.Enabled = true;
                stergeToolStripMenuItem.Enabled = true;
                modificaToolStripMenuItem.Enabled = true;
            }
            else
            {  
                stergeToolStripMenuItem.Enabled = false;
                modificaToolStripMenuItem.Enabled = false;
                rezervaToolStripMenuItem.Enabled = false;
            }
        }

        private void rezervaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                this.Hide();
                if (menu.rez == null){
                    RezervaForm mf = new RezervaForm(menu,this, null);
                    menu.rez = mf;
                    mf.back = this;
                    
                }
                menu.rez.CurataControale();
                listViewCamere.SelectedIndexChanged += new EventHandler(menu.rez.ActualizeazaControale);
                menu.rez.ActualizeazaControale(listViewCamere, e);
                menu.rez.button1.Text = "Schimba camera";
                if (isBd == true) menu.rez.buttonRezerva.Text = "Insert";
                else menu.rez.buttonRezerva.Text = "Adauga";
                menu.rez.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void listViewCamere_MouseDown(object sender, MouseEventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
                listViewCamere.DoDragDrop(listViewCamere.SelectedItems[0], DragDropEffects.Copy);
            
        }
        Point loc;
        bool mouseDown;
       
        private void VizualizareCamere_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; loc = e.Location;
        }

        private void VizualizareCamere_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
                this.Location = new Point((this.Location.X - loc.X) + e.X, (this.Location.Y - loc.Y) + e.Y);

        }

        private void VizualizareCamere_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Camera> camere = listViewCamere.Items.Cast<ListViewItem>().Select(item => (Camera)item.Tag).ToList();
            StreamWriter sw = new StreamWriter("Camere.txt");
            foreach (Camera m in camere)
            {
                sw.WriteLine(m.Tip);
                sw.WriteLine(m.Numar);
                sw.WriteLine(m.Etaj);
                sw.WriteLine(m.PretPeNoapte);
                sw.WriteLine(m.VedereLaMare);
                sw.WriteLine(m.Capacitate);
            }
            sw.Close();
        }
        private void AdaugaCamereListView()
        {
            listViewCamere.Items.Clear();
            foreach(Camera m in camere.ToList())
            {
                ListViewItem lvi1 = new ListViewItem(m.Numar.ToString());
                lvi1.SubItems.Add(m.Tip);
                lvi1.SubItems.Add(m.Etaj.ToString());
                lvi1.SubItems.Add(m.Capacitate.ToString());
                if (m.VedereLaMare) lvi1.SubItems.Add("Da");
                else lvi1.SubItems.Add("Nu");
                lvi1.SubItems.Add(m.PretPeNoapte.ToString());
                lvi1.UseItemStyleForSubItems = false;
                lvi1.Tag = m;
                listViewCamere.Items.Add(lvi1);
            }
        }
        private void citesteCamere()
        {
           
            List<Camera> lista = new List<Camera>();
            StreamReader sr = new StreamReader("Camere.txt");
            string[] lines = System.IO.File.ReadAllLines("Camere.txt");
            for (int i = 0; i < lines.Length - 5; i += 6)
            {
                bool vedere = false;
                if (lines[i + 4] == "True") vedere = true;
                Camera c = new Camera(lines[i], (short)(Int32.Parse(lines[i + 1])), (short)(Int32.Parse(lines[i + 2])),
                    Double.Parse(lines[i + 3]), vedere, Int32.Parse(lines[i + 5]));
                lista.Add(c);
            }
            sr.Close();
            camere = null;
            camere = lista;
            AdaugaCamereListView();
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            citesteCamere();
            Adauga();
            grupBD.Visible = false;
            stergeToolStripMenuItem.Enabled = true;
            modificaToolStripMenuItem.Enabled = true;
        }
        //citire din binar
        private void binarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stergeToolStripMenuItem.Enabled = true;
            modificaToolStripMenuItem.Enabled = true;
            grupBD.Visible = false;
            OpenFileDialog fd = new OpenFileDialog();
            fd.CheckPathExists = true;
            fd.CheckFileExists = true;
            fd.Filter = "Fisiere binare (*bin)|*.bin";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fb = File.OpenRead(fd.FileName);
                BinaryFormatter des = new BinaryFormatter();
                camere = null;
                camere = (List<Camera>)des.Deserialize(fb);
                AdaugaCamereListView();
                Adauga();
                fb.Close();
            }
          
        }
        // salvare in binar
        private void binarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.CheckPathExists = true;
            fd.Filter = "Fisiere binare (*bin)|*.bin";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fb = File.Create(fd.FileName);
                BinaryFormatter serializator = new BinaryFormatter();
                serializator.Serialize(fb, camere);
                fb.Close();
            }
        }
        void Adauga()
        {
            List<string> luni = new List<string>();
            luni.Add("Single"); luni.Add("Double"); luni.Add("Triple"); luni.Add("Family");
            List<double> valori = new List<double>(); valori.Add(0); valori.Add(0); valori.Add(0); valori.Add(0);
            for (int i = 0; i < 4; i++)
            {
                foreach(Camera c in camere)
                {
                    if (c.Tip.TrimEnd() == luni[i])
                        valori[i]++;
                }
            }
            for(int i=0;i<4;i++)
            {
                if (valori[i] == 0)
                {
                    valori.Remove(valori[i]);
                    luni.Remove(luni[i]);
                    i++;
                }
            }
            if (luni.Count == 0)
            {
                MessageBox.Show("Camere insuficiente");
                return;
            }
            grafic1.Luni = luni;
            grafic1.Valori = valori;
            grafic1.Invalidate(true);
        }

        void IncarcaDate()
        {
            listViewCamere.Items.Clear();
            SqlConnection conexiune = new SqlConnection(stringConexiune);
            conexiune.Open();  
            SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommand, conexiune);
            adaptor.Fill(dsCamere, "Camere");
            dsCamere.Tables["Camere"].PrimaryKey = new DataColumn[1] { dsCamere.Tables["Camere"].Columns["Numar"] };

            conexiune.Close(); 
            DataTable dt = dsCamere.Tables[0];
            camere.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                bool vedere = false;
                if (dr[4].ToString() == "True") vedere = true;
                Camera c = new Camera(dr[1].ToString(), (short)(Int32.Parse(dr[0].ToString())), (short)(Int32.Parse(dr[2].ToString())),
                    Double.Parse(dr[3].ToString()), vedere, Int32.Parse(dr[5].ToString()));
                camere.Add(c);
            }
            Adauga();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            IncarcaDate();
            AdaugaCamereListView();
            grupBD.Visible = true;
            stergeToolStripMenuItem.Enabled = false;
            modificaToolStripMenuItem.Enabled = false;
            isBd = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                Camera c = (Camera)listViewCamere.SelectedItems[0].Tag;
               
                    AdaugaCameraForm fm = new AdaugaCameraForm(this, c);

                    fm.Text = "Modificare camera";
                    string btntext = "Update camera";
                    // listViewCamere.SelectedIndexChanged += new EventHandler(fm.ActualizeazaControale);
                    fm.ActualizeazaControale(listViewCamere, e, btntext);
                    fm.parinte = this;
                    fm.ShowDialog();
            }
            else MessageBox.Show("Selectati o camera pentru a efectua operatia");
            Adauga();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewCamere.SelectedItems.Count > 0)
            {
                Camera c = (Camera)listViewCamere.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti camera numarul " + c.Numar + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    listViewCamere.SelectedItems[0].Remove();
                    camere.Remove(c);
                    string UpdateCommand = "delete from dbo.Camere where Numar=@Numar";
                    SqlConnection conexiune = new SqlConnection(stringConexiune);
                    conexiune.Open();
                    SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommand, conexiune);
                    adaptor.UpdateCommand = conexiune.CreateCommand();
                    adaptor.UpdateCommand.CommandText = UpdateCommand;
                    int nr = Int32.Parse(c.Numar.ToString());
                    adaptor.UpdateCommand.Parameters.AddWithValue("@Numar", nr);
                    adaptor.UpdateCommand.ExecuteNonQuery();
                    conexiune.Close(); Adauga();
                }               
            }
            else MessageBox.Show("Selectati o camera pentru a efectua operatia");

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(new string[] { "", "", "", "", "", "" });
            listViewCamere.Items.Add(lvi);
            Camera m = new Camera("", 0, 0, 0, false, 0);
            lvi.Tag = m;
            AdaugaCameraForm fm = new AdaugaCameraForm(this, m);
            fm.Text = "Insert Camera";
            fm.ShowDialog(); 
            if (fm.DialogResult != DialogResult.OK)   lvi.Remove();
            else
            {
                camere.Add(m);
                string InsertCommand = "insert into dbo.Camere(Numar,Tip,Etaj,Capacitate,Vedere,Pret)" +
                    " values (@Numar,@Tip,@Etaj,@Capacitate,@Vedere,@Pret)";
                SqlConnection conexiune = new SqlConnection(stringConexiune);
                conexiune.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommand, conexiune);
                adaptor.InsertCommand = conexiune.CreateCommand();
                adaptor.InsertCommand.CommandText = InsertCommand;
                adaptor.InsertCommand.Parameters.AddWithValue("@Tip", m.Tip.ToString());
                adaptor.InsertCommand.Parameters.AddWithValue("@Etaj", m.Etaj.ToString());
                adaptor.InsertCommand.Parameters.AddWithValue("@Capacitate", m.Capacitate);
                adaptor.InsertCommand.Parameters.AddWithValue("@Vedere", m.VedereLaMare);
                adaptor.InsertCommand.Parameters.AddWithValue("@Pret", m.PretPeNoapte);
                adaptor.InsertCommand.Parameters.AddWithValue("@Numar", m.Numar);
                adaptor.InsertCommand.ExecuteNonQuery();
                conexiune.Close();
            }
            Adauga();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
