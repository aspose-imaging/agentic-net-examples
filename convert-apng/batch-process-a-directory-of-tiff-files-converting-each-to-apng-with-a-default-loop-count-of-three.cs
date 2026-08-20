// HOW-TO: Batch Convert TIFF Files to Animated PNG with Loop Count in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string tiffFilePath in tiffFiles)
            {
                // Build input and output paths
                string inputPath = tiffFilePath;
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(tiffFilePath) + ".png");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as APNG with 3 loops
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions
                    {
                        NumPlays = 3 // default loop count
                    };
                    image.Save(outputPath, apngOptions);
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
 * 1. When you need to automatically turn a collection of scanned TIFF pages into looping animated PNGs for web galleries.
 * 2. When a reporting system generates multi‑page TIFF charts and you want to display them as short looping animations in a dashboard.
 * 3. When migrating legacy TIFF assets to a modern format that supports animation and you require a fixed three‑loop playback for consistency.
 * 4. When building a batch image‑processing tool that processes all TIFF files in a folder and outputs APNG files ready for mobile apps.
 * 5. When integrating Aspose.Imaging into a C# service that must convert incoming TIFF uploads to animated PNGs with a predefined loop count.
 */
