using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project
{
    public partial class Form1 : Form
    {
        //Путь для соединения с БД.
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database.accdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            //Открытие соединения с БД.
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Поступления". При необходимости она может быть перемещена или удалена.
            this.поступленияTableAdapter.Fill(this.databaseDataSet.Поступления);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Авторизация". При необходимости она может быть перемещена или удалена.
            this.авторизацияTableAdapter.Fill(this.databaseDataSet.Авторизация);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Добавление записи в Авторизация.
            string fio = textBox1.Text;
            string dolzhnost = comboBox1.Text;
            string login = textBox2.Text;
            string parol = textBox3.Text;

            string query = "INSERT INTO Авторизация (ФИО, Должность, Логин, Пароль) VALUES ('" + fio + "', '" + dolzhnost + "', '" + login + "', '" + parol + "')";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Создание выполнено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Редактирование записи в Авторизация.
            string kod = textBox4.Text;
            string fio = textBox5.Text;
            string dolzhnost = comboBox2.Text;
            string login = textBox6.Text;
            string parol = textBox7.Text;

            if (fio != "")
            {
                string query = "UPDATE Авторизация SET ФИО ='" + fio + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (dolzhnost != "")
            {
                string query = "UPDATE Авторизация SET Должность ='" + dolzhnost + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (login != "")
            {
                string query = "UPDATE Авторизация SET Логин ='" + login + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (parol != "")
            {
                string query = "UPDATE Авторизация SET Пароль ='" + parol + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Редактирование выполнено");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Удаление записи в Авторизация.
            string kod = textBox8.Text;

            string query = "DELETE FROM Авторизация WHERE Код =" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();

            MessageBox.Show("Удаление выполнено");
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            //Поиск в Авторизация.
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                int j = 0;
                if (radioButton1.Checked == true) j = 0;
                if (radioButton2.Checked == true) j = 1;
                if (radioButton3.Checked == true) j = 2;
                if (radioButton4.Checked == true) j = 3;
                if (radioButton5.Checked == true) j = 4;

                dataGridView1.Rows[i].Selected = false;
                if (dataGridView1.Rows[i].Cells[j].Value != null)
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox9.Text))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        break;
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.авторизацияTableAdapter.Fill(this.databaseDataSet.Авторизация);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Добавление записи в Поступления.
            string naimenovanie_tovarov = textBox10.Text;
            string kategoria_tovarov = comboBox3.Text;
            string kolichestvo = textBox11.Text;
            string data_pribytia = maskedTextBox1.Text;
            string data_spisania = maskedTextBox2.Text;

            string query = "INSERT INTO Поступления (Наименование_товаров, Категория_товаров, Количество, Дата_прибытия, Дата_списания) VALUES ('" + naimenovanie_tovarov + "', '" + kategoria_tovarov + "', '" + kolichestvo + "', '" + data_pribytia + "', '" + data_spisania + "')";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Создание выполнено");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Редактирование записи в Поступления.
            string kod = textBox12.Text;
            string naimenovanie_tovarov = textBox13.Text;
            string kategoria_tovarov = comboBox4.Text;
            string kolichestvo = textBox14.Text;
            string data_pribytia = maskedTextBox3.Text;
            string data_spisania = maskedTextBox4.Text;

            if (naimenovanie_tovarov != "")
            {
                string query = "UPDATE Поступления SET Наименование_товаров ='" + naimenovanie_tovarov + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (kategoria_tovarov != "")
            {
                string query = "UPDATE Поступления SET Категория_товаров ='" + kategoria_tovarov + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (kolichestvo != "")
            {
                string query = "UPDATE Поступления SET Количество ='" + kolichestvo + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (data_pribytia != "  .  .")
            {
                string query = "UPDATE Поступления SET Дата_прибытия ='" + data_pribytia + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            if (data_spisania != "  .  .")
            {
                string query = "UPDATE Поступления SET Дата_списания ='" + data_spisania + "' WHERE Код =" + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Редактирование выполнено");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Удаление записи в Поступления.
            string kod = textBox15.Text;

            string query = "DELETE FROM Поступления WHERE Код =" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();

            MessageBox.Show("Удаление выполнено");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Поиск в Поступления.
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                int j = 0;
                if (radioButton6.Checked == true) j = 0;
                if (radioButton7.Checked == true) j = 1;
                if (radioButton8.Checked == true) j = 2;
                if (radioButton9.Checked == true) j = 3;
                if (radioButton10.Checked == true) j = 4;
                if (radioButton11.Checked == true) j = 5;

                dataGridView2.Rows[i].Selected = false;
                if (dataGridView2.Rows[i].Cells[j].Value != null)
                    if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox16.Text))
                    {
                        dataGridView2.Rows[i].Selected = true;
                        break;
                    }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.авторизацияTableAdapter.Fill(this.databaseDataSet.Авторизация);
        }
    }
}
