// HOW-TO: Apply 5x5 Blur Box Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);
                double factor = 1.0;
                int bias = 0;

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, factor, bias);

                raster.Filter(raster.Bounds, convOptions);

                var pngOptions = new PngOptions();
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
 * 1. When you need to soften the edges of a PNG image to create a smoother web thumbnail.
 * 2. When you want to reduce visual noise in scanned PNG documents before running OCR.
 * 3. When you need to generate a blurred background effect for UI overlays using C#.
 * 4. When you are preprocessing PNG images for a machine‑learning pipeline that requires uniform smoothing.
 * 5. When you must batch‑process PNG files to apply a consistent blur for privacy masking.
 */
