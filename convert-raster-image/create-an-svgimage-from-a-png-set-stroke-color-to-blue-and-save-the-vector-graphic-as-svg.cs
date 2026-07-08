using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PNG path
            string inputPath = @"C:\Images\source.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output SVG path
            string outputPath = @"C:\Images\result.svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Determine dimensions for the SVG canvas
                int width = rasterImage.Width;
                int height = rasterImage.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Set a blue stroke (pen) for drawing operations
                Pen bluePen = new Pen(Color.Blue, 1);

                // Optionally draw a blue rectangle border around the image
                graphics.DrawRectangle(bluePen, 0, 0, width, height);

                // Draw the raster PNG onto the SVG canvas
                graphics.DrawImage((RasterImage)rasterImage, new Point(0, 0), new Size(width, height));

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
 * 1. When a web developer uses Aspose.Imaging for .NET to convert a product PNG into a scalable SVG with a blue border for responsive design.
 * 2. When an e‑learning platform leverages C# and Aspose.Imaging to embed a PNG diagram as a vector graphic with a blue outline that matches the brand palette.
 * 3. When a reporting tool written in C# transforms chart PNGs into SVG files with a blue stroke so they can be printed at any resolution without pixelation.
 * 4. When a mobile app creates custom icons from PNG assets, adds a blue rectangular frame using Aspose.Imaging, and saves them as SVG for high‑DPI screens.
 * 5. When an automated batch job in .NET converts legacy PNG logos into SVG files with a consistent blue border for corporate branding guidelines.
 */