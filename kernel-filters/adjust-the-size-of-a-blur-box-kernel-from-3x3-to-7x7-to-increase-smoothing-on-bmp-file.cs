using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(7);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, filterOptions);

                var bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to reduce noise in scanned BMP documents before OCR by applying a 7x7 blur box kernel for stronger smoothing.
 * 2. When a C# application must prepare BMP textures for a video game by softening harsh edges using Aspose.Imaging’s 7x7 convolution blur filter.
 * 3. When an image‑processing pipeline requires consistent background smoothing of BMP screenshots for UI testing, increasing the kernel size from 3x3 to 7x7 to eliminate pixel‑level artifacts.
 * 4. When a medical imaging tool stores BMP slices and wants to apply a gentle blur to hide patient identifiers, using a 7x7 blur box kernel via Aspose.Imaging in .NET.
 * 5. When a batch‑processing script needs to generate visually pleasing thumbnail BMPs by applying a larger 7x7 blur to create a smoother preview without changing file format.
 */