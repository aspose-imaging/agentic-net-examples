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
        string outputPath = @"C:\Images\output_filtered.png";

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
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Define a 3x3 kernel: edges = 0.1, center = 0.6, then normalize
            double[] rawKernel = new double[]
            {
                0.1, 0.1, 0.1,
                0.1, 0.6, 0.1,
                0.1, 0.1, 0.1
            };

            // Compute sum for normalization
            double sum = 0;
            foreach (double v in rawKernel) sum += v;

            // Normalize kernel values so that they sum to 1
            double[] normalizedKernel = new double[rawKernel.Length];
            for (int i = 0; i < rawKernel.Length; i++)
            {
                normalizedKernel[i] = rawKernel[i] / sum;
            }

            // Create convolution filter options with factor = 1 (already normalized) and bias = 0
            var filterOptions = new ConvolutionFilterOptions(normalizedKernel, 1.0, 0);

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }
}