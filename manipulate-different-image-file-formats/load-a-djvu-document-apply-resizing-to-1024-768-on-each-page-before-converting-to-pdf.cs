// HOW-TO: Resize DjVu Pages to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.djvu");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    var page = djvu.Pages[i];
                    if (page is RasterImage raster)
                    {
                        if (!raster.IsCached)
                            raster.CacheData();

                        raster.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                    }
                }

                var pdfOptions = new PdfOptions();
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to shrink high‑resolution DjVu scans to a standard 1024×768 size before bundling them into a searchable PDF for faster web viewing.
 * 2. When a document‑management system must automatically convert multi‑page DjVu files into PDFs with uniform page dimensions to ensure consistent layout across devices.
 * 3. When you want to preprocess DjVu e‑books by resizing each page to fit mobile screens and then generate a PDF for distribution on e‑readers.
 * 4. When an archival workflow requires reducing the pixel dimensions of DjVu technical drawings before archiving them as PDFs to save storage space.
 * 5. When a batch‑processing tool needs to load DjVu files, apply nearest‑neighbour resampling to each raster page, and output a PDF for downstream OCR or indexing.
 */
