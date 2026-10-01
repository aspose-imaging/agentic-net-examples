// HOW-TO: Batch Convert BMP Images to PDF with Sequential Naming in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchBmpToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputBmp";
                string outputDirectory = @"C:\OutputPdf";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                int counter = 1;
                foreach (string bmpPath in bmpFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(bmpPath))
                    {
                        Console.Error.WriteLine($"File not found: {bmpPath}");
                        return;
                    }

                    // Prepare output file path with sequential numeric suffix
                    string outputPath = Path.Combine(outputDirectory, $"output_{counter}.pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load BMP and save as PDF
                    using (Image image = Image.Load(bmpPath))
                    {
                        PdfOptions pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically turn a folder of scanned BMP pictures into PDF documents for archiving, assigning each PDF a unique numeric filename.
 * 2. When a desktop application must generate separate PDF reports from multiple BMP charts and ensure the files are ordered by a sequential counter.
 * 3. When a batch processing script has to convert legacy BMP assets to PDF for a document management system while preserving a predictable naming scheme.
 * 4. When an automated build pipeline requires converting BMP icons to PDF files for inclusion in a PDF portfolio, using incremental filenames to avoid overwrites.
 * 5. When a user wants to migrate a collection of BMP graphics to PDF format on Windows, creating a new output folder and naming each file like output_1.pdf, output_2.pdf, etc.
 */
