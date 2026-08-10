// HOW-TO: Batch Convert CDR Files To JPG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Default input and output directories (hard‑coded)
            string inputFolder = @"C:\InputCdr";
            string outputFolder = @"C:\OutputJpg";

            // Get all CDR files in the input folder
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Ensure the image data is cached (optional but improves performance)
                    cdrImage.CacheData();

                    // Process each page of the CDR document
                    for (int i = 0; i < cdrImage.Pages.Length; i++)
                    {
                        var page = (CdrImagePage)cdrImage.Pages[i];

                        // Build the output JPG file name (one JPG per page)
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + $"_page{i}.jpg";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as JPG using default options
                        page.Save(outputPath, new JpegOptions());
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
 * 1. When you need to convert a collection of CorelDRAW (CDR) design files into JPEGs for web publishing or preview generation.
 * 2. When automating the creation of page‑by‑page JPEG thumbnails from multi‑page CDR documents for a digital asset management system.
 * 3. When migrating legacy CDR artwork to a format compatible with standard image viewers and editors without manual intervention.
 * 4. When generating JPEG versions of CDR files to embed in reports, emails, or content management systems that only support raster images.
 * 5. When building a batch processing tool that processes all CDR files in a folder and saves each page as a separate JPEG using default compression settings.
 */
