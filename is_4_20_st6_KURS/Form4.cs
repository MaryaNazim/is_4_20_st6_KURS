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
        //ID выбранного клиента
        string id_selected_clients = "0";
        string selected_id_place = "0";
        string id_place = "0";
        string count_place = "0";
        string id_Order = "0";
        //переменная хранящая итоговую сумму заказа
        double sumOrder = 0;
        string prSumOrder = "0";
        //Объявляем соединения с БД
        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
        }
        public void GetPlaceInfo(string id_place)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запроc
            string sql = $"SELECT id, title, count_place FROM Room WHERE id={id_place}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                 string title = reader[1].ToString();
                 string count_place = reader[2].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        public void OrderPlace(string selected_id_place)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запроc
            string sql = $"SELECT id, Afisha, place, orderM FROM OrderPlace WHERE id={selected_id_place}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                string title = reader[1].ToString();
                string count_place = reader[2].ToString();
                string orderM = reader[3].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        public void CreateOrder(string msg)
        {
            //Определяем цикл для добавление позиций заказа в таблицу
            //conn.Open();
            sumOrder = Convert.ToDouble(metroLabel46.Text);

            //Изменение переменной отчечающей за понимание, создан ли заказ
            issetOrder = true;
            GetPriceInfo(Convert.ToString(sumOrder));

            if (issetOrder == true)
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
                    //Создание заказа с запоминанием ID этого самого заказа, она нужна для формирования позиций в составе зказа
                    InsertOrderMain();
                    //Формирование запросов на добавение позиций заказа
                    string query = $"INSERT INTO OrderPlace (Afisha, place, OrderM) " +
                            $"VALUES ('{metroLabel1.Text}', '{id_place}', '{SomeClass.new_inserted_Order_id}')";
                    conn.Open();
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(query, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                    this.TopMost = true;
                    //Обновление итоговой суммы заказа
                    MessageBox.Show($"Итоговая сумма заказа №{SomeClass.new_inserted_Order_id} составляет {metroLabel46.Text}");
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
                    //SomeClass.new_inserted_Order_id = "0";
                    MessageBox.Show($"место {msg}, {metroLabel31.Text} забронировано");
               
                }
                //Иначе произошла какая то ошибка и покажем пользователю уведомление
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Заказ не создан. Создайте заказ!");
            }
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);

            metroLabel1.Text = Auth.title;
            string prSumOrder = Convert.ToString(sumOrder);
            metroLabel46.Text = Convert.ToString(sumOrder);

            foreach (var item in this.Controls) //обходим все элементы формы
            {
                if (item is Button) // проверяем, что это кнопка
                {
                    if (issetOrder == false)
                    {
                        ((Button)item).Click += metroButton10_Click; //приводим к типу и устанавливаем обработчик события  
                    }
                    else
                    {
                        MessageBox.Show("Нельзя забронировать место");
                    }
                }
            }
            
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
            string msg = ((Button)sender).Text;
            CreateOrder(msg);
        }
        /*
        private void metroButton22_Click(object sender, EventArgs e)
        {
            //Определяем цикл для добавление позиций заказа в таблицу
            conn.Open();
            //переменная хранящая итоговую сумму заказа
            double sumOrder = 0;
            sumOrder = Convert.ToDouble(metroLabel46.Text);
            //Задание переменных для формирования запроса в БД
            string ins_Afisha = metroLabel1.Text;
            string ins_title = metroButton22.Text;
            string ins_count_place = metroLabel33.Text;
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
                GetPriceInfo(Convert.ToString(sumOrder));
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
        */

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

        private void metroButton28_Click(object sender, EventArgs e)
        {

        }

        private void metroButton34_Click(object sender, EventArgs e)
        {

        }

        private void metroButton40_Click(object sender, EventArgs e)
        {

        }

        private void metroButton46_Click(object sender, EventArgs e)
        {

        }

        private void metroButton66_Click(object sender, EventArgs e)
        {

        }

        private void metroButton87_Click(object sender, EventArgs e)
        {

        }

        private void metroButton86_Click(object sender, EventArgs e)
        {

        }

        private void metroButton79_Click(object sender, EventArgs e)
        {

        }

        private void metroButton78_Click(object sender, EventArgs e)
        {

        }

        private void metroButton77_Click(object sender, EventArgs e)
        {

        }

        private void metroButton76_Click(object sender, EventArgs e)
        {

        }

        private void metroButton75_Click(object sender, EventArgs e)
        {

        }
    }
}
