using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreasureHunter
{
    public partial class Form1 : Form
    {
        Image hunterImg;
        private int curFrame = 0;
        private int curAnimation = 0;
        private bool keyWasPressed = false;
        //private string lastMove;
        public Form1()
        {
            InitializeComponent();
            hunterImg = new Bitmap("Hero.png");
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            //timer2.Interval = 10;
            //timer2.Tick += new EventHandler(UpdateMove);
            //timer2.Start();
            this.KeyDown += new KeyEventHandler(Keyboard);
            this.KeyUp += new KeyEventHandler(FreeKey);
        }

        //private void UpdateMove(object sender, EventArgs e)
        //{
        //    var move = lastMove;
        //    if (move == "D")
        //    {
        //        pictureBox1.Location = new Point(pictureBox1.Location.X + 4, pictureBox1.Location.Y);
        //    }
        //    else if (move == "A")
        //    {
        //        pictureBox1.Location = new Point(pictureBox1.Location.X - 4, pictureBox1.Location.Y);
        //    }
        //    else if (move == "W")
        //    {
        //        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 4);
        //    }
        //    else if (move == "S")
        //    {
        //        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 4);
        //    }
        //}

        private void FreeKey(object sender, KeyEventArgs e)
        {
            keyWasPressed = false;
        }

        private void Keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    curAnimation = 0;
                    //lastMove = "D";
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 4, pictureBox1.Location.Y);
                    break;
                case "A":
                    curAnimation = 1;
                    //lastMove = "A";
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 4, pictureBox1.Location.Y);
                    break;
                case "W":
                    //lastMove = "W";
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 4);
                    break;
                case "S":
                    //lastMove = "S";
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 4);
                    break;
            }
            if (e.KeyCode.ToString() == "W" 
                || e.KeyCode.ToString() == "A" 
                || e.KeyCode.ToString() == "S" 
                || e.KeyCode.ToString() == "D")
                keyWasPressed = true;
        }

        private void Update(object sender, EventArgs e)
        {
            if(keyWasPressed)
                PlayHunterAnimation();
            else if (curAnimation == 0)
            {
                Image part = new Bitmap(60, 96);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(hunterImg, 0, 0, new Rectangle(new Point(120, 0),
                    new Size(60, 96)), GraphicsUnit.Pixel);
                pictureBox1.Image = part;
            }
            else
            {
                Image part = new Bitmap(60, 96);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(hunterImg, 0, 0, new Rectangle(new Point(180, 96),
                    new Size(60, 96)), GraphicsUnit.Pixel);
                pictureBox1.Image = part;
            }
            if (curFrame == 5)
                curFrame = 0;
            curFrame++;
        }

        private void PlayHunterAnimation()
        {
            Image part = new Bitmap(60, 96);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(hunterImg, 0, 0, new Rectangle(new Point(60 * curFrame, 96*curAnimation),
                new Size(60, 96)), GraphicsUnit.Pixel);
            pictureBox1.Image = part;
        }
    }
}
