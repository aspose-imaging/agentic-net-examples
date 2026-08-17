// HOW-TO: Combine Multiple PSD Files Into a Single PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = {
                @"C:\temp\page1.psd",
                @"C:\temp\page2.psd",
                @"C:\temp\page3.psd"
            };

            // Hardcoded output PDF file
            string outputPath = @"C:\temp\combined.pdf";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load each PSD image
            List<Image> loadedImages = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                loadedImages.Add(img);
            }

            // Create a multipage image from the loaded PSD images
            Image multipageImage = Image.Create(loadedImages.ToArray());

            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);

            // Dispose all images
            multipageImage.Dispose();
            foreach (Image img in loadedImages)
            {
                img.Dispose();
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
 * 1. When you need to merge several Photoshop PSD layers or documents into one multipage PDF report for client review.
 * 2. When generating a printable catalog where each product page is designed in PSD and must be combined into a single PDF file.
 * 3. When automating the creation of a PDF portfolio from a set of PSD artwork files in a batch processing pipeline.
 * 4. When converting a series of PSD mock‑ups into a single PDF presentation to share with stakeholders without requiring Photoshop.
 * 5. When building a server‑side service that receives multiple PSD uploads and returns a combined PDF for download.
 */
