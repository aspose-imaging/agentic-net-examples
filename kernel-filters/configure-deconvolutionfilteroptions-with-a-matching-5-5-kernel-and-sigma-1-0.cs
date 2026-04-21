using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and apply a 5x5 Gaussian deconvolution filter with sigma 1.0
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Configure DeconvolutionFilterOptions (GaussWienerFilterOptions) with size 5 and sigma 1.0
            var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 1.0);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}