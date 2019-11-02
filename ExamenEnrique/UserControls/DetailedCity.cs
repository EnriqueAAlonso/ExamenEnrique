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
    public partial class DetailedCity : UserControl
    {
        IProxy proxy = new Proxy();
        private Form1 owner;
        WeatherObject weather=new WeatherObject();
        Forecast forecast=new Forecast();
        public DetailedCity()
        {
            InitializeComponent();
        }

        public void setCity(string city)
        {
            label1.Text = city;
            weather = proxy.weather(city);
            forecast = proxy.forecast(city);
            if (weather.main.temp < 20)
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.Snowflake;
            }
            else if (weather.main.temp > 30)
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.fire;
            }
            else
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.medium;
            }

            label2.Text = weather.main.temp.ToString() + "°";
            label3.Text = "Humidity";
            label4.Text=weather.main.humidity.ToString() + "%";
            label5.Text = "Wind";
            label6.Text = weather.wind.speed.ToString()+ "Km/H";
            small_Forecast1.setWo(forecast,0);
            small_Forecast2.setWo(forecast, 1);
            small_Forecast3.setWo(forecast, 2);
            small_Forecast4.setWo(forecast, 3);
            small_Forecast5.setWo(forecast, 4);

        }
        public void setOwner(Form1 o)
        {
            owner = o;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            owner.exitDetails(label1.Text, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            owner.exitDetails(label1.Text, true);
        }
    }
}
