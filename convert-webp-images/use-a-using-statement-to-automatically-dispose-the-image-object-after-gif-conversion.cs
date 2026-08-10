// HOW-TO: Convert GIF to PNG with Automatic Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image; the using statement disposes it automatically
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default PNG options
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a GIF file to a PNG image in a C# application while ensuring the Image object is released automatically to prevent memory leaks.
 * 2. When building a server‑side image processing service that receives GIF uploads and stores them as PNGs for faster delivery.
 * 3. When creating a desktop utility that batch‑converts user‑selected GIFs to PNGs and must clean up resources after each conversion.
 * 4. When integrating Aspose.Imaging into a .NET workflow that transforms animated GIFs into static PNGs for inclusion in PDF reports.
 * 5. When developing a background job that processes temporary GIF files and saves the results as PNGs, using a using block to guarantee proper disposal even on errors.
 */
