// HOW-TO: Convert OTG to PDF with Title Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output.pdf";

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

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Set PDF document title metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Converted OTG Document"
                };

                // Configure rasterization for vector content
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pdfOptions.VectorRasterizationOptions = otgRaster;

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
 * 1. When you need to archive engineering drawings stored as OTG files into searchable PDF documents with a proper title property.
 * 2. When a web application must generate PDF reports from OTG images and embed the document title for easier indexing.
 * 3. When automating a batch process that converts legacy OTG graphics to PDF while preserving vector quality and setting metadata for document management systems.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that allows users to export OTG designs to PDF with a custom title for printing workflows.
 * 5. When creating a document conversion service that transforms OTG files to PDF and adds title metadata to comply with corporate filing standards.
 */
