// HOW-TO: Batch Convert ODG Files to PNG in C# With Aspose Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputOdg";
            string outputFolder = @"C:\OutputPng";

            // Get all ODG files in the input folder
            string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg");

            foreach (string inputPath in odgFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG file path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG save options with rasterization settings
                    var pngOptions = new PngOptions();
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        // Preserve original size
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically generate web‑ready PNG thumbnails from a collection of OpenDocument graphics (ODG) stored in a directory.
 * 2. When a document management system must migrate legacy ODG diagrams to PNG format for compatibility with browsers and mobile apps.
 * 3. When a reporting tool requires batch rasterization of vector ODG charts into PNG images before embedding them into PDF reports.
 * 4. When a CI/CD pipeline has to convert newly added ODG assets to PNG during build time to ensure consistent image assets.
 * 5. When an archival process needs to preserve the visual appearance of ODG files by exporting them as PNG files with a white background.
 */
