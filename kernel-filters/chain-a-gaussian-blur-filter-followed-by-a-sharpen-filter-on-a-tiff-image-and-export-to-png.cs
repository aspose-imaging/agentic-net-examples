// HOW-TO: Apply Gaussian Blur Then Sharpen to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.tif";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                var gaussOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0f);
                raster.Filter(raster.Bounds, gaussOptions);

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                raster.Filter(raster.Bounds, sharpenOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce noise in a scanned TIFF document before enhancing edges and delivering a web‑friendly PNG.
 * 2. When preparing high‑resolution TIFF photographs for an online gallery, applying a blur to smooth grain and then sharpening to restore detail before converting to PNG.
 * 3. When processing medical imaging TIFF files to soften background artifacts and accentuate structures, then exporting to PNG for integration into a reporting system.
 * 4. When automating a batch workflow that cleans up scanned receipts (TIFF) by blurring and sharpening before saving as PNG for OCR preprocessing.
 * 5. When creating thumbnail previews from large TIFF maps, applying a Gaussian blur followed by a sharpen filter to improve visual clarity and saving the result as PNG.
 */
