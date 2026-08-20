// HOW-TO: Convert BMP Image to PDF Document Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample.pdf";

            // Verify that the input BMP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the image as a PDF document
                bmpImage.Save(outputPath, pdfOptions);
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
 * 1. When a desktop application needs to embed a legacy BMP graphic into a printable PDF report, this code converts the raster image to a PDF page.
 * 2. When an automated workflow must archive scanned BMP files as searchable PDF documents for compliance, the snippet performs the conversion in C#.
 * 3. When a web service receives BMP uploads and must return them as PDF thumbnails for preview, the code shows how to generate the PDF on the fly.
 * 4. When a migration script moves image assets from a file system into a PDF‑based catalog, this example demonstrates the BMP‑to‑PDF conversion using Aspose.Imaging.
 * 5. When a Windows service creates PDF invoices that include company logos stored as BMP files, the snippet provides the necessary conversion step.
 */
