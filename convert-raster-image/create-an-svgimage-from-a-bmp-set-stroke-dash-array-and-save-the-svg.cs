// HOW-TO: Create SVG from BMP with Dashed Border Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                // Create an SVG graphics context with the same dimensions as the BMP
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Create a pen with a dash pattern (5 units dash, 3 units gap)
                var dashPen = new Pen(Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 3 };

                // Draw a dashed rectangle around the image
                graphics.DrawRectangle(dashPen, 0, 0, width, height);

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Ensure the output directory exists
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
 * 1. When you need to embed a raster BMP into a scalable SVG for responsive web graphics while adding a custom dashed outline.
 * 2. When generating vector assets from legacy bitmap logos and you want to programmatically apply a stroke dash pattern for branding consistency.
 * 3. When automating batch conversion of BMP files to SVG format in a C# application and require a visual border to highlight each image.
 * 4. When creating printable SVG diagrams from bitmap screenshots and need a dashed rectangle to indicate selection or focus area.
 * 5. When building a reporting tool that converts scanned BMP images to SVG and adds a stylized border to separate sections in the final document.
 */
