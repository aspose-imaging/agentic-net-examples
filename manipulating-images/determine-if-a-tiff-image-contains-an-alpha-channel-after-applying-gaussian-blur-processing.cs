// HOW-TO: Check for Alpha Channel in TIFF After Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\blurred.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                bool hasAlpha = image.BitsPerPixel > 24;
                Console.WriteLine($"Alpha channel present: {hasAlpha}");

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to verify whether a scanned TIFF document retains transparency after applying a Gaussian blur filter using Aspose.Imaging in C#.
 * 2. When processing medical imaging TIFF files and must ensure that any alpha channel is preserved before saving the blurred result.
 * 3. When building a batch image‑processing pipeline that blurs large TIFF images and conditionally handles files with an alpha channel differently.
 * 4. When integrating image preprocessing for a GIS application and need to detect transparency in TIFF layers after smoothing.
 * 5. When creating a PDF conversion workflow that first applies a Gaussian blur to TIFF pages and must know if the pages contain an alpha channel for proper rendering.
 */
