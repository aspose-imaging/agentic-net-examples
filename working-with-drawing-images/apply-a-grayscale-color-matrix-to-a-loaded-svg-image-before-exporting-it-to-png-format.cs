using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for SVG -> PNG conversion
                var rasterizationOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized PNG from memory
                    using (PngImage pngImage = (PngImage)Image.Load(memoryStream))
                    {
                        // Apply grayscale conversion
                        pngImage.Grayscale();

                        // Save the final grayscale PNG to disk
                        pngImage.Save(outputPath);
                    }
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
 * 1. When a web application must generate a black‑and‑white preview thumbnail of a user‑uploaded SVG logo for display on a product catalog page.
 * 2. When an automated reporting tool needs to convert vector diagrams stored as SVG into grayscale PNG images to embed in PDF reports that require consistent print‑ready contrast.
 * 3. When a mobile app backend processes SVG icons and creates low‑color‑depth PNG assets for devices that only support grayscale displays.
 * 4. When a document management system archives SVG illustrations as grayscale PNG files to reduce storage size while preserving visual fidelity for archival purposes.
 * 5. When a batch‑processing script applies a grayscale color matrix to SVG graphics before exporting them to PNG for use in a machine‑learning pipeline that expects single‑channel images.
 */