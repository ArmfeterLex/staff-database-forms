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
    public partial class Form1 : Form

    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Кадровый_состав.accdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.кадровый_составDataSet.Сотрудники);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Сотрудники WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о сотруднике удалены");
            this.сотрудникиTableAdapter.Fill(this.кадровый_составDataSet.Сотрудники);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.кадровый_составDataSet.Сотрудники);
        }
    }
}
