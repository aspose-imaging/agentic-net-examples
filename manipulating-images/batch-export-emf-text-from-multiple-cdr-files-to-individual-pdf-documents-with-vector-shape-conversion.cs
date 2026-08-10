// HOW-TO: Batch Export CDR Text to PDF With Vector Shapes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input CDR files
            string[] inputFiles = new[]
            {
                @"C:\Data\sample1.cdr",
                @"C:\Data\sample2.cdr"
            };

            // Output directory for generated PDFs
            string outputDir = @"C:\Data\PdfOutput";

            // Ensure the output directory exists (unconditional as per rules)
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through all pages of the CDR document
                    for (int pageIndex = 0; pageIndex < cdrImage.Pages.Length; pageIndex++)
                    {
                        var page = (CdrImagePage)cdrImage.Pages[pageIndex];

                        // Prepare PDF options with vector rasterization settings
                        PdfOptions pdfOptions = new PdfOptions();
                        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;

                        // Build output file path for the current page
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.pdf";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure the directory for the output file exists (unconditional)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PDF document
                        page.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a designer needs to convert multiple CorelDRAW (CDR) files containing EMF text into separate PDF documents while preserving vector quality for printing.
 * 2. When an automated build process must generate PDFs from a batch of CDR assets without rasterizing the text, ensuring the text remains selectable and scalable.
 * 3. When a web service receives CDR uploads and must return PDF versions with exact page dimensions and vector shapes for downstream editing.
 * 4. When a migration tool moves legacy CDR artwork to a PDF archive and requires the text to be rendered with single‑bit per pixel hinting for crisp edges.
 * 5. When a QA script validates that each page of several CDR files is correctly exported to PDF with no loss of vector information.
 */
