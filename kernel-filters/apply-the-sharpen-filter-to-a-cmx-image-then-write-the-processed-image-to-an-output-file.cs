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
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image cmxImage = Image.Load(inputPath))
        {
            // Save a temporary rasterized version (PNG) of the CMX image
            string tempPath = Path.Combine(Path.GetTempPath(), "temp_cmx_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            cmxImage.Save(tempPath, new PngOptions());

            // Load the rasterized image
            using (Image rasterImage = Image.Load(tempPath))
            {
                // Cast to RasterImage to access the Filter method
                var raster = (RasterImage)rasterImage;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image to the desired output path
                raster.Save(outputPath);
            }

            // Clean up temporary file
            try { File.Delete(Path.Combine(Path.GetTempPath(), "temp_cmx_raster.png")); } catch { }
        }
    }
}