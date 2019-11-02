using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEnrique.Classes
{
    public class User
    {
        public string _mail; 
        public string _password;
        public List<string> _cities;

        public string getMail()
        {
            return _mail;
        }

        public string getPWD()
        {
            return _password;
        }

        

    }
}
