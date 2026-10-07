// HOW-TO: Apply Gamma Correction to PNG and Save as PDF using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = Path.Combine("Input", "image.png");
                string outputPath = Path.Combine("Output", "corrected.pdf");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.AdjustGamma(2.2f);

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
}

/*
 * Real-World Use Cases:
 * 1. When you need to improve the visual brightness of a scanned PNG before embedding it in a PDF report.
 * 2. When converting product photos to PDF brochures while applying a standard gamma of 2.2 for consistent display on screens.
 * 3. When preparing images for print‑ready PDFs that require gamma correction to match printer color profiles.
 * 4. When automating the generation of PDF invoices that include raster logos adjusted for proper contrast.
 * 5. When building a batch process that normalizes gamma of user‑uploaded images and archives them as PDFs.
 */
