// HOW-TO: Extract All Pages From DjVu And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Log total number of pages
                    Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                    // Iterate through each page and save as PNG
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file name based on page number
                        string outputFileName = $"sample.{djvuPage.PageNumber}.png";
                        string outputPath = Path.Combine(@"c:\temp\", outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        djvuPage.Save(outputPath, new PngOptions());
                        Console.WriteLine($"Saved page {djvuPage.PageNumber} to {outputPath}");
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
 * 1. When you need to batch‑convert a multi‑page DjVu document into individual PNG images for web preview.
 * 2. When you must programmatically determine how many pages a DjVu file contains before processing.
 * 3. When you want to automate the extraction of each DjVu page to PNG for OCR or further image analysis.
 * 4. When you need to ensure the output folder exists and save each page with a clear naming convention.
 * 5. When you are handling DjVu files in a .NET application and want robust error handling around file I/O and conversion.
 */
