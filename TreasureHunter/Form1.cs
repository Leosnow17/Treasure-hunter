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
        public Form1()
        {
            InitializeComponent();
            hunterImg = new Bitmap("C:\\Users\\Leosnow\\Desktop\\Hero.png");
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(Keyboard);
            this.KeyUp += new KeyEventHandler(FreeKey);
        }

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
                    break;
                case "A":
                    curAnimation = 1;
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
            else
            {
                Image part = new Bitmap(60, 96);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(hunterImg, 0, 0, new Rectangle(new Point(120, 0),
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
