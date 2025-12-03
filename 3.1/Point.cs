using System;

namespace Points
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Конструктор с параметрами
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Конструктор копирования (копирует другую точку)
        public Point(Point p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }

        // Проверка совпадения координат двух точек
        public bool IsHit(Point p)
        {
            return this.X == p.X && this.Y == p.Y;
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }
}
