using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output_sharpened.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            // Apply a sharpen filter (kernel size 5, sigma 4.0) to the whole image
            var sharpenOptions = new SharpenFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, sharpenOptions);

            // Save the processed image to the output path
            raster.Save(outputPath);
        }
    }
}