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
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Build a GraphicsPath covering the whole image
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
            path.AddFigure(figure);

            // Create a semi‑transparent red SolidBrush
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                brush.Opacity = 0.5f; // 50% opacity
                // Fill the path with the brush (overlay effect)
                graphics.FillPath(brush, path);
            }

            // Save the modified image as PNG
            PngOptions saveOptions = new PngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}