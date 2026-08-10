// HOW-TO: Convert CDR to PDF with ClearType Text Rendering in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

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
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.ClearTypeGridFit,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as PDF
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
 * 1. When you need to generate a PDF from a CorelDRAW file while preserving sharp, ClearType‑rendered text for high‑quality print or on‑screen viewing.
 * 2. When an application must batch‑process CDR documents and output PDFs that retain the original text clarity without manual rasterization settings.
 * 3. When you are building a document‑conversion service that requires anti‑aliased vector rendering and precise text positioning defined by the source CDR file.
 * 4. When you want to ensure that the converted PDF displays readable text on Windows devices that rely on ClearType font smoothing.
 * 5. When you need to programmatically verify the existence of the source CDR file and create the output folder before performing the conversion in a .NET environment.
 */
