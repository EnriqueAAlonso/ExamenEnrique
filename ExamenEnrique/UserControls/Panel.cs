using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenEnrique.ProxyServices;

namespace ExamenEnrique.UserControls
{
    public partial class Panel : UserControl
    {
        IProxy proxy = new Proxy();
        
        public Panel()
        {
            InitializeComponent();
        }

        public void updateWeather(string city)
        {
            var response = proxy.weather(city);
            label1.Text = response.name;
             if(response.main.temp<20)
             {
                 pictureBox1.Image = ExamenEnrique.Properties.Resources.Snowflake;
             }
            else if (response.main.temp > 30)
             {
                 pictureBox1.Image = ExamenEnrique.Properties.Resources.fire;
             }
             else
             {
                 pictureBox1.Image = ExamenEnrique.Properties.Resources.medium;
             }

            label2.Text = response.main.temp.ToString();

            label3.Text = response.main.temp_min.ToString();

            label4.Text = response.main.temp_max.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Notify Observer to change to detailed view
        }
    }
}
