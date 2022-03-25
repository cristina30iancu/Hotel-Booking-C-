using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class VizRezervariForm : Form
    {
        public MeniuForm menu = null;
        Rezervare rez;
        List<Rezervare> rezervari = null;
        List<Client> clienti = null;
        List<Camera> camere = null;

        string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cazari;Integrated Security=True";
        DataSet dsCamereRez = new DataSet();
        DataSet dsRez = new DataSet();
        DataSet dsClienti = new DataSet();
        string SelectCommandCam = "Select * from dbo.Camere";
        string SelectCommandRez = "Select * from dbo.Rezervari";
        string SelectCommandCL = "Select * from dbo.Clienti";
        public VizRezervariForm(Rezervare rez)
        {
            InitializeComponent();
            this.rez = rez;
            rezervari = new List<Rezervare>();
            clienti = new List<Client>();
            camere = new List<Camera>();
            citestefisier();
            int idMax = 0;
            if (rezervari.Count > 0)
                idMax = rezervari.Max(r => r.Id);
            rez.Id = idMax + 1;
            rezervari.Add(rez);
            SadesteArbore();
            grupBD.Visible = false;
        }
        public VizRezervariForm(MeniuForm menu)
        {
            InitializeComponent();
            rezervari = new List<Rezervare>();
            clienti = new List<Client>();
            camere = new List<Camera>();
            this.menu = menu;
            citestefisier();
            grupBD.Visible = false;
        }
        private void AdaugaRezervari()
        {
            TreeNode tCam = treeView1.Nodes.Add("Camera nr " + rez.Camera.Numar);  //creeaza nodul si adauga in colectie - se vede in arbore
            tCam.Tag = rez.Camera;
            TreeNode trez = tCam.Nodes.Add("Rez. nr. " + rez.Id + " intre " + rez.CheckIn.ToString("d") + " si " + rez.CheckOut.ToString("d"));
            trez.Tag = rez;
            rezervari.Add(rez);
            Adauga();
            treeView1.ExpandAll();
        }
        void Adauga()
        {
            List<string> luni = new List<string>();
            List<double> valori = new List<double>();
            for (int i = 5; i <=12; i++)
            {
                double x = rezervari
                         .Where(r => r.CheckIn.Month == i && r.CheckIn.Year == DateTime.Now.Year)
                         .Select(r => r.Pret)
                         .Sum(p => p);
                if (x != 0)
                {
                    luni.Add((new DateTime(2000, i, 1)).ToString("MMMM"));
                    valori.Add(x);
                }
            }

            if (luni.Count == 0)
            {
                MessageBox.Show("Rezervari insuficiente");
                return;
            }
            grafic1.Luni = luni;
            grafic1.Valori = valori;
            grafic1.Invalidate(true);
        }

        internal void UpdateRezervare()
        {
            SqlConnection conex = new SqlConnection(stringConexiune);
            conex.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(SelectCommandRez, conex);
            adapt.Fill(dsRez, "Rezervari");
            dsRez.Tables["Rezervari"].PrimaryKey = new DataColumn[1] { dsRez.Tables["Rezervari"].Columns["Id"] };
            conex.Close();
            string UpdateCommand = "update dbo.Rezervari set NrCam=@NrCam,"
                + "CnpClient=@CnpClient, NrPersoane=@NrPersoane, CheckIn=@CheckIn, CheckOut=@CheckOut " +
                " where Id=@Id";
            SqlConnection conexiune = new SqlConnection(stringConexiune);
            conexiune.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandRez, conexiune);
            adaptor.UpdateCommand = conexiune.CreateCommand();
            adaptor.UpdateCommand.CommandText = UpdateCommand;
            adaptor.UpdateCommand.Parameters.AddWithValue("@NrCam", rez.Camera.Numar);
            adaptor.UpdateCommand.Parameters.AddWithValue("@CnpClient", rez.Client.Cnp);
            adaptor.UpdateCommand.Parameters.AddWithValue("@NrPersoane", rez.NrPersoane);
            adaptor.UpdateCommand.Parameters.AddWithValue("@CheckIn", rez.CheckIn);
            adaptor.UpdateCommand.Parameters.AddWithValue("@CheckOut", rez.CheckOut);
            adaptor.UpdateCommand.Parameters.AddWithValue("@Id", rez.Id);
            adaptor.UpdateCommand.ExecuteNonQuery();
            conexiune.Close();

            conex = new SqlConnection(stringConexiune);
            conex.Open();
            adapt = new SqlDataAdapter(SelectCommandCL, conex);
            adapt.Fill(dsClienti, "Clienti");
            dsClienti.Tables["Clienti"].PrimaryKey = new DataColumn[1] { dsClienti.Tables["Clienti"].Columns["Cnp"] };
            conex.Close();
            string InsertCommCl = "update dbo.Clienti set Nume=@Nume,Prenume=@Prenume,Telefon=@Telefon,Email=@Email " +
                "where Cnp=@Cnp" ;
            SqlConnection con = new SqlConnection(stringConexiune);
            con.Open();
            BindingManagerBase legatura = BindingContext[dsClienti.Tables["Clienti"]];
            SqlDataAdapter adap = new SqlDataAdapter(SelectCommandCL, con);
            adap.UpdateCommand = con.CreateCommand();
            adap.UpdateCommand.CommandText = InsertCommCl;
            adap.UpdateCommand.Parameters.AddWithValue("@Cnp", rez.Client.Cnp.TrimEnd());
            adap.UpdateCommand.Parameters.AddWithValue("@Nume", rez.Client.Nume);
            adap.UpdateCommand.Parameters.AddWithValue("@Prenume", rez.Client.Prenume);
            adap.UpdateCommand.Parameters.AddWithValue("@Telefon", rez.Client.Telefon);
            adap.UpdateCommand.Parameters.AddWithValue("@Email", rez.Client.Email);
            adap.UpdateCommand.ExecuteNonQuery();
            con.Close();
        }

        public void AdaugaNod(Rezervare rezN, bool bd)
        {
            
            int idMax = 0;
            if (rezervari.Count > 0)
                idMax = rezervari.Max(r => r.Id);
            rezN.Id = idMax + 1;
            string deCautat = "Camera nr " + rezN.Camera.Numar;
            TreeNode tCam ;
            TreeNode[] treeNodes = null;
            treeNodes=treeView1.Nodes.Cast<TreeNode>().Where(r => r.Text == deCautat)                                .ToArray();
            
            if (treeNodes.Length<1)
            {
                tCam = treeView1.Nodes.Add("Camera nr " + rezN.Camera.Numar);  //creeaza nodul si adauga in colectie - se vede in arbore
                tCam.Tag = rezN.Camera;
            }
            else
            {
                tCam = treeNodes[0];
            }
            TreeNode trez = tCam.Nodes.Add("Rez. nr. " + rezN.Id + " intre " + rezN.CheckIn.ToString("d") + " si " + rezN.CheckOut.ToString("d"));
            trez.Tag = rezN;
            rezervari.Add(rezN);
            Adauga();
            treeView1.ExpandAll();
            if(bd == true)
            {
                string InsertCommand = "insert into dbo.Rezervari(Id,NrCam,CnpClient,NrPersoane,CheckIn,CheckOut)" +
                        " values (@Id,@NrCam,@CnpClient,@NrPersoane,@CheckIn,@CheckOut)";
                SqlConnection conexiune = new SqlConnection(stringConexiune);
                conexiune.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandRez, conexiune);
                adaptor.InsertCommand = conexiune.CreateCommand();
                adaptor.InsertCommand.CommandText = InsertCommand;
                adaptor.InsertCommand.Parameters.AddWithValue("@NrCam", rezN.Camera.Numar);
                adaptor.InsertCommand.Parameters.AddWithValue("@CnpClient", rezN.Client.Cnp);
                adaptor.InsertCommand.Parameters.AddWithValue("@NrPersoane", rezN.NrPersoane);
                adaptor.InsertCommand.Parameters.AddWithValue("@CheckIn", rezN.CheckIn);
                adaptor.InsertCommand.Parameters.AddWithValue("@CheckOut", rezN.CheckOut);
                adaptor.InsertCommand.Parameters.AddWithValue("@Id", rezN.Id);
                adaptor.InsertCommand.ExecuteNonQuery();
                conexiune.Close();

                string InsertCommCl = "insert into dbo.Clienti(Cnp,Nume,Prenume,Telefon,Email)" +
                        " values (@Cnp,@Nume,@Prenume,@Telefon,@Email)";
                SqlConnection conex = new SqlConnection(stringConexiune);
                conex.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(SelectCommandRez, conex);
                adapt.InsertCommand = conex.CreateCommand();
                adapt.InsertCommand.CommandText = InsertCommCl;
                adapt.InsertCommand.Parameters.AddWithValue("@Cnp", rezN.Client.Cnp);
                adapt.InsertCommand.Parameters.AddWithValue("@Nume", rezN.Client.Nume);
                adapt.InsertCommand.Parameters.AddWithValue("@Prenume", rezN.Client.Prenume);
                adapt.InsertCommand.Parameters.AddWithValue("@Telefon", rezN.Client.Telefon);
                adapt.InsertCommand.Parameters.AddWithValue("@Email", rezN.Client.Email);
                adapt.InsertCommand.ExecuteNonQuery();
                conex.Close();
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
        private void AddChildren(List<TreeNode> Nodes, TreeNode Node)
        {
            foreach (TreeNode thisNode in Node.Nodes)
            {
                Nodes.Add(thisNode);
                AddChildren(Nodes, thisNode);
            }
        }
        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        List<Camera> camere = treeView1.Nodes.Cast<TreeNode>().Select(item => (Camera)item.Tag).ToList();
            StreamWriter sw = new StreamWriter("CamereRezervate.txt");
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
       
        StreamWriter sr = new StreamWriter("Rezervari.txt");
            foreach(Rezervare r in rezervari)
            {
                sr.WriteLine(r.Id);
                sr.WriteLine(r.Camera.Numar);
                sr.WriteLine(r.Client.Cnp);
                sr.WriteLine(r.NrPersoane);
                sr.WriteLine(r.CheckIn);
                sr.WriteLine(r.CheckOut);
                sr.WriteLine(r.Pret);
            }
            sr.Close();

        StreamWriter scl = new StreamWriter("Clienti.txt");
            foreach (Rezervare r in rezervari)
            {
                scl.WriteLine(r.Client.Nume);
                scl.WriteLine(r.Client.Prenume);
                scl.WriteLine(r.Client.Cnp);
                scl.WriteLine(r.Client.Telefon);
                scl.WriteLine(r.Client.Email);
            }
            scl.Close();
        }
        private void citestefisier()
        {
            camere.Clear(); rezervari.Clear(); clienti.Clear();
            StreamReader sr = new StreamReader("CamereRezervate.txt");
            string[] lines = System.IO.File.ReadAllLines("CamereRezervate.txt");
            for (int i = 0; i < lines.Length - 5; i += 6)
            {
                bool vedere = false;
                if (lines[i + 4] == "True") vedere = true;
                Camera c = new Camera(lines[i], (short)(Int32.Parse(lines[i + 1])), (short)(Int32.Parse(lines[i + 2])),
                    Double.Parse(lines[i + 3]), vedere, Int32.Parse(lines[i + 5]));
                camere.Add(c);
            }
            sr.Close();
            
            StreamReader scl = new StreamReader("Clienti.txt");
            string[] linii = System.IO.File.ReadAllLines("Clienti.txt");
            for (int i = 0; i < linii.Length - 4; i += 5)
            {
                Client c = new Client(linii[i], linii[i + 1], linii[i + 2], linii[i + 3], linii[i + 4]);
                clienti.Add(c);
            }
            scl.Close();

            StreamReader s = new StreamReader("Rezervari.txt");
            lines = null;
            lines = System.IO.File.ReadAllLines("Rezervari.txt");
            for (int i = 0; i < lines.Length - 6; i += 7)
            {
                string nrcam = lines[i + 1];
                Camera cam = null;
                foreach (Camera m1 in camere)
                    if (m1.Numar.ToString() == nrcam)
                        cam = m1;

                string cnp = lines[i + 2];
                Client cl = null;
                foreach (Client m1 in clienti)
                    if (m1.Cnp == cnp)
                        cl = m1;

                Rezervare c = new Rezervare(cam, cl, Int32.Parse(lines[i + 3]),DateTime.Parse(lines[i + 4]), DateTime.Parse(lines[i + 5]));
                c.Id = Int32.Parse(lines[i]);
                c.calculeazaPret();
                rezervari.Add(c);
            }
            s.Close();
            SadesteArbore();
            Adauga();            
        }
        internal void SadesteArbore()
        {
            treeView1.Nodes.Clear();
            foreach (Camera m1 in camere)
            {
                TreeNode tCam = treeView1.Nodes.Add("Camera nr " + m1.Numar);  //creeaza nodul si adauga in colectie - se vede in arbore
                tCam.Tag = m1;
                foreach (Rezervare rezi in rezervari)
                {
                    if (rezi.Camera.Numar == m1.Numar)
                    {
                        TreeNode trez = tCam.Nodes.Add("Rez. nr. " + rezi.Id + " intre " + rezi.CheckIn.ToString("d") + " si " + rezi.CheckOut.ToString("d"));
                        trez.Tag = rezi;
                    }
                }
            }
            treeView1.ExpandAll();
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            citestefisier();
            grupBD.Visible = false;
        }
        Point loc;
        bool mouseDown;
        private void VizRezervariForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; loc = e.Location;
        }
        private void VizRezervariForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
                this.Location = new Point((this.Location.X - loc.X) + e.X, (this.Location.Y - loc.Y) + e.Y);
        }
        private void VizRezervariForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void binarSaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stream fb = File.Create("Clienti.bin");
            BinaryFormatter serializator = new BinaryFormatter();
            serializator.Serialize(fb, clienti);
            fb.Close();

            Stream fc = File.Create("CamereRezervate.bin");
            BinaryFormatter serializatorC = new BinaryFormatter();
            serializatorC.Serialize(fc, camere);
            fc.Close();

            Stream fR = File.Create("Rezervari.bin");
            BinaryFormatter serializatorR = new BinaryFormatter();
            serializatorR.Serialize(fR, rezervari);
            fR.Close();
        }
        private void binarIncarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grupBD.Visible = false; 
            camere.Clear(); rezervari.Clear(); clienti.Clear();
            Stream fb = File.OpenRead("Clienti.bin");
            BinaryFormatter des = new BinaryFormatter();
            clienti = (List<Client>)des.Deserialize(fb);
            fb.Close();

            Stream fc = File.OpenRead("CamereRezervate.bin");
            BinaryFormatter desC = new BinaryFormatter();
            camere = (List<Camera>)desC.Deserialize(fc);
            fc.Close(); 

            Stream fR = File.OpenRead("Rezervari.bin");
            BinaryFormatter desR = new BinaryFormatter();
            rezervari = (List<Rezervare>)desR.Deserialize(fR);
            fR.Close();
            Adauga();
            SadesteArbore();
        }
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null)
            {
                bool removeRoom = false; TreeNode room = treeView1.SelectedNode.Parent;
                if (treeView1.SelectedNode.Parent.Nodes.Count == 1) removeRoom = true;
                Rezervare deSters = (Rezervare)treeView1.SelectedNode.Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti rezervarea numarul " + deSters.Id + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    treeView1.SelectedNode.Remove();
                    rezervari.Remove(deSters);
                    if (removeRoom == true) treeView1.Nodes.Remove(room);
                    Adauga();
                    if(bd==true)
                    {
                        Delete(deSters.Id);
                    }
                }
                bd = false;
            }
            else MessageBox.Show("Puteti sterge doar rezervarea!");
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null)
            {
                stergeToolStripMenuItem.Enabled = true;
                modificaToolStripMenuItem.Enabled = true;
            }
            else
            {
                stergeToolStripMenuItem.Enabled = false;
                modificaToolStripMenuItem.Enabled = false;
            }
        }
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null)
            {
                Rezervare deModificat = (Rezervare)treeView1.SelectedNode.Tag;
                this.Hide();
                if (menu.rez == null)
                {
                    RezervaForm mf = new RezervaForm(menu);
                    menu.rez = mf;
                }
                menu.rez.CurataControale();
                menu.rez.rezervare = deModificat;
                menu.rez.camera = deModificat.Camera;
                menu.rez.ActualizeazaControaleTreeView();
                menu.rez.buttonRezerva.Text = "Modifica";
                menu.rez.button1.Text = "Schimba camera";
                Adauga(); menu.rez.back = this;
                menu.rez.Show();
            }
        }
        Rezervare deprintat=null;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                deprintat = (Rezervare)treeView1.SelectedNode.Tag;
                pageSetupDialog1.Document = printDocument1;
                if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;

                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
            }
            else MessageBox.Show("Selectati o rezervare pentru a o putea printa!");
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (deprintat != null)
            {
                Graphics graphics = e.Graphics;
                Font font = new Font("Showcard Gothic", 14F);
                Brush brush = Brushes.DarkBlue;
                Pen pen = new Pen(brush);

                PageSettings pageSettings = printDocument1.DefaultPageSettings;
                var latime = pageSettings.PaperSize.Width - pageSettings.Margins.Left - pageSettings.Margins.Right;
                var lungime = pageSettings.PaperSize.Height - pageSettings.Margins.Top - pageSettings.Margins.Bottom;

                if (pageSettings.Landscape)
                {
                    var temp = lungime;
                    lungime = latime;
                    latime = temp;
                }

                int cellWidth = latime / 2;
                int cellHeight = 40;

                int x = pageSettings.Margins.Left;
                int y = 100;

                graphics.DrawString("CONFIRMARE REZERVARE", font, brush, latime / 3, y);
                y += 30;
                try
                {
                    Icon icon = new Icon(@"C:\Users\EU\source\repos\ProiectPAW\ProiectPAW\Resources\Inipagi-Job-Seeker-Room-tag.ico");
                    graphics.DrawIcon(icon, x, y);
                    y += 40;
                }
                catch { }
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);

                //desenare continut
                graphics.DrawString("Numar rezervare", font, brush, x, y);
                graphics.DrawString(deprintat.Id.ToString(), font, brush, x + cellWidth, y);
                y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                //desenare continut
                graphics.DrawString("Nume client", font, brush, x, y);
                graphics.DrawString(deprintat.Client.Nume+" "+deprintat.Client.Prenume, font, brush, x + cellWidth, y);
                y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                //desenare continut
                graphics.DrawString("CNP client", font, brush, x, y);
                graphics.DrawString(deprintat.Client.Cnp, font, brush, x + cellWidth, y);
                y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                //desenare continut
                graphics.DrawString("Telefon client", font, brush, x, y);
                graphics.DrawString(deprintat.Client.Telefon, font, brush, x + cellWidth, y);
                y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                //desenare continut
                graphics.DrawString("Email client", font, brush, x, y);
                graphics.DrawString(deprintat.Client.Email, font, brush, x + cellWidth, y);
                y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                //desenare continut
                graphics.DrawString("CNP client", font, brush, x, y);
                graphics.DrawString(deprintat.Client.Cnp, font, brush, x + cellWidth, y);
                y += 80; graphics.DrawString(" --->  Date camera", font, brush, x, y); y += cellHeight;
                graphics.DrawString(deprintat.Camera.ToString(), font, brush, x, y);
                y += cellHeight; y += cellHeight; y += cellHeight;
                //desenare celule
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                graphics.DrawString("Check in / out: ", font, brush, x, y);
                graphics.DrawString(deprintat.CheckIn+" "+deprintat.CheckOut, font, brush, x + cellWidth, y);
                y += cellHeight;
                graphics.DrawRectangle(pen, x, y, cellWidth, cellHeight);
                graphics.DrawRectangle(pen, x + cellWidth, y, cellWidth, cellHeight);
                graphics.DrawString("Numar persoane: ", font, brush, x, y);
                graphics.DrawString(deprintat.NrPersoane.ToString(), font, brush, x + cellWidth, y);
                y += cellHeight; y += cellHeight;
                graphics.DrawString("Pret: "+deprintat.Pret, font, brush,latime/2,y+10);
                try
                {
                    Icon icon2 = new Icon(@"C:\Users\EU\source\repos\ProiectPAW\ProiectPAW\Resources\money.ico");
                    graphics.DrawIcon(icon2, (latime / 2) + 60, y + 10);
                }
                catch { }
            }
        }
        private void VizRezervariForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                toolStripButton2_Click(sender, e);
            }
        }
       internal void IncarcaDate()
        {
            try
            {
                camere.Clear(); rezervari.Clear(); clienti.Clear();
                treeView1.Nodes.Clear();
                SqlConnection conexiune = new SqlConnection(stringConexiune);
                conexiune.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandCam, conexiune);
                adaptor.Fill(dsCamereRez, "Camere");
                dsCamereRez.Tables["Camere"].PrimaryKey = new DataColumn[1] { dsCamereRez.Tables["Camere"].Columns["Numar"] };

                DataTable dt = dsCamereRez.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    bool vedere = false;
                    if (dr[4].ToString() == "True") vedere = true;
                    Camera c = new Camera(dr[1].ToString(), (short)(Int32.Parse(dr[0].ToString())), (short)(Int32.Parse(dr[2].ToString())),
                        Double.Parse(dr[3].ToString()), vedere, Int32.Parse(dr[5].ToString()));
                    camere.Add(c);
                }
                adaptor.Dispose();
                adaptor = new SqlDataAdapter(SelectCommandCL, conexiune);
                adaptor.Fill(dsClienti, "Clienti");
                dsClienti.Tables["Clienti"].PrimaryKey = new DataColumn[1] { dsClienti.Tables["Clienti"].Columns["Cnp"] };
                dt.Clear();
                dt = dsClienti.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Client cl = new Client(dr[1].ToString(), dr[2].ToString(), dr[0].ToString(), dr[3].ToString(), dr[4].ToString());
                    clienti.Add(cl);
                }

                adaptor.Dispose();
                adaptor = new SqlDataAdapter(SelectCommandRez, conexiune);
                adaptor.Fill(dsRez, "Rezervari");
                dsRez.Tables["Rezervari"].PrimaryKey = new DataColumn[1] { dsRez.Tables["Rezervari"].Columns["Id"] };
                dt.Clear();
                dt = dsRez.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    int nrcam = Int32.Parse(dr[1].ToString());
                    Camera cam = null;
                    foreach (Camera m1 in camere)
                        if (m1.Numar == nrcam)
                            cam = m1;

                    string cnp = dr[2].ToString();
                    Client cl = null;
                    foreach (Client m1 in clienti)
                        if (m1.Cnp == cnp)
                            cl = m1;

                    Rezervare c = new Rezervare(cam, cl, Int32.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()));
                    c.Id = Int32.Parse(dr[0].ToString());
                    c.calculeazaPret();
                    rezervari.Add(c);
                }
                conexiune.Close();
                grupBD.Visible = true;
                SadesteArbore();
            }
            catch { MessageBox.Show("Nu s-au incarcat datele corect din baza de date!"); }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            IncarcaDate();
            Adauga();
            grupBD.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           if (treeView1.SelectedNode.Parent != null)
            {
                Rezervare deModificat = (Rezervare)treeView1.SelectedNode.Tag;
                this.Hide();
                if (menu.rez == null)
                {
                    RezervaForm mf = new RezervaForm(menu);
                    menu.rez = mf;
                }
                menu.rez.CurataControale();
                menu.rez.rezervare = deModificat;
                menu.rez.camera = deModificat.Camera;
                menu.rez.button1.Text = "Schimba camera";
                menu.rez.buttonRezerva.Text = "Update";
                menu.rez.ActualizeazaControaleTreeView();
                Adauga();
                menu.rez.back = this;
                menu.rez.textBoxCNP.Enabled = false;
                menu.rez.Show();
                rez = deModificat;
               
            }
        }

        void Delete(int nr)
        {
            string UpdateCommand = "delete from dbo.Rezervari where Id=@Id";
            SqlConnection conexiune = new SqlConnection(stringConexiune);
            conexiune.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandRez, conexiune);
            adaptor.UpdateCommand = conexiune.CreateCommand();
            adaptor.UpdateCommand.CommandText = UpdateCommand;
            adaptor.UpdateCommand.Parameters.AddWithValue("@Id", nr);
            adaptor.UpdateCommand.ExecuteNonQuery();
            conexiune.Close();
        }
        bool bd = false;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bd = true;
            stergeToolStripMenuItem_Click(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (menu.rez == null)
            {
                RezervaForm mf = new RezervaForm(menu);
                menu.rez = mf;
            }
            menu.rez.CurataControale();
            menu.rez.buttonRezerva.Text = "Insert";
            menu.rez.Show();
            
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (menu.rez == null)
            {
                RezervaForm mf = new RezervaForm(menu);
                menu.rez = mf;
            }
            menu.rez.CurataControale();
            menu.rez.buttonRezerva.Text = "Adauga";
            menu.rez.Show();
        }

    }
}
