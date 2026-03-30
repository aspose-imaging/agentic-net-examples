using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
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

        // Load the PNG image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a custom 4x4 kernel whose elements sum to 1 (uniform blur)
            double[,] kernel = new double[,]
            {
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 }
            };

            // Create convolution filter options (factor = 1.0, divisor = 1)
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 1);

            // Apply the custom convolution filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare PNG save options with a FileCreateSource
            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image
            raster.Save(outputPath, saveOptions);
        }
    }
}