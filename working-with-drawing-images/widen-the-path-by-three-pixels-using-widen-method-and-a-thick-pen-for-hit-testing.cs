using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png; // For PNG support if needed

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Build a simple GraphicsPath (a rectangle in this example)
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            path.AddFigure(figure);

            // Widen the path by 3 pixels using a thick pen (used for hit testing)
            Pen widenPen = new Pen(Aspose.Imaging.Color.Black, 3);
            path.Widen(widenPen);

            // Optionally draw the widened path to visualize the result
            graphics.DrawPath(new Pen(Aspose.Imaging.Color.Red, 1), path);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}