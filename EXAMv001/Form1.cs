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

namespace EXAMv001
{
    public partial class Form1 : Form
    {


        private MySqlConnection connection; //holds the 'state' of the connection & where the connection should go
        private string server;
        private string database;
        private string uid;
        private string password;
        private void iniConnection()   //function for initializing connection
        {
            server = "localhost";
            database = "caffee";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);


        }
        public List<string>[] Select()//gets all the tables from orders database
        {
            string query = "SELECT * FROM orders";


            List<string>[] list = new List<string>[4];
            list[0] = new List<string>(); //id
            list[1] = new List<string>(); //name
            list[2] = new List<string>(); //price
            list[3] = new List<string>(); //ammount


            if (OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();


                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["amo"] + "");
                    list[3].Add(dataReader["price"] + "");
                }


                dataReader.Close();

                CloseConnection();


                return list;
            }
            else
            {
                return list;
            }
        }


        public Form1()//launches when the program comes to live
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            comboBox1.Items.Add("Black 2 $");
            comboBox1.Items.Add("White 4 $ ");
            comboBox1.Items.Add("Powerfull 6 $");
            comboBox2.Items.Add("Tasty 3 $");
            comboBox2.Items.Add("BigChicken 7 $");
            comboBox2.Items.Add("BigBacon 7 $");
            comboBox3.Items.Add("Sweet 3 $");
            comboBox3.Items.Add("SuperSweet 4 $");
            comboBox3.Items.Add("ExtraSweet 5 $");



        }

        private bool OpenConnection()//function for opening connection
        {
            try
            {
                connection.Open();
                return true;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("First connect to darabase");
                return false;
            }
           

        }

        private bool CloseConnection()//function for closing connection
        {
            try
            {
                connection.Close();
                return true;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private string add(string where)// function for adding numbers into textbox(ammount)
        {
            int i;
            i = Int32.Parse(where);
            i++;
            where = i.ToString();
            return where;

        }

        private string substruct(string where)// function for substracting numbers into textbox(ammount)
        {
            int i;
            i = Int32.Parse(where);
            if (i > 0)
            {
                i--;
            }
            where = i.ToString();
            return where;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(IsNumeric(textBox1.Text))
              textBox1.Text = add(textBox1.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (IsNumeric(textBox1.Text))
                textBox1.Text = substruct(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsNumeric(textBox2.Text))
                textBox2.Text = add(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsNumeric(textBox2.Text))
                textBox2.Text = substruct(textBox2.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsNumeric(textBox3.Text))
                textBox3.Text = add(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsNumeric(textBox3.Text))
                textBox3.Text = substruct(textBox3.Text);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0" && comboBox1.Text != "" && IsNumeric(textBox1.Text))//checks if the textBox1 is nor empty nor equal to zero
            {
                string no = comboBox1.Text;
                string[] items = no.Split(' ');
                listBox1.Items.Add(items[0] + " " + items[1]+" $:" + " " + textBox1.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "0" && comboBox2.Text != "" && IsNumeric(textBox2.Text))
            {
                string no = comboBox2.Text;
                string[] items = no.Split(' ');
                listBox1.Items.Add(items[0] + " " + items[1] + " $:" + " " + textBox2.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0" && comboBox3.Text != "" && IsNumeric(textBox3.Text))
            {
                string no = comboBox3.Text;
                string[] items = no.Split(' ');
                listBox1.Items.Add(items[0] + " " + items[1] + " $:" + " " + textBox3.Text);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            iniConnection();
            

            List<string>[] list;
            list = Select();

            for (int i = 0; i < list[0].Count; i++)
            {
                String a = list[0][i] + "  " + list[1][i] + "  price: " + list[2][i] + "  ammount: " + list[3][i];
                listBox2.Items.Add(a);
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
            
            for (int i = 0; i < listBox1.Items.Count; i++)
            {               
                string no = listBox1.Items[i].ToString();
                string[] item = no.Split(' ');
                string names = item[0];
                string costs = item[1];
                string amon = item[3];
              //  iniConnection();

               // connection.Close();
                try
                    {
                    connection.CreateCommand();
                }
                catch(System.NullReferenceException)
                {
                    MessageBox.Show("First connect to the database");
                    break;
                }
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO orders (id,name,amo,price) VALUES (?id,?name,?amo,?cost)"; //adds  
                command.Parameters.AddWithValue("?id", cheeck());
                command.Parameters.AddWithValue("?name", names);
                command.Parameters.AddWithValue("?amo", amon);
                command.Parameters.AddWithValue("?cost", costs);
                connection.Open();
                command.ExecuteNonQuery();
               
                connection.Close();
            }
            listBox1.Items.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            CloseConnection();
            listBox2.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
            catch(System.IndexOutOfRangeException)
            {
                MessageBox.Show("Please select item to remove");
            }
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string itemss = listBox2.SelectedItem.ToString();
            string[] item = itemss.Split(' ');
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM orders WHERE id = " + item[0], connection);
            cmd.ExecuteNonQuery();
            CloseConnection();

        }
        private int cheeck()
        {
            
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(id) FROM orders ", connection);
            string a = cmd.ExecuteScalar().ToString();
            try
            {
                int id = Int32.Parse(a) + 1;
                CloseConnection();
                return id;
            }
            catch
            {
                int id = 1;
                CloseConnection();
                return id;
            }
        }

        private bool IsNumeric(string num)
        {
            int output;
            return Int32.TryParse(num, out output);
        }
    }

}




