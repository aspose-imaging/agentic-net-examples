using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96; // Standard DPI

                // Create SVG graphics canvas
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Define a custom pen with desired stroke width
                Pen customPen = new Pen(Color.Blue, 5);

                // Draw a rectangle border using the custom pen
                graphics.DrawRectangle(customPen, 0, 0, width, height);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0));

                // Finalize SVG image
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
 * 1. When a developer needs to convert a bitmap (BMP) into a scalable SVG for responsive web graphics while preserving the original raster content.
 * 2. When a developer wants to add a custom blue border with a 5‑pixel stroke around an image before embedding it in an SVG for branding or UI design.
 * 3. When a developer must generate an SVG file from a raster source on the server side in a .NET application, ensuring the output directory exists and handling missing files gracefully.
 * 4. When a developer requires a DPI‑aware SVG canvas (96 DPI) to maintain consistent sizing across different devices when rendering raster images in vector format.
 * 5. When a developer needs to programmatically create an SVG with defined stroke widths using Aspose.Imaging for .NET, then save it as a vector file for further editing in design tools.
 */