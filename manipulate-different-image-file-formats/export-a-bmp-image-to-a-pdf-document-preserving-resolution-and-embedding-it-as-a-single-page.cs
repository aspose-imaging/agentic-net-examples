// HOW-TO: Convert BMP Image to Single‑Page PDF Preserving Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Preserve the original image resolution
                    UseOriginalImageResolution = true
                };

                // Save the image as a single‑page PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed a high‑resolution bitmap into a PDF report without losing detail.
 * 2. When generating printable PDFs from scanned BMP files for archival or distribution.
 * 3. When converting legacy BMP assets to PDF for inclusion in a document workflow that only accepts PDF.
 * 4. When creating a single‑page PDF thumbnail from a BMP to share with clients while keeping original resolution.
 * 5. When automating batch processing of BMP images to PDF for compliance with electronic filing standards.
 */
