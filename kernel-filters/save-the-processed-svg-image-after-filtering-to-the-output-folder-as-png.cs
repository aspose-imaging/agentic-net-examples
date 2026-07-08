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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to convert user‑uploaded SVG icons to PNG thumbnails for display on browsers that do not support SVG.
 * 2. When an automated build pipeline must generate PNG assets from vector logos stored as SVG files for inclusion in mobile app resources.
 * 3. When a reporting tool has to embed high‑resolution PNG charts that were originally designed in SVG format into PDF documents.
 * 4. When a desktop utility processes a batch of SVG diagrams and saves them as PNG images to a shared network folder for non‑technical stakeholders.
 * 5. When a content management system converts SVG illustrations to PNG format on the fly to ensure compatibility with older email clients.
 */