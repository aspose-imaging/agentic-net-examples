// HOW-TO: Convert OTG to PDF with Flate Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up OTG rasterization options (preserve original size)
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF compression (e.g., Flate compression)
                var pdfCoreOptions = new PdfCoreOptions
                {
                    Compression = PdfImageCompressionOptions.Flate
                };

                // Combine PDF options with vector rasterization options
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = pdfCoreOptions,
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the image as PDF with the specified options
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
 * 1. When you need to generate a searchable PDF from an OTG vector graphic while preserving its original dimensions.
 * 2. When you want to reduce the PDF file size by applying Flate compression to the embedded images.
 * 3. When your application must batch‑convert OTG design files to PDF for archiving or printing workflows.
 * 4. When you need to ensure the output PDF is created using Aspose.Imaging’s PdfOptions and OtgRasterizationOptions in a .NET environment.
 * 5. When you have to programmatically verify the source OTG file exists and create the destination folder before saving the compressed PDF.
 */
