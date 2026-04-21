using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
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

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Create a graphics path
            GraphicsPath path = new GraphicsPath();

            // Create a figure and add a rectangle shape
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Create a semi‑transparent red solid brush
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                brush.Opacity = 0.5f; // 0 = fully visible, 1 = fully opaque

                // Fill the path with the brush
                graphics.FillPath(brush, path);
            }

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}