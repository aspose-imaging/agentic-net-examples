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
        string inputPath = @"C:\temp\input.jp2";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Create graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Define a graphics path with a figure containing shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Fill the path with a solid green brush
            using (SolidBrush brush = new SolidBrush(Color.Green))
            {
                brush.Opacity = 100;
                graphics.FillPath(brush, path);
            }

            // Save the modified image as JPEG2000
            Jpeg2000Options saveOptions = new Jpeg2000Options();
            image.Save(outputPath, saveOptions);
        }
    }
}