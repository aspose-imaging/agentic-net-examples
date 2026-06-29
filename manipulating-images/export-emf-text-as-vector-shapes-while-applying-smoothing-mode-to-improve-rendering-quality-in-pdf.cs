using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.pdf";

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
                EmfImage emfImage = (EmfImage)image;

                // Configure PDF export options with vector rasterization
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = emfImage.Size,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                // Save as PDF
                emfImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert legacy EMF diagrams containing text into high‑resolution PDF reports while preserving vector quality and smoothing the text edges.
 * 2. When an application must generate printable invoices or certificates from EMF templates and ensure the text appears crisp by using anti‑aliasing during PDF export.
 * 3. When a CAD or engineering tool exports design schematics as EMF and the downstream system requires PDF files with scalable vector text for accurate scaling and on‑screen rendering.
 * 4. When a document management system ingests EMF logos and watermarks and needs to embed them in PDFs with smooth text rendering to meet branding guidelines.
 * 5. When a batch processing script converts a folder of EMF files to PDFs for archiving, applying SmoothingMode.AntiAlias to improve readability of embedded text across different devices.
 */