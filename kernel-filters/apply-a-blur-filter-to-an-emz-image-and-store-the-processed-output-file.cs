using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.emz";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image vectorImage = Image.Load(inputPath))
        {
            // Rasterize vector image to a memory stream as PNG
            using (var memoryStream = new MemoryStream())
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = vectorImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load rasterized image
                using (Image rasterImageBase = Image.Load(memoryStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageBase;

                    // Apply Gaussian blur filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}