// HOW-TO: Create SVG from PNG with Linear Gradient Fill in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image to obtain its dimensions
            using (RasterImage pngImage = (RasterImage)Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                // Create an SVG graphics canvas with the same size as the PNG
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, 96);

                // Draw the PNG onto the SVG canvas
                graphics.DrawImage(pngImage, new Point(0, 0), new Size(width, height));

                // Create a pen for the rectangle outline
                Pen outlinePen = new Pen(Color.Black, 1);

                // Create a linear gradient brush (red to blue) covering the whole canvas
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new RectangleF(0, 0, width, height),
                    Color.Red,
                    Color.Blue,
                    0); // 0 = horizontal gradient (mode value)

                // Fill a rectangle with the gradient brush
                graphics.FillRectangle(outlinePen, gradientBrush, 0, 0, width, height);

                // Finalize and save the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    svgImage.Save(outputPath);
                }
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
 * 1. When you need to convert a raster PNG into a scalable SVG while preserving the original dimensions for responsive web graphics.
 * 2. When you want to overlay a full‑canvas linear gradient on an image to create a colored fade effect in vector format.
 * 3. When generating SVG assets for print or UI design that require both the original bitmap content and a gradient background.
 * 4. When automating batch processing of PNG files to SVG with consistent gradient styling using C# and Aspose.Imaging.
 * 5. When integrating vector graphics with gradient fills into a .NET application that manipulates images programmatically.
 */
