// HOW-TO: Batch Convert Multiple CDR Files To PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputCdr";
        string outputDirectory = @"C:\OutputPng";

        try
        {
            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through each page of the CDR document
                    for (int pageIndex = 0; pageIndex < cdrImage.PageCount; pageIndex++)
                    {
                        // Retrieve the specific page
                        var page = (CdrImagePage)cdrImage.Pages[pageIndex];

                        // Build the output PNG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set PNG save options (default options are sufficient for basic export)
                        var pngOptions = new PngOptions();

                        // Save the page as PNG
                        page.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to automatically export every page of several CorelDRAW (CDR) documents in a folder to high‑resolution PNG files for web publishing.
 * 2. When a desktop application must generate PNG previews of CDR assets stored on a server without manual conversion.
 * 3. When a build pipeline has to transform a collection of CDR design files into PNG thumbnails for a product catalog.
 * 4. When a migration script has to extract each page of legacy CDR files and save them as PNGs for use in a new .NET‑based imaging system.
 * 5. When an automated reporting tool must batch‑process CDR drawings and output them as PNG images for inclusion in PDF reports.
 */
