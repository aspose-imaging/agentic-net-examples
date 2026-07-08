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
            string inputPath = @"C:\Data\sample.otg";
            string outputPath = @"C:\Data\Result\sample.pdf";

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
                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Set custom PDF metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "John Doe",
                    Title = "Sample OTG to PDF"
                };

                // Configure vector rasterization for OTG
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };
                pdfOptions.VectorRasterizationOptions = otgRasterization;

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
 * 1. When a medical imaging system stores scans in OTG format and needs to generate PDF reports with author and title metadata for electronic health records.
 * 2. When an engineering firm archives CAD drawings saved as OTG files and wants to create searchable PDF documents that include project title and designer name.
 * 3. When a document management workflow receives OTG graphics from a third‑party tool and must convert them to PDF while embedding custom metadata for compliance tracking.
 * 4. When a web application allows users to upload OTG illustrations and automatically produces PDF downloads that contain the creator’s name and a descriptive title.
 * 5. When a batch processing script converts a library of OTG assets to PDF and adds consistent author and title information for cataloguing in a digital asset management system.
 */