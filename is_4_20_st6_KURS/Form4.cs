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
        //Перемененная отвечающая за понимание, создан ли заказ
        bool issetOrder = false;
        //Переменная для подсчёта предварительной суммы заказа
        double prSumOrder = 0;
        //ID выбранного клиента
        string id_selected_clients = "0";
        string selected_id_place = "0";
        string id_place = "0";
        //Объявляем соединения с БД
        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
        }
        public void GetUserInfo(string selected_id_place)
        {
  
            // устанавливаем соединение с БД
            conn.Open();
            // запроc
            string sql = $"SELECT title, count_place FROM Room WHERE id={selected_id_place}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                 metroLabel31.Text = reader[1].ToString();
                 metroButton10.Text = reader[2].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        public void GetUserPlace(string id_place)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запроc
            string sql = $"SELECT id, Afisha, place, orderM FROM OrderPlace WHERE place={id_place}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroLabel31.Text = reader[1].ToString();
                metroButton10.Text = reader[2].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);

            metroLabel1.Text = Auth.title;
            metroLabel46.Text = Convert.ToString(prSumOrder);
            
            metroButton11.Click += metroButton10_Click;
            metroButton12.Click += metroButton10_Click;
            metroButton13.Click += metroButton10_Click;
            metroButton14.Click += metroButton10_Click;
            metroButton15.Click += metroButton10_Click;
            metroButton16.Click += metroButton16_Click;
            metroButton17.Click += metroButton16_Click;
            metroButton18.Click += metroButton16_Click;


        }
        //Метод добавления заказа в главную таблицу заказов
        public void InsertOrderMain()
        {
            //Определяем значение переменных для записи в БД
            string dataOrder = DateTime.Now.ToString("yyyy-MM-dd");
            string idClient = id_selected_clients;
            string summOrder = metroLabel46.Text;

            //Формируем запрос на вставку с возвратом последного вставленного ID
            string sql_update_current_stud = $"INSERT INTO OrderM (datatime, empl, total_Pr) " +
                                              $"VALUES ('{dataOrder}', '{idClient}', '{summOrder}'); " +
                                              $"SELECT id FROM OrderM WHERE (id = LAST_INSERT_ID());";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            // выполняем запрос
            string new_inserted_mainOrder_id = command.ExecuteScalar().ToString();
            //Записываем возвращённый последний добавленный ID заказа в глобальную переменную
            SomeClass.new_inserted_Order_id = new_inserted_mainOrder_id;
            //Пишем инфу в статус бар
            MessageBox.Show($"Добавлен заказ в БД с ID {SomeClass.new_inserted_Order_id}");
            // закрываем подключение к БД
            conn.Close();
        }



        private void metroButton10_Click(object sender, EventArgs e)
        {
            //Определяем цикл для добавление позиций заказа в таблицу
            conn.Open();
            //переменная хранящая итоговую сумму заказа
            double sumOrder = 0;
            sumOrder = Convert.ToDouble(metroLabel46.Text);
            //Задание переменных для формирования запроса в БД
            string ins_Afisha = metroLabel1.Text;
            string ins_title = metroButton10.Text;
            string ins_count_place = metroLabel31.Text;
            string id_selected_place = selected_id_place;
            //Получение номера заказа в рамках которого добавляются позиции
            string idOrder = SomeClass.new_inserted_Order_id;

            if (id_place == id_selected_place)
            {
                MessageBox.Show("Место занято, нельзя забронировать");
            }
            else
            {
                //Изменение переменной отчечающей за понимание, создан ли заказ
                issetOrder = true;
                //Создание заказа с запоминанием ID этого самого заказа, она нужна для формирования позиций в составе зказа
                InsertOrderMain();
                GetPriceInfo(Convert.ToString(prSumOrder));
                if (issetOrder)
                {
                    DialogResult result = MessageBox.Show(
                     "Забронировать место ?",
                     "Сообщение",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);

                    //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
                    if (result == DialogResult.Yes)
                    {
                        //Подсчёт итоговой суммы
                        //sumOrder = Convert.ToDouble(countPosition) * Convert.ToDouble(metroGrid2.Rows[i].Cells[6].Value);
                        //sumOrder = Convert.ToDouble(metroLabel46.Text);
                        //sumOrder += Convert.ToInt32(countItems) * priceItems;
                        //Формирование запросов на добавение позиций заказа
                        string query = $"INSERT INTO OrderPlace (Afisha, place, OrderM) " +
                                $"VALUES ('{ins_Afisha}', '{id_selected_place}', '{idOrder}')";
                        //conn.Open();
                        // объект для выполнения SQL-запроса
                        MySqlCommand command = new MySqlCommand(query, conn);
                        // выполняем запрос
                        command.ExecuteNonQuery();

                        metroButton10.Highlight = true;
                        this.TopMost = true;
                        //Обновление итоговой суммы заказа
                        MessageBox.Show($"Итоговая сумма заказа №{SomeClass.new_inserted_Order_id} составляет {sumOrder}");
                        conn.Close();

                        //Открываем подключение к БД
                        conn.Open();
                        // запрос обновления данных
                        string query2 = $"UPDATE OrderM SET total_Pr='{sumOrder}' WHERE (id='{SomeClass.new_inserted_Order_id}')";
                        // объект для выполнения SQL-запроса
                        MySqlCommand comman1 = new MySqlCommand(query2, conn);
                        // выполняем запрос
                        comman1.ExecuteNonQuery();
                        // закрываем подключение к БД
                        conn.Close();

                        //Чистим переменную хранящую созданный заказ
                        SomeClass.new_inserted_Order_id = "0";


                    }
                    //Иначе произошла какая то ошибка и покажем пользователю уведомление
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }

                    MessageBox.Show($"место {ins_title} {ins_count_place} забронировано");

                }
                else
                {
                    MessageBox.Show("Заказ не создан. Создайте заказ!");
                }

            }
            conn.Close();
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

        public void GetPriceInfo(string prSumOrder)
        {

            // устанавливаем соединение с БД
            conn.Open();
            //запрос
            string sql = $"SELECT id, count_bilet, id_Rooms, id_Afish , time, date, price FROM AfishaRooms";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                metroLabel46.Text = reader[6].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }



    }
}
