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
    public partial class PasswordChange : Form
    {
        User user;
        public PasswordChange(User usr)
        {
            InitializeComponent();
            user = usr;
            this.username.Text = usr.UserName2;
            this.ranga.Text = Enum.GetName(typeof(Ranga), usr.isAdmin2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.Password2 = user.Hasło(textBox1.Text);
            this.Close();
        }
    }
}
