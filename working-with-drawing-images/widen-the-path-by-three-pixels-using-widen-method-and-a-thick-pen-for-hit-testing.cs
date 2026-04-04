using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas (optional)
            graphics.Clear(Color.White);

            // Create a GraphicsPath and add a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            path.AddFigure(figure);

            // Draw the original path with a thin black pen
            graphics.DrawPath(new Pen(Color.Black, 1), path);

            // Widen the path by 3 pixels using a thick pen (for hit testing)
            Pen widenPen = new Pen(Color.Red, 3);
            path.Widen(widenPen);

            // Draw the widened path with a blue pen to visualize the result
            graphics.DrawPath(new Pen(Color.Blue, 1), path);

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}