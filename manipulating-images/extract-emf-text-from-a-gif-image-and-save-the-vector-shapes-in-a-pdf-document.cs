using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.gif";
        string outputPath = @"C:\Images\output.pdf";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options (EMF rasterization) to keep vector shapes
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save as PDF with vector rasterization (text will be kept as shapes)
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
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
 * 1. When a developer must convert a GIF banner that contains embedded EMF text into a PDF brochure while keeping the text as scalable vector shapes for high‑resolution printing.
 * 2. When an application needs to archive legacy GIF graphics from a content management system as PDF files that retain editable vector outlines for future design edits.
 * 3. When a reporting tool generates PDF invoices from GIF logos and wants the logo’s EMF text to remain crisp and searchable rather than rasterized.
 * 4. When a migration script extracts vector‑based captions from animated GIF tutorials and saves them in PDF manuals to ensure accessibility and text extraction.
 * 5. When a document‑generation service transforms user‑uploaded GIF signatures into PDF contracts, preserving the signature’s EMF text as vector paths for legal authenticity.
 */