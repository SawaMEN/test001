using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace test001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection("Server=mysql.sawamen.myjino.ru; Port=3306; Database=sawamen_test; Uid=046596423_test; Pwd=z1z2z3z4z5z6z7z8; charset=utf8; ");
                mycon.Open();
                View_SQL();
                mycon.Close();
            }
            catch
            {
                MessageBox.Show("Доступа у базе нет");
                Close();
            }

        }

        void View_SQL()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            MySqlCommand command = new MySqlCommand(); ;
            MySqlConnection connection = new MySqlConnection("Server=mysql.sawamen.myjino.ru; Port=3306; Database=sawamen_test; Uid=046596423_test; Pwd=z1z2z3z4z5z6z7z8; charset=utf8; ");
            command.CommandText = "SELECT * FROM users;";
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("id", "User ID");
                this.dataGridView1.Columns["id"].Visible = false;
                this.dataGridView1.Columns.Add("name", "Имя");
                this.dataGridView1.Columns.Add("surname", "Фамилия");
                this.dataGridView1.Columns.Add("patro", "Отчество");
                this.dataGridView1.Columns.Add("telefone", "Телефон");
                this.dataGridView1.Columns.Add("data", "Дата рождения");
                this.dataGridView1.Columns.Add("male", "Пол");
                this.dataGridView1.Columns.Add("titile", "Должность");
                this.dataGridView1.Columns.Add("management", "Кем руководит");

                string mal;
                while (reader.Read())
                {
                    if ((Convert.ToBoolean(reader["male"]))  == true)
                        mal = "Мужчина"; 
                        else
                        mal = "Женщина";

                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["surname"].ToString(), reader["patro"].ToString(),
                        reader["telefone"].ToString(), Convert.ToDateTime(reader["data"]).ToString("MM.dd.yyyy"), mal, reader["titile"].ToString(), reader["management"].ToString()); ;
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //new Form2().Show(this);

            Form2 f2 = new Form2();
            f2.FormClosed += new FormClosedEventHandler(f2_FormClosed);
            f2.ShowDialog();

        }

        private void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            View_SQL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить данную строку?", dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString() + " " + dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlConnection mycon = new MySqlConnection("Server=mysql.sawamen.myjino.ru; Port=3306; Database=sawamen_test; Uid=046596423_test; Pwd=z1z2z3z4z5z6z7z8; charset=utf8; ");
                string sql = "DELETE FROM `users` WHERE `users`.`id` = " + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();

                //MessageBox.Show(sql);

                mycon.Open();
                MySqlCommand command = new MySqlCommand(sql, mycon);
                command.ExecuteScalar();
                mycon.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex); 
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("Server=mysql.sawamen.myjino.ru; Port=3306; Database=sawamen_test; Uid=046596423_test; Pwd=z1z2z3z4z5z6z7z8; charset=utf8; ");
            
            string sql1 = "UPDATE `users` SET `";
            string sql2 = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name.ToString() + "` = '";
            string sql3 = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string sql4 = "' WHERE `users`.`id` = " + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string sql = sql1 + sql2 + sql3 + sql4;

            //MessageBox.Show(sql);

            mycon.Open();
            MySqlCommand command = new MySqlCommand(sql, mycon);
            command.ExecuteScalar();
            mycon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View_SQL();
        }
    }
}