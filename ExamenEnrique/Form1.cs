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
using ExamenEnrique.Memento;


namespace ExamenEnrique
{
    public partial class Form1 : Form
    {
        Caretaker caretaker=new Caretaker();
        Originator og=new Originator();
        static string connectionString = "data source=COMPENSATOR\\SQLEXPRESS02;initial catalog=examen; integrated security = True";
        private User currentUser = new User();
        UserService uservice=new UserService(connectionString);

        public Form1()
        {
            
            InitializeComponent();
            login1.Show();
            login1.setOwner(this);
            selectCity1.setOwner(this);
            detailedCity1.setOwner(this);
            cities_window1.setOwner(this);
            cities_window1.Hide();
            detailedCity1.Hide();
            login1.updateCSTR(connectionString);
            selectCity1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
        }

        public void getDetails(string city)
        {
            detailedCity1.setCity(city);
            cities_window1.Hide();
            detailedCity1.Show();
        }

        public void exitDetails(string city, bool delete)
        {
            if (delete)
            {
                og.setState(currentUser.Clone());
                caretaker.AddMemento(og.SaveToMemento());
                if (caretaker.Size() > 0) button2.Show();
                else button2.Hide();
                currentUser._cities.Remove(city);
                uservice.deletecity(city, currentUser);
                cities_window1.updateList(uservice.getcities(currentUser));

            }

            cities_window1.Show();
            detailedCity1.Hide();
        }

        public void notifyOwner(UserControl uc, User ucUser)
        {
            uc.Hide();
            currentUser = ucUser;
            if (currentUser != null) currentUser._cities = uservice.getcities(currentUser);
            button1.Show();
            login1.Reset();
            cities_window1.updateList(uservice.getcities(currentUser));
            cities_window1.Show();
            button3.Show();
        }

        public void undo()
        {
            og.GetStateFromMemento(caretaker.GetMemento()) ;
            currentUser._cities = og.getState()._cities;
            var mementoList = currentUser._cities;
            var lists= uservice.getcities(currentUser);
            foreach (string city in currentUser._cities)
            {
                uservice.addCity(city, currentUser);
            }

            foreach (string city in lists)
            {
                if (!currentUser._cities.Contains(city))
                {
                    uservice.deletecity(city,currentUser);
                }
            }
            cities_window1.updateList(currentUser._cities);

            if (caretaker.Size()>0)button2.Show();
            else button2.Hide();

        }

        public bool increaseCities(string txt)
        {
            bool ret = false;
            if (!currentUser._cities.Contains(txt))
            {
                og.setState(currentUser.Clone());
                caretaker.AddMemento(og.SaveToMemento());
                if (caretaker.Size() > 0) button2.Show();
                else button2.Hide();
                currentUser._cities.Add(txt);
                MessageBox.Show(uservice.addCity(txt, currentUser));
                cities_window1.updateList(currentUser._cities);
                cities_window1.Show();
                ret = true;
            }
            else
            {
                MessageBox.Show("City is already registered by this user");
                return false;
            }
            button1.Show();
            return ret;

        }

        public void cancel()
        {
            cities_window1.Show();
            button1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cities_window1.Hide();
            selectCity1.Show();
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void logout()
        {
            caretaker = new Caretaker();
            og = new Originator();
            login1.Show();
            login1.setOwner(this);
            selectCity1.setOwner(this);
            detailedCity1.setOwner(this);
            cities_window1.setOwner(this);
            cities_window1.Hide();
            detailedCity1.Hide();
            login1.updateCSTR(connectionString);
            selectCity1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();


            var lists = uservice.getcities(currentUser);
            foreach (string city in currentUser._cities)
            {
                uservice.addCity(city, currentUser);
            }

            foreach (string city in lists)
            {
                if (!currentUser._cities.Contains(city))
                {
                    uservice.deletecity(city, currentUser);
                }
            }
            currentUser = new User();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logout();


        }
    }
}
