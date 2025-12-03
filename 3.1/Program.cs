using System;
using Points;

namespace Points
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.CursorVisible = false;

                // ===== ЧАСТЬ 1: Тесты с точками =====
                Console.WriteLine("=== Тест 1: Две одинаковые точки ===");
                Point p1 = new Point(5, 10);
                Point p2 = new Point(p1);  // Копируем p1
                Console.WriteLine($"p1: {p1}");
                Console.WriteLine($"p2 (копия p1): {p2}");

                // Проверка IsHit на одной из точек с другой точкой
                bool hitResult1 = p1.IsHit(p2);
                Console.WriteLine($"p1.IsHit(p2) = {hitResult1}");  // Должно быть true
                Console.WriteLine();

                // ===== ЧАСТЬ 2: Изменение координаты =====
                Console.WriteLine("=== Тест 2: Изменение координаты ===");
                p2.X = 10;  // Меняем X координату
                Console.WriteLine($"После изменения p2.X на 10: {p2}");
                bool hitResult2 = p1.IsHit(p2);
                Console.WriteLine($"p1.IsHit(p2) = {hitResult2}");  // Должно быть false
                Console.WriteLine();

                // ===== ЧАСТЬ 3: Две линии с пересечением =====
                Console.WriteLine("=== Тест 3: Пересечение линий ===");
                HorizontalLine h = new HorizontalLine(5, 15, 5, '*');
                VerticalLine v = new VerticalLine(10, 2, 8, '*');
                
                Console.WriteLine("Рисуем горизонтальную линию (y=5, x=5..15):");
                h.Draw();
                Console.WriteLine();
                
                Console.WriteLine("Рисуем вертикальную линию (x=10, y=2..8):");
                v.Draw();
                Console.WriteLine();

                // Проверка пересечения
                bool intersects = h.IsHit(v);
                Console.WriteLine($"h.IsHit(v) (пересекаются ли?) = {intersects}");  // Должно быть true
                Console.WriteLine();

                // ===== ДОП. ТЕСТ: точка на линиях =====
                Console.WriteLine("=== Доп. тест: Попадание точки на линии ===");
                Point pOnH = new Point(10, 5);  // На пересечении
                Point pNotOnH = new Point(10, 4);  // Не на линии
                
                Console.WriteLine($"pOnH: {pOnH}");
                Console.WriteLine($"h.IsHit(pOnH) = {h.IsHit(pOnH)}");  // true
                
                Console.WriteLine($"pNotOnH: {pNotOnH}");
                Console.WriteLine($"h.IsHit(pNotOnH) = {h.IsHit(pNotOnH)}");  // false
                Console.WriteLine();

                // Переместим курсор ниже всего вывода
                try { Console.SetCursorPosition(0, 20); } catch { }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                try { Console.CursorVisible = true; } catch { }
                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                try { Console.ReadKey(true); } catch { }
            }
        }
    }
}
