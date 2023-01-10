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
    public partial class Form3_afisha : Form
    {
        MySqlConnection conn;
        // строка подключения к БД
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";

        public Form3_afisha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = dateTimePicker1.Text;
            label5.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Переменная для хранения даты
            string dateAfishFromDB;
            //Объявлем переменную для запроса в БД
            string selected_id_afish = textBox2.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM Afisha WHERE idAfish={selected_id_afish}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox3.Text = reader[1].ToString();
                dateAfishFromDB = reader[2].ToString();
                //Переводим дату из БД в дату для dateTimePicker и присваиваем
                dateTimePicker2.Value = Convert.ToDateTime(dateAfishFromDB);
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void Form3_afisha_Load(object sender, EventArgs e)
        {
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Показываем пользователю сколько строк вставлено

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //Открываем соединение
                conn.Open();
                //Конструкция using напоминает https://metanit.com/sharp/tutorial/8.5.php
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Afish (title,duration,dt) " +
                   "VALUES (@title,@duration,@dt)", conn))
                {
                    //Использование параметров в запросах. Это повышает безопасность работы программы
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@date", MySqlDbType.Timestamp).Value = dateTimePicker2.Value;
                    int insertedRows = cmd.ExecuteNonQuery();
                    // закрываем подключение  БД
                    conn.Close();

                }
            }

        }
    }
}
