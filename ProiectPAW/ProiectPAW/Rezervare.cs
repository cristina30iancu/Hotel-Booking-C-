using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW
{
    [Serializable]
    public class Rezervare
    {
        private  int id;
        private static int nrRezervari=0;
        private Camera camera;
        private Client client;
        private int nrPersoane;
        private DateTime checkIn;
        private DateTime checkOut;
        private double pret;

        public Rezervare()
        {
            //this.id = ++nrRezervari;
            checkIn = DateTime.Now;
            checkOut = DateTime.Now;
        }
        public Rezervare( Camera camera, Client client, int nrPersoane, DateTime checkIn, DateTime checkOut)
        {
            this.id = ++nrRezervari;
            this.camera = camera;
            this.client = client;
            this.nrPersoane = nrPersoane;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.pret = ((checkOut - checkIn).TotalDays) * camera.PretPeNoapte;
        }
        public int Id
        {
            get { return id; }
            set { if (value > 0) id = value; }
            
        }
        public Camera Camera
        {
            get { return camera; }
            set { if (value != null) camera = value; }
        }
        public Client Client
        {
            get { return client; }
            set { if (value != null) client = value; }
        }
        public int NrPersoane
        {
            get { return nrPersoane; }
            set { if (value != nrPersoane && value > 0) nrPersoane = value; }
        }
        public DateTime CheckIn
        {
            get { return checkIn; }
            set { /*if (value != checkIn && value >= DateTime.Now)*/ checkIn = value; }
        }
        public DateTime CheckOut
        {
            get { return checkOut; }
            set { /*if (value != checkOut && value >= DateTime.Now)*/ checkOut = value; }
        }
        public double Pret
        {
            get { return pret; }
            set { this.pret = ((checkOut - checkIn).TotalDays) * camera.PretPeNoapte; }
        }
        public void calculeazaPret()
        {
            double calc = 0;
            if(camera!=null)
                calc =((checkOut - checkIn).TotalDays)*(camera.PretPeNoapte);
            this.pret = calc;
            
        }
    }

}
