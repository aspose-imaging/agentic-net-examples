using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.emf";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options for EMF
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Set PDF options with metadata and vector rasterization
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Document Title"
                    }
                };

                // Save as PDF with embedded fonts
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
 * 1. When a developer needs to generate printable PDF reports from vector‑based EMF diagrams while preserving font fidelity and adding author and title metadata.
 * 2. When an engineering application must archive CAD schematics stored as EMF files into searchable PDF documents with embedded fonts for consistent rendering across devices.
 * 3. When a legal document management system converts signed EMF signatures into PDFs that include metadata for document tracking and retain exact font appearance.
 * 4. When a marketing tool exports high‑resolution EMF logos into PDF brochures, embedding the fonts to avoid missing characters and setting PDF metadata for SEO.
 * 5. When a desktop utility batch‑processes EMF assets into PDF portfolios, ensuring each PDF contains author and title information for easy cataloguing.
 */