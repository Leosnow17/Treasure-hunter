using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureHunter1._1.Entities;

namespace TreasureHunter1._1.Controllers
{
    public static class MapController
    {
        public const int mapHeight = 20;
        public const int mapWidth = 20;
        public static int cellSize = 40;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image mapImg;
        public static List<MapEntity> mapObjects;

        public static void Init()
        {
            map = GetMap();
            mapImg = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Forest.png"));
            mapObjects = new List<MapEntity>();
        }
        public static int[,] GetMap()
        {
            return new int[,]
            {
                { 3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,4 },
                { 7,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8 },
                { 6,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5 },
            };
        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 0)
                    {
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 610, 131, 27, 22, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                }
            }
        }
        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 0)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 1)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 3)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 4)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 5)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 6)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 2)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 7)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 8)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);
                    else if (map[i, j] == 9)
                        g.DrawImage(mapImg, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                }
            }

            SeedMap(g);
        }

        public static int GetWidth() => cellSize * mapWidth + 16;
        public static int GetHeight() => cellSize * (mapHeight + 1) - 1;
    }
}
