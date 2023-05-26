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
    public partial class Form8_actorafisha : MetroForm
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

        string idActorItems_selected_rows = "";
        //Переменная которая хранит стоимость товара
        string idAfishItems_selected_rows = "";
        public void GetComboBox1()
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_Actor", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("fio", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            metroComboBox1.DataSource = list_stud_table;
            metroComboBox1.DisplayMember = "fio";
            metroComboBox1.ValueMember = "id_Actor";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_Actor, fio FROM Actor";
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
                    rowToAdd["id_Actor"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["fio"] = list_stud_reader[1].ToString();
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
        public void GetComboBox2()
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
            metroComboBox2.DataSource = list_stud_table;
            metroComboBox2.DisplayMember = "title";
            metroComboBox2.ValueMember = "id_Afisha";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = $"SELECT id_Afisha, title FROM Afisha";
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
        public Form8_actorafisha()
        {
            InitializeComponent();
        }

        private void Form8_actors_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.sdlik.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызов заполнения первого Combobox
            GetComboBox1();
            //Заполнение ComboBox'a с клиентами
            GetComboBox2();
            metroComboBox2.Text = "";
            //Установка пустой строки по умолчанию в ComboBox1
            metroComboBox1.Text = "";
            //Вывод списка всех товаров
            GetListUsers();
            //Видимость полей в гриде
            metroGrid1.Columns[0].Visible = true;
            metroGrid1.Columns[1].Visible = true;
            metroGrid1.Columns[2].Visible = true;

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

        //Метод загрузки товаров в грид1 без условия, то есть грузятся все товары
        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = $"SELECT id AS 'Код', id_Actor AS 'Код актёра', id_Afish AS 'Код афиши' FROM ActorAfisha";
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
            GetListUsers();
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
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Объявляем форму
            Form8_actors formNewActorr = new Form8_actors();
            formNewActorr.ShowDialog();

            //Вызываем обновление данных в комбобоксе с клиентами
            GetComboBox1();
            toolStripStatusLabel1.Text = $"Добавлен актёр {metroComboBox1.Text}";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = $"INSERT INTO ActorAfisha (id_Actor, id_Afish) " +
                        $"VALUES ('{metroComboBox1.SelectedValue}', '{metroComboBox2.SelectedValue}')";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД

            conn.Close();
            reload_list();
            //Обновление итоговой суммы заказа
            toolStripStatusLabel1.Text = $"Актёр {metroComboBox1.Text} привязан к спектаклю {metroComboBox2.Text}";
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись ?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                //Формируем строку запроса на добавление строк
                string sql_delete = "DELETE FROM ActorAfisha WHERE id='" + id_selected_rows + "'";
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
    }
}
