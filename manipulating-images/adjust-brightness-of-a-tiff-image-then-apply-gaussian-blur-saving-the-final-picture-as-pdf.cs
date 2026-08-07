using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.pdf";

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

                GaussianBlurFilterOptions blurOptions = new GaussianBlurFilterOptions
                {
                    Radius = 5,
                    Sigma = 2.0f
                };
                raster.Filter(raster.Bounds, blurOptions);

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
 * 1. When a medical imaging system needs to enhance the contrast of a high‑resolution TIFF scan, apply a soft blur to reduce noise, and archive the result as a searchable PDF for patient records.
 * 2. When a publishing workflow must convert scanned book pages in TIFF format, brighten faded text, smooth artifacts with a Gaussian blur, and output a print‑ready PDF.
 * 3. When an e‑commerce platform processes product catalog TIFF images, increases brightness for better visibility, applies a subtle blur to hide imperfections, and generates PDF brochures for distribution.
 * 4. When a legal firm digitizes signed documents stored as TIFF files, adjusts brightness to make signatures clearer, uses Gaussian blur to obscure background details, and saves the final document as a PDF for court filing.
 * 5. When an archival software batch‑processes historical photographs in TIFF, boosts brightness to restore faded colors, applies Gaussian blur to soften grain, and creates PDF portfolios for easy viewing.
 */