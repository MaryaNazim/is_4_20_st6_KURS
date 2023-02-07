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
    public partial class Form8_OrderM : MetroForm
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
            list_stud_table.Columns.Add(new DataColumn("id_MainCateg", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("title_MainCateg", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox1.DataSource = list_stud_table;
            metroComboBox1.DisplayMember = "title_MainCateg";
            metroComboBox1.ValueMember = "id_MainCateg";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_MainCateg, title_MainCateg FROM t_mainCateg";
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
                    rowToAdd["id_MainCateg"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["title_MainCateg"] = list_stud_reader[1].ToString();
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
        public void GetComboBox2(string id_MainCateg)
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_SubCateg", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("title_SubCateg", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox2.DataSource = list_stud_table;
            metroComboBox2.DisplayMember = "title_SubCateg";
            metroComboBox2.ValueMember = "id_SubCateg";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = $"SELECT id_SubCateg, title_SubCateg FROM t_subCateg WHERE id_MainCateg = {id_MainCateg}";
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
                    rowToAdd["id_SubCateg"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["title_SubCateg"] = list_stud_reader[1].ToString();
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
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("idClient", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("fioClient", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox3.DataSource = list_stud_table;
            metroComboBox3.DisplayMember = "fioClient";
            metroComboBox3.ValueMember = "idClient";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT idClient, fioClient FROM t_client";
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
                    rowToAdd["idClient"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["fioClient"] = list_stud_reader[1].ToString();
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
        public Form8_OrderM()
        {
            InitializeComponent();
        }
        private void Form8_OrderM_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
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
            //GetFirstListUsers();
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;
            metroGrid1.Columns[3].Visible = false;
            //Ширина полей
            metroGrid1.Columns[0].FillWeight = 10;
            metroGrid1.Columns[1].FillWeight = 70;
            metroGrid1.Columns[2].FillWeight = 20;
            //Режим для полей "Только для чтения"
            metroGrid1.Columns[0].ReadOnly = true;
            metroGrid1.Columns[1].ReadOnly = true;
            metroGrid1.Columns[2].ReadOnly = true;
            //Растягивание полей грида
            metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            //GetListUsers(metroComboBox2.SelectedValue.ToString());
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;
            metroGrid1.Columns[3].Visible = false;
            //Ширина полей
            metroGrid1.Columns[0].FillWeight = 10;
            metroGrid1.Columns[1].FillWeight = 70;
            metroGrid1.Columns[2].FillWeight = 20;
            //Режим для полей "Только для чтения"
            metroGrid1.Columns[0].ReadOnly = true;
            metroGrid1.Columns[1].ReadOnly = true;
            metroGrid1.Columns[2].ReadOnly = true;
            //Растягивание полей грида
            metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            metroGrid1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            metroGrid1.ColumnHeadersVisible = true;
        }


    }
}
