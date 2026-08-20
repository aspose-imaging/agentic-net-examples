// HOW-TO: Batch Convert BMP Files to PDF with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputBmp";
            string outputDirectory = @"C:\OutputPdf";

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Create a unique timestamp prefix
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputFileName = $"{timestamp}_{fileNameWithoutExt}.pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive a large collection of legacy BMP scans as PDF documents while ensuring each PDF has a unique timestamped name to avoid overwriting.
 * 2. When an automated nightly job must transform newly uploaded BMP images from a folder into PDF reports for downstream workflow systems.
 * 3. When a web service receives BMP uploads and must store them as PDF files with a timestamp prefix for audit‑trail compliance.
 * 4. When migrating a digital asset library from BMP to PDF format and you require a quick C# script to batch convert and uniquely name each file.
 * 5. When generating PDF invoices from BMP graphics produced by a third‑party tool, and you need to guarantee unique filenames for each run.
 */
