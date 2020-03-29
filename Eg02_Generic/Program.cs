using System;
using static System.Console;

namespace Eg02_Generic
{
    class Program
    {
        static void GenericBasic()
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));

            dm.DisplayAllDocuments();

            if (dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                WriteLine(d.Content);
            }
        }

        static void CovariantAndContravariant()
        {
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;
            for (int i = 0; i < shapes.Count; i++)
            {
                WriteLine(shapes[i]);
            }

            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(rectangles[0]);
        }

        static void Main(string[] args)
        {
            GenericBasic();
            CovariantAndContravariant();
        }
    }
}