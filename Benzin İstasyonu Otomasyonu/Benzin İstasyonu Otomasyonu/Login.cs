using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzin_İstasyonu_Otomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Personel Obj = new Personel();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-N9LKLML\SQLEXPRESS;Initial Catalog=BenzinIstasyonu;Integrated Security=True");
        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik Bigi Girdiniz");
            }else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from StaffTbl where StName = '"+textBox1.Text+"' and StPass = '"+textBox2.Text+"'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    UserName = textBox1.Text;
                    AnaSayfa obj = new AnaSayfa();
                    obj.Show();
                    this.Hide();
                    Con.Close();
                }else
                {
                    MessageBox.Show("Yanlış Ad ya da Şifre");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                Con.Close();
            }
        }
    }
}
