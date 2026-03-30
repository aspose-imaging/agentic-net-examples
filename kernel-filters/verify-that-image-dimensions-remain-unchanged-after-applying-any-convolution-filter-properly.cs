using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/sample.png";
        string outputPath = "output/filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image and cast to RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            int originalWidth = raster.Width;
            int originalHeight = raster.Height;

            // Apply a Gaussian blur convolution filter
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Verify dimensions remain unchanged
            if (raster.Width != originalWidth || raster.Height != originalHeight)
            {
                Console.Error.WriteLine("Image dimensions changed after filtering.");
                return;
            }

            // Save the filtered image
            raster.Save(outputPath);
        }
    }
}