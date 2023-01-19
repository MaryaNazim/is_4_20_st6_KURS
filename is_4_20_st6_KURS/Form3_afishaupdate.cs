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
    public partial class Form3_afishaupdate : Form
    {
        public Form3_afishaupdate()
        {
            InitializeComponent();
        }
        MySqlConnection conn;

        private void Form3_afishaupdate_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_afish = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT title FROM Afisha WHERE id={selected_id_afish}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            string name = command.ExecuteScalar().ToString();
            // выводим ответ в TextBox
            textBox2.Text = name;
            // закрываем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем ID изменяемого студента
            string redact_id = textBox1.Text;
            //Получаем значение нового ФИО из TextBox
            string new_title = textBox2.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE Afisha SET title = '{new_title}' WHERE id = {redact_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_afish = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT fio FROM Afisha WHERE id={selected_id_afish}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            string name = command.ExecuteScalar().ToString();
            // выводим ответ в TextBox
            MessageBox.Show($"Новое название представления прочтённое из БД - {name}");
            // закрываем соединение с БД
            conn.Close();
        }
    }
}
