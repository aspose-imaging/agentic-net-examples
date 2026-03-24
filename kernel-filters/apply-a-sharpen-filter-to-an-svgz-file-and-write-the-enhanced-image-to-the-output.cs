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

        // Load the compressed SVG (SVGZ) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert SVG to raster format
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Set up PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the SVGZ into a memory stream
            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply a sharpen filter to the entire image
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the enhanced raster image to the output path
                    raster.Save(outputPath);
                }
            }
        }
    }
}