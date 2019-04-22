using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logowanie
{
    public partial class Form1 : Form
    {

        public Form1(string UserName, Enum isAdmin)
        {

            InitializeComponent();
            label1.Text = UserName;
           

        }



        public void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form f = new Login();
            
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
        private void Edycja_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
