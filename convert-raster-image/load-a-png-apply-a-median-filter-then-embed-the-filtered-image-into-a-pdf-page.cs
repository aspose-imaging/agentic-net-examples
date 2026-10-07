// HOW-TO: Apply Median Filter to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
                string inputPath = "Input\\image.png";
                string outputPath = "Output\\result.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to reduce salt‑and‑pepper noise in a PNG before generating a printable PDF report.
 * 2. When creating a PDF catalog that must contain cleaned‑up product images originally stored as PNG files.
 * 3. When automating the conversion of scanned PNG screenshots into PDF documents while smoothing visual artifacts.
 * 4. When a web service receives PNG uploads, applies a median filter to improve image quality, and returns a single‑page PDF.
 * 5. When generating archival PDFs from PNG assets and you want to ensure the embedded images are noise‑free using Aspose.Imaging in C#.
 */
