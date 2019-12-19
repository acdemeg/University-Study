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

namespace Учет_ВКР
{

    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VKR_DATABASE.mdb;";

        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            // создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);
            // открываем соединение с БД
            myConnection.Open();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        //получаем все данные
        private void button1_Click(object sender, EventArgs e)
        {
            // текст запроса
            string query = "SELECT id, student, title, data_order, title_order, supervisor, act_implementation, organization, data_protection, rate FROM vkr_table ORDER BY title";
            GetData(query);
        }

        //поиск по руководителю
        private void button2_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            string query = "SELECT id, student, title, data_order, title_order, supervisor, act_implementation, organization, data_protection, rate FROM vkr_table WHERE supervisor = " + "'" + key + "'";
            GetData(query);
        }

        //поиск по студенту
        private void button3_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            string query = "SELECT id, student, title, data_order, title_order, supervisor, act_implementation, organization, data_protection, rate FROM vkr_table WHERE student = " + "'" + key + "'";
            GetData(query); 
        }

        //поиск по дате защиты
        private void button4_Click(object sender, EventArgs e)
        {
            string key = "#" + textBox1.Text + "#";   //  #YYYY-MM-DD#
            
            if(textBox1.Text == "")
            {
                button1_Click(sender, e);
                return;
            }

            string query = "SELECT id, student, title, data_order, title_order, supervisor, act_implementation, organization, data_protection, rate FROM vkr_table WHERE data_protection = " + key;  
            GetData(query);   
        }
       
        //отчет по группе
        private void button5_Click(object sender, EventArgs e)
        {
            string key = textBox2.Text;
            string query = "SELECT student, title_order, rate, act_implementation, data_protection FROM vkr_table WHERE students_group = " + "'" + key + "'";
            GetReport(query); 
        }

        //отчет по предподавателю
        private void button6_Click(object sender, EventArgs e)
        {
            string key = textBox2.Text;
            string query = "SELECT student, title_order, rate, act_implementation, data_protection FROM vkr_table WHERE supervisor = " + "'" + key + "'";
            GetReport(query); 
        }

        //отчет по дате защиты
        private void button7_Click(object sender, EventArgs e)
        {
            string key = "#" + textBox2.Text + "#";   //  #YYYY-MM-DD#
            string query = "SELECT student, title_order, rate, act_implementation, data_protection FROM vkr_table WHERE data_protection = " + key; 
            GetReport(query);
        }

        private void GetData(string query)
        {
            //try
            //{
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                // в цикле построчно читаем ответ от БД
                while (reader.Read())
                {
                    string[] rows = { reader[0].ToString(), 
                                      reader[1].ToString(), 
                                      reader[2].ToString(), 
                                      reader[3].ToString().Substring(0, 10), 
                                      reader[4].ToString(),
                                      reader[5].ToString(), 
                                      reader[6].ToString(), 
                                      reader[7].ToString(), 
                                      reader[8].ToString().Substring(0, 10), 
                                      reader[9].ToString() };

                    dataGridView1.Rows.Add(rows);
                }

                // закрываем OleDbDataReader
                reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    GetData("SELECT student, title, data_order, title_order, supervisor, act_implementation, organization, data_protection, rate FROM vkr_table ORDER BY title");
            //}
            
        }

        private void GetReport(string query)
        {
            try
            {
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();

                if (!reader.HasRows)
                {
                    listBox1.Items.Add(" Данные отсутствуют!");
                    return;
                }

                // в цикле построчно читаем ответ от БД
                while (reader.Read())
                {
                    listBox1.Items.Add("Студент:                               " + reader[0].ToString());
                    listBox1.Items.Add("Название работы:          " + reader[1].ToString());
                    listBox1.Items.Add("Оценка:                                " + reader[2].ToString());
                    listBox1.Items.Add("Акт внедрения:                " + reader[3].ToString());
                    listBox1.Items.Add("Дата защиты:                    " + reader[4].ToString().Substring(0, 10));
                    listBox1.Items.Add("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    listBox1.Items.Add("");
                }

                // закрываем OleDbDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(" Пожалуйста, введите корректные данные!");
            }
           
        }


    }
}
