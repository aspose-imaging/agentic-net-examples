using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image canvas
        PngOptions pngOptions = new PngOptions();
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Build a graphics path with several shapes
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 100f, 200f, 200f)));
            // Pie shape
            figure.AddShape(new PieShape(
                new Aspose.Imaging.RectangleF(new Aspose.Imaging.PointF(200f, 200f), new Aspose.Imaging.SizeF(150f, 150f)),
                0f, 90f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path outline with a black pen of width 2
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

            // Save the image to the output file
            image.Save(outputPath, pngOptions);
        }
    }
}