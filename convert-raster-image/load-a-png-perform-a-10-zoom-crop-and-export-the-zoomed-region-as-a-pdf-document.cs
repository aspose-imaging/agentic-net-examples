// HOW-TO: Export Center 10 Percent Crop Of PNG As PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate a central rectangle that is 10 % of the original size
                int cropWidth = (int)(image.Width * 0.10);
                int cropHeight = (int)(image.Height * 0.10);
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var bounds = new Rectangle(left, top, cropWidth, cropHeight);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save only the cropped region to a PDF file
                image.Save(outputPath, pdfOptions, bounds);
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
 * 1. When you need to generate a PDF preview that shows only the central portion of a high‑resolution PNG, such as a logo or artwork thumbnail.
 * 2. When creating printable reports that require embedding a zoomed‑in section of a PNG image without scaling the entire file.
 * 3. When extracting a focused area from a scanned PNG document to share as a lightweight PDF for review.
 * 4. When automating the production of PDF assets that contain a specific 10 % region of product images for marketing catalogs.
 * 5. When building a web service that returns a PDF containing the central crop of user‑uploaded PNGs for compliance or watermarking purposes.
 */
