using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\source.tif";
        string outputPath = @"C:\temp\output.png";

        // Input existence check – do not throw, just report and continue
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
        }

        // Ensure the output directory exists before saving
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare image: load if it exists, otherwise create a new blank PNG
        Image image;
        if (File.Exists(inputPath))
        {
            image = Image.Load(inputPath);
        }
        else
        {
            var pngOptions = new PngOptions();               // create options for a PNG image
            image = Image.Create(pngOptions, 500, 500);      // 500×500 pixels canvas
        }

        // Use a using block to guarantee disposal
        using (image)
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Optional: clear the canvas to a light background color
            graphics.Clear(Color.LightGray);

            // Build a graphics path containing a rectangle and an ellipse
            var path = new GraphicsPath();

            var figure = new Figure { IsClosed = true };
            // Rectangle at (50,50) with width 200 and height 150
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse inside a rectangle at (150,120) with width 200 and height 150
            figure.AddShape(new EllipseShape(new RectangleF(150f, 120f, 200f, 150f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Fill the interior of the path with a semi‑transparent blue brush
            var fillBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
            graphics.FillPath(fillBrush, path);

            // Stroke the outline with a thick red pen
            var pen = new Pen(Color.Red, 5);
            graphics.DrawPath(pen, path);

            // Save the resulting image to the output path
            image.Save(outputPath);
        }
    }
}