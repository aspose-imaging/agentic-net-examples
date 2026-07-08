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
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Adjust contrast
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.AdjustContrast(50f); // increase contrast

                // Prepare PDF export with text rendering hint
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a designer needs to increase the contrast of a Photoshop PSD file and deliver the final artwork as a PDF for client review.
 * 2. When an e‑learning platform must convert layered PSD slides into PDF handouts while ensuring crisp text rendering with a single‑bit‑per‑pixel hint.
 * 3. When a marketing automation script processes product mockups stored as PSD, boosts visual contrast, and archives them as PDF reports.
 * 4. When a document management system imports PSD assets, normalizes their appearance by adjusting contrast, and saves them as searchable PDFs with specific text rendering settings.
 * 5. When a batch job prepares print‑ready PDFs from PSD source files, applying contrast enhancement and disabling smoothing to meet printing specifications.
 */