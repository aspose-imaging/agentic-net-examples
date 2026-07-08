using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Define central 400x400 crop rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (raster.Width - cropWidth) / 2;
                int top = (raster.Height - cropHeight) / 2;
                Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);

                // Perform cropping
                raster.Crop(cropRect);

                // Create an empty SVG canvas with the cropped dimensions
                using (SvgImage svg = new SvgImage(raster.Width, raster.Height))
                {
                    // Draw the raster image onto the SVG canvas
                    Graphics graphics = new Graphics(svg);
                    graphics.DrawImage(raster, new Point(0, 0));

                    // Save the result as SVG
                    svg.Save(outputPath, new SvgOptions());
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
 * 1. When creating responsive web graphics, a developer can use this code to extract a 400 × 400 central portion of a high‑resolution PNG and convert it to a lightweight SVG for scalable display.
 * 2. When generating printable icons from a large PNG sprite sheet, the snippet crops the required 400 × 400 icon and saves it as an SVG so it can be resized without loss of quality.
 * 3. When building an automated asset pipeline for a mobile app, the routine trims the central area of each PNG screenshot and transforms it into an SVG vector that reduces app bundle size.
 * 4. When preparing marketing materials, a designer can run this C# code to isolate the focal 400 × 400 region of a product photo in PNG format and output it as an SVG for easy editing in vector tools.
 * 5. When integrating with a GIS system that requires vector overlays, the program crops a central 400 × 400 tile from a raster PNG map and converts it to SVG for overlay rendering.
 */