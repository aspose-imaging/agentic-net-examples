using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom 5x5 convolution kernel
                double[,] kernel = new double[5, 5]
                {
                    { 0, 0, 1, 0, 0 },
                    { 0, 1, 2, 1, 0 },
                    { 1, 2, 4, 2, 1 },
                    { 0, 1, 2, 1, 0 },
                    { 0, 0, 1, 0, 0 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to enhance the sharpness of PNG photographs by applying a custom 5x5 Gaussian‑like convolution kernel.
 * 2. When a developer wants to emphasize edges in scanned TIFF or JPEG documents for OCR preprocessing using a tailored convolution filter.
 * 3. When a developer must reduce noise in medical imaging files converted to PNG by applying a custom smoothing kernel.
 * 4. When a developer aims to create a vignette effect around the borders of a PNG sprite sheet for game UI design with a 5x5 kernel.
 * 5. When a developer needs to simulate a custom emboss effect on product images before uploading them to an e‑commerce site.
 */