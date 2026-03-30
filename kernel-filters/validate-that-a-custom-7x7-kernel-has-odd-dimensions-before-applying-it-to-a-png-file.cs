using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
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

        // Define a custom 7x7 kernel (example values)
        double[,] kernel = new double[7, 7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };

        // Validate that kernel dimensions are odd
        if (kernel.GetLength(0) % 2 == 0 || kernel.GetLength(1) % 2 == 0)
        {
            Console.Error.WriteLine("Kernel dimensions must be odd.");
            return;
        }

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply the custom convolution filter
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(outputPath, saveOptions);
        }
    }
}