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

namespace TVDatabaseForm1
{
    public partial class Form1 : Form
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source='G:\SUMMER2020\TVDatabaseForm1\TVDatabaseA2.accdb'";
        public Form1()
        {
            InitializeComponent();
        }

        private void addEntry_btn_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                string id = id_txtbx.Text;
                string title = title_txtbx.Text;
                int year = int.Parse(yr_txtbx.Text);
                string genre = genre_txtbx.Text;
                int minutes = int.Parse(time_txtbx.Text);
                string rate = rating_txtbx.Text;
/*
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = InsertMovie(id, title, year, genre, minutes, rate);
                    cmd.ExecuteNonQuery();
                }

                string InsertMovie(string id, string title, int year, string genre, int minutes, string rate)
                {
                    return string.Format("INSERT INTO Movies VALUES ('{0}', '{1}', {2}, '{3}', {4}, '{5}');",
                                        id, title, year, genre, minutes, rate);
                }
            }

*/
            OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO Movies VALUES ('{0}', '{1}', {2}, '{3}', {4}, '{5}');", 
                    id, title, year, genre, minutes, rate);
                cmd.ExecuteNonQuery();
            }
        }

        private void showEntries_btn_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbCommand cmdA = conn.CreateCommand();
                cmdA.CommandText = "SELECT * FROM Movies;";
                using (OleDbDataReader myDReader = cmdA.ExecuteReader())
                {
                    dt1.Load(myDReader);
                    dataGridView1.DataSource = dt1;
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            id_txtbx.Text = "";
            title_txtbx.Text = "";
            yr_txtbx.Text = "";
            genre_txtbx.Text = "";
            time_txtbx.Text = "";
            rating_txtbx.Text = "";
        }
    }
}
