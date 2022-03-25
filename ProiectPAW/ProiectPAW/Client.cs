using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAW
{
    [Serializable]
    public class Client
    {
        private string nume;
        private string prenume;
        private string cnp;
        private string telefon;
        private string email;
        
        public string Nume
        {
            get { return nume; }
            set { if (value != this.nume && value.Length > 3) this.nume = value; }
        }
        public string Prenume
        {
            get { return prenume; }
            set { if (value != this.prenume && value.Length > 3) this.prenume = value; }
        }
        public string Cnp
        {
            get { return cnp; }
            set { if (value != this.cnp && value.Length == 13) this.cnp = value; }
        }
        public string Telefon
        {
            get { return telefon; }
            set { if (value != this.telefon && value.Length ==10) this.telefon = value; }
        }
        public string Email
        {
            get { return email; }
            set { if (value != this.email && value.Length > 3) this.email = value; }
        }

        public Client(string nume, string prenume, string cnp, string telefon, string email)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.cnp = cnp;
            this.telefon = telefon;
            this.email = email;
        }

        public Client()
        {

        }
        override public string ToString()
        {
            return "Client " + nume + " " + prenume + ", cnp: " +
                cnp + ", telefon:  " + telefon + ", email: "+email;
        }

    }
}
