using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

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
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context with the same dimensions as the BMP
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Create a pen with a dash pattern (stroke dash array)
                var dashPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 5 }; // 5 units dash, 5 units gap

                // Draw a rectangle around the image using the dashed pen
                graphics.DrawRectangle(dashPen, 0, 0, width, height);

                // Finalize the SVG image and save it
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
 * 1. When a developer needs to embed a legacy BMP photograph into a web‑ready SVG file and add a dashed border for branding or visual emphasis.
 * 2. When an application must convert scanned BMP assets into scalable SVG graphics for responsive UI layouts while preserving exact dimensions and DPI.
 * 3. When a reporting tool generates vector‑based PDFs and requires BMP charts to be wrapped in SVG with a custom stroke dash array for consistent styling across formats.
 * 4. When a GIS system imports raster map tiles in BMP and creates SVG overlays with dashed outlines to highlight selected regions.
 * 5. When an e‑learning platform automates the creation of SVG diagrams from BMP illustrations, adding a dashed rectangle to indicate interactive hotspots.
 */