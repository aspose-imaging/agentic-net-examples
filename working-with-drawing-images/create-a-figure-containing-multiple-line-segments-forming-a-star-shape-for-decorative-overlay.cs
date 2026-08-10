// HOW-TO: Draw a 5‑point Star Overlay on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

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
            using (Image image = Image.Load(inputPath))
            {
                // Create graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a graphics path to hold the figure
                GraphicsPath graphicPath = new GraphicsPath();

                // Create a figure that will contain the star shape
                Figure starFigure = new Figure();

                // Define points for a 5‑point star
                PointF[] starPoints = new PointF[]
                {
                    new PointF(250f, 50f),   // top point
                    new PointF(300f, 200f),
                    new PointF(450f, 200f),
                    new PointF(330f, 300f),
                    new PointF(380f, 450f),
                    new PointF(250f, 350f),
                    new PointF(120f, 450f),
                    new PointF(170f, 300f),
                    new PointF(50f, 200f),
                    new PointF(200f, 200f)
                };

                // Add a closed polygon shape (the star) to the figure
                starFigure.AddShape(new PolygonShape(starPoints, true));

                // Add the figure to the graphics path
                graphicPath.AddFigure(starFigure);

                // Draw the path with a red pen
                graphics.DrawPath(new Pen(Aspose.Imaging.Color.Red, 3), graphicPath);

                // Save the modified image to the output path
                image.Save(outputPath);
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
 * 1. When you need to add a decorative star watermark to a BMP photo before publishing it online.
 * 2. When you want to generate custom badge icons by drawing geometric figures directly onto raster images in a C# application.
 * 3. When you are building a game UI and must overlay a star‑shaped marker onto background textures at runtime.
 * 4. When you have to programmatically create printable certificates that include a star‑shaped seal on top of scanned templates.
 * 5. When you need to batch‑process a folder of bitmap assets to add a consistent star‑shaped highlight for branding purposes.
 */
