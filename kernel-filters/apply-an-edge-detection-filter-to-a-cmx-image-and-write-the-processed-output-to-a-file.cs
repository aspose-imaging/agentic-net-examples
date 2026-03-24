using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image cmxImage = Image.Load(inputPath))
        {
            // Save the CMX image to a memory stream as PNG (rasterize it)
            using (var memoryStream = new MemoryStream())
            {
                cmxImage.Save(memoryStream, new PngOptions());
                memoryStream.Position = 0;

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply a sharpen filter (used here as a simple edge detection approximation)
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the output path
                    raster.Save(outputPath);
                }
            }
        }
    }
}