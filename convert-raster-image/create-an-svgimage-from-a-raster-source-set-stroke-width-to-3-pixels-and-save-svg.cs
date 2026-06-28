using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input raster image and output SVG paths
            string inputPath = "C:\\temp\\source.png";
            string outputPath = "C:\\temp\\result.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image rasterImage = Image.Load(inputPath))
            {
                int width = rasterImage.Width;
                int height = rasterImage.Height;
                int dpi = 96; // Standard screen DPI

                // Create an SVG graphics context with the same dimensions
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Set stroke width to 3 pixels using a pen
                Pen pen = new Pen(Color.Black, 3);

                // Draw a rectangle border around the entire image area
                graphics.DrawRectangle(pen, 0, 0, width, height);

                // Finalize SVG recording and obtain the SvgImage
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
 * 1. When a developer needs to convert a PNG icon into a scalable SVG file with a 3‑pixel black border for responsive web layouts, this code creates the vector outline directly from the raster source.
 * 2. When an image‑processing service must generate SVG placeholders that preserve the original image dimensions and add a uniform stroke for UI mockups, the snippet records the raster size and saves the SVG with the specified pen width.
 * 3. When a reporting tool requires embedding raster charts inside SVG diagrams while ensuring a consistent 3‑pixel border for visual emphasis, this C# example produces the SVG wrapper using Aspose.Imaging.
 * 4. When a desktop application automates the creation of printable SVG assets from scanned PNG files and needs a precise stroke thickness to meet branding guidelines, the code records the raster dimensions and applies the required pen width.
 * 5. When a batch conversion utility must generate SVG files from a folder of PNG images and add a standard border for downstream vector editing, this program demonstrates the end‑to‑end process of loading, drawing, and saving the SVG.
 */