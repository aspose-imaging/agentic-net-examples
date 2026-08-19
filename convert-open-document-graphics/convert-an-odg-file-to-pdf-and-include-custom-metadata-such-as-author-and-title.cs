// HOW-TO: Convert ODG to PDF with Custom Metadata in C# (Aspose.Imaging for .NET)
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
                // Configure rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF options and set custom metadata
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
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
 * 1. When a developer needs to programmatically export OpenDocument graphics (ODG) to a searchable PDF while embedding author and title information for document management systems.
 * 2. When an application must generate PDF reports from ODG diagrams and include custom metadata to comply with corporate publishing standards.
 * 3. When a batch conversion tool processes multiple ODG files and must preserve source attribution by setting the PDF's Author and Title fields.
 * 4. When integrating Aspose.Imaging into a C# workflow to rasterize vector ODG content into PDF pages with a white background and specific page size.
 * 5. When automating the creation of PDF portfolios that contain ODG illustrations and require embedded metadata for easier indexing in content repositories.
 */
