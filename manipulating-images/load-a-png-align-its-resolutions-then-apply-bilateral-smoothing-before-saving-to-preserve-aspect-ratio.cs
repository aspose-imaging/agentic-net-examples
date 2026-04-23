using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to PngImage for resolution handling
                var pngImage = (Aspose.Imaging.FileFormats.Png.PngImage)image;

                // Align horizontal and vertical resolutions (make them equal)
                double hRes = pngImage.HorizontalResolution;
                double vRes = pngImage.VerticalResolution;
                if (hRes != vRes)
                {
                    // Set both resolutions to the horizontal value
                    pngImage.SetResolution(hRes, hRes);
                }

                // Apply bilateral smoothing filter to the entire image
                var rasterImage = (RasterImage)pngImage;
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Save the processed image
                pngImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}