using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private int usr_Id;
        private int rol_Id;

        public int Rol_Id
        {
            get { return rol_Id; }
            set { rol_Id = value; }
        }
        private string usr_Apellido;

        public string Usr_Apellido
        {
            get { return usr_Apellido; }
            set { usr_Apellido = value; }
        }
        private string usr_Email;

        public string Usr_Email
        {
            get { return usr_Email; }
            set { usr_Email = value; }
        }
        private string usr_Nombre;

        public string Usr_Nombre
        {
            get { return usr_Nombre; }
            set { usr_Nombre = value; }
        }
        private string usr_Password;

        public string Usr_Password
        {
            get { return usr_Password; }
            set { usr_Password = value; }
        }
        private string usr_UserName;

        public string Usr_UserName
        {
            get { return usr_UserName; }
            set { usr_UserName = value; }
        }

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }


        public Usuario(string username, string password)
        {
            Usr_UserName = username;
            Usr_Password = password;
        }

        public Usuario()
        {
            // TODO: Complete member initialization
        }
    }
}
