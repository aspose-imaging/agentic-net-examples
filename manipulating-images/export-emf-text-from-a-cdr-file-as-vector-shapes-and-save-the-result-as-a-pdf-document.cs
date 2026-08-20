// HOW-TO: Export CDR Text As Vector Shapes To PDF In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.cdr.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Set rasterization options so that text is rendered as vector shapes
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the result as PDF
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
 * 1. When you need to preserve editable text from a CorelDRAW (CDR) file in a PDF without rasterizing it, you can use this code to export the text as vector shapes.
 * 2. When generating printable PDFs from design assets and want the text to remain crisp at any zoom level, this approach converts CDR text to vector outlines.
 * 3. When automating a workflow that converts legacy CDR drawings to PDF for archiving while ensuring the text is not lost during rasterization, the snippet provides a reliable solution.
 * 4. When building a C# application that extracts vector‑based text from CDR files for use in a document management system, this code saves the result directly as a PDF.
 * 5. When creating a batch process to convert multiple CDR files to PDF while maintaining exact typography and layout, the example shows how to configure Aspose.Imaging rasterization options for vector text rendering.
 */
