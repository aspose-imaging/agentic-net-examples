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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Save as animated APNG with infinite looping (NumPlays = 0)
                var apngOptions = new ApngOptions
                {
                    NumPlays = 0 // 0 indicates infinite looping
                };

                tiffImage.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to convert scanned multi‑page TIFF documents into a single animated APNG for web galleries that require infinite looping playback.
 * 2. When an application must generate lightweight, lossless animations from multi‑frame medical imaging TIFFs for embedding in electronic health records.
 * 3. When a reporting tool has to transform multi‑page TIFF charts into an animated APNG that continuously loops on a dashboard without user interaction.
 * 4. When a mobile app needs to display a series of product photos stored as a multi‑page TIFF as an endlessly looping animation to attract shoppers.
 * 5. When a developer wants to automate the creation of infinite‑loop animated PNGs from archival TIFF scans for inclusion in interactive e‑learning modules.
 */