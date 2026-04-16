using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster‑specific operations
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Resize the image to 1200x1200 pixels (default nearest‑neighbour resampling)
            raster.Resize(1200, 1200);

            // Prepare SVG save options with rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Set the page size to match the resized image dimensions
                    PageSize = raster.Size
                }
            };

            // Save the processed image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}