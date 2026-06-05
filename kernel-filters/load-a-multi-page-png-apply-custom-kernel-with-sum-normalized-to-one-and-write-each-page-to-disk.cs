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
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page PNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                // Define a custom 3x3 kernel (example values)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                // Normalize kernel so that sum equals 1
                double sum = 0;
                for (int y = 0; y < kernel.GetLength(0); y++)
                {
                    for (int x = 0; x < kernel.GetLength(1); x++)
                    {
                        sum += kernel[y, x];
                    }
                }
                if (sum != 0)
                {
                    for (int y = 0; y < kernel.GetLength(0); y++)
                    {
                        for (int x = 0; x < kernel.GetLength(1); x++)
                        {
                            kernel[y, x] /= sum;
                        }
                    }
                }

                // Process each page
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Retrieve the page as a RasterImage
                    using (RasterImage raster = (RasterImage)multipage.Pages[i])
                    {
                        // Apply convolution filter with the custom kernel
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        // Prepare output path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed page as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                }
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
 * 1. When a developer needs to batch‑process a multi‑page PNG (e.g., a scanned PDF saved as PNG) by applying a custom convolution kernel for uniform noise reduction before exporting each page as a separate image file.
 * 2. When building a C# application that prepares multi‑frame PNG animations for web delivery, using Aspose.Imaging to apply a normalized blur kernel to each frame and save the processed frames individually.
 * 3. When creating a medical imaging workflow that loads multi‑slice PNG scans, applies a custom edge‑enhancement kernel with sum = 1 to improve contrast, and writes each slice to a folder for further analysis.
 * 4. When implementing a satellite‑imagery preprocessing pipeline that reads multi‑band PNG tiles, applies a custom smoothing kernel to each band to eliminate sensor noise, and stores the cleaned tiles as separate files.
 * 5. When developing a document archival tool that extracts each page of a multi‑page PNG invoice, applies a standardized sharpening kernel to improve readability, and saves the sharpened pages to a designated output directory.
 */