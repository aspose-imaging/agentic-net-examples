// HOW-TO: Convert CMX to PDF with Custom Document Title in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cmx";
        string outputPath = "sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CMX image with default load options
            var loadOptions = new CmxLoadOptions();

            using (var image = Image.Load(inputPath, loadOptions) as CmxImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load CMX image.");
                    return;
                }

                // Prepare PDF export options
                var pdfOptions = new PdfOptions
                {
                    // Set custom document title
                    PdfDocumentInfo = new PdfDocumentInfo { Title = "Custom Document Title" },

                    // Configure rasterization for vector content
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as searchable PDF files and embed a specific title for easy identification.
 * 2. When generating PDF reports from CMX assets in an automated C# workflow and want the PDF metadata to reflect a custom document title.
 * 3. When converting vector CMX illustrations to PDF for printing while preserving exact page dimensions and setting a descriptive title for document management systems.
 * 4. When building a document conversion service that receives CMX uploads and returns PDFs with consistent metadata for downstream indexing or search.
 * 5. When migrating a design library from CorelDRAW to PDF format and need to programmatically assign titles to each PDF to match the original project names.
 */
