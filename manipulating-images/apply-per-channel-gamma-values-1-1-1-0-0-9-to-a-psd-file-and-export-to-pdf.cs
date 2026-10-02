// HOW-TO: Apply Per‑Channel Gamma To PSD And Save As PDF In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                raster.AdjustGamma(1.1f, 1.0f, 0.9f);

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to correct the color balance of individual RGB channels in a Photoshop PSD before generating a printable PDF.
 * 2. When an automated workflow must adjust gamma for each channel to match a specific monitor profile and then export the design to PDF for client review.
 * 3. When a web service creates PDF previews of uploaded PSD files and wants to fine‑tune brightness per channel without manually editing the image.
 * 4. When a batch conversion tool processes multiple PSD assets, applying custom per‑channel gamma to ensure consistent visual appearance across all resulting PDFs.
 * 5. When a digital publishing system requires converting layered PSD artwork to PDF while applying subtle gamma shifts to meet branding color standards.
 */
