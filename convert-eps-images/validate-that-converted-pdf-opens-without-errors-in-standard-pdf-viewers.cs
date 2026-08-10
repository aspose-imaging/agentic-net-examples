// HOW-TO: Convert JPG to PDF and Verify PDF Opens in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image and convert to PDF
            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
            }

            // Validate that the generated PDF can be loaded without errors
            using (Image pdfImage = Image.Load(outputPath))
            {
                // Simple validation: check that dimensions are positive
                if (pdfImage.Width <= 0 || pdfImage.Height <= 0)
                {
                    Console.Error.WriteLine("Validation failed: PDF has invalid dimensions.");
                    return;
                }
            }

            Console.WriteLine("PDF conversion and validation succeeded.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF report from user‑uploaded JPEG images and ensure the resulting file can be opened by any PDF viewer.
 * 2. When an automated workflow must convert product photos to PDF for archiving and validate that the PDFs are not corrupted before storage.
 * 3. When a web service creates printable PDFs from scanned JPEG documents and requires a quick check that the PDF dimensions are valid.
 * 4. When a desktop application batch‑processes image assets into PDFs and needs to confirm each PDF loads without errors to avoid downstream failures.
 * 5. When integrating Aspose.Imaging into a CI pipeline to test that image‑to‑PDF conversion produces viewable PDFs for quality assurance.
 */
