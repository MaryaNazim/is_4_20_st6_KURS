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
    public partial class Form3 : MetroForm
    {
        // строка подключения к БД
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_4_20_6;database=is_4_20_st6_KURS;password=22702128;";
        MySqlConnection conn;

        public Form3()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            metroLabel1.Text = Auth.title;
            pictureBox1.Visible = true;
            switch (metroDateTime1.Value.ToShortDateString()) //dateTimePicker1.Value - значение в dateTimePicker1. ".ToShortDateString()" - преобразование типа данных в string
            {
                case "04.12.2022": //В случае если выбранная дата - 04.12.2022
                    Payazi();//Выводится картинка, по пути, прописанный в переменной im1
                    break;
                case "09.12.2022":
                    MisterX();
                    break;
                case "26.12.2022":
                    Shelkunchic();
                    break;
                case "27.12.2022":
                    Shelkunchic();
                    break;
                case "28.12.2022":
                    Karenina();
                    break;

            }
        }
        public void Payazi()
        {
            //metroLabel1.Text = "Р. Леонкавалло «Паяцы»";
            pictureBox1.Image = Properties.Resources.payazi_afisha;
            pictureBox1.Visible = true;
        }
        public void Shelkunchic()
        {
            //metroLabel1.Text = "П. Чайковский «Щелкунчик»";
            pictureBox1.Image = Properties.Resources.shelkuunchik;
            pictureBox1.Visible = true;
        }
        public void Karenina()
        {
            //metroLabel1.Text = "К. Монтеверди, В. А. Моцарт, Ф. Лист, С. Рахманинов, О. Респиги, Б. Бриттен, Л. Левашкевич «Анна Каренина»";
            pictureBox1.Image = Properties.Resources._237karenina;
            pictureBox1.Visible = true;
        }
        public void MisterX()
        {
            //metroLabel1.Text = "И. Кальман «Мистер Икс»";
            pictureBox1.Image = Properties.Resources.misterx;
            pictureBox1.Visible = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
        }

        /*public void GetSpectaclInfo()
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT title FROM `Afisha`";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.title = reader[1].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        */

    }
}
    

