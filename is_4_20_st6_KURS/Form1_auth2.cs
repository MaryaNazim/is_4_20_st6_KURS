﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MetroFramework.Forms;


namespace is_4_20_st6_KURS
{
    public partial class Form1_auth2 : MetroForm
    {
        // строка подключения к БД
        string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
        //Переменная соединения
        MySqlConnection conn;

        //Вычисление хэша строки и возрат его из метода
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

        //Метод запроса данных пользователя по логину для запоминания их в полях класса
        public void GetUserInfo(string login)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT * FROM `Users` WHERE `login`='{login}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.auth_id = reader[0].ToString();
                Auth.auth_login = reader[2].ToString();
                Auth.auth_password = reader[3].ToString();
                Auth.auth_role = Convert.ToInt32(reader[4].ToString());
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        public Form1_auth2()
        {
            InitializeComponent();
        }

        Thread thread1;
        Form1_auth1 Form1_Auth1 = new Form1_auth1();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(()=>
            {
                //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
                string sql = "SELECT * FROM `Users` WHERE `login` = @un and  `password`= @up";
                //Открытие соединения
                conn.Open();
                //Объявляем таблицу
                DataTable table = new DataTable();
                //Объявляем адаптер
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                //Объявляем команду
                MySqlCommand command = new MySqlCommand(sql, conn);
                //Определяем параметры
                command.Parameters.Add("@un", MySqlDbType.VarChar, 255);
                command.Parameters.Add("@up", MySqlDbType.VarChar, 255);
                //Присваиваем параметрам значение
                command.Parameters["@un"].Value = metroTextBox1.Text;
                command.Parameters["@up"].Value = sha256(metroTextBox2.Text);
                //Заносим команду в адаптер
                adapter.SelectCommand = command;
                //Заполняем таблицу
                adapter.Fill(table);
                //Закрываем соединение
                conn.Close();
                //Если вернулась больше 0 строк, значит такой пользователь существует
                if (table.Rows.Count > 0)
                {
                    //Присваеваем глобальный признак авторизации
                    Auth.auth = true;
                    //Достаем данные пользователя в случае успеха
                    GetUserInfo(metroTextBox1.Text);
                    MessageBox.Show("Авторизация успешна", "Информация");
                    //Закрываем форму
                    //this.Close();
                    //this.Invoke(new Action(() => Form1_Auth1.Show()));
                    this.Invoke(new Action(() => Hide())); //скрытие данной формы
                }
                else
                {
                    //Отобразить сообщение о том, что авторизаия неуспешна
                    MessageBox.Show("Неверные данные авторизации", "Информация");
                }

            });
            thread1.Start();
        }
        

        private void Form1_auth2_Load(object sender, EventArgs e)
        {
            //Инициализируем соединение с подходящей строкой
            conn = new MySqlConnection(connStr);
            metroTextBox2.PasswordChar = '●';
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '●';
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            metroTextBox2.PasswordChar = '\0';
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Form2_registr form2_registr = new Form2_registr();
            form2_registr.ShowDialog();
        }
    }
}
