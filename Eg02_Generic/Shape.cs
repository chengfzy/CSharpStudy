using System;

namespace Eg02_Generic
{
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString() => $"Width: {Width}, Height: {Height}";
    }

    public class Rectangle : Shape
    {
    }

    public interface IIndex<out T>
    {
        T this[int index] { get; }
        int Count { get; }
    }

    public class RectangleCollection : IIndex<Rectangle>
    {
        private Rectangle[] _data = new Rectangle[3]
        {
            new Rectangle {Height = 2, Width = 5},
            new Rectangle {Height = 3, Width = 7},
            new Rectangle {Height = 4.5, Width = 2.9}
        };

        private static RectangleCollection _collection;
        public static RectangleCollection GetRectangles() => _collection ??= new RectangleCollection();

        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index > _data.Length)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _data[index];
            }
        }

        public int Count => _data.Length;
    }

    public interface IDisplay<in T>
    {
        void Show(T item);
    }

    public class ShapeDisplay : IDisplay<Shape>
    {
        public void Show(Shape s) =>
            System.Console.WriteLine($"{s.GetType().Name} Width: {s.Width}, Height: {s.Height}");
    }
}