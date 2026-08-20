// HOW-TO: Resize BMP to 1200x1200 and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"C:\Images\resized.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1200x1200 pixels
                image.Resize(1200, 1200);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set the page size to match the resized image dimensions
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the resized image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a desktop application needs to shrink a high‑resolution BMP logo to a standard 1200 × 1200 size and store it as a scalable SVG for UI rendering.
 * 2. When a batch‑processing script must prepare BMP assets for web pages by resizing them and converting them to vector‑compatible SVG files.
 * 3. When an e‑learning platform wants to reduce the file size of BMP diagrams while keeping them editable in SVG format for responsive design.
 * 4. When a reporting tool generates charts as BMP images and then needs to embed them as SVG graphics in PDF or HTML reports.
 * 5. When a migration utility converts legacy BMP icons to 1200 × 1200 SVG icons to support high‑DPI displays in modern .NET applications.
 */
