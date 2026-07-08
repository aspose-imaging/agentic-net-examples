using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputCdrFiles";
            string outputDirectory = @"C:\OutputPdfFiles";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Configure rasterization options with AntiAlias rendering
                    CdrRasterizationOptions rasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.AntiAlias,
                        SmoothingMode = SmoothingMode.AntiAlias
                    };

                    pdfOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When a design studio needs to convert a large collection of CorelDRAW (.cdr) artwork into high‑quality PDF portfolios while preserving smooth text edges using AntiAlias rendering in a C# .NET batch job.
 * 2. When an automated document‑generation pipeline must transform daily exported CDR diagrams into searchable PDFs for archiving, ensuring text is rasterized with anti‑aliasing for readability.
 * 3. When a print‑shop workflow requires mass conversion of client‑submitted CDR files to PDF with consistent anti‑aliased text rendering to meet print‑ready specifications using Aspose.Imaging for .NET.
 * 4. When a cloud‑based conversion service processes user‑uploaded CDR files in bulk, applying TextRenderingHint.AntiAlias to produce crisp PDF outputs that retain the original design fidelity.
 * 5. When a quality‑control script validates that all CDR assets in a repository are correctly exported to PDF with anti‑aliased text, enabling downstream review tools to display clean vector graphics without jagged edges.
 */