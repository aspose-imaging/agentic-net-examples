using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ICO image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Apply emboss filter using convolution kernel
            raster.Filter(
                raster.Bounds,
                new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image back as ICO
            raster.Save(outputPath, new IcoOptions());
        }
    }
}