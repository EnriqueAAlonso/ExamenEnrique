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
        User currentUser=new User();
        UserService uservice=new UserService(connectionString);

        public Form1()
        {
            
            InitializeComponent();
            login1.Show();
            login1.setOwner(this);
            selectCity1.setOwner(this);
            detailedCity1.setOwner(this);
            detailedCity1.setCity("Mexico City");

            login1.updateCSTR(connectionString);
            selectCity1.Hide();
            button1.Hide();
            button2.Hide();
        }

        public void notifyOwner(UserControl uc, User ucUser)
        {
            uc.Hide();
            currentUser = ucUser;
            if (currentUser != null) currentUser._cities = uservice.getcities(currentUser);
            button1.Show();
            login1.Reset();
            detailedCity1.Show();
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


            if (caretaker.Size()>0)button2.Show();
            else button2.Hide();

        }

        public void increaseCities(string txt)
        {
            if (!currentUser._cities.Contains(txt))
            {
                og.setState(currentUser.Clone());
                caretaker.AddMemento(og.SaveToMemento());
                if (caretaker.Size() > 0) button2.Show();
                else button2.Hide();
                currentUser._cities.Add(txt);
                MessageBox.Show(uservice.addCity(txt, currentUser));
            }
            else
            {
                MessageBox.Show("City is already registered by this user");
                selectCity1.Show();
            }
            button1.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectCity1.Show();
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void logout()
        {
            //Update user service so it gets the new lists, if something got deleted, it should delete it
        }
    }
}
