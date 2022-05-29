using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace test001
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox4.Text == "" | dateTimePicker1.Text == "" | listBox1.SelectedItems.Count == 0)                    
                MessageBox.Show("Проверьте правильность ввода");
            else
            {
                MySqlConnection mycon = new MySqlConnection("Server=mysql.sawamen.myjino.ru; Port=3306; Database=sawamen_test; Uid=046596423_test; Pwd=z1z2z3z4z5z6z7z8; charset=utf8; ");
                string sql1 = "INSERT INTO `users` (`name`, `surname`, `patro`, `telefone`, `data`, `male`, `titile`, `management`) VALUES (";
                string sql2 = "'" + textBox1.Text + "', "; //имя
                string sql3 = "'" + textBox2.Text + "', "; //Фамилия
                string sql4 = "'" + textBox3.Text + "', "; //Очество
                string sql5 = "'" + textBox4.Text + "', "; //телефон
                string sql6 = "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', "; //Дата рождения
                string sql7 = "'" + listBox1.SelectedIndex.ToString() + "', "; //Пол
                string sql8 = "'" + textBox5.Text + "', "; //Должность
                string sql9 = "'" + textBox6.Text + "')"; //кем руководит
                string sql = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9;

                //MessageBox.Show(sql);

                mycon.Open();
                MySqlCommand command = new MySqlCommand(sql, mycon);
                command.ExecuteScalar();
                mycon.Close();
                Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
