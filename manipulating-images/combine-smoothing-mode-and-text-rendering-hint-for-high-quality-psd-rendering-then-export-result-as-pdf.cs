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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Configure high‑quality rasterization options
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,                     // Preserve original dimensions
                    SmoothingMode = SmoothingMode.AntiAlias,   // High‑quality smoothing
                    TextRenderingHint = TextRenderingHint.AntiAlias // High‑quality text rendering
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a developer needs to convert a layered Photoshop PSD file to a PDF while preserving the original dimensions and applying anti‑aliased smoothing and text rendering using Aspose.Imaging for .NET.
 * 2. When an application must generate printable PDFs from design assets stored as PSDs, requiring high‑quality rasterization to avoid jagged edges and blurry text.
 * 3. When a batch‑processing service automates the export of marketing visuals from PSD to PDF and must ensure smooth graphics and crisp typography for client review.
 * 4. When a document management system ingests PSD files and needs to store them as searchable PDFs with accurate color, background handling, and high‑quality text rendering.
 * 5. When a C# utility validates the existence of source PSD files, creates the necessary output directories, and performs high‑quality vector rasterization before saving the result as a PDF.
 */