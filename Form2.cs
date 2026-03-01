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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form9
{
    public partial class Form2 : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Кадровый_состав.accdb";
        private OleDbConnection myConnection;

        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Surname = textBox2.Text;
            string Name = textBox3.Text;
            string Otestvo = textBox4.Text;
            int Position = Convert.ToInt32(textBox5.Text);
            string query = "INSERT INTO Сотрудники ([Кодсотрудника], Фамилия, Имя, Отчество, [КодДолжности]) VALUES " + "(" + kod + ",'" + Surname + "', '" + Name + "', '" + Otestvo + "', " + Position + ")";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Сотрудник добавлен");

        }
    }
}
