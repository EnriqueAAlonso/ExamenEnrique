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
        string connectionString = "data source=COMPENSATOR\\SQLEXPRESS02;initial catalog=examen; integrated security = True";
        public Form1()
        {
            
            InitializeComponent();
            UserDS userDS = UserDS.getInstance(connectionString);
            login1.Show();
            login1.updateCSTR(connectionString);

        }

    }
}
