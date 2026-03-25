using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.png";
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

            // Resize the image to thumbnail dimensions (e.g., 150x150)
            const int thumbWidth = 150;
            const int thumbHeight = 150;
            raster.Resize(thumbWidth, thumbHeight);

            // Prepare SVG rasterization options using the current image size
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = raster.Size
            };

            // Set up SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the processed image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}