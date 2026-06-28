using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new MaskingOptions
                {
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PdfOptions()
                };

                var masking = new ImageMasking(image);
                using (var result = masking.Decompose(maskingOptions))
                using (RasterImage transparentImage = (RasterImage)result[1].GetImage())
                {
                    transparentImage.Filter(transparentImage.Bounds, new MedianFilterOptions(5));
                    transparentImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert scanned PNG documents with uneven backgrounds into clean PDF files that have a transparent background for seamless overlay on other pages.
 * 2. When an e‑commerce platform wants to automatically remove background noise from product PNG images, apply a median filter, and embed the resulting transparent images into PDF catalogs.
 * 3. When a medical imaging system must preprocess PNG scans by applying a median filter to reduce speckle noise before generating PDF reports with a transparent background.
 * 4. When a publishing workflow requires batch conversion of PNG illustrations to PDF while preserving transparency and smoothing edges using a median filter.
 * 5. When a GIS application needs to export raster map tiles (PNG) as PDF layers with transparent backgrounds and noise reduction for seamless map composition.
 */