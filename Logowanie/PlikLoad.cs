using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Logowanie
{


    class Class1
    {
        public delegate List<User> Load(string x);
        public Load load;
        public delegate List<User> Aut(string x, string y, List<User> a);
        public Aut a;
        public Class1()
        {
            load += Log;
            a += autoryz;
        }

        private List<User> Log(string x)
        {
            List<User> list = new List<User> { };
            string scieszka = Directory.GetCurrentDirectory() + "\\" + x + ".BIN";
            List<string> wiersze = new List<string>();

            try
            {
                list = File.ReadLines(scieszka).Select(l =>
                {
                    string[] element = l.Split(';');
                    Ranga ranga;
                    Enum.TryParse<Ranga>(element[3].ToString(), out ranga);
                    return new User(Guid.Parse(element[0]), element[1], element[2], ranga);
                }).ToList();
                //using (StreamReader reader = new StreamReader(scieszka))
                //{
                //    string wiersz;
                //    while ((wiersz = reader.ReadLine()) != null)
                //    {
                //        wiersze.Add(wiersz);
                //        string[] element = wiersz.Split(';');
                //        list.Add(new User(Guid.Parse(element[0]), element[1], element[2], bool.Parse(element[3])));

                //    }
                //}
            }
            catch (FileNotFoundException)
            {
                DialogResult dialogResult = MessageBox.Show("Brak listy użytkowników czy chcesz stwożyć liste użytkowników?", "Brak Listy użytkowników", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Yes)
                {
                    using (StreamWriter sw = File.CreateText(scieszka))
                    {
                        list.Add(new User("D", "M", Ranga.Administrator));
                        Login L = new Login();
                        L.Hide();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }

            }
            return list;
        }

        private List<User> autoryz(string x, string y, List<User> a)
        {
            foreach (User u in a)
            {
                if (u.UserName == x && u.PassCrypt(y) == true)
                {
                    Login L = new Login();
                    L.Hide();
                    Form1 f = new Form1(u.UserName, u.isAdmin);

                    f.Show();
                    break;
                }
                else if (u.UserName == x && (u.PassCrypt(y) == false))
                {
                    MessageBox.Show("Błędne Hasło", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return a;
           
        }

    }
}


