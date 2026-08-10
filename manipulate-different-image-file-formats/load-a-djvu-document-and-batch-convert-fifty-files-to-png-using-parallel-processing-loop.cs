// HOW-TO: Batch Convert Multiple DjVu Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\DjvuInput";
        string outputDir = @"C:\PngOutput";

        // Prepare list of 50 input file paths
        var inputFiles = new List<string>();
        for (int i = 1; i <= 50; i++)
        {
            inputFiles.Add(Path.Combine(inputDir, $"file{i}.djvu"));
        }

        try
        {
            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu document
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                    {
                        // Iterate through pages (most DjVu files have a single page)
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            // Build output file name based on original file name and page number
                            string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputFileName = $"{baseFileName}.{page.PageNumber}.png";
                            string outputPath = Path.Combine(outputDir, outputFileName);

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as PNG
                            page.Save(outputPath, new PngOptions());
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly generate PNG previews of a large collection of DjVu documents for a web gallery.
 * 2. When an archival system must transform thousands of scanned DjVu pages into PNG thumbnails using multithreading to reduce processing time.
 * 3. When a document‑management workflow requires converting each page of multiple DjVu files into separate PNG images for OCR preprocessing.
 * 4. When a desktop utility must batch‑process user‑uploaded DjVu files and save each page as a PNG while preserving the original file names.
 * 5. When a cloud service automates the conversion of DjVu reports into PNG format for compatibility with downstream image analysis tools.
 */
