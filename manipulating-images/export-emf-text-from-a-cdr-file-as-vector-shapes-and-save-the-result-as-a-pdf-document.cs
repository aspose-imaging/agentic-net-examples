using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Set up PDF export options with rasterization that renders text as shapes
                PdfOptions pdfOptions = new PdfOptions();

                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    // Render text as vector shapes
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a graphic designer needs to convert CorelDRAW (CDR) artwork containing EMF text into a PDF while preserving the text as scalable vector shapes for high‑resolution printing.
 * 2. When an automated document processing pipeline must extract vector‑based text from CDR files and generate searchable PDF reports without losing font fidelity.
 * 3. When a web application offers users the ability to upload CDR files and instantly download PDF versions that retain editable vector outlines of all text elements.
 * 4. When a legacy archiving system requires converting legacy CDR drawings with embedded EMF text into PDF archives that keep the text as vector graphics for future editing.
 * 5. When a batch conversion tool needs to programmatically load CDR images in C#, apply rasterization options that render text as vector shapes, and save the results as PDF files for compliance documentation.
 */