using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

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
                // Adjust brightness
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.AdjustBrightness(50);

                // Apply Gaussian blur using filter
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save as PDF
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
 * 1. When a developer needs to preprocess scanned TIFF documents by increasing brightness and smoothing details before converting them to searchable PDF reports.
 * 2. When an application must enhance low‑contrast medical imaging TIFF files with a brightness boost and Gaussian blur to reduce noise prior to archiving them as PDF.
 * 3. When a batch job processes archival TIFF photographs, adjusts their exposure, applies a softening filter, and saves the results as PDF portfolios for easy distribution.
 * 4. When a document management system requires automatic correction of underexposed TIFF scans and a blur effect to protect sensitive details before generating PDF files for compliance.
 * 5. When a C# service integrates Aspose.Imaging to prepare TIFF maps by brightening and applying a Gaussian blur to improve visual clarity before exporting them as PDF maps.
 */