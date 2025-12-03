using System;

namespace Points
{
    public class VerticalLine : Figure
    {
        private int x;
        private int yTop;
        private int yBottom;

        public VerticalLine(int x, int yTop, int yBottom, char symbol) : base(symbol)
        {
            this.x = x;
            this.yTop = yTop;
            this.yBottom = yBottom;
        }

        public override void Draw()
        {
            for (int y = yTop; y <= yBottom; y++)
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

        // Проверка попадания точки на вертикальную линию
        public override bool IsHit(Point p)
        {
            return p.X == this.x && p.Y >= this.yTop && p.Y <= this.yBottom;
        }

        // Проверка пересечения с другой фигурой
        public override bool IsHit(Figure figure)
        {
            if (figure is HorizontalLine hLine)
            {
                // Вертикальная линия пересекается с горизонтальной, если:
                // горизонтальная линия находится в диапазоне Y вертикальной
                // и вертикальная находится в диапазоне X горизонтальной
                return hLine.IsHitByVertical(this.x, this.yTop, this.yBottom);
            }
            return false;
        }

        // Вспомогательный метод для проверки пересечения с горизонтальной линией
        public bool IsHitByHorizontal(int xLeft, int xRight, int y)
        {
            return this.x >= xLeft && this.x <= xRight && y >= this.yTop && y <= this.yBottom;
        }
    }
}
