using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bersenham_Algorithm
{
    public class Arrays_Sample
    {
        public int x = 0;
        public int y = 0;
        public int Ps = 0;
        public Arrays_Sample(int X, int Y, int PS)
        {
            x = X; y = Y; Ps = PS;
        }
        public Arrays_Sample()
        { }
    }
    public partial class Form1 : Form
    {
        public static bool Revese_ = false;
        public static System.Collections.Generic.List<Arrays_Sample> arrays_Samples = new List<Arrays_Sample>();
        int x1 = 20;
        int y1 = 10;
        //============
        int x2 = 60;
        int y2 = 58;
        //============
        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            box.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 30);
            box.Size = new Size(150,50);
            box.Text = "Reverse the line now...";
            box.Font = new Font("Lucida Sans Unicode", 15.0f);
            box.CheckStateChanged += Box_CheckStateChanged;
            Controls.Add(box);
            /////////////////////////////////////////////////////////////////////////////
            box_x1.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 90);
            box_x1.Size = new Size(100, 70);
            box_x1.Text = "X 1 Value";
            box_x1.Font = new Font("Lucida Sans Unicode", 10.0f);
            Controls.Add(box_x1);
            /////////////////////
            box_x2.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 120);
            box_x2.Size = new Size(100, 70);
            box_x2.Text = "X 2 Value";
            box_x2.Font = new Font("Lucida Sans Unicode", 10.0f);
            Controls.Add(box_x2);
            ////////////////////
            box_y1.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 170);
            box_y1.Size = new Size(100, 70);
            box_y1.Text = "Y 1 Value";
            box_y1.Font = new Font("Lucida Sans Unicode", 10.0f);
            Controls.Add(box_y1);
            ////////////////////
            box_y2.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 200);
            box_y2.Size = new Size(100, 70);
            box_y2.Text = "Y 1 Value";
            box_y2.Font = new Font("Lucida Sans Unicode", 10.0f);
            Controls.Add(box_y2);
            ////////////////////
            Button button = new Button();
            button.Location = new Point(Screen.FromControl(this).Bounds.Width - 200, 260);
            button.Size = new Size(100, 90);
            button.Text = "Calculate again ...";
            button.BackColor = Color.Green; button.ForeColor = Color.White;
            button.Click += new System.EventHandler((x, y) => { if (int.Parse(box_x1.Text) != int.Parse(box_x2.Text)) { x1 = int.Parse(box_x1.Text); x2 = int.Parse(box_x2.Text); y1 = int.Parse(box_y1.Text); y2 = int.Parse(box_y2.Text); this.Invalidate(); } else { MessageBox.Show("Should not have same x1 x2 values.... hey.... ","Info",MessageBoxButtons.OK,MessageBoxIcon.Information); } });
            Controls.Add(button);
            InitializeComponent();
        }
        private void Box_CheckStateChanged(object sender, System.EventArgs e)
        {
            if (Revese_ == false)
            {
                Revese_ = true;
            }
            else
            {
                Revese_ = false;
            }
            try
            {
                Form1.ActiveForm.Invalidate();
            }
            catch (System.Exception) { }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int Max_X = 0;
            int Min_X = 0;

            float rep_start_x = 0;
            float rep_start_y = 0;
            bool isX1 = false;
            //===========

            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 8.0f);

            //==========
            if (x1 < x2 && Revese_ == false)
            {
                rep_start_x = x1;
                rep_start_y = y1;
                isX1 = true;
                Max_X = x2;
                Min_X = x1;
            }
            else if (x2 < x1 && Revese_ == false)
            {
                isX1 = false;
                rep_start_x = x2;
                rep_start_y = y2;
                Max_X = x1;
                Min_X = x2;
            }
            else if (x1 == x2) { rep_start_x = x1; rep_start_y = y1; }
            //====================================
            //===========================
            //====================================

            if (x1 > x2 && Revese_ == true)
            {
                rep_start_x = x1;
                rep_start_y = y1;
                isX1 = true;
                Max_X = x1; Min_X = x2;
            }
            else if (x1 < x2 && Revese_ == true)
            {
                isX1 = false;
                rep_start_x = x2;
                rep_start_y = y2;
                Max_X = x2; Min_X = x1;
            }
            arrays_Samples.Clear();

            //Ends here the first step draw

            int P = (2 * (y2 - y1)) - (x2 - x1);

            #region main_Process
            int temp = 0;
            while (temp != (Max_X - Min_X))
            {
                if (P < 0)
                {
                    if(Revese_ == false)
                    rep_start_x += 1;
                    else
                    rep_start_x -= 1;
                    P = P + (2 * (y2 - y1));
                    arrays_Samples.Add(new Arrays_Sample((int)rep_start_x, (int)rep_start_y, P));
                    temp++;
                }
                if (P >= 0)
                {
                    if(Revese_ == false) { 
                    rep_start_x += 1;
                    rep_start_y += 1;
                    }
                    else
                    {
                        rep_start_x -= 1;
                        rep_start_y -= 1;
                    }
                    P = P + ((2 * (y2 - y1)) - (2 * (x2 - x1)));
                    arrays_Samples.Add(new Arrays_Sample((int)rep_start_x, (int)rep_start_y, P));
                    temp += 1;
                }
            }
            bool IS_first = true;
            Arrays_Sample Point1 = arrays_Samples[0];
            // if (Revese_ == false)
            //{ 
                if (IS_first == true && isX1 == true)
                {
                    graphics.DrawLine(new Pen(Color.Purple, 40.0f), x1, y1, Point1.x, Point1.y);
                    IS_first = false;
                }
                else if (isX1 == false && IS_first == true)
                {
                    graphics.DrawLine(new Pen(Color.Purple, 40.0f), x2, y2, Point1.x, Point1.y);
                    IS_first = false;
                }
                for (int i = 1; i < arrays_Samples.Count - 1;)
                {
                    Arrays_Sample temp1_ = arrays_Samples[i];
                    Arrays_Sample temp2_ = arrays_Samples[++i];
                    graphics.DrawLine(pen, temp1_.x, temp1_.y, temp2_.x, temp2_.y);
                }
            //}
            /*
            else if(Revese_ == true)
            {
                if (IS_first == true && isX1 == true)
                {
                    graphics.DrawLine(new Pen(Color.Purple, 20.0f), x1, y1, Point1.x, Point1.y);
                    IS_first = false;
                }
                else if (isX1 == false && IS_first == true)
                {
                    graphics.DrawLine(new Pen(Color.Purple, 20.0f), x2, y2, Point1.x, Point1.y);
                    IS_first = false;
                }

                for (int i = 1; i < arrays_Samples.Count - 1;)
                {
                    Arrays_Sample temp1_ = arrays_Samples[i];
                    Arrays_Sample temp2_ = arrays_Samples[++i];
                    graphics.DrawLine(pen, temp1_.x, temp1_.y, temp2_.x, temp2_.y);
                }
            }
            */
            #endregion
        }
    }
    public partial class Form1
    {
        CheckBox box = new CheckBox();
        TextBox box_x1 = new TextBox();
        TextBox box_x2 = new TextBox();
        TextBox box_y1 = new TextBox();
        TextBox box_y2 = new TextBox();
    }
}
