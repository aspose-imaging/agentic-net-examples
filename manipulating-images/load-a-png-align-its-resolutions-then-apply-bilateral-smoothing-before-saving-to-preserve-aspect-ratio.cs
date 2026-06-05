using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to the specific PNG type
                PngImage pngImage = image as PngImage;
                if (pngImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a PNG.");
                    return;
                }

                // Align horizontal and vertical resolutions (make them equal)
                double hRes = pngImage.HorizontalResolution;
                double vRes = pngImage.VerticalResolution;
                if (hRes != vRes)
                {
                    // Set both resolutions to the horizontal value
                    pngImage.SetResolution(hRes, hRes);
                }

                // Apply bilateral smoothing filter to the whole image
                var raster = pngImage as RasterImage;
                if (raster != null)
                {
                    raster.Filter(raster.Bounds, new BilateralSmoothingFilterOptions(5));
                }

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