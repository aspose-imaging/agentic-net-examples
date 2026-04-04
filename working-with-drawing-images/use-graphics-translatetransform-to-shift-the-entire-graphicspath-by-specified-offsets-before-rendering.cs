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
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the input image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached) image.CacheData();

            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath with a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            path.AddFigure(figure);

            // Apply translation to shift the entire path
            graphics.TranslateTransform(100f, 50f);

            // Draw the translated path
            graphics.DrawPath(new Pen(Color.Blue, 3), path);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}