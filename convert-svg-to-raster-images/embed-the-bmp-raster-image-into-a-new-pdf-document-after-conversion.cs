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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\sample.bmp";
            string outputPath = @"C:\Temp\sample.pdf";

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
                PdfOptions pdfOptions = new PdfOptions();

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
 * 1. When a developer needs to embed a legacy BMP raster graphic into a PDF report for client delivery using Aspose.Imaging in C# without manual conversion.
 * 2. When an automated batch job must convert scanned BMP images from a legacy system into PDF files for archiving, leveraging Aspose.Imaging's PdfOptions.
 * 3. When a web service generates PDF invoices that include company logos stored as BMP files, requiring on‑the‑fly conversion with Aspose.Imaging in .NET.
 * 4. When a desktop application prepares printable PDFs from user‑uploaded BMP screenshots for documentation, using C# and Aspose.Imaging to preserve image fidelity.
 * 5. When a migration script moves image assets from a file system into PDF portfolios, employing Aspose.Imaging to load BMP files and save them as PDFs.
 */