// HOW-TO: Deskew PSD Image, Set Text Rendering Hint, Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.psd");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    if (!raster.IsCached) raster.CacheData();
                    raster.NormalizeAngle(false, Color.LightGray);
                }

                Graphics graphics = new Graphics(image);
                graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When you need to correct a scanned Photoshop PSD file that is slightly rotated before generating a printable PDF report.
 * 2. When you want to ensure crisp, single‑bit text rendering in a PDF created from a PSD layer using Aspose.Imaging for .NET.
 * 3. When an automated workflow must convert multiple PSD assets to PDF while automatically normalizing their orientation.
 * 4. When a web service receives user‑uploaded PSD files and must return a deskewed PDF with optimized text clarity.
 * 5. When integrating Aspose.Imaging into a desktop application to batch‑process design files, applying deskew and custom text rendering before saving as PDF.
 */
