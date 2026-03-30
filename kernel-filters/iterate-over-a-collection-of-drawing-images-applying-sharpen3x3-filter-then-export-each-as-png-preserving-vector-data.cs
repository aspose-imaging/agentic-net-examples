using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded collection of input image paths
        var inputPaths = new List<string>
        {
            @"C:\Images\sample1.tif",
            @"C:\Images\sample2.tif",
            @"C:\Images\sample3.tif"
        };

        // Corresponding output PNG paths
        var outputPaths = new List<string>
        {
            @"C:\Processed\sample1.png",
            @"C:\Processed\sample2.png",
            @"C:\Processed\sample3.png"
        };

        // Iterate over the collection
        for (int i = 0; i < inputPaths.Count; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply the 3x3 sharpen filter using SharpenFilterOptions (size 3, sigma 0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 0));

                // Save as PNG preserving any raster data
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }
        }
    }
}