using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // URL of the image to process
            string imageUrl = "https://example.com/sample.png";

            // Download the image into a stream and process
            using (var httpClient = new System.Net.Http.HttpClient())
            using (var stream = httpClient.GetStreamAsync(imageUrl).Result)
            using (Image image = Image.Load(stream))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Obtain the Emboss3x3 kernel (2D array)
                double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;

                // Create convolution filter options with the kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}