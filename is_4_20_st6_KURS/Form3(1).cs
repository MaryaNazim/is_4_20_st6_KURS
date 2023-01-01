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

namespace is_4_20_st6_KURS
{
    public partial class Form3_1_ : MetroForm
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
        MySqlConnection conn;
        public Form3_1_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metroLabel1.Text = metroDateTime1.Text;
            metroLabel1.Text = metroDateTime1.Value.ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Переменная для хранения даты
            string dateStudFromDB;
            //Объявлем переменную для запроса в БД
            string selected_id_stud = textBox2.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM t_datetime WHERE idStud={selected_id_stud}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox3.Text = reader[1].ToString();
                dateStudFromDB = reader[2].ToString();
                //Переводим дату из БД в дату для dateTimePicker и присваиваем
                metroDateTime1.Value = Convert.ToDateTime(dateStudFromDB);
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void Form3_1__Load(object sender, EventArgs e)
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
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO t_datetime (fioStud,drStud) " +
                   "VALUES (@name, @date)", conn))
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
