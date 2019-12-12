using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace minefield_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList mine = new ArrayList();
        void DoMine(ArrayList arr, int min, int max, int cnt)
        {
            Random rnd = new Random();

            for (int i = 0; arr.Count < cnt; i++)
            {
                int sayi = rnd.Next(min, max + 1);
                if (!mine.Contains(sayi))
                {
                    mine.Add(sayi);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MineField";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            panel1.Controls.Clear();
            mine.Clear();
            button2.Enabled = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            button3.Enabled = true;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Width = 35;
                    btn.Height = 35;
                    btn.Top = i * 35;
                    btn.Left = j * 35;
                    btn.Text = ((i * 10) + (j + 1)).ToString();
                    btn.Click += Btn_Click;
                    panel1.Controls.Add(btn);
                }
            }
            DoMine(mine, 1, 100, 10);

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (mine.Contains(Convert.ToInt32(b.Text)))
            {
                b.BackColor = Color.Red;
                MessageBox.Show("You lost. Try Again \nScore : " + label1.Text);
                button2.Enabled = true;
                b.Enabled = false;
            }
            else
            {
                b.BackColor = Color.Green;
                label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
                b.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mine.Sort();
            foreach (object item in mine)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int a = r.Next(0, mine.Count-1);

            if (!listBox2.Items.Contains(mine[a]))
            {
                listBox2.Items.Add(mine[a]);
                label1.Text = (Convert.ToInt32(label1.Text) - 1).ToString();

                
            }

            if (listBox2.Items.Count == mine.Count)
            {
                button3.Enabled = false;
                MessageBox.Show("Skorunuz : " + label1.Text);
            }
        }
    }
}
