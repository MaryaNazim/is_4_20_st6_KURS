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

namespace is_4_20_st6_KURS
{
    public partial class Form3_afishadelete : Form
    {
        //Простой метод принимающий в качества параметра любой ListBox и выводящий в него список преподавателей
        public void GetListAfisha(ListBox lv)
        {
            //Чистим ListBox
            lv.Items.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM Afisha";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                //Присваеваем переменным значения в ридере
                // элементы массива [] - это значения столбцов из запроса SELECT
                string id_Afish = reader[0].ToString();
                string title = reader[1].ToString();
                string duration = reader[2].ToString();
                string dt = reader[3].ToString();

                lv.Items.Add($"{id_Afish} {title} {duration} {dt}");

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
           conn.Close();
        }

        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        public bool DeleteAfisha(string id_del)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запрос удаления данных
            string query = $"DELETE FROM Afisha WHERE (id_Afish='{id_del}')";
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

        public Form3_afishadelete()
        {
            InitializeComponent();
        }

        private void Form3_afishadelete_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызов метода обновления списка преподавателей с передачей в качестве параметра ListBox
            GetListAfisha(listBox1);
            //Формируем колонки в элементе listView
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Помещаем в переменную введёный ИД для удаления
            string id_del = textBox1.Text;
            //Если функция удалила строку, то
            if (DeleteAfisha(id_del))
            {
                //Вызываем метод обновления листбокса
                GetListAfisha(listBox1);
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
