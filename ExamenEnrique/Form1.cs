using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenEnrique.UserControls;
using ExamenEnrique.Classes;
using ExamenEnrique.ProxyServices;
using System.Configuration;


namespace ExamenEnrique
{
    public partial class Form1 : Form
    {
        static string connectionString = "data source=COMPENSATOR\\SQLEXPRESS02;initial catalog=examen; integrated security = True";
        User currentUser=new User();
        UserService uservice=new UserService(connectionString);
        public Form1()
        {
            
            InitializeComponent();
            
            login1.Show();
            login1.setOwner(this);
            selectCity1.setOwner(this);
            login1.updateCSTR(connectionString);
            selectCity1.Hide();
            button1.Hide();
        }

        public void notifyOwner(UserControl uc, User ucUser)
        {
            uc.Hide();
            currentUser = ucUser;
            if (currentUser != null) currentUser._cities = uservice.getcities(currentUser);
            button1.Show();

        }

        public void increaseCities(string txt)
        {
            if (!currentUser._cities.Contains(txt))
            {
                currentUser._cities.Add(txt);
                MessageBox.Show(uservice.addCity(txt, currentUser));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectCity1.Show();
        }
    }
}
