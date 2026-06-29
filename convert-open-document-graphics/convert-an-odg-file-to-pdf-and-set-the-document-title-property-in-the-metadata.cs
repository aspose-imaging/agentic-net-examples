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
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Converted ODG Document"
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
 * 1. When a developer needs to programmatically convert OpenDocument graphics (ODG) files to PDF for distribution while preserving the original page size and setting a custom document title in the PDF metadata.
 * 2. When an automated document processing pipeline must validate the existence of source ODG files, rasterize them with a white background, and generate searchable PDF reports with a predefined title.
 * 3. When integrating Aspose.Imaging into a C# application to batch‑convert design assets from ODG to PDF and embed meaningful metadata for document management systems.
 * 4. When a Windows service has to ensure output directories exist before saving converted PDFs, applying rasterization options to maintain visual fidelity of ODG drawings.
 * 5. When troubleshooting file conversion errors, a developer uses try‑catch handling around Aspose.Imaging’s Image.Load and Save methods to log issues while converting ODG graphics to PDF with title metadata.
 */