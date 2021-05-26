using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreasureHunter.Entities;
using TreasureHunter1._1.Controllers;

namespace TreasureHunter1._1.Controllers
{
    public static class PhysicsController
    {
        public static bool IsCollide(Entity entity, Point dir)
        {
            for (int i = 0; i < MapController.mapObjects.Count; i++)
            {
                var currObject = MapController.mapObjects[i];
                PointF delta = new PointF();
                delta.X = (entity.posX + entity.heroSizeX / 2) - (currObject.position.X + currObject.size.Width / 2);
                delta.Y = (entity.posY + entity.heroSizeY / 2) - (currObject.position.Y + currObject.size.Height / 2);
                if (Math.Abs(delta.X) <= entity.heroSizeX / 2 + currObject.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= entity.heroSizeY / 2 + currObject.size.Height / 2)
                    {
                        if (delta.X < 0 && dir.X == 1)
                        {
                            return true;
                        }
                        if (delta.X > 0 && dir.X == -1)
                        {
                            return true;
                        }
                        if (delta.Y < 0 && dir.Y == 1)
                        {
                            return true;
                        }
                        if (delta.Y > 0 && dir.Y == -1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
