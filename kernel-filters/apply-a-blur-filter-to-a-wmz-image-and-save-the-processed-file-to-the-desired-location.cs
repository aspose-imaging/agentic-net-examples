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
        string inputPath = @"C:\Images\input.wmz";
        string outputPath = @"C:\Images\output.wmz";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMZ image, apply Gaussian blur, and save as compressed WMZ
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filter
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Set up rasterization options for WMF/WMZ output
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = rasterImage.Size
            };

            // Configure WMF options with compression (WMZ)
            var wmfOptions = new WmfOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                Compress = true
            };

            // Save the processed image as WMZ
            rasterImage.Save(outputPath, wmfOptions);
        }
    }
}