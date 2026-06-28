using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\source.bmp";
        string outputPath = @"C:\Temp\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create SVG graphics with same dimensions as raster image
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // standard screen DPI

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Create a pen with dash pattern for drawing a border
                Pen dashedPen = new Pen(Color.Black, 2);
                // Set dash pattern: 5 units on, 5 units off
                dashedPen.DashPattern = new float[] { 5, 5 };

                // Draw a dashed rectangle around the image bounds
                graphics.DrawRectangle(dashedPen, 0, 0, width, height);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save SVG file
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
 * 1. When a developer needs to convert a BMP screenshot into a scalable SVG file while adding a dashed border for visual emphasis in a web dashboard.
 * 2. When generating printable diagrams from raster scans where the output SVG must retain the original dimensions and include a custom dash pattern around the image edges.
 * 3. When creating SVG assets for responsive UI components that require a consistent 96‑dpi size and a stylized dashed outline to match corporate branding guidelines.
 * 4. When automating the preparation of image assets for PDF reports, converting raster images to SVG and applying a dash array to highlight sections without increasing file size.
 * 5. When building a C# tool that overlays vector graphics on raster photos, using Aspose.Imaging to draw a dashed rectangle and embed the original bitmap into an SVG for interactive web viewers.
 */