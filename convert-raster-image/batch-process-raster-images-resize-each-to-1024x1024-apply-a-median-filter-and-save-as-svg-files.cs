using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded list of raster images to process
        string[] inputFiles = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.png",
            @"C:\Images\photo3.bmp"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output path by changing the extension to .svg
            string outputPath = Path.ChangeExtension(inputPath, ".svg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024 pixels
                image.Resize(1024, 1024);

                // Apply a median filter with kernel size 5
                if (image is RasterImage rasterImage)
                {
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
                }

                // Configure SVG save options with appropriate rasterization settings
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(1024, 1024)
                };
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}