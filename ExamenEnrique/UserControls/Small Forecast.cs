using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenEnrique.Classes;
using ExamenEnrique.ProxyServices;

namespace ExamenEnrique.UserControls
{
    public partial class Small_Forecast : UserControl
    {
        private WeatherObject wo;
        AdapterForecastWeather adapter= new AdapterForecastWeather();
        public Small_Forecast()
        {
            InitializeComponent();
        }

        public void setWo(Forecast f, int index)
        {
            wo = adapter.forecastToWeather(f, index);
            DateTime today=DateTime.Now;
            switch (index)
            {
                case 0:
                    today = today.AddDays(1);
                    break;
                case 1:
                    today = today.AddDays(2);
                    break;
                case 2:
                    today = today.AddDays(3);
                    break;
                case 3:
                    today = today.AddDays(4);
                    break;
                default:
                    today = today.AddDays(5);
                    break;
            }

            label1.Text = today.DayOfWeek.ToString();
            if (wo.main.temp < 20)
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.Snowflake;
            }
            else if (wo.main.temp > 30)
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.fire;
            }
            else
            {
                pictureBox1.Image = ExamenEnrique.Properties.Resources.medium;
            }

            label2.Text = wo.main.temp.ToString() + "°";
            
        }
    }
}
