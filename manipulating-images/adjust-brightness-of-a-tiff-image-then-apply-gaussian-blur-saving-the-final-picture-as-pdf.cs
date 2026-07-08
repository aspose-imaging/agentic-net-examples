using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Adjust brightness
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.AdjustBrightness(50);

                // Apply Gaussian blur
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions { Radius = 5 });

                // Save as PDF
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
 * 1. When a developer needs to preprocess scanned TIFF documents by increasing brightness, applying a Gaussian blur to reduce noise, and then exporting the result as a PDF for archiving or sharing.
 * 2. When an application must convert medical imaging TIFF files to PDF while enhancing visibility with brightness adjustment and smoothing details with a Gaussian blur filter.
 * 3. When a batch job processes high‑resolution TIFF photographs, uniformly brightens them, softens edges with a Gaussian blur, and saves each image as a PDF portfolio for client review.
 * 4. When a document management system requires on‑the‑fly transformation of uploaded TIFF scans, adjusting brightness, applying a blur to obscure sensitive details, and outputting the final image as a PDF for secure distribution.
 * 5. When a reporting tool generates PDF reports that embed TIFF charts and the developer wants to programmatically boost the chart’s brightness and apply a Gaussian blur before embedding to ensure consistent visual quality.
 */