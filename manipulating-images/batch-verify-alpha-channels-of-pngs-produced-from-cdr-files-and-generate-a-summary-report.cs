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
            // Hardcoded input folder containing PNGs generated from CDR files
            string inputFolder = @"C:\Temp\CdrPngs";
            // Hardcoded output report file path
            string outputReport = @"C:\Temp\AlphaReport.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputReport));

            using (StreamWriter writer = new StreamWriter(outputReport, false))
            {
                writer.WriteLine("FileName,HasAlpha");

                // Retrieve all PNG files recursively
                string[] pngFiles = Directory.GetFiles(inputFolder, "*.png", SearchOption.AllDirectories);
                foreach (string pngPath in pngFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        continue;
                    }

                    bool hasAlpha = false;
                    // Load the image and check the alpha channel
                    using (Image img = Image.Load(pngPath))
                    {
                        // All raster images (including PNG) expose HasAlpha
                        if (img is RasterImage rasterImg)
                        {
                            hasAlpha = rasterImg.HasAlpha;
                        }
                    }

                    string fileName = Path.GetFileName(pngPath);
                    writer.WriteLine($"{fileName},{hasAlpha}");
                }
            }

            Console.WriteLine($"Alpha channel verification completed. Report saved to {outputReport}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphics pipeline converts CorelDRAW (CDR) files to PNGs and needs to ensure every exported image contains an alpha channel for proper transparency handling, this batch verification code can automatically check each file and produce a CSV‑style report.
 * 2. When a QA team validates a large set of marketing assets generated from CDR sources to confirm they meet web‑ready PNG specifications, they can run this C# script to flag images lacking an alpha channel before publishing.
 * 3. When a CI/CD build process includes image asset generation from CDR files, developers can integrate this code to automatically audit the output PNGs for alpha transparency and log the results for build verification.
 * 4. When a digital signage system imports PNGs derived from CDR designs and requires transparent backgrounds, the script helps identify which files need re‑exporting by summarizing the presence of alpha channels.
 * 5. When a freelance designer exports multiple CDR illustrations to PNG and wants a quick summary of which files preserve transparency, they can use this Aspose.Imaging‑based utility to generate an easy‑to‑read report.
 */