// HOW-TO: Convert Multi‑Page TIFF to Lossless APNG in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = "input.tif";
            string outputPath = "output.apng";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG; PNG compression is lossless by default
                image.Save(outputPath, new ApngOptions());
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
 * 1. When you need to display a scanned document as an animated image on a website without losing any detail, you can convert the multi‑page TIFF into a lossless APNG using C# and Aspose.Imaging.
 * 2. When creating a product catalog that includes high‑resolution page‑by‑page previews, converting the TIFF pages to an APNG ensures smooth animation while preserving original image quality.
 * 3. When archiving medical imaging records that are stored as multi‑page TIFFs, generating a lossless APNG allows easy playback in browsers while maintaining diagnostic fidelity.
 * 4. When developing a desktop application that shows step‑by‑step tutorials from a multi‑page TIFF, converting to APNG provides a lightweight, animated format that retains all pixel data.
 * 5. When preparing animated graphics for mobile apps from multi‑page TIFF source files, using C# to produce a lossless APNG keeps the file size reasonable and ensures crisp visuals on high‑density screens.
 */
