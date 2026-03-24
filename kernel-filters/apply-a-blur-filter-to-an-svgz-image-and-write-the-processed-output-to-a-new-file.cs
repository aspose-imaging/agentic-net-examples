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
        string inputPath = @"C:\Images\input.svgz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVGZ image (auto-detected)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Rasterize vector image to PNG in memory
            var rasterOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load rasterized image as RasterImage
                using (Image rasterImageBase = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageBase;

                    // Apply Gaussian blur filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed raster image to the output file
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}