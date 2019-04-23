using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logowanie
{
    public partial class Form2 : Form
    {
        public BindingSource rdzen = new BindingSource();
        Login ListaLog = new Login();
        public List<User> list = new List<User> { };
        



        public Form2()
        {
            //Ranga isAdmin;
            //Enum.TryParse<Ranga>(SetUserState.SelectedValue.ToString(), out isAdmin);
            list = ListaLog.list;
            rdzen.DataSource = list;
            InitializeComponent();
            SetUserState.DataSource = Enum.GetValues(typeof(Ranga));
            //if (isAdmin ==(Ranga)1)
            //{
            //    tabControl1.TabPages.Remove(tabPage1);
            //}
           
        }
        private void button4_Click(object sender, EventArgs e) //zapisz w Tab Edycja
        {

            PlikDodaj o1 = new PlikDodaj();
            o1.S2.Invoke("DM8419",rdzen);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdzen.DataSource = null;
            rdzen.DataSource = list;
            dataGridView1.DataSource = rdzen;
            if (dataGridView1.Columns.Count == 4)
            {
                dataGridView1.Columns[0].HeaderText = "Uid";
                dataGridView1.Columns[1].HeaderText = "Login";
                dataGridView1.Columns[2].HeaderText = "Hasło";
                dataGridView1.Columns[3].HeaderText = "Ranga";
            }

        }

        private void button1_Click(object sender, EventArgs e) //Dodaj z zapisem w Tab Dodaj
        {
            Ranga isAdmin;
            Enum.TryParse<Ranga>(SetUserState.SelectedValue.ToString(), out isAdmin);
            list.Add(new User(textBox1.Text, textBox2.Text, isAdmin));
            rdzen.DataSource = list;
            button4_Click(sender, e); // zapis do pliku
        }



        private void button3_Click(object sender, EventArgs e) //usun
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                // wybranie guid z zaznaczonego wiersza
                Guid selectedGuid = (Guid)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                //wybranie pierwszego usera z listy  za pomocą linq dla którego spełniona jest lambda (x => x)
                // lambda - wyrarzenie logiczne prawda fałsz sprawdzane dla karzdego elementu w kolekcji
                PasswordChange frmPass = new PasswordChange(list.First(u => u.uid2 == selectedGuid));

                
                if(frmPass.ShowDialog() == DialogResult.Cancel)
                {
                    rdzen.DataSource = null;
                    rdzen.DataSource = list;
                    dataGridView1.DataSource = rdzen;
                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać tylko 1");
            }
        }
    }
}
