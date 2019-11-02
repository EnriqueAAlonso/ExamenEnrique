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
namespace ExamenEnrique.UserControls
{
    public partial class Login : UserControl
    {
        private Form1 owner;
        private string cString;
        private UserService us;
        private bool register = false;
        private bool valid = false;
        public Login()
        {
            InitializeComponent();
            pictureBox1.Image = ExamenEnrique.Properties.Resources.mountain;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           User u=new User();
            u._mail = textBox1.Text;
            u._password = textBox2.Text;
            if (!register)
            {
                if (IsValidEmail(u._mail))
                {
                    if (us.loginUser(u))
                    {
                        MessageBox.Show("Login successful");
                        valid = true;
                        owner.notifyOwner(this, u);
                    }
                
                    else MessageBox.Show("Login failed");
                }
                else
                {
                    MessageBox.Show("Please enter a valid e-mail address");
                }
            }
        
            else
            {
                if (IsValidEmail(u._mail))
                {
                    if (u._password.Length < 6)
                    {
                        MessageBox.Show("Please use a longer password");
                    }
                    else
                    {
                        string s = us.AddUser(u);
                        MessageBox.Show(s);
                        if (s == "User registered correctly") valid = true;
                        owner.notifyOwner(this, u);
                    }

                    

                }
                else
                {
                    MessageBox.Show("Please enter a valid e-mail address");
                }
            }
            

        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public void setOwner(Form1 o)
        {
            owner = o;
        }

        public void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            register = false;
            label5.Text = "Register here";
            label4.Text = "Not a user?";
            label3.Text = "Log-in";
            button1.Text = "Log-in";
            pictureBox1.Image = ExamenEnrique.Properties.Resources.mountain;
        }

        public void updateCSTR(string cStr)
        {
            cString = cStr;
            us=new UserService(cStr);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (!register)
            {
                label5.Text = "Log-in here";
                label4.Text = "Already a user?";
                label3.Text = "Sign up";
                button1.Text = "Register";
                pictureBox1.Image = ExamenEnrique.Properties.Resources.ice;
                register = true;
            }
            else
            {
                register = false;
                label5.Text = "Register here";
                label4.Text = "Not a user?";
                label3.Text = "Log-in";
                button1.Text = "Log-in";
                pictureBox1.Image = ExamenEnrique.Properties.Resources.mountain;
            }


        }
    }
}
