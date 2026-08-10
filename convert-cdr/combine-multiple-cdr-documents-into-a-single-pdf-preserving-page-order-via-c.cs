// HOW-TO: Combine Multiple CDR Files into a Single PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR files and output PDF path
            string[] inputPaths = {
                @"C:\Images\doc1.cdr",
                @"C:\Images\doc2.cdr",
                @"C:\Images\doc3.cdr"
            };
            string outputPath = @"C:\Images\CombinedOutput.pdf";

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PDF options with CDR rasterization settings
            PdfOptions pdfOptions = new PdfOptions();
            CdrRasterizationOptions rasterizationOptions = new CdrRasterizationOptions
            {
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
            };
            pdfOptions.VectorRasterizationOptions = rasterizationOptions;

            // Process each CDR file and append its pages to the PDF
            foreach (string inputPath in inputPaths)
            {
                using (Image cdrImage = Image.Load(inputPath))
                {
                    // Save the CDR (all its pages) to the PDF.
                    // Aspose.Imaging appends pages when the same PDF file is used repeatedly.
                    cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When a designer needs to merge several CorelDRAW (.cdr) drawings into one PDF portfolio for client review.
 * 2. When an automated build process must convert a batch of CDR assets into a single PDF report without manual intervention.
 * 3. When a web service receives multiple CDR uploads and must return a combined PDF for easy download.
 * 4. When a document management system archives multiple CDR pages as a single searchable PDF file.
 * 5. When a printing workflow requires concatenating CDR pages into one PDF to preserve page order before sending to a printer.
 */
