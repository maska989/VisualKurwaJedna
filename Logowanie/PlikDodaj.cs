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
    class PlikDodaj
    {
        public delegate List<User> Save(string x,string y,Ranga a);
        public Save S;
        public delegate void Save2(string x,BindingSource rdzen);
        public Save2 S2;

        public PlikDodaj(){

        S += Dodawanie;
        S2 += Dodawanie2;

        }
        Login ListaLog = new Login();
        public List<User> list = new List<User> { };


        private List<User> Dodawanie(string x,string y, Ranga a)
        {
            list.Add(new User(x, y, a));
            return list;
        }
        private void Dodawanie2(string x,BindingSource rdzen)
        {
            string scieszka = Directory.GetCurrentDirectory() + "\\" + x + ".BIN";
            string sPath = scieszka;
            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
            {
                foreach (User p in rdzen)
                {
                    SaveFile.WriteLine(p);
                }
                
            }
            
        }
    }
}
