using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Parse kernel coefficients from command‑line arguments
            // Expecting a square matrix (odd size). If invalid, fall back to a 3x3 identity kernel.
            int coeffCount = args.Length;
            int size = (int)Math.Sqrt(coeffCount);
            if (size * size != coeffCount || size % 2 == 0)
            {
                size = 3;
                coeffCount = 9;
                args = new string[9]; // reset args to default identity values
                for (int i = 0; i < 9; i++) args[i] = (i == 4) ? "1" : "0"; // center = 1, others = 0
            }

            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double value = 0;
                    double.TryParse(args[i * size + j], out value);
                    kernel[i, j] = value;
                }
            }

            // Create convolution filter options with the custom kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Load image, apply filter, and save result
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When a developer needs to apply a custom sharpening or edge‑detection filter to PNG or JPEG images from a script or CI pipeline, they can pass the kernel values to this utility to process the files automatically.
 * 2. When building a batch‑processing tool that prepares product photos for an e‑commerce site, the code can be invoked with a blur or noise‑reduction kernel to uniformly soften images before upload.
 * 3. When creating a scientific imaging workflow that requires a specific convolution matrix (e.g., a Sobel operator) to extract gradients from microscopy PNG files, the command‑line program lets researchers supply the coefficients without modifying source code.
 * 4. When integrating image preprocessing into a machine‑learning data pipeline, developers can use the utility to apply a custom high‑pass filter to training images, ensuring consistent pixel transformations across large datasets.
 * 5. When troubleshooting or fine‑tuning visual effects in a game asset pipeline, artists can experiment with different kernel values by running the tool from the terminal to instantly see the impact on PNG textures.
 */