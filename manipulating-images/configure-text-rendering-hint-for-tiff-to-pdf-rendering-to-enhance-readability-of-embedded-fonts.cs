// HOW-TO: Convert TIFF to PDF with Anti-Alias Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with vector rasterization settings
                var pdfOptions = new PdfOptions();

                var vectorOpts = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.AntiAlias, // Enhance readability of embedded fonts
                    SmoothingMode = SmoothingMode.None
                };

                pdfOptions.VectorRasterizationOptions = vectorOpts;

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
 * 1. When you need to generate searchable PDF documents from high‑resolution TIFF scans while keeping the embedded text crisp and readable.
 * 2. When a medical imaging application must export patient scans as PDFs with anti‑aliased text to improve legibility on screen.
 * 3. When an archival system converts scanned legal documents from TIFF to PDF and wants the vectorized text to appear smooth without jagged edges.
 * 4. When a desktop utility processes batch TIFF files into PDFs and requires consistent font rendering across different page sizes.
 * 5. When a reporting tool embeds TIFF charts into PDFs and needs the text labels to be rendered with anti‑aliasing for professional presentation.
 */
