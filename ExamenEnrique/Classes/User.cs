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
        //Prototype clone
        public User Clone()
        {
            var usr= new User { _mail = this._mail, _password = this._password, _cities = new List<string>() };
            foreach (var element in _cities)
            {
                usr._cities.Add(element);
            }

            return usr;
        }


    }
}
