using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load raster image
            using (Aspose.Imaging.Image loadedImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = loadedImage as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                // Create SVG graphics canvas
                var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Set background color to white
                    svgImage.BackgroundColor = Aspose.Imaging.Color.White;

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
 * 1. When a developer needs to convert user‑uploaded PNG screenshots into scalable SVG files for responsive web pages while ensuring a consistent white background.
 * 2. When an automated report generator must embed high‑resolution raster charts as vector graphics in PDF or HTML output, using Aspose.Imaging to draw the PNG onto an SVG canvas.
 * 3. When a desktop application has to batch‑process product photos, turning each raster image into a lightweight SVG thumbnail with a white background for faster loading in e‑commerce catalogs.
 * 4. When a migration script converts legacy bitmap assets stored in PNG format to SVG for a design system, preserving the original dimensions and DPI using C# and Aspose.Imaging.
 * 5. When a CI/CD pipeline validates image assets by rendering them onto an SVG surface and saving the result, allowing visual diff tools to compare vector versions of raster sources.
 */