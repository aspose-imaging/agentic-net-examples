using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Create deconvolution filter options (Gauss-Wiener filter)
            // Radius = 5, Sigma = 4.0 are typical values for deblurring
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}