// HOW-TO: Dither PSD Image and Convert to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\processed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var raster = (RasterCachedImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Dither(DitheringMethod.ThresholdDithering, 0, null);

                var pdfOptions = new PdfOptions();

                raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to reduce color banding in a Photoshop PSD before generating a printable PDF report.
 * 2. When an automated workflow must convert cached PSD files to PDF while applying threshold dithering for consistent monochrome output.
 * 3. When a web service processes user‑uploaded PSD files, applies dithering to meet PDF/A compliance, and returns the PDF to the client.
 * 4. When a desktop application prepares design assets by caching large PSD layers, dithering them, and exporting to PDF for archival storage.
 * 5. When a batch job iterates over a folder of PSD files, applies dithering to improve visual quality, and saves each as a PDF for distribution.
 */
