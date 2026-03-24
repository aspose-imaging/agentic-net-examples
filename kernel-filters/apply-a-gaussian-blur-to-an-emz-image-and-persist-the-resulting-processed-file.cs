using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emz";
        string outputPath = @"C:\Images\sample_blur.png";
        string tempPath = @"C:\Images\temp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Step 1: Rasterize the EMZ (vector) image to a temporary PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempPath, pngOptions);
        }

        // Step 2: Load the rasterized PNG, apply Gaussian blur, and save the final image
        using (Image rasterImage = Image.Load(tempPath))
        {
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            raster.Save(outputPath);
        }
    }
}