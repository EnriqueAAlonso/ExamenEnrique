using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenEnrique.UserControls
{
    public partial class Cities_window : UserControl
    {
        private Form1 owner;
        private int limit = 0;
        private int page = 1;
        private int count = 0;
        List<string> cities=new List<string>();
        public Cities_window()
        {
            
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            label1.Hide();
        }
        public void setOwner(Form1 o)
        {
            owner = o;
        }

        public void updateList(List<string> locations)
        {
            cities = new List<string>();
            foreach (var loc in locations)
            {
                cities.Add(loc);
            }

            count = cities.Count;
            if (count % 3 != 0)
            {
                numericUpDown1.Maximum = (int) (cities.Count / 3) + 1;
                limit = count % 3;
                
            }
            else
            {
                numericUpDown1.Maximum = (cities.Count / 3);
                limit = 0;
            }

            cities = new List<string>();
            foreach (var loc in locations)
            {
                cities.Add(loc);
            }

            int val = Convert.ToInt32(numericUpDown1.Value);
            count = cities.Count;

            if (count >= (3 * val) - 2)
            {
                numericUpDown1.Minimum = 1;
                panel1.updateWeather(cities[(val * 3) - 3]);
                panel1.Show();
                button1.Show();
            }
            else
            {
                panel1.Hide();
                button1.Hide();
            }
            if (count >= (3 * val) - 1)
            {
                panel2.updateWeather(cities[(3 * val) - 2]);
                panel2.Show();
                button2.Show();
            }
            else
            {
                panel2.Hide();
                button2.Hide();
            }

            if (count >= (3 * val))
            {
                panel3.updateWeather(cities[(3 * val) - 1]);
                panel3.Show();
                button3.Show();
            }
            else
            {
                panel3.Hide();
                button3.Hide();
            }
            if (count==0) label1.Show();
            else label1.Hide();






        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            int val = Convert.ToInt32(numericUpDown1.Value);
            
            if (count >=(3*val)-2)
            {
                numericUpDown1.Minimum = 1;
                panel1.updateWeather(cities[(val*3) - 3]);
                panel1.Show();
                button1.Show();
            }
            else
            {
                panel1.Hide();
                button1.Hide();
            }
            if (count >= (3 * val) - 1)
            {
                panel2.updateWeather(cities[(3 * val) - 2]);
                panel2.Show();
                button2.Show();
            }
            else
            {
                panel2.Hide();
                button2.Hide();
            }

            if (count >= (3 * val) )
            {
                panel3.updateWeather(cities[(3 * val) - 1]);
                panel3.Show();
                button3.Show();
            }
            else
            {
                panel3.Hide();
                button3.Hide();
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            int val = Convert.ToInt32(numericUpDown1.Value);
            if (val == 0) val = 1;
            owner.getDetails(cities[(val * 3) - 3]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            int val = Convert.ToInt32(numericUpDown1.Value);
            if (val == 0) val = 1;
            owner.getDetails(cities[(val * 3) - 2]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            int val = Convert.ToInt32(numericUpDown1.Value);
            if (val == 0) val = 1;
            owner.getDetails(cities[(val * 3) - 1]);
        }
    }
}
