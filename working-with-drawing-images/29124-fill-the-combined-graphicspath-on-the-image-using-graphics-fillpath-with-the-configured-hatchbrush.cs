using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input\sample.png";
        string outputPath = @"output\result.png";

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

            // Configure a SolidBrush
            using (SolidBrush solidBrush = new SolidBrush(Color.LightGray))
            {
                // Create a graphics path and add a figure with shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));
                // Add an ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));

                // Add the figure to the path
                path.AddFigure(figure);

                // Fill the combined path using the configured SolidBrush
                graphics.FillPath(solidBrush, path);
            }

            // Save the modified image
            image.Save(outputPath);
        }
    }
}