using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = @"C:\Images\filtered\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));

            // Save the filtered image as PNG
            PngOptions pngOptions = new PngOptions
            {
                Progressive = true
            };
            raster.Save(outputPath, pngOptions);
        }

        // Azure Blob Storage integration is not available with the permitted namespaces
        throw new NotSupportedException("Azure Blob Storage integration is not supported with the allowed namespaces.");
    }
}