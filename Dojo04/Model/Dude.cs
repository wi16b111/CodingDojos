using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo04.Model
{
    public class Dude
    {
        // ---------------------------------

        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private int ssn;
        public int Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        // ---------------------------------

        public Dude(string fname, string lname, int no, DateTime birth)
        {
            this.Firstname = fname;
            this.Lastname = lname;
            this.Ssn = no;
            this.Birthdate = birth;
        }
    }
}
