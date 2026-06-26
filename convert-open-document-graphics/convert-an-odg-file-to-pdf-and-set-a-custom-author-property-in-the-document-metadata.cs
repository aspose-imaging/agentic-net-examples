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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.pdf";

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
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options and set custom author metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
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
 * 1. When a developer needs to convert OpenDocument Graphics (ODG) drawings created in LibreOffice into searchable PDF files for archiving while preserving the original page size.
 * 2. When an application must programmatically generate PDF reports from ODG diagrams and embed a custom author name in the PDF metadata for compliance tracking.
 * 3. When a batch processing tool has to validate the existence of ODG source files, create the output folder structure, and rasterize the vector graphics to PDF using Aspose.Imaging in a C# environment.
 * 4. When a document management system requires converting ODG assets to PDF and setting the PdfDocumentInfo.Author property so that end‑users can filter documents by author in the UI.
 * 5. When a .NET service automates the conversion of design assets from ODG to PDF with a white background and needs to handle exceptions gracefully during the image loading and saving process.
 */