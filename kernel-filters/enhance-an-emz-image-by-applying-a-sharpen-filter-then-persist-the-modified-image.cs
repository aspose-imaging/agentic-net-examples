using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emz";
        string outputPath = @"C:\Images\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMZ image (vector format)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Rasterize the vector image into a PNG stored in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    // Use EMF rasterization options to render the vector image
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    }
                };

                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // Reset stream for reading

                // Load the rasterized image
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to apply filters
                    var raster = (RasterImage)rasterImage;

                    // Apply Sharpen filter to the entire image
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the sharpened image to the output path
                    raster.Save(outputPath);
                }
            }
        }
    }
}