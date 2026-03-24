using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.apng";
        string outputPath = @"C:\Images\output_denoised.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Apply filters to each frame
            foreach (ApngFrame frame in apngImage.Pages)
            {
                // Each frame can be treated as a RasterImage
                RasterImage raster = (RasterImage)frame;

                // Apply median filter (kernel size 5)
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Apply Gauss-Wiener filter (radius 5, smooth value 4.0)
                raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));
            }

            // Save the processed APNG image
            apngImage.Save(outputPath);
        }
    }
}