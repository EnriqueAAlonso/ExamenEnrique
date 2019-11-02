using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEnrique.Classes
{
    public class UserService
    {
        private readonly UserDS _ds;

        public UserService(string cstr)
        {
            _ds=UserDS.getInstance(cstr);
        }

        public List<string> getcities(User u)
        {
            return _ds.getCities(u._mail);
        }
        public string AddUser(User u)
        {
            try
            {
                if(!_ds.getUser(u._mail)) return _ds.AddUser(u) ? "User registered correctly" : "Failed adding user ";
                else
                {
                    return "User already registered";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string addCity(string city, User u)
        {
             return _ds.addCity(u,city) ? "City Added correctly" : "Failed adding city ";
          
        }

        public bool loginUser(User u)
        {
            if (_ds.loginUser(u._mail, u._password) != null) return true;
            else return false;
        }
    }
}
