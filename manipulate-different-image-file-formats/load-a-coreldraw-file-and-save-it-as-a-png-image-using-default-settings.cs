// HOW-TO: Convert CorelDRAW CDR File To PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.png";

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

            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Create default PNG save options
                var pngOptions = new PngOptions();

                // Save the image as PNG using the default options
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
 * 1. When you need to generate web‑ready PNG thumbnails from legacy CorelDRAW designs in a .NET application.
 * 2. When automating a batch process that converts customer‑submitted CDR artwork into PNG for preview in a content management system.
 * 3. When integrating Aspose.Imaging into a reporting tool that must embed CorelDRAW graphics as PNG images in PDF reports.
 * 4. When building a server‑side service that receives CDR files via API and returns PNG images for mobile app consumption.
 * 5. When migrating old CDR assets to a modern image format without manually opening each file in CorelDRAW.
 */
