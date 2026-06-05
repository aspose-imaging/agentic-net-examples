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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with ClearType text rendering
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.ClearTypeGridFit
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
 * 1. When a developer needs to convert CorelDRAW (CDR) artwork to a PDF document while preserving crisp, ClearType‑rendered text for high‑resolution printing.
 * 2. When an application must batch‑process CDR files into searchable PDFs and wants to ensure the text appears sharp on screen by setting TextRenderingHint.ClearTypeGridFit.
 * 3. When integrating Aspose.Imaging into a C# workflow that generates PDF reports from vector graphics and requires ClearType text rendering to improve readability on Windows displays.
 * 4. When a user uploads a CDR file to a web service that returns a PDF and the service must render the embedded fonts with ClearType to meet branding guidelines for sharp typography.
 * 5. When automating document conversion in a CI/CD pipeline and the team wants to guarantee that any converted PDF retains ClearType‑optimized text for consistent visual quality across devices.
 */