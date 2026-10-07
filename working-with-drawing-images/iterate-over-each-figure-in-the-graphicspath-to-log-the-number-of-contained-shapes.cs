// HOW-TO: How to Count Shapes in Each Figure of a GraphicsPath in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output\\result.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create a GraphicsPath and add a Figure with a RectangleShape
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            RectangleShape rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(10, 10, 100, 50));
            figure.AddShape(rectShape);

            graphicsPath.AddFigure(figure);

            // Iterate over each Figure and log the number of contained shapes
            foreach (Aspose.Imaging.Figure fig in graphicsPath.Figures)
            {
                int shapeCount = fig.Shapes.Count();
                Console.WriteLine($"Figure has {shapeCount} shape(s).");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify how many vector shapes are stored in each figure of a drawing before exporting it to PDF using Aspose.Imaging.
 * 2. When debugging a complex graphics path to ensure that all expected shapes (rectangles, ellipses, etc.) have been added to each figure.
 * 3. When generating a report that lists the shape count per figure for automated quality checks in a C# image processing pipeline.
 * 4. When dynamically adjusting rendering settings based on the number of shapes inside a figure, such as applying different compression levels.
 * 5. When logging shape statistics for auditing purposes in a server‑side application that processes user‑uploaded vector images.
 */
