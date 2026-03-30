using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Textures\input.png";
        string outputPath = @"C:\Textures\output_emboss.png";

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
            RasterImage raster = (RasterImage)image;

            // Create emboss filter using a predefined convolution kernel
            double[,] embossKernel = ConvolutionFilter.Emboss3x3;
            var filterOptions = new ConvolutionFilterOptions(embossKernel);

            // Apply the emboss filter to the whole image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}