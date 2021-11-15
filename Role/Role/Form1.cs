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

namespace Role
{
    public partial class Form1 : Form
    {
        MyConnection db = new MyConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (db.con)
                {
                    SqlCommand cmd = new SqlCommand("sp_role_login", db.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    db.con.Open();
                    cmd.Parameters.AddWithValue("@uname", txtuser.Text);
                    cmd.Parameters.AddWithValue("@upass", txtpass.Text);
                  
                    SqlDataReader rd = cmd.ExecuteReader();
                    if(rd.HasRows)
                    {
                        rd.Read();
                        if(rd[3].ToString()=="Admin")
                        {
                            MyConnection.type = "A";
                        }
                        else if (rd[3].ToString() == "User")
                        {
                            MyConnection.type = "U";
                        }
                        MessageBox.Show("Welcome " + txtuser.Text);

                        Dashboard d = new Dashboard();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
             
        }
    }
}
