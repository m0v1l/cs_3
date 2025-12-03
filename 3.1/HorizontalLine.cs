using System;

namespace Points
{
    public class HorizontalLine : Figure
    {
        private int xLeft;
        private int xRight;
        private int y;

        public HorizontalLine(int xLeft, int xRight, int y, char symbol) : base(symbol)
        {
            this.xLeft = xLeft;
            this.xRight = xRight;
            this.y = y;
        }

        public override void Draw()
        {
            for (int x = xLeft; x <= xRight; x++)
            {
                if (x < 0 || y < 0) continue;
                try
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(symbol);
                }
                catch
                {
                    // Игнорируем ошибки установки курсора
                }
            }
        }

        // Проверка попадания точки на горизонтальную линию
        public override bool IsHit(Point p)
        {
            return p.Y == this.y && p.X >= this.xLeft && p.X <= this.xRight;
        }

        // Проверка пересечения с другой фигурой
        public override bool IsHit(Figure figure)
        {
            if (figure is VerticalLine vLine)
            {
                // Горизонтальная линия пересекается с вертикальной, если:
                // вертикальная линия находится в диапазоне X горизонтальной
                // и горизонтальная находится в диапазоне Y вертикальной
                return vLine.IsHitByHorizontal(this.xLeft, this.xRight, this.y);
            }
            return false;
        }

        // Вспомогательный метод для проверки пересечения с горизонтальной линией
        public bool IsHitByVertical(int x, int yTop, int yBottom)
        {
            return this.y >= yTop && this.y <= yBottom && x >= this.xLeft && x <= this.xRight;
        }
    }
}
