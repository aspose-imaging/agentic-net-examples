using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output files
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Apply a sharpen filter (kernel size 5, sigma 4.0) to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as an APNG file
            raster.Save(outputPath, new ApngOptions());

            Console.WriteLine("Sharpen filter applied and saved as APNG.");
        }
    }
}