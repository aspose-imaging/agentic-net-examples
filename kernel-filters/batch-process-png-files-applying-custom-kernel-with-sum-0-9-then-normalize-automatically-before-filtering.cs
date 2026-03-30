using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare the output file path
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "_filtered.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and process it
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Automatic normalization before filtering
                raster.NormalizeHistogram();

                // Custom 3x3 kernel with sum 0.9
                double[,] kernel = new double[,]
                {
                    { 0.1, 0.1, 0.1 },
                    { 0.1, 0.1, 0.1 },
                    { 0.1, 0.1, 0.1 }
                };

                // Apply convolution filter using the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}