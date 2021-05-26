using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunter.Entities
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;

        public int flip;

        public int curAnimation;
        public int curFrame;
        public int curLimit;

        public int idleFrames;
        public int runFrames;
        public int attackFrames;

        public int heroSizeX;
        public int heroSizeY;

        public Image sprites;

        public Entity(int posX, int posY, int idleFrames, int runFrames, int attackFrames, Image sprites)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.sprites = sprites;
            heroSizeX = 60;
            heroSizeY = 96;
            curAnimation = 0;
            curFrame = 2;
            curLimit = idleFrames;
            flip = 1;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (curFrame < curLimit - 1)
                curFrame++;
            else
                curFrame = 0;

            g.DrawImage(sprites, new Rectangle(new Point(posX - flip*heroSizeX/2, posY), new Size(flip*heroSizeX, heroSizeY)), 60*curFrame, 96*curAnimation, heroSizeX, heroSizeY, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfig(int curAnimation)
        {
            this.curAnimation = curAnimation;

            switch(curAnimation)
            {
                case 0:
                    curLimit = runFrames;
                    break;
                case 2:
                    curLimit = idleFrames;
                    break;
                case 3:
                    curLimit = attackFrames;
                    break;
            }
        }
    }
}
