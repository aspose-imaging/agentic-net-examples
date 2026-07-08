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
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new height to preserve aspect ratio for width = 2000
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Prepare PDF options with PDF/A-1b compliance
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save as PDF
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
 * 1. When a developer must convert a vector EPS logo to a PDF/A‑1b compliant file for archival purposes while scaling it to a fixed width of 2000 pixels to fit a print layout.
 * 2. When a C# application needs to resize an EPS‑based engineering diagram to a standard web‑ready width and export it as a PDF that meets PDF/A‑1b compliance for regulatory submission.
 * 3. When an automated workflow processes incoming EPS artwork, resizes it to 2000 px wide to maintain consistent branding, and saves it as a PDF/A‑1b document for distribution to clients.
 * 4. When a document management system imports EPS files, adjusts their dimensions for screen viewing, and stores them as PDF/A‑1b files to ensure long‑term accessibility and legal validity.
 * 5. When a batch‑processing tool prepares EPS marketing assets for digital publishing by resizing them to 2000 pixels in width and converting them to PDF/A‑1b compliant PDFs for cross‑platform compatibility.
 */