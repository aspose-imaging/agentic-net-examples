using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a custom kernel (example 3x3 kernel)
        double[,] kernel = new double[,]
        {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };

        // Compute sum of all coefficients
        double sum = 0;
        foreach (double v in kernel)
            sum += v;

        // Normalize kernel so that sum equals 1
        for (int i = 0; i < kernel.GetLength(0); i++)
        {
            for (int j = 0; j < kernel.GetLength(1); j++)
            {
                kernel[i, j] /= sum;
            }
        }

        // Create convolution filter options with the normalized kernel
        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

        // Load the JPEG image, apply the filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, filterOptions);

            // Configure JPEG save options
            var jpegOptions = new JpegOptions();
            jpegOptions.Source = new FileCreateSource(outputPath, false);

            // Save the processed image
            raster.Save(outputPath, jpegOptions);
        }
    }
}