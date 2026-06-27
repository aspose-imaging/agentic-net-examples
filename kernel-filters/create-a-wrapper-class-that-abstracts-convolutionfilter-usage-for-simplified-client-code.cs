using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = ConvolutionFilter.Emboss3x3;
                var options = new ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, options);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to apply an emboss effect to user‑uploaded PNG photos in a .NET web application without dealing directly with kernel matrices.
 * 2. When a desktop C# utility must batch‑process scanned PNG documents to enhance edge details using a 3×3 convolution filter.
 * 3. When a mobile backend service has to generate stylized thumbnails from PNG assets by applying a convolution filter before saving them with PngOptions.
 * 4. When an image‑processing pipeline requires a simple wrapper around Aspose.Imaging’s ConvolutionFilter to hide low‑level raster operations for maintainable code.
 * 5. When a C# automation script must verify the existence of input PNG files, apply a custom kernel, and save the transformed image while handling exceptions gracefully.
 */