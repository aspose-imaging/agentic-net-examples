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
            // Input WebP image and output PDF paths (relative)
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary WebP file with adjusted quality
            string tempWebpPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_quality.webp");
            Directory.CreateDirectory(Path.GetDirectoryName(tempWebpPath));

            // Adjust quality by re‑encoding the original WebP
            var qualityOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 50f // desired quality (0‑100)
            };

            using (Image original = Image.Load(inputPath))
            {
                original.Save(tempWebpPath, qualityOptions);
            }

            // Load the quality‑adjusted WebP and save as PDF with specific resolution
            using (Image adjusted = Image.Load(tempWebpPath))
            {
                var pdfOptions = new PdfOptions
                {
                    ResolutionSettings = new ResolutionSetting(150, 150) // DPI X, DPI Y
                };
                adjusted.Save(outputPath, pdfOptions);
            }

            // Optional: clean up temporary file
            if (File.Exists(tempWebpPath))
            {
                File.Delete(tempWebpPath);
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
 * 1. When a web application needs to generate printable PDF reports from user‑uploaded WebP images while controlling file size by lowering the WebP quality before conversion.
 * 2. When an e‑commerce platform wants to create product catalogs in PDF format from high‑resolution WebP photos and must set a specific DPI (e.g., 150 × 150) to meet printing standards.
 * 3. When a document‑management system processes bulk WebP assets and must re‑encode them at a chosen quality level to ensure consistent visual fidelity across all generated PDFs.
 * 4. When a mobile‑to‑desktop workflow requires converting camera‑captured WebP screenshots into PDFs with a predefined resolution, using Aspose.Imaging in a C# backend service.
 * 5. When a compliance‑driven archiving solution needs to store WebP images as PDFs with controlled resolution and must clean up temporary quality‑adjusted files automatically after saving.
 */