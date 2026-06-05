using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/input.eps";
            string outputPath = "output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new height to keep aspect ratio when width is set to 2000
                int newWidth = 2000;
                int newHeight = (int)((double)image.Height / image.Width * newWidth);

                // Resize using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Prepare PDF options with PDF/A‑1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the resized image as PDF
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
 * 1. When a publishing workflow requires converting high‑resolution EPS artwork to a PDF/A‑1b compliant file of a specific width for archival printing.
 * 2. When an e‑commerce platform needs to generate web‑ready product catalogs by resizing vector EPS logos to 2000 px wide and saving them as PDF/A‑1b for consistent cross‑browser rendering.
 * 3. When a legal document management system must embed EPS diagrams into PDF/A‑1b reports while ensuring the images are scaled to a uniform width for standardized page layout.
 * 4. When a marketing automation tool automates the creation of PDF brochures from EPS brand assets, resizing them to 2000 px to meet design guidelines and guaranteeing PDF/A‑1b compliance for long‑term preservation.
 * 5. When a desktop application processes batch EPS files, resizing each to a 2000‑pixel width and exporting to PDF/A‑1b to satisfy regulatory requirements for searchable, archivable PDFs.
 */