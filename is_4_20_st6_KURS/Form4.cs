using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace is_4_20_st6_KURS
{
    public partial class Form4 : MetroForm
    {
        //Простой метод принимающий в качества параметра любой ListBox и выводящий в него список преподавателей
        public void GetListAfisha()
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM OrderPlace";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                //Присваеваем переменным значения в ридере
                // элементы массива [] - это значения столбцов из запроса SELECT
                string id = reader[0].ToString();
                string Afisha = reader[1].ToString();
                string place = reader[2].ToString();
                string OrderM = reader[3].ToString();

            }
            reader.Close(); // закрываем reader
                            // закрываем соединение с БД
            conn.Close();
        }

        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        public bool InsertAfisha(string i_Afisha, string i_place, string i_OrderM)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO OrderPlace (Afisha, place, OrderM) VALUES ('{i_Afisha}', '{i_place}', '{i_OrderM}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        //Объявляем соединения с БД
        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            
            metroButton11.Click += metroButton10_Click;
            metroButton12.Click += metroButton10_Click;
            metroButton13.Click += metroButton10_Click;
            metroButton14.Click += metroButton10_Click;
            metroButton15.Click += metroButton10_Click;
            metroButton16.Click += metroButton16_Click;
            metroButton17.Click += metroButton16_Click;
            metroButton18.Click += metroButton16_Click;


        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string ins_Afisha = metroLabel1.Text;
            string ins_place = metroLabel31.Text;
            string ins_OrderM = "0"; 

            DialogResult result = MessageBox.Show(
                  "Забронировать место ?",
                  "Сообщение",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
                //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
                if (InsertAfisha(ins_Afisha, ins_place, ins_OrderM))
                {
                    GetListAfisha();
                }
                //Иначе произошла какая то ошибка и покажем пользователю уведомление
                else
                {
                    MessageBox.Show("Ошибка");
                }
            MessageBox.Show($"место {metroLabel31.Text} забронировано");

            this.TopMost = true;
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "Забронировать место ?",
                 "Сообщение",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
                MessageBox.Show($"место {metroLabel32.Text} забронировано");

            this.TopMost = true;
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {

        }
    }
}
