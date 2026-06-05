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
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Desired output dimensions
                int targetWidth = 800;
                int targetHeight = 600;

                // Configure rasterization options with custom size
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(targetWidth, targetHeight),
                    BackgroundColor = Color.White
                };

                // Set PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rendered PNG image
                svgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos as 800×600 PNG files for display in a product catalog.
 * 2. When an automated build pipeline must convert vector icons stored as SVG into raster PNG assets of specific size for inclusion in a mobile app’s resource bundle.
 * 3. When a reporting service has to embed high‑resolution PNG charts derived from SVG diagrams into PDF invoices, requiring precise width and height control.
 * 4. When a desktop utility processes a batch of SVG floor‑plan files and outputs them as white‑background PNG images sized to fit a predefined print layout.
 * 5. When a content management system needs to render SVG illustrations to PNG on the fly, ensuring the output matches the exact pixel dimensions required by a responsive web page.
 */