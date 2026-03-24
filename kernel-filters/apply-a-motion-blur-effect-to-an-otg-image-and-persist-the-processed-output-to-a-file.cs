using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string outputPath = "output.png";
        string tempPath = "temp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Ensure temporary directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Load the OTG image and rasterize it to a temporary PNG file
        using (Image otgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // Set up PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary file
            otgImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized image, apply motion blur, and save the final result
        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            // Apply motion blur (length=10, smooth=1.0, angle=90.0)
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image to the output path as PNG
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        try
        {
            File.Delete(tempPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}