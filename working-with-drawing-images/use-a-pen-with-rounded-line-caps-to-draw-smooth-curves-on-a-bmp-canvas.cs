using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Input file existence check (if you need to load an existing image)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the input BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a Pen with rounded line caps
                Pen pen = new Pen(Color.Blue, 5);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // Build a smooth curve using a cubic Bezier shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                path.AddFigure(figure);

                // Define control points for the Bezier curve
                PointF[] bezierPoints = new PointF[]
                {
                    new PointF(100, 500),   // Start point
                    new PointF(200, 100),   // First control point
                    new PointF(600, 100),   // Second control point
                    new PointF(700, 500)    // End point
                };
                figure.AddShape(new BezierShape(bezierPoints));

                // Draw the path onto the image
                graphics.DrawPath(pen, path);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}