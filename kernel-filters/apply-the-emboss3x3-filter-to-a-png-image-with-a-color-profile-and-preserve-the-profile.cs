using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
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

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Create Emboss3x3 convolution filter options
            var embossFilter = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, embossFilter);

            // Prepare PNG save options and preserve metadata (including color profile)
            var saveOptions = new PngOptions
            {
                KeepMetadata = true
            };

            // Save the processed image
            raster.Save(outputPath, saveOptions);
        }
    }
}