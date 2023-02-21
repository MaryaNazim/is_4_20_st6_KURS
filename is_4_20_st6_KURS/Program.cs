using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_4_20_st6_KURS
{
    //Класс для передачи значений между формами
    static class SomeClass
    {
        //Статичное поле, которое хранит значение для передачи его между формами
        public static string variable_class;
        //Статичное поле, которое хранит значения ID добавленного клиента на Form15-addClient
        public static string new_inserted_id;
        //Статичное поле, которое хранит значение ID добаленного заказа
        public static string new_inserted_mainOrder_id;
    }
    

    //Класс необходимый для хранения состояния авторизации во время работы программы
    static class Auth
    {
        //Статичное поле, которое хранит значение статуса авторизации
        public static bool auth = false;
        //Статичное поле, которое хранит значения ID пользователя
        public static string auth_id = null;
        public static string auth_login = null;
        public static string auth_password = null;
        //Статичное поле, которое хранит количество привелегий пользователя
        public static int auth_role = 0;

        public static string title = null;
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
            Application.Run(new Form1_auth1());
        }
    }
}
