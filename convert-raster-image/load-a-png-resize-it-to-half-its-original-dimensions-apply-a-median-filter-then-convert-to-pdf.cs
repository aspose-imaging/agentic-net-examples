// HOW-TO: Resize PNG, Apply Median Filter, and Convert to PDF in C# (Aspose.Imaging for .NET)
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

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

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
 * 1. When you need to generate a smaller, noise‑reduced PDF version of a high‑resolution PNG for email attachments.
 * 2. When creating printable PDFs from scanned PNG images while reducing file size and smoothing artifacts.
 * 3. When preprocessing product‑photo PNGs for a catalog by halving dimensions, removing speckle noise, and exporting to PDF.
 * 4. When automating the conversion of PNG screenshots into compact PDFs for documentation with consistent image quality.
 * 5. When building a batch job that prepares PNG assets for archival by resizing, denoising with a median filter, and storing them as PDFs.
 */
