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
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Configure rasterization to render text as vector shapes
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    // Render text as shapes by using single-bit per pixel rendering hint
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                // Set page size based on the source image dimensions
                rasterOptions.PageWidth = image.Width;
                rasterOptions.PageHeight = image.Height;

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
 * 1. When a graphic designer needs to convert CorelDRAW (CDR) files that contain EMF text into searchable PDF documents while preserving the text as scalable vector shapes.
 * 2. When an automated document processing pipeline must extract vector‑based text from CDR artwork and generate PDF reports without losing font fidelity.
 * 3. When a web application offers users the ability to upload CDR files and receive PDF previews that render text as crisp vectors for high‑resolution printing.
 * 4. When a legacy archival system requires migration of CDR drawings to PDF format, ensuring that embedded EMF text remains editable as vector objects rather than raster images.
 * 5. When a batch conversion tool needs to programmatically render CDR pages to PDF using Aspose.Imaging in C# while applying specific rasterization options such as SingleBitPerPixel text rendering and no smoothing.
 */