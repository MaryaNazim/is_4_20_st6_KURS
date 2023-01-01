using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_4_20_st6_KURS
{
    //Класс необходимый для хранения состояния авторизации во время работы программы
    static class Auth
    {
        //Статичное поле, которое хранит значение статуса авторизации
        public static bool auth = false;
        //Статичное поле, которое хранит значения ID пользователя
        public static string id_u = null;
        //Статичное поле, которое хранит значения ФИО пользователя
        public static string id_emp = null;
        public static string login = null;
        public static string password = null;
        //Статичное поле, которое хранит количество привелегий пользователя
        public static int auth_role = 0;

    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
