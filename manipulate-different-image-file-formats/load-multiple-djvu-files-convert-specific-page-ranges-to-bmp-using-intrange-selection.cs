// HOW-TO: Convert Selected DjVu Pages to BMP in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input files
            string[] inputPaths = {
                @"C:\Images\sample1.djvu",
                @"C:\Images\sample2.djvu"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Converted";

            // Define the page ranges to export (e.g., pages 1‑3 and page 5)
            IntRange[] ranges = {
                new IntRange(1, 3),
                new IntRange(5, 5)
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path (same name with .bmp extension)
                string outputPath = Path.Combine(outputDirectory,
                    $"{Path.GetFileNameWithoutExtension(inputPath)}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Set up BMP options with the desired page ranges
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(ranges)
                    };

                    // Save selected pages as BMP
                    djvuImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract only certain pages from a multi‑page DjVu document and save them as BMP files for legacy Windows applications.
 * 2. When a batch conversion tool must process several DjVu files and generate BMP images for specific page ranges to reduce file size and processing time.
 * 3. When integrating document preview functionality that requires converting selected DjVu pages to BMP thumbnails in a C# web service.
 * 4. When automating archival workflows that involve extracting high‑resolution BMP copies of particular DjVu pages for quality‑controlled printing.
 * 5. When building a migration script that reads DjVu files from a directory, selects pages 1‑3 and 5, and outputs BMP images for downstream image‑analysis pipelines.
 */
