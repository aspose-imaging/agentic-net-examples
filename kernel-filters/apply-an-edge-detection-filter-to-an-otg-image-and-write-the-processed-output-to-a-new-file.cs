using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_edge.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary raster file path
        string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the OTG image and rasterize it to a PNG file
        using (Image otgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size // Preserve original size
            };

            // Set up PNG saving options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            otgImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG, apply an edge‑detecting (sharpen) filter, and save the result
        using (Image rasterImage = Image.Load(tempRasterPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)rasterImage;

            // Apply a sharpen filter (commonly used for edge detection)
            // Kernel size 5, sigma 4.0 – adjust as needed for stronger edges
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to the final output path
            raster.Save(outputPath);
        }

        // Optionally clean up the temporary raster file
        try
        {
            if (File.Exists(tempRasterPath))
                File.Delete(tempRasterPath);
        }
        catch
        {
            // Suppress any cleanup errors
        }
    }
}