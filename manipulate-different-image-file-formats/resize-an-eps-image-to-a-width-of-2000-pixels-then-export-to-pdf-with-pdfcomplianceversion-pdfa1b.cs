using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new height to preserve aspect ratio
                int newHeight = (int)Math.Round((double)image.Height * 2000 / image.Width);

                // Resize the image to the required width (2000 px) and computed height
                image.Resize(2000, newHeight, ResizeType.LanczosResample);

                // Prepare PDF export options with PDF/A-1b compliance
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
 * 1. When a developer needs to convert a vector EPS artwork into a PDF/A‑1b compliant document for archival while ensuring the output fits a 2000‑pixel width for consistent printing.
 * 2. When an automated publishing pipeline must resize high‑resolution EPS logos to a standard width before embedding them in PDF reports that must meet PDF/A‑1b compliance for legal submission.
 * 3. When a web service processes user‑uploaded EPS files, scales them to a fixed 2000‑pixel width to reduce file size, and returns a PDF/A‑1b file suitable for long‑term storage.
 * 4. When a desktop application generates printable PDFs from EPS diagrams, preserving aspect ratio and applying Lanczos resampling to maintain image quality while complying with PDF/A‑1b standards.
 * 5. When a batch job iterates over a collection of EPS files, resizes each to a uniform 2000‑pixel width and saves them as PDF/A‑1b PDFs for inclusion in a searchable digital archive.
 */