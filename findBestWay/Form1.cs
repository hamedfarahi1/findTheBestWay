using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace findBestWay
{
    public partial class Form1 : Form
    {
        int k = 0;
        bestWay best = new bestWay(8);
        results item;
        public Form1(int k)
        {
            this.k = k;
            this.item = bestWay.res;
            InitializeComponent();
        }

        private void Form1_Paint(object sender,System.Windows.Forms.PaintEventArgs e)
        {
            PaintEventArgs m = e;
            
            button1.Text = item.path;
            int[,] loc = new int[item.n, item.n];
            if (k>0)
            {
                Console.WriteLine(item.Paths[k].ToString());
                for (int i = 0; i < item.Paths[k].ToString().Length - 1; i++)
                {
                    if (i == 0 || i == item.Paths[k].ToString().Length - 2)
                        loc[Convert.ToInt32(new string(item.Paths[k].ToString()[i], 1)), Convert.ToInt32(new string(item.Paths[k].ToString()[i + 1], 1))] = 2;
                    else
                        loc[Convert.ToInt32(new string(item.Paths[k].ToString()[i], 1)), Convert.ToInt32(new string(item.Paths[k].ToString()[i + 1], 1))] = 1;
                    i++;
                }
            }
            else
            {
                for (int i = 0; i < item.path.Length - 1; i++)
                {
                    if (i == 0 || i == item.path.Length - 2)
                        loc[Convert.ToInt32(new string(item.path[i], 1)), Convert.ToInt32(new string(item.path[i + 1], 1))] = 2;
                    else
                        loc[Convert.ToInt32(new string(item.path[i], 1)), Convert.ToInt32(new string(item.path[i + 1], 1))] = 1;
                    i++;
                }
            }
            
        // Draw the rectangle...

            Pen pen = new Pen(Color.Orange);
            Random r = new Random();
            Rectangle Rc = new Rectangle();
            Rectangle Way = new Rectangle();
            SolidBrush BlackBrush = new SolidBrush(Color.Black);
            SolidBrush WhiteBrush = new SolidBrush(Color.White);
            SolidBrush GreenBrush = new SolidBrush(Color.Green);
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);

            for (int i = 0; i < item.n; i++)
                for (int j = 0; j < item.n; j++)
                {
                    
                    Way.X= 105 + j * 40;
                    Way.Y = 155 + i * 40;
                    Way.Size = new Size(30, 30);



                    Rc.X = 100 + j * 40;
                    Rc.Y = 150 + i * 40;
                    Rc.Size = new Size(37, 37);
                    if (loc[i, j] == 2)
                    {
                        e.Graphics.FillRectangle(BlueBrush, Way);
                    }
                    else if (loc[i, j] == 1)
                    {
                        e.Graphics.FillRectangle(GreenBrush, Way);
                    }
                    else if (item.test[i, j] == 0)
                    {
                        e.Graphics.FillRectangle(BlackBrush, Rc);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(WhiteBrush, Rc);
                    }
                }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
