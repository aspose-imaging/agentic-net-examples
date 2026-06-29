using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Work only with raster images
                if (image is not RasterImage rasterImage)
                {
                    Console.Error.WriteLine("Input image is not a raster image.");
                    return;
                }

                // Create a graphics object for drawing
                Graphics graphics = new Graphics(rasterImage);

                // Build a simple graphics path (a rectangle)
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                path.AddFigure(figure);

                // Widen the path by 3 pixels using a thick pen (for hit testing)
                Pen widenPen = new Pen(Color.Black, 3);
                path.Widen(widenPen);

                // Draw the widened path (optional visual verification)
                Pen drawPen = new Pen(Color.Red, 1);
                graphics.DrawPath(drawPen, path);

                // Save the modified image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to enlarge the clickable area around a rectangle in a PNG image to make mouse hit‑testing more forgiving in a C# desktop application.
 * 2. When creating a custom image annotation tool that must draw a clearly visible selection border on high‑resolution raster images such as PNG or JPEG.
 * 3. When implementing collision detection between vector shapes and raster graphics, a developer can widen the path by three pixels to add a tolerance buffer before performing hit testing.
 * 4. When preparing a region of interest for OCR or barcode scanning, widening the path ensures marginal pixels are included so the recognition engine does not miss faint edges.
 * 5. When generating printable output from a PNG and needing to meet minimum line‑weight standards, a developer can use the Widen method with a thick Pen to thicken thin lines before saving the image.
 */