// HOW-TO: Create SVG from BMP with Dashed Line Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                // Create SVG graphics canvas
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Create a pen with a dash pattern
                Pen dashedPen = new Pen(Aspose.Imaging.Color.Black, 2);
                dashedPen.DashPattern = new float[] { 5, 5 }; // 5 units dash, 5 units gap

                // Draw a diagonal dashed line
                graphics.DrawLine(dashedPen, 0, 0, width, height);

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to embed a bitmap into an SVG for scalable web graphics while adding custom dashed annotations.
 * 2. When you want to generate vector‑based diagrams from raster images programmatically in a C# application.
 * 3. When you must overlay measurement lines or guides with dash patterns on an SVG that contains a raster background.
 * 4. When you are converting legacy BMP assets to SVG format to reduce file size and enable resolution‑independent rendering.
 * 5. When you require automated creation of SVG files with specific stroke styles for printing or reporting pipelines.
 */
