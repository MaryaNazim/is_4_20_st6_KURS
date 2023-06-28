using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;

namespace is_4_20_st6_KURS
{
    public partial class Form2_registr : MetroForm
    {
        // строка подключения к БД
        MySqlConnection conn = new MySqlConnection("server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;");
        public static int id_emp = 1;
        public static string login;
        public static string password;
        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public bool InsertUser(int id_emp,string login, string password)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO `Users` (`id_emp`,`login`,`password`,`role`) VALUES ('{id_emp}','{login}','{sha256(password)}','{3}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
                conn.Close();
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = false;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }

        public Form2_registr()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string login = metroTextBox1.Text;
            string password = metroTextBox2.Text;
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertUser(id_emp,login, password))
            {
                MessageBox.Show("Пользователь успешно зарегистрирован","Информация");
                this.Hide();
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Ошибка при регистрации","Ошибка");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '●';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '●';
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '\0';
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }
    }
}
