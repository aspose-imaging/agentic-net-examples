// HOW-TO: Apply Grayscale Filter to PNG Image and Save with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\sample.png";
            string outputPath = @"c:\temp\sample.grayscale.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image, apply grayscale, and save the result
            using (PngImage pngImage = new PngImage(inputPath))
            {
                pngImage.Grayscale();               // Convert to grayscale
                pngImage.Save(outputPath);          // Save the processed image
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert color PNG graphics to grayscale for a print‑ready PDF workflow in a C# application.
 * 2. When you want to preprocess user‑uploaded PNG photos to a single‑channel format before storing them in a database.
 * 3. When you are generating grayscale icons from original PNG assets for a dark‑mode UI using Aspose.Imaging.
 * 4. When you must prepare PNG images for OCR engines that require a grayscale input in a .NET service.
 * 5. When you are creating low‑contrast PNG placeholders for performance testing of web pages in C#.
 */
