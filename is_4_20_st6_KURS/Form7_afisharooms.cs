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
    public partial class Form7_afisharooms : MetroForm
    {
        //Объявляем соединение
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        //ID выбранного клиента
        string id_selected_clients = "0";
        //Переменная которая хранить имя товара 
        string titleItems_selected_rows = "";
        //Переменная которая хранит стоимость товара
        string priceItems_selected_rows = "";

        string countPlaceItems_selected_rows = "";

        string countBiletItems_selected_rows = "";

        string timeItems_selected_rows = "";

        string dateItems_selected_rows = "";

        //Перемененная отвечающая за понимание, создан ли заказ
        bool issetOrder = false;
        //Переменная для подсчёта предварительной суммы заказа
        double prSumOrder = 0;

        public void GetComboBox1()
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_Afisha", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("title", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox1.DataSource = list_stud_table;
            metroComboBox1.DisplayMember = "title";
            metroComboBox1.ValueMember = "id_Afisha";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_Afisha, title FROM Afisha";
            list_stud_command.CommandText = sql_list_users;
            list_stud_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_stud_reader;
            try
            {
                //Инициализируем ридер
                list_stud_reader = list_stud_command.ExecuteReader();
                while (list_stud_reader.Read())
                {
                    DataRow rowToAdd = list_stud_table.NewRow();
                    rowToAdd["id_Afisha"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["title"] = list_stud_reader[1].ToString();
                    list_stud_table.Rows.Add(rowToAdd);
                }
                list_stud_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }
        public void GetComboBox2(string id_Afisha)
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("count_bilet", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox2.DataSource = list_stud_table;
            metroComboBox2.DisplayMember = "count_bilet";
            metroComboBox2.ValueMember = "id";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = $"SELECT id, count_bilet FROM AfishaRooms WHERE id = {id_Afisha}";
            list_stud_command.CommandText = sql_list_users;
            list_stud_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_stud_reader;
            try
            {
                //Инициализируем ридер
                list_stud_reader = list_stud_command.ExecuteReader();
                while (list_stud_reader.Read())
                {
                    DataRow rowToAdd = list_stud_table.NewRow();
                    rowToAdd["id"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["count_bilet"] = list_stud_reader[1].ToString();
                    list_stud_table.Rows.Add(rowToAdd);
                }
                list_stud_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }
        public void GetComboBox3()
        {
            //Формирование списка статусов
            DataTable list_order_table = new DataTable();
            MySqlCommand list_order_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_order_table.Columns.Add(new DataColumn("id_emp", System.Type.GetType("System.Int32")));
            list_order_table.Columns.Add(new DataColumn("fio", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox3.DataSource = list_order_table;
            metroComboBox3.DisplayMember = "fio";
            metroComboBox3.ValueMember = "id_emp";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_bilets = "SELECT id_emp, fio FROM Employ";
            list_order_command.CommandText = sql_list_bilets;
            list_order_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_bilets_reader;
            try
            {
                //Инициализируем ридер
                list_bilets_reader = list_order_command.ExecuteReader();
                while (list_bilets_reader.Read())
                {
                    DataRow rowToAdd = list_order_table.NewRow();
                    rowToAdd["id_emp"] = Convert.ToInt32(list_bilets_reader[0]);
                    rowToAdd["fio"] = list_bilets_reader[1].ToString();
                    list_order_table.Rows.Add(rowToAdd);
                }
                list_bilets_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }


        public Form7_afisharooms()
        {
            InitializeComponent();
        }

        private void Form7_afisharooms_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызов заполнения первого Combobox
            GetComboBox1();
            //Заполнение ComboBox'a с клиентами
            GetComboBox3();
            metroComboBox3.Text = "";
            //Установка пустой строки по умолчанию в ComboBox1
            metroComboBox1.Text = "";
            //Вывод списка всех товаров
            GetFirstListUsers();
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;
            metroGrid1.Columns[3].Visible = true;
            metroGrid1.Columns[4].Visible = true;
            metroGrid1.Columns[5].Visible = true;
            metroGrid1.Columns[6].Visible = true;
            //Ширина полей
            metroGrid1.Columns[0].FillWeight = 10;
            metroGrid1.Columns[1].FillWeight = 70;
            metroGrid1.Columns[2].FillWeight = 20;
            metroGrid1.Columns[3].FillWeight = 20;
            metroGrid1.Columns[4].FillWeight = 20;
            metroGrid1.Columns[5].FillWeight = 20;
            metroGrid1.Columns[6].FillWeight = 20;
            //Режим для полей "Только для чтения"
            metroGrid1.Columns[0].ReadOnly = true;
            metroGrid1.Columns[1].ReadOnly = true;
            metroGrid1.Columns[2].ReadOnly = true;
            metroGrid1.Columns[3].ReadOnly = true;
            metroGrid1.Columns[4].ReadOnly = true;
            metroGrid1.Columns[5].ReadOnly = true;
            metroGrid1.Columns[6].ReadOnly = true;
            //Растягивание полей грида
            metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            metroGrid1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            metroGrid1.ColumnHeadersVisible = true;
        }

        //Событие на выборе значения в первом комбобоксе
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Включение ComboBox2
            metroComboBox2.Enabled = true;
            //Заполнение Combobox2 теми подкатегориями, которые относятся к выбранной категории
            GetComboBox2(metroComboBox1.SelectedValue.ToString());
            //Установка пустой строки по умолчанию в ComboBox2
            metroComboBox2.Text = "";
        }

        //Событие на выборе значения во втором комбобоксе
        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод наполнения ДатаГрид только теми объектами, которые подходят по условию
            GetListUsers(metroComboBox2.SelectedValue.ToString());
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;
            metroGrid1.Columns[3].Visible = true;
            metroGrid1.Columns[4].Visible = true;
            metroGrid1.Columns[5].Visible = true;
            metroGrid1.Columns[6].Visible = true;
            //Ширина полей
            metroGrid1.Columns[0].FillWeight = 10;
            metroGrid1.Columns[1].FillWeight = 70;
            metroGrid1.Columns[2].FillWeight = 20;
            metroGrid1.Columns[3].FillWeight = 20;
            metroGrid1.Columns[4].FillWeight = 20;
            metroGrid1.Columns[5].FillWeight = 20;
            metroGrid1.Columns[6].FillWeight = 20;
            //Режим для полей "Только для чтения"
            metroGrid1.Columns[0].ReadOnly = true;
            metroGrid1.Columns[1].ReadOnly = true;
            metroGrid1.Columns[2].ReadOnly = true;
            metroGrid1.Columns[3].ReadOnly = true;
            metroGrid1.Columns[4].ReadOnly = true;
            metroGrid1.Columns[5].ReadOnly = true;
            metroGrid1.Columns[6].ReadOnly = true;
            //Растягивание полей грида
            metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            metroGrid1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            metroGrid1.ColumnHeadersVisible = true;
        }

        //Метод загрузки товаров в грид1 без условия, то есть грузятся все товары
        public void GetFirstListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = $"SELECT id AS 'Код', count_bilet AS 'Номер билета', id_Rooms AS 'Код места', id_Afish AS 'Код представления', time AS 'Время', date AS 'Дата', price  AS 'Цена товара' FROM AfishaRooms";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            metroGrid1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();

        }
        //Метод наполнения виртуальной таблицы и присвоение её к датагриду
        public void GetListUsers(string idCountBilet)
        {
            //Запрос для вывода строк в БД
            string commandStr = $"SELECT id AS 'Код', count_bilet AS 'Номер билета', id_Rooms AS 'Код места', id_Afish AS 'Код представления', time AS 'Время', date AS 'Дата', price  AS 'Цена товара' FROM AfishaRooms WHERE id= {idCountBilet}";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            metroGrid1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();

        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsers(metroComboBox2.SelectedValue.ToString());
        }
        //Метод получения ID выделенной строки для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = metroGrid1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = metroGrid1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            //название товара конкретной записи в Базе данных, на основании индекса строки
            titleItems_selected_rows = metroGrid1.Rows[Convert.ToInt32(index_selected_rows)].Cells[3].Value.ToString();
            //стоимость товара конкретной записи в Базе данных, на основании индекса строки
            priceItems_selected_rows = metroGrid1.Rows[Convert.ToInt32(index_selected_rows)].Cells[6].Value.ToString();

        }

        //Выделение всей строки по ПКМ
        private void metroGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                metroGrid1.CurrentCell = metroGrid1[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                metroGrid1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки
            metroGrid1.CurrentCell = metroGrid1[e.ColumnIndex, e.RowIndex];
            metroGrid1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }

        //Метод добавления заказа в главную таблицу заказов
        public void InsertOrderMain()
        {
            //Определяем значение переменных для записи в БД
            string dataOrder = DateTime.Now.ToString("yyyy-MM-dd");
            string idClient = id_selected_clients; 
            string summOrder = "0";

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
            toolStripStatusLabel1.Text = $"Добавлен заказ в БД с ID {SomeClass.new_inserted_Order_id}";
            // закрываем подключение к БД
            conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Устанавливаем в переменную ИД выбранного клиента для формирования заказа
            id_selected_clients = metroComboBox3.SelectedValue.ToString();
            //Создание заказа с запоминанием ID этого самого заказа, она нужна для формирования позиций в составе зказа
            InsertOrderMain();
            //Изменение переменной отчечающей за понимание, создан ли заказ
            issetOrder = true;

        }

        //Добавление позиций во временную корзину
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Определяем количество товаров в DataGridView2
            int countPosition = metroGrid2.Rows.Count;

            metroGrid2.Columns.Add("text", "Код");
            metroGrid2.Columns.Add("text", "Номер билета");
            metroGrid2.Columns.Add("text", "Код места");
            metroGrid2.Columns.Add("text", "Код представления");
            metroGrid2.Columns.Add("text", "Время");
            metroGrid2.Columns.Add("text", "Дата");
            metroGrid2.Columns.Add("text", "Цена");
            
            
            //Индекс добавленной строки
            int rowNumber = metroGrid2.Rows.Add();
            //Распихивание данных по полям грида
            metroGrid2.Rows[rowNumber].Cells[0].Value = id_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[1].Value = countBiletItems_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[2].Value = countPlaceItems_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[3].Value = titleItems_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[4].Value = timeItems_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[5].Value = dateItems_selected_rows;
            metroGrid2.Rows[rowNumber].Cells[6].Value = priceItems_selected_rows;

            metroGrid2.RowHeadersVisible = false;

            //Обновление итоговой суммы заказа
            prSumOrder += 1 * Convert.ToDouble(metroGrid2.Rows[rowNumber].Cells[6].Value);
            //Вывод предварительной итоговой суммы заказа
            metroLabel6.Text = prSumOrder.ToString();
        }

        //Кнопка для записи в БД информации о позициях заказа и обновление итоговой суммы заказа
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (issetOrder)
            {
                //переменная хранящая итоговую сумму заказа
                double sumOrder = 0;
                //Определяем количество товаров в DataGridView2
                int countPosition = metroGrid2.Rows.Count;
                //Определяем цикл для добавление позиций заказа в таблицу
                conn.Open();
                for (int i = 0; i < countPosition; i++)
                {
                    //Задание переменных для формирования запроса в БД
                    string idItems = Convert.ToString(metroGrid2.Rows[i].Cells[3].Value);
                    string countItems = Convert.ToString(metroGrid2.Rows[i].Cells[2].Value);
                    double priceItems = Convert.ToDouble(metroGrid2.Rows[i].Cells[6].Value);
                    //Получение номера заказа в рамках которого добавляются позиции
                    string idOrder = SomeClass.new_inserted_Order_id;
                    //Подсчёт итоговой суммы
                    //sumOrder = Convert.ToDouble(countPosition) * Convert.ToDouble(metroGrid2.Rows[i].Cells[6].Value);
                    sumOrder = prSumOrder;
                    //sumOrder += Convert.ToInt32(countItems) * priceItems;
                    //Формирование запросов на добавение позиций заказа
                    string query = $"INSERT INTO OrderPlace (Afisha, place, OrderM) " +
                        $"VALUES ('{idItems}', '{countItems}', '{idOrder}')";
                    // объект для выполнения SQL-запроса
                    MySqlCommand command = new MySqlCommand(query, conn);
                    // выполняем запрос
                    command.ExecuteNonQuery();
                    // закрываем подключение к БД
                }
                conn.Close();

                //Обновление итоговой суммы заказа
                toolStripStatusLabel1.Text = $"Итоговая сумма заказа №{SomeClass.new_inserted_Order_id} составляет {sumOrder}";
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
                //Чистим корзину
                metroGrid2.Rows.Clear();
                //Чистим переменную хранящую созданный заказ
                SomeClass.new_inserted_Order_id = "0";
            }
            else
            {
                MessageBox.Show("Заказ не создан. Создайте заказ!", "Информация");
            }
        }

        
        private void metroGrid2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Обнуляем предварительную сумму заказа
            prSumOrder = 0;
            //Определяем индекс выбранной строки
            //int selRowNum = metroGrid2.CurrentCell.RowIndex;
            //Формируем тоговую сумму по позиции
            //double itogPosition = Convert.ToDouble(metroGrid2.Rows[selRowNum].Cells[3].Value) * Convert.ToDouble(metroGrid2.Rows[selRowNum].Cells[2].Value);
            //Присваиваем итоговую сумму в ячейку
            //metroGrid2.Rows[selRowNum].Cells[4].Value = itogPosition.ToString();
            //Определяем количество товаров в DataGridView2
            int countPosition = metroGrid2.Rows.Count;
            //Определяем цикл для добавление позиций заказа в таблицу

            for (int i = 0; i < countPosition; i++)
            {
                string countItems = metroGrid2.Rows[i].Cells[2].Value.ToString();
                double priceItems = Convert.ToDouble(metroGrid2.Rows[i].Cells[6].Value);
                //Подсчёт итоговой суммы
                prSumOrder = Convert.ToInt32(countItems) * priceItems;
                //prSumOrder = Convert.ToInt32(countPosition) * priceItems;
            }
            //Вывод обновлённый суммы заказа в лэйбл
            metroLabel6.Text = prSumOrder.ToString();
        }
        


    }
}
