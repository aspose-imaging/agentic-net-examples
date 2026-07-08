using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

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
                // Resize to half of the original dimensions
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

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
 * 1. When a developer needs to generate lightweight vector previews of legacy BMP assets for web pages by halving their size and converting them to SVG.
 * 2. When an application must batch‑process scanned BMP documents, reduce their resolution to save bandwidth, and store the result as scalable SVG files for responsive UI rendering.
 * 3. When a desktop tool has to create thumbnail‑style SVG icons from high‑resolution BMP graphics while preserving aspect ratio using Aspose.Imaging in C#.
 * 4. When a reporting system requires converting large BMP charts into smaller, resolution‑independent SVG diagrams to embed in PDF reports.
 * 5. When a migration script must transform BMP resources in a legacy codebase to half‑size SVG assets for modern mobile apps without losing vector quality.
 */