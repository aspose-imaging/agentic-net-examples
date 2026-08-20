// HOW-TO: Resize WMF to 800x800 PNG in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

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

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Resize to 800x800 pixels (using default nearest‑neighbour resampling)
                wmfImage.Resize(800, 800);

                // Save the resized image as PNG
                wmfImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate web‑ready thumbnails from legacy WMF vector graphics by resizing them to 800 × 800 PNG using Aspose.Imaging in C#.
 * 2. When an automated report generator must convert and resize WMF logos to a fixed 800 × 800 PNG for email attachments with Aspose.Imaging.
 * 3. When a batch processing script has to standardize the dimensions of WMF icons to 800 × 800 PNG before uploading them to cloud storage using Aspose.Imaging.
 * 4. When a desktop application requires converting user‑provided WMF drawings into 800 × 800 PNG images for printing, leveraging Aspose.Imaging in C#.
 * 5. When a migration tool moves old WMF assets to modern PNG format while ensuring each image fits an 800‑pixel square layout with Aspose.Imaging.
 */
