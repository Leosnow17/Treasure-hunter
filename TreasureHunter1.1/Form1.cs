using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreasureHunter.Entities;
using TreasureHunter.Models;
using TreasureHunter1._1.Controllers;

namespace TreasureHunter1._1
{
    public partial class Form1 : Form
    {
        public Image hunterImg;
        public Image enemyImg;
        public Entity player;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }

            if (player.dirY == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                player.SetAnimationConfig(2);
            }

        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -4;
                    player.isMoving = true;
                    player.SetAnimationConfig(0);
                    break;
                case Keys.S:
                    player.dirY = 4;
                    player.isMoving = true;
                    player.SetAnimationConfig(0);
                    break;
                case Keys.A:
                    player.dirX = -4;
                    player.isMoving = true;
                    player.flip = -1;
                    player.SetAnimationConfig(0);
                    break;
                case Keys.D:
                    player.dirX = 4;
                    player.isMoving = true;
                    player.flip = 1;
                    player.SetAnimationConfig(0);
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    player.SetAnimationConfig(3);
                    break;
            }
        }

        public void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();
            hunterImg = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Hero.png"));

            player = new Entity(60, 40, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, hunterImg);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            //if (!PhysicsController.IsCollide(player, new Point(player.dirX, player.dirY)))
            //{
            if (player.isMoving)
                player.Move();
            //}

            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            MapController.DrawMap(g);
            player.PlayAnimation(g);
        }
    }
}
