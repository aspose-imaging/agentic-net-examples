// HOW-TO: Fill a Rectangle Path with Solid Color on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear the canvas (optional)
                graphics.Clear(Aspose.Imaging.Color.White);

                // Build a path consisting of a single rectangle figure
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 400f, 300f)));
                path.AddFigure(figure);

                // Create a brush for filling the path.
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.LightBlue;
                    brush.Opacity = 100;

                    // Fill the path with the brush
                    graphics.FillPath(brush, path);
                }

                // Save the modified image
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to overlay a solid‑colored rectangle onto an existing PNG image in a C# application.
 * 2. When generating a watermark or background shape programmatically using Aspose.Imaging’s Graphics.FillPath method.
 * 3. When creating custom UI thumbnails that require a colored rectangle highlight on top of a source image.
 * 4. When preprocessing images for reports and you must fill a defined area with a specific color before saving as PNG.
 * 5. When automating batch image editing to add a light‑blue banner or panel to multiple PNG files using C#.
 */
