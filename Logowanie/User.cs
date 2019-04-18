using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Logowanie
{
    public class User
    {
        public Guid uid;
        public string UserName;
        public string Password;
        public bool isAdmin;


        public User(string UserName, string Password, bool isAdmin)
        {
            this.uid = Guid.NewGuid();
            Console.WriteLine("Guid: {0}", uid);
            this.UserName = UserName;
            this.Password = Hasło(Password);
            this.isAdmin = isAdmin;
        }
        public User(Guid uid, string UserName, string Password, bool isAdmin)
        {
            this.uid = uid;
            this.UserName = UserName;
            this.Password = Password;
            this.isAdmin = isAdmin;
        }
        public override string ToString()
        {
            return $"{uid};{UserName};{Password};{isAdmin}";
        }
        public Guid uid2
        {
            get { return uid; }
            set { this.uid = Guid.NewGuid(); }
        }

        public string UserName2
        {
            get { return UserName; }
            set { this.UserName = value; }
        }

        public string Password2
        {
            get { return Password; }
            set { this.Password = Hasło(value); }
        }

        public bool isAdmin2
        {
            get { return isAdmin; }
            set { this.isAdmin = value; }
        }
        public string Hasło(string Has)
        {
            byte[] salt = Encoding.ASCII.GetBytes(uid + "8419" + "DamianModzelewski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Has, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpieczne hasło to 25 znaków
            return Convert.ToBase64String(crypted);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Has"></param>
        /// <returns></returns>
        public bool PassCrypt(string Has)
        {
            byte[] salt = Encoding.ASCII.GetBytes(uid+"8419"+"DamianModzelewski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Has, salt);
            byte[] crypted = crypt.GetBytes(25);
            string InPassword = Convert.ToBase64String(crypted);
            bool isCorrect = false;
            if (InPassword == Password)
            {
                isCorrect = true;
            }
            return isCorrect;
        }






    }
}
