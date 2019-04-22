using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Logowanie
{
    public partial class Login : Form
    {

        public List<User> list = new List<User> { };
        public Login()
        {
            Baza();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            logowanie();
            
        }
        private void logowanie()
        {
            Class1 K = new Class1();
            list = K.a.Invoke(textBox_login.Text, textBox_pass.Text,list);
            //foreach (User u in list)
            //{
            //    if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text) == true)
            //    {
            //
            //        this.Hide();
            //        Form1 f = new Form1(u.UserName, u.isAdmin);
            //
            //        f.Show();
            //        break;
            //    }
            //    else if (u.UserName == textBox_login.Text && (u.PassCrypt(textBox_pass.Text) == false))
            //    {
            //        MessageBox.Show("Błędne Hasło", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //if ((u.UserName == textBox_login.Text) == false)
            // {
            //     MessageBox.Show("Błędny login", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }
            // else if (u.PassCrypt(textBox_pass.Text) == false)
            // {
            //     MessageBox.Show("Błędne Hasło", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }

            Hide();
        }
        private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logowanie();
            }
        }
        public void Baza(){
            Class1 o1 = new Class1();
            list = o1.load.Invoke("DM8419"); 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}



