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
    public partial class Form6_employinsert : Form
    {
        //Простой метод принимающий в качества параметра любой ListBox и выводящий в него список преподавателей
        public void GetListPrepods(ListBox lb)
        {
            //Чистим ListBox
            lb.Items.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM Employ";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                lb.Items.Add($"ФИО: {reader[1].ToString()} День рождения: {reader[2].ToString()}");

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        public bool InsertPrepods(string i_fio, string i_dr, int i_phone)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = true;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO Employ (fio, dr, phone) VALUES ('{i_fio}', '{i_dr}', '{i_phone}')";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            InsertCount = command.ExecuteNonQuery();
            //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
             if (InsertCount != 0)
             {
                    //то результат операции - истина
                    result = true;

             }
             else
             {
                    //Если возникла ошибка, то запрос не вставит ни одной строки
                    InsertCount = 0;
             }
            conn.Close();
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        //Объявляем соединения с БД
        MySqlConnection conn;

        public Form6_employinsert()
        {
            InitializeComponent();
        }

        private void Form6_employinsert_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызов метода обновления списка преподавателей с передачей в качестве параметра ListBox
            GetListPrepods(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string ins_fio = textBox1.Text;
            string ins_dr = textBox2.Text;
            int ins_phone = 0;
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertPrepods(ins_fio, ins_dr, ins_phone))
            {
                GetListPrepods(listBox1);
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.", "Ошибка");
            }
        }
    }
}
