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
    public partial class Form2 : Form
    {
        int k = 0;
        Form1 form = new Form1(0);
        bestWay best = new bestWay(8);
        PictureBox pictureBox1 = new PictureBox();
        results item;
        public Form2()
        {
            this.item = bestWay.res;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ArrayList p = new ArrayList();
            best.fillTable();
            best.fillTableCustom();
            best.showTable();
            best.best(best.setStartEnd(), p, "");
            best.bestWayFinder();
            
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.item = bestWay.res;
            pictureBox1.Size = new System.Drawing.Size(this.item.n * 40+4, this.item.n * 40+5);
            int[,] loc = new int[item.n, item.n];
            if (k > 0)
            {
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
            int s = 0; int l = 0;
            for (int i = 0; i < item.n; i++)
                for (int j = 0; j < item.n; j++)
                {
                    
                    Way.X = 10+ j * 40;
                    Way.Y = 13+  i * 40;
                    Way.Size = new Size(20, 20);
                    
                    Rc.X = 4+ j * 40;
                    Rc.Y = 5+ i * 40;
                    Rc.Size = new Size(35, 35);
                    if (loc[i, j] == 2)
                    {

                        e.Graphics.FillRectangle(WhiteBrush, Rc);
                        e.Graphics.FillRectangle(BlueBrush, Way);
                        
                        if (s+1 == i)
                        {
                            Pen Pn = new Pen(Color.FromArgb(255, 0, 0, 0));
                            e.Graphics.DrawLine(Pn, Way.X, Way.Y+10, Way.X+20, Way.Y + 10);
                        }
                        if (l+1 == j)
                        {
                            Pen Pn = new Pen(Color.FromArgb(255, 0, 0, 0));
                            e.Graphics.DrawLine(Pn, Way.X+10, Way.Y, Way.X+10, Way.Y + 20);
                        }
                        s = i; l = j;
                        
                    }
                    else if (loc[i, j] == 1)
                    {
                        e.Graphics.FillRectangle(WhiteBrush, Rc);
                        e.Graphics.FillRectangle(GreenBrush, Way);

                        if (s+1 == i)
                        {
                            Pen Pn = new Pen(Color.FromArgb(255, 0, 0, 0));
                            e.Graphics.DrawLine(Pn, Way.X, Way.Y + 10, Way.X + 20, Way.Y + 10);
                        }
                        if (l+1 == j)
                        {
                            Pen Pn = new Pen(Color.FromArgb(255, 0, 0, 0));
                            e.Graphics.DrawLine(Pn, Way.X + 10, Way.Y, Way.X + 10, Way.Y + 20);
                        }
                        s = i; l = j;
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
            k++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Dispose();
            pictureBox1 = new PictureBox();
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.Location = new System.Drawing.Point(413, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(515, 437);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += PictureBox1_Paint; ;
            Controls.Add(pictureBox1);
            
        }
    }
}
