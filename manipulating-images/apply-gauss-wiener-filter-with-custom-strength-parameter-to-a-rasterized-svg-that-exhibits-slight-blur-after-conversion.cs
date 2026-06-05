using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputSvgPath = "input.svg";
            string tempRasterPath = "temp.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempRasterPath, pngOptions);
            }

            // Load the rasterized image
            using (Image rasterImageBase = Image.Load(tempRasterPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)rasterImageBase;

                // Custom strength parameters for Gauss-Wiener filter
                int kernelSize = 5;          // example size (must be odd)
                double sigma = 4.0;          // custom strength (smoothing)

                // Apply Gauss-Wiener filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(kernelSize, sigma));

                // Save the filtered image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}