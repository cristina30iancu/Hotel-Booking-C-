using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class AdaugaCameraForm : Form
    {
        public VizualizareCamere parinte;
        public Camera camera;
        string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cazari;Integrated Security=True";
        DataSet dsCamere = new DataSet();
        string SelectCommand = "Select * from dbo.Camere";
        public AdaugaCameraForm(VizualizareCamere p,Camera c)
        {
            parinte = p;
            camera = c;
            InitializeComponent();
            if (c.Numar==0) tbNr.ReadOnly = false;
        }
        
        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Tip = comboBoxTip.Text;
                camera.Numar =(short)(Convert.ToInt32(tbNr.Text));
                camera.Etaj = (short)(Convert.ToInt32(tbEtaj.Text)); 
                camera.PretPeNoapte = Convert.ToDouble(tbPret.Text);
                camera.Capacitate = Convert.ToInt32(comboBoxCapacitate.Text);
                if (checkBoxVedere.Checked) camera.VedereLaMare = true;
                else camera.VedereLaMare = false;
            }
            if (buttonAdauga.Text == "Update camera")
            {
                SqlConnection conex = new SqlConnection(stringConexiune);
                conex.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(SelectCommand, conex);
                adapt.Fill(dsCamere, "Camere");
                dsCamere.Tables["Camere"].PrimaryKey = new DataColumn[1] { dsCamere.Tables["Camere"].Columns["Numar"] };
                conex.Close();
                BindingManagerBase legatura = BindingContext[dsCamere.Tables["Camere"]];
                // creez comanda
                string UpdateCommand = "update dbo.Camere set Tip=@Tip,"
                    + "Etaj=@Etaj, Capacitate=@Capacitate, Pret=@Pret, Vedere=@Vedere " +
                    " where Numar=@Numar";
                SqlConnection conexiune = new SqlConnection(stringConexiune);
                conexiune.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommand, conexiune);
                adaptor.UpdateCommand = conexiune.CreateCommand();
                adaptor.UpdateCommand.CommandText = UpdateCommand;
                adaptor.UpdateCommand.Parameters.AddWithValue("@Tip", comboBoxTip.Text);
                adaptor.UpdateCommand.Parameters.AddWithValue("@Etaj", tbEtaj.Text);
                adaptor.UpdateCommand.Parameters.AddWithValue("@Capacitate", comboBoxCapacitate.Text);
                if (checkBoxVedere.Checked == true)
                    adaptor.UpdateCommand.Parameters.AddWithValue("@Vedere", 1);
                else adaptor.UpdateCommand.Parameters.AddWithValue("@Vedere", 0);
                adaptor.UpdateCommand.Parameters.AddWithValue("@Pret", tbPret.Text);
                int nr = Int32.Parse(tbNr.Text);
                adaptor.UpdateCommand.Parameters.AddWithValue("@Numar", nr);
                adaptor.UpdateCommand.ExecuteNonQuery();
                
                conexiune.Close();
            }
                parinte.UpdateItems();
                this.DialogResult = DialogResult.OK;
            
        }

        private void tbNr_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(tbNr.Text, out int rez) == false)
            {
                errorProvider1.SetError(tbNr, "Numar de camera invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(tbNr.Text) < 0)
                {
                    errorProvider1.SetError(tbNr, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbNr, ""); // sau string.empty
                }
            }
        }

        private void tbEtaj_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(tbEtaj.Text, out int rez) == false)
            {
                errorProvider1.SetError(tbEtaj, "Numar de etaj invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(tbEtaj.Text) < 0)
                {
                    errorProvider1.SetError(tbEtaj, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbEtaj, ""); // sau string.empty
                }
            }
        }

        public void ActualizeazaControale(object sender, EventArgs e, string btntext)
        {
            if (camera != null)
            {
                buttonAdauga.Text = btntext;
                comboBoxTip.Text= camera.Tip;
                tbNr.Text = camera.Numar.ToString();
                tbEtaj.Text = camera.Etaj.ToString();
                tbPret.Text = camera.PretPeNoapte.ToString();
                comboBoxCapacitate.Text = camera.Capacitate.ToString();
                if (camera.VedereLaMare == true) checkBoxVedere.Checked=true;
                else checkBoxVedere.Checked = false;
            }
        }

        private void tbPret_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(tbPret.Text, out double rez) == false)
            {
                errorProvider1.SetError(tbPret, "Pret invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToDouble(tbPret.Text) < 0)
                {
                    errorProvider1.SetError(tbPret, "Introduceti numar real.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbPret, ""); // sau string.empty
                }
            }
        }
    }
}
