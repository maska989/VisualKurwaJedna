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
            list = ListaLog.list;
            rdzen.DataSource = list;
            InitializeComponent();
            
        }
        private void button4_Click(object sender, EventArgs e) //zapisz w Tab Edycja
        {

            PlikDodaj o1 = new PlikDodaj();
            rdzen = o1.S2.Invoke("DM8419",rdzen);

            //string sPath = "DM8419.bin";
            //using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
            //{
            //    foreach (User p in rdzen)
            //    {
            //        SaveFile.WriteLine(p);
            //    }
            //}
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
                dataGridView1.Columns[3].HeaderText = "Admin?";
            }

        }

        private void button1_Click(object sender, EventArgs e) //Dodaj z zapisem w Tab Dodaj
        {
            list.Add(new User(textBox1.Text, textBox2.Text, checkBox1.Checked));
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


    }
}
