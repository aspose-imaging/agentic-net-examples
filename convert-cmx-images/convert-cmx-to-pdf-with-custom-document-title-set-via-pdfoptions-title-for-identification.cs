using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with custom title
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Title = "Custom Document Title" }
                };

                // Set up vector rasterization options for CMX conversion
                var rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to archive legacy CorelDRAW CMX vector drawings as searchable PDF files with a custom document title for easy identification in document management systems.
 * 2. When an engineering workflow requires converting CMX schematics to PDF reports while preserving exact page dimensions and setting a specific title for inclusion in automated report generators.
 * 3. When a web application must allow users to upload CMX artwork and instantly generate PDF previews with a predefined title that appears in the PDF metadata for SEO and indexing purposes.
 * 4. When a batch processing script has to transform a folder of CMX files into PDFs, ensuring each PDF carries a consistent title that matches the project naming convention for downstream printing pipelines.
 * 5. When a compliance tool needs to convert CMX legal diagrams to PDF format and embed a custom title in the PDF metadata to satisfy audit trail requirements.
 */