using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the BMP raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                // Create an SVG graphics context with the same dimensions as the BMP
                SvgGraphics2D graphics = new SvgGraphics2D(rasterImage.Width, rasterImage.Height, 96);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(rasterImage, new Point(0, 0), new Size(rasterImage.Width, rasterImage.Height));

                // Set stroke width for vector paths (example: draw a rectangle border)
                Pen borderPen = new Pen(Color.Black, 5); // Stroke width set to 5
                graphics.DrawRectangle(borderPen, 0, 0, rasterImage.Width, rasterImage.Height);

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the customized SVG
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
 * 1. When a developer needs to convert legacy BMP icons into scalable SVG files with a consistent border for use in responsive web applications.
 * 2. When an automation script must generate vector‑based product labels from raster photographs, adding a 5‑pixel stroke to ensure the edges remain visible at any size.
 * 3. When a desktop application creates printable PDFs and first transforms user‑uploaded BMP drawings into SVG format with a defined outline to preserve line thickness during scaling.
 * 4. When a GIS tool imports bitmap map tiles and exports them as SVG overlays, applying a uniform stroke to highlight tile boundaries in the final vector layer.
 * 5. When a CI/CD pipeline processes UI mockup BMP assets, converting them to SVG with a black border so designers can preview crisp vector assets directly in browsers.
 */