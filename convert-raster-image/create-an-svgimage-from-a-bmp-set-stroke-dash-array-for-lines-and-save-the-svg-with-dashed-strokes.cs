// HOW-TO: Create SVG from BMP with Dashed Line Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.svg";

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

            // Load the BMP as a raster image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96; // standard screen DPI

                // Create an SVG graphics context with the same dimensions as the BMP
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0), new Size(width, height));

                // Create a pen with a dash pattern (e.g., 5 units on, 5 units off)
                Pen dashedPen = new Pen(Color.Black, 2);
                dashedPen.DashPattern = new float[] { 5, 5 };

                // Draw a diagonal line using the dashed pen
                graphics.DrawLine(dashedPen, 0, 0, width, height);

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG file
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
 * 1. When you need to convert a raster BMP file into a scalable SVG for web display while adding a custom dashed border around the image.
 * 2. When you want to generate vector graphics from existing bitmap assets and overlay diagnostic or guide lines with dash patterns for documentation purposes.
 * 3. When an application must produce printable SVG diagrams from BMP screenshots and highlight specific diagonals using dashed strokes for emphasis.
 * 4. When integrating Aspose.Imaging in a C# workflow to automate batch conversion of BMP icons into SVG icons with consistent dashed outlines for UI styling.
 * 5. When creating interactive reports that embed BMP images in SVG containers and require programmatic dashed lines to separate sections or indicate measurements.
 */
