// HOW-TO: Apply Gaussian Blur and Brightness Adjustment to TIFF and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        const string inputPath = "input.tif";
        const string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, blurOptions);
                raster.AdjustBrightness(30);
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
 * 1. When you need to soften a scanned TIFF document with a Gaussian blur, boost its brightness, and output the result as a PDF for easier sharing.
 * 2. When preprocessing high‑resolution TIFF images from a scanner by applying blur and brightness correction before converting them to PDF archives using C#.
 * 3. When creating printable PDFs from noisy TIFF files where a gentle blur reduces grain and a brightness increase improves legibility.
 * 4. When automating a workflow that transforms medical imaging TIFFs into PDFs with enhanced contrast and a subtle blur to protect patient privacy.
 * 5. When building a batch process that prepares product catalog pages stored as TIFFs by smoothing edges and brightening colors before exporting them to PDF.
 */
