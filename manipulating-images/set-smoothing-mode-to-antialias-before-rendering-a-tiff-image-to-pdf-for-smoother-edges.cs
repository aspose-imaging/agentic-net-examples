// HOW-TO: Render TIFF to PDF with Anti-Alias Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.pdf";

        // Ensure any runtime exception is reported without crashing
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

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions();

                // Create and configure vector rasterization options
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    // Enable anti-aliasing for smoother edges
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

                // Save the image as PDF using the configured options
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
 * 1. When you need to convert high‑resolution scanned TIFF documents to PDF while preserving smooth line edges for professional printing.
 * 2. When generating PDF reports from medical imaging TIFF files and want to avoid jagged borders in the rendered graphics.
 * 3. When creating searchable PDF archives from architectural blueprint TIFFs and require anti‑aliased rendering for clearer details.
 * 4. When automating batch conversion of TIFF invoices to PDF in a C# application and need consistent visual quality across all pages.
 * 5. When integrating Aspose.Imaging into a document workflow that transforms TIFF graphics into PDF brochures with smooth vector‑rasterized output.
 */
