﻿using System;
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
    public partial class Form6_employees : MetroForm
    {
        //Переменная соединения
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

        public Form6_employees()
        {
            InitializeComponent();
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки - не вникать
            metroGrid1.CurrentCell = metroGrid1[e.ColumnIndex, e.RowIndex];
            metroGrid1.CurrentRow.Selected = true;
            GetSelectedIDString();
        }

        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsers();
        }

        //Метод наполнения виртуальной таблицы и присвоение её к датагриду
        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id_emp AS 'Код', fio AS 'ФИО', dr AS 'Дата рождения', phone AS 'Номер телефона' FROM Employ";
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

        private void Form6_employ_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод для заполнение дата Грида
            GetListUsers();
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;
            metroGrid1.Columns[3].Visible = true;
            //Ширина полей
            metroGrid1.Columns[0].FillWeight = 15;
            metroGrid1.Columns[1].FillWeight = 40;
            metroGrid1.Columns[2].FillWeight = 15;
            metroGrid1.Columns[3].FillWeight = 15;
            //Режим для полей "Только для чтения"
            metroGrid1.Columns[0].ReadOnly = true;
            metroGrid1.Columns[1].ReadOnly = true;
            metroGrid1.Columns[2].ReadOnly = true;
            metroGrid1.Columns[3].ReadOnly = true;
            //Растягивание полей грида
            metroGrid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            metroGrid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            metroGrid1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            metroGrid1.ColumnHeadersVisible = true;
        }

        /*
        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        public bool InsertAfisha(string i_fio, string i_dr, string i_phone)
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
        */

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string ins_phone = Convert.ToString(metroTextBox3.Text);
            string tmp = $"INSERT INTO Employ (fio, dr, phone) VALUES ('{metroTextBox1.Text}', '{metroDateTime1.Value.ToString("yyyy-MM-dd")}', '{Convert.ToDecimal(ins_phone)}')";
            MySqlCommand cmd = new MySqlCommand(tmp, conn);
            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Добавление прошло успешно", "Информация");
                reload_list();
            }
            /*
            //Объявляем переменные для вставки в БД
            string ins_fio = metroTextBox2.Text;
            string ins_dr = metroTextBox3.Text;
            string ins_phone = metroTextBox4.Text;
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertAfisha(ins_fio, ins_dr, ins_phone))
            {
                GetListUsers();
                reload_list();
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Ошибка");
            }
            */
        }

        /*
        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ФИО и Предмет
        public bool DeletePrepods(string id_del)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запрос удаления данных
            string query = $"DELETE FROM Employ WHERE (id_emp='{id_del}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                // закрываем подключение к БД
            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        */

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /*
            //Помещаем в переменную введёный ИД для удаления
            string id_del = metroTextBox1.Text;
            //Если функция удалила строку, то
            if (DeletePrepods(id_del))
            {
                //Вызываем метод обновления листбокса
                GetListUsers();
                reload_list();
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.", "Ошибка");
            }
            */
            //Формируем строку запроса на добавление строк
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись ?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string sql_delete = "DELETE FROM Employ WHERE id_emp ='" + id_selected_rows + "'";
                //Посылаем запрос на обновление данных
                MySqlCommand delete = new MySqlCommand(sql_delete, conn);
                try
                {
                    conn.Open();
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    conn.Close();
                    reload_list();
                }
            }
        }

        private void metroGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                metroGrid1.CurrentCell = metroGrid1[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                metroGrid1.CurrentCell.Selected = true;
                GetSelectedIDString();
            }
        }

        //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = metroGrid1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = metroGrid1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();

        }
    }

}
