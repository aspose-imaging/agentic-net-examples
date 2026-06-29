using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the BMP image onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0), new Size(width, height));

                // Draw a green outline around the image
                var greenPen = new Pen(Color.Green, 1);
                graphics.DrawRectangle(greenPen, 0, 0, width, height);

                using (SvgImage svg = graphics.EndRecording())
                {
                    svg.Save(outputPath);
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
 * 1. When a developer needs to convert legacy BMP assets into scalable SVG files with a green border for responsive web design.
 * 2. When an application must generate vector graphics from raster screenshots and highlight them with a green outline for documentation purposes.
 * 3. When a reporting tool requires embedding BMP images as SVG with consistent green stroke styling to match corporate branding.
 * 4. When an automated batch process has to transform a folder of BMP icons into SVG format and add a green rectangle to indicate selection state.
 * 5. When a C# service creates printable SVG diagrams from BMP drawings and uses a green pen to delineate the image boundaries for visual clarity.
 */