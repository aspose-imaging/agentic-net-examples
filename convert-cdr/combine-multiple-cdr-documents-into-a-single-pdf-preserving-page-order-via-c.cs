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
            // Input CDR files (hardcoded paths)
            string inputPath1 = @"C:\input\doc1.cdr";
            string inputPath2 = @"C:\input\doc2.cdr";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Output PDF file (hardcoded path)
            string outputPath = @"C:\output\combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a multipage image from the CDR files
            string[] cdrFiles = new[] { inputPath1, inputPath2 };
            using (Image multipageImage = Image.Create(cdrFiles))
            {
                // Configure PDF options with vector rasterization for CDR pages
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                    }
                };

                // Save combined PDF
                multipageImage.Save(outputPath, pdfOptions);
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
 * 1. When a graphic design studio needs to merge several CorelDRAW (CDR) artwork files into a single PDF portfolio for client review, preserving the original page order.
 * 2. When an automated document processing pipeline must convert multiple CDR drawings into a combined PDF report for archiving or compliance purposes.
 * 3. When a web application offers users the ability to upload multiple CDR files and receive a single downloadable PDF that retains vector quality through Aspose.Imaging rasterization options.
 * 4. When a batch job runs nightly to consolidate daily CDR design drafts into one PDF booklet for distribution to the production team.
 * 5. When a Windows service integrates Aspose.Imaging to programmatically combine CDR pages into a PDF for printing workflows that require consistent page sequencing.
 */