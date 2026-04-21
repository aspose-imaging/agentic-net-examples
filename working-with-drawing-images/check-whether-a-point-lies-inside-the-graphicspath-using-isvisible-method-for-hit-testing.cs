using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the input image
        using (Image image = Image.Load(inputPath))
        {
            // Create a graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Build a GraphicsPath containing a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 100f, 100f)));
            path.AddFigure(figure);

            // Test a point for containment within the path
            float testX = 50f;
            float testY = 50f;
            bool isInside = path.IsVisible(testX, testY);
            Console.WriteLine($"Point ({testX}, {testY}) inside path: {isInside}");

            // Draw the path for visual verification
            graphics.DrawPath(new Pen(Color.Blue, 2), path);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}