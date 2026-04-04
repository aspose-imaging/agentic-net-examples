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
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Build a clipping region using a rectangle shape
            GraphicsPath clipPath = new GraphicsPath();
            Figure clipFigure = new Figure();
            clipFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            clipPath.AddFigure(clipFigure);

            // Apply the clipping region
            graphics.Clip = new Region(clipPath);

            // Draw a diagonal red line; only the part inside the clip will appear
            graphics.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(image.Width, image.Height));

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}