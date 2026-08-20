// HOW-TO: Convert EPS to PDF with Balanced Compression and JPEG Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PDF options with balanced compression settings
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Use Flate compression for lossless images and set JPEG quality for raster images
                    Compression = PdfImageCompressionOptions.Flate,
                    JpegQuality = 85
                }
            };

            // Load the EPS image and convert it to PDF using the configured options
            using (var image = (EpsImage)Image.Load(inputPath))
            {
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
 * 1. When you need to generate PDF reports from EPS graphics while keeping file size reasonable without sacrificing image clarity.
 * 2. When an automated workflow must convert vector EPS logos to PDFs for web publishing and requires lossless compression for vector parts and controlled JPEG quality for embedded raster images.
 * 3. When a desktop application processes design files and must store the output PDFs with consistent compression settings to meet email attachment limits.
 * 4. When a batch conversion tool needs to ensure all PDFs use Flate compression for text and graphics while applying an 85% JPEG quality to photographs inside the EPS.
 * 5. When you want to programmatically verify the existence of the source EPS file and create the destination folder before converting it to a PDF with balanced compression in a .NET environment.
 */
