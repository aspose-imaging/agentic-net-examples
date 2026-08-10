// HOW-TO: Convert ODG File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display OpenDocument graphics on a website that only supports PNG images.
 * 2. When a desktop application must convert user‑uploaded ODG drawings to PNG thumbnails for preview.
 * 3. When an automated report generator transforms ODG diagrams into PNG files for inclusion in PDF documents.
 * 4. When a migration script rewrites legacy ODG assets into PNG format to reduce dependency on OpenDocument viewers.
 * 5. When a cloud service processes ODG files and returns PNG images to client applications via an API.
 */
