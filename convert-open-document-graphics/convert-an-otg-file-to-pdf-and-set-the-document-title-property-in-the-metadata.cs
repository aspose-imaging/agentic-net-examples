using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.pdf";

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
                // Prepare PDF options
                PdfOptions pdfOptions = new PdfOptions();

                // Set PDF document title metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Converted OTG Document"
                };

                // Configure rasterization options for vector conversion
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
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
 * 1. When an engineering firm needs to archive their AutoCAD OTG vector drawings as searchable PDF files with a proper title metadata for easy retrieval.
 * 2. When a web application must convert user‑uploaded OTG images to PDF on the server side in C# while embedding a custom document title for compliance reporting.
 * 3. When a document management system integrates Aspose.Imaging to transform legacy OTG files into PDF format and set the title property so that the PDFs appear correctly in catalog listings.
 * 4. When a batch job processes a folder of OTG files, converting each to PDF and assigning a meaningful title to meet corporate record‑keeping standards.
 * 5. When a desktop utility creates printable PDFs from OTG graphics and uses the PdfDocumentInfo.Title field to display the document name in PDF viewers and search indexes.
 */