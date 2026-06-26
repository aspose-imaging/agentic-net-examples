using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = inputPath + ".pdf";

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
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,   // flatten annotations onto white background
                    PageSize = image.Size            // preserve original page size
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PDF (flattened)
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
 * 1. When a developer needs to generate a printable PDF from an OpenDocument Graphics (ODG) design while ensuring all drawing annotations are merged into a single static page.
 * 2. When an application must archive ODG diagrams as PDF files for compliance, requiring the annotations to be flattened so they cannot be edited later.
 * 3. When a web service converts user‑uploaded ODG files to PDF for preview in browsers, using C# Image.Load and PdfOptions to preserve the original page size.
 * 4. When a batch‑processing tool needs to automate the conversion of multiple ODG files to PDF on a Windows server, handling missing files and creating output directories programmatically.
 * 5. When a document‑management system stores ODG assets but needs to provide a read‑only PDF version for clients, leveraging Aspose.Imaging rasterization to embed annotations onto a white background.
 */