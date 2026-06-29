using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.tif";
            string outputPath = "C:\\temp\\output.pdf";

            // Verify input file exists
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
                // Configure rasterization options with enhanced text rendering
                var rasterizationOptions = new VectorRasterizationOptions
                {
                    // Use anti‑aliased text rendering for better readability of embedded fonts
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    // Preserve original image size
                    PageSize = image.Size
                };

                // Set PDF options to use the configured rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

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
 * 1. When converting scanned legal documents saved as TIFF files to searchable PDFs and need anti‑aliased text rendering to keep the embedded fonts clear for court reviewers.
 * 2. When generating PDF reports from high‑resolution TIFF maps that contain street names, and you want the text labels to appear crisp by setting TextRenderingHint to AntiAlias.
 * 3. When automating archival of medical imaging records stored as TIFF and require readable patient information in the resulting PDFs for compliance audits.
 * 4. When building a C# desktop application that batch‑processes engineering drawings in TIFF format into PDFs, and you need enhanced text readability for dimension annotations.
 * 5. When creating an e‑learning platform that converts scanned textbook pages (TIFF) to PDFs, ensuring the embedded font text is legible on various devices by configuring rasterization options.
 */