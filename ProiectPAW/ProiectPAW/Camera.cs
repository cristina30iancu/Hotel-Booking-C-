using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW
{
    [Serializable]
   public class Camera 
   {
        private string tip;
        private short numar;  
        private short etaj; 
        private double pretPeNoapte;
        private bool vedereLaMare;
        private int capacitate;

        public Camera()
        {

        }
        public Camera(string tip, short numar, short etaj, double pretPeNoapte, bool vedereLaMare, int capacitate)
        {
            this.tip = tip;
            this.numar = numar;
            this.etaj = etaj;
            this.pretPeNoapte = pretPeNoapte;
            this.vedereLaMare = vedereLaMare;
            this.capacitate = capacitate;
        }
        public string Tip
        {
            get { return tip; }
            set { if (tip != value && value.Length > 3) tip = value; }
        }
        public short Numar
        {
            get { return numar; }
            set { if (value != numar && value > 0) numar = value; }
        }
        public short Etaj
        {
            get { return etaj; }
            set { if (value != etaj && value > 0) etaj = value; }
        }
        public double PretPeNoapte
        {
            get { return pretPeNoapte; }
            set { if (value != pretPeNoapte && value > 0) pretPeNoapte = value; }
        }
        public bool VedereLaMare
        {
            get { return vedereLaMare; }
            set { if (value != vedereLaMare) vedereLaMare = value; }
        }
        public int Capacitate
        {
            get { return capacitate; }
            set { if (value != capacitate && value > 0) capacitate = value; }
        }
        
        override public string ToString()
        {
            return "Camera "+tip+" \ncu numarul "+numar+", capacitate maxima "+
                capacitate+" \nsi "+pretPeNoapte+" lei pe noapte";
        }
    }
}
