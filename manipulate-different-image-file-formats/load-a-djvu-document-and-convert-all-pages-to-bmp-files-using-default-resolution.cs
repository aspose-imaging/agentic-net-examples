// HOW-TO: Convert All DjVu Pages To BMP Images In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\sample.djvu";
            string outputDirectory = @"C:\temp\output\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file name
                        string outputPath = Path.Combine(outputDirectory,
                            $"sample.{djvuPage.PageNumber}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as BMP using default resolution
                        djvuPage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract each page of a multi‑page DjVu file as separate BMP files for legacy Windows applications.
 * 2. When you want to batch‑process scanned documents stored in DjVu format and generate bitmap images for OCR preprocessing.
 * 3. When a printing workflow requires converting DjVu pages to BMP because the downstream printer driver only accepts BMP input.
 * 4. When you are building a document viewer that must display DjVu content on systems that only support BMP rendering.
 * 5. When you need to archive DjVu pages as lossless BMP files to preserve image quality before further image analysis.
 */
