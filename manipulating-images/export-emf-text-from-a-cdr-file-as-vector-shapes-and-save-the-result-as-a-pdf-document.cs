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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.cdr";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Set rasterization options to keep text as vector shapes
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
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
 * 1. When a developer needs to convert CorelDRAW (.cdr) artwork into a print‑ready PDF while preserving all text as editable vector shapes for high‑resolution output, they can use this code.
 * 2. When an enterprise document workflow requires automated extraction of EMF text from CDR files and saving them as searchable PDFs for compliance archives, this snippet provides the necessary C# implementation.
 * 3. When a graphic design portal wants to let users upload CDR files and instantly generate PDF previews that retain crisp vector text for web viewing, the code demonstrates the required Aspose.Imaging conversion.
 * 4. When a batch processing tool must convert a library of CorelDRAW files to PDFs without rasterizing the text, ensuring the resulting documents remain lightweight and scalable, the example shows how to configure vector rasterization options in C#.
 * 5. When integrating a C# application with a content management system that stores design assets as CDR and needs to deliver PDF versions with vector‑based text for downstream editing, this code handles the export efficiently.
 */