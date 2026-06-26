using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.pdf";

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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for vector image
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options and set custom metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "John Doe",
                        Title = "Sample ODG to PDF Conversion"
                    }
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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) files to PDF for distribution while preserving vector quality and adding author and title metadata.
 * 2. When an application must generate searchable PDF reports from ODG diagrams and embed custom document information for compliance tracking.
 * 3. When a document management system requires automated conversion of user‑uploaded ODG illustrations to PDF with standardized metadata for indexing.
 * 4. When a C# service processes batch image files, rasterizes ODG vector graphics to PDF pages, and sets PDF document properties for archival purposes.
 * 5. When a desktop utility needs to ensure the output PDF has a white background, correct page size, and embedded author/title fields for printing or e‑signature workflows.
 */