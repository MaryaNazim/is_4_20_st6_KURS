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
    public partial class Form1_auth1 : MetroForm
    {
        public Form1_auth1()
        {
            InitializeComponent();
        }
        //Метод расстановки функционала формы взависимости от роли пользователя, которая передается посредством  поля класса,
        //в которое данное значени в свою очередь попало из запроса
        public void ManagerRole(int role)
        {
            switch (role)
            {
                //И в зависимости от того, какая роль (цифра) хранится в поле класса и передана в метод, показываются те или иные кнопки.
                //Вы можете скрыть их и не отображать вообще, здесь они просто выключены
                case 1:
                    metroLabel8.Text = "Максимальный";
                    metroLabel8.ForeColor = Color.Green;
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = true;
                    metroButton3.Enabled = true;
                    metroButton4.Enabled = true;
                    break;
                case 2:
                    metroLabel8.Text = "Умеренный";
                    metroLabel8.ForeColor = Color.YellowGreen;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    metroButton4.Enabled = false;
                    break;
                case 3:
                    metroLabel8.Text = "Минимальный";
                    metroLabel8.ForeColor = Color.Yellow;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    metroButton4.Enabled = false;
                    break;
                //Если по какой то причине в классе ничего не содержится, то всё отключается вообще
                default:
                    metroLabel8.Text = "Неопределённый";
                    metroLabel8.ForeColor = Color.Red;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    metroButton4.Enabled = false;
                    break;
            }
        }

        private void Form1_auth1_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Form1_auth2 form1_auth2 = new Form1_auth2();
            //Вызов формы в режиме диалога
            form1_auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
                //Вытаскиваем из класса поля в label'ы
                metroLabel5.Text = Auth.auth_id;
                metroLabel4.Text = Auth.auth_login;
                metroLabel6.Text = "Успешна!";
                //Красим текст в label в зелёный цвет
                metroLabel6.ForeColor = Color.Green;
                //Вызываем метод управления ролями
                ManagerRole(Auth.auth_role);
            }
            //иначе
            else
            {
                //Закрываем форму
                this.Close();
            }

            metroButton1.ContextMenuStrip = metroContextMenu1;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form6_employees form6_employees = new Form6_employees();
            form6_employees.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form3_afisha form3_afisha = new Form3_afisha();
            form3_afisha.ShowDialog();
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form5_order form5_order = new Form5_order();
            form5_order.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Form8_actorafisha form8_actorafisha = new Form8_actorafisha();
            form8_actorafisha.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Form7_bilets form7_bilets = new Form7_bilets();
            form7_bilets.ShowDialog();
        }
    }
}
