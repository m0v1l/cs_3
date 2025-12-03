using System;

namespace Points
{
    public abstract class Figure
    {
        protected char symbol;

        public Figure(char symbol)
        {
            this.symbol = symbol;
        }

        // Абстрактный метод для проверки попадания точки в фигуру
        public abstract bool IsHit(Point p);

        // Проверка пересечения с другой фигурой
        // Реализуется переопределением в подклассах (по-умолчанию возвращает false)
        public virtual bool IsHit(Figure figure)
        {
            return false;
        }

        // Абстрактный метод рисования
        public abstract void Draw();
    }
}
