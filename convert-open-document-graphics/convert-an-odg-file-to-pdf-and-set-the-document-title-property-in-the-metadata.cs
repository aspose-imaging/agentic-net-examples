// HOW-TO: Convert ODG to PDF and Set Document Title in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.OpenDocument.Objects;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Set ODG metadata title
                if (image is OdImage odImage)
                {
                    odImage.Metadata.Title = "My Document Title";
                }

                // Configure rasterization options for PDF conversion
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Configure PDF options and set PDF document title
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    PdfDocumentInfo = new PdfDocumentInfo { Title = "My Document Title" }
                };

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
 * 1. When you need to generate a searchable PDF from an OpenDocument graphics file while preserving the original title for cataloging.
 * 2. When automating a batch process that converts multiple ODG drawings to PDFs and assigns a consistent document title for downstream indexing.
 * 3. When creating PDF reports from ODG diagrams in a C# application and you want the PDF metadata to reflect the drawing’s title.
 * 4. When integrating Aspose.Imaging into a document management system to ensure converted PDFs carry the correct title property for compliance.
 * 5. When exporting ODG artwork to PDF for client delivery and you must embed the title in the PDF metadata without manual editing.
 */
