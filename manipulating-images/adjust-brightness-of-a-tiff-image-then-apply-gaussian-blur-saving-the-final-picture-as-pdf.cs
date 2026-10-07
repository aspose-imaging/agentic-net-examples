// HOW-TO: Increase TIFF Brightness and Apply Gaussian Blur Then Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "image.tif");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustBrightness(50);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

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
 * 1. When you need to enhance a scanned TIFF document’s visibility by brightening it, blur background noise, and deliver the result as a searchable PDF for archiving.
 * 2. When converting legacy TIFF maps or blueprints to PDF while adjusting exposure and smoothing details to improve readability on digital devices.
 * 3. When preparing medical imaging TIFF files for patient reports, increasing contrast, reducing speckle with Gaussian blur, and exporting to PDF for secure sharing.
 * 4. When automating a batch workflow that normalizes lighting of product photos stored as TIFF, applies a subtle blur for aesthetic effect, and generates PDF catalogs.
 * 5. When integrating Aspose.Imaging into a C# application to preprocess scanned receipts (brightening, noise reduction) before saving them as PDF invoices.
 */
