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
    public partial class Form7_visitors : MetroForm
    {
        //Объявляем объект соединения глобально
        MySqlConnection conn;
        public Form7_visitors()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Определяем значение переменных для записи в БД
            string fio = metroTextBox1.Text;
            string phone_number = metroTextBox2.Text;

            //Формируем запрос на изменени
            string sql_update_current_stud = $"INSERT INTO Visitors (fio, phone_number) " +
                                              $"VALUES ('{fio}', '{phone_number}'); " +
                                              $"SELECT id FROM OrderM WHERE (id = LAST_INSERT_ID());";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            // выполняем запрос
            string id_insert_client = command.ExecuteScalar().ToString();
            SomeClass.new_inserted_id = id_insert_client;
            MessageBox.Show($"ID нового клиента {id_insert_client}");
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();
        }

        private void Form7_addticket_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }
    }
}
