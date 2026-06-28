using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save the image as PDF
                webPImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to embed a WebP image into a printable PDF report generated from a C# .NET application using Aspose.Imaging.
 * 2. When an e‑commerce platform must convert product photos stored as WebP files into PDF catalogs for offline distribution.
 * 3. When a content management system automates the archival of WebP graphics by saving them as PDF documents for compliance and long‑term storage.
 * 4. When a mobile app backend processes user‑uploaded WebP screenshots and creates PDF receipts to email to customers.
 * 5. When a Windows service runs a batch job that converts a folder of WebP assets into PDF files for easy sharing with stakeholders.
 */