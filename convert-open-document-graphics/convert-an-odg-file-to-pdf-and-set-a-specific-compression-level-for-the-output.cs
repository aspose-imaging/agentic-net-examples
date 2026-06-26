using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.odg";
            string outputPath = @"C:\Temp\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options with desired compression
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Flate // specific compression level
                    }
                };

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
 * 1. When a developer needs to generate a compact PDF report from an OpenDocument Graphics (ODG) diagram in a C# application, using Aspose.Imaging to apply Flate compression.
 * 2. When an enterprise workflow requires batch conversion of ODG files to PDF while preserving page size and background color, and the code provides the necessary rasterization options.
 * 3. When a document management system must store vector drawings as PDF files with reduced file size for faster upload and download, leveraging Aspose.Imaging’s PdfCoreOptions compression.
 * 4. When a Windows service automates the conversion of user‑submitted ODG drawings into PDF invoices, ensuring the output directory exists and handling missing input files gracefully.
 * 5. When a .NET developer wants to embed ODG illustrations into a PDF portfolio and control the compression level to meet archival standards, using the PdfOptions and OdgRasterizationOptions classes.
 */