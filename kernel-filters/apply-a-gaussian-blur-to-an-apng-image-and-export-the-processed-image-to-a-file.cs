using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (APNG or any raster format)
        using (Image image = Image.Load(inputPath))
        {
            // Try to treat the loaded image as an APNG image
            if (image is ApngImage apngImage)
            {
                // Apply Gaussian blur to each frame of the APNG
                foreach (ApngFrame frame in apngImage.Pages)
                {
                    if (frame is RasterImage rasterFrame)
                    {
                        rasterFrame.Filter(rasterFrame.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                    }
                }

                // Save the processed APNG
                apngImage.Save(outputPath, new ApngOptions());
            }
            else if (image is RasterImage rasterImage)
            {
                // If not an APNG, apply blur to the whole raster image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save as PNG (or keep original format by using appropriate options)
                rasterImage.Save(outputPath, new PngOptions());
            }
            // If the image type is unsupported, nothing is saved.
        }
    }
}