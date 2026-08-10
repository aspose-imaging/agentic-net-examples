// HOW-TO: Apply Custom 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 kernel with center weight 0.7 and surrounding 0.075, then normalize
                double[,] kernel = new double[3, 3]
                {
                    { 0.0576923076923077, 0.0576923076923077, 0.0576923076923077 },
                    { 0.0576923076923077, 0.5384615384615384, 0.0576923076923077 },
                    { 0.0576923076923077, 0.0576923076923077, 0.0576923076923077 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the filtered image as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to soften a PNG image using a custom low‑pass filter to reduce noise before further processing.
 * 2. When you want to apply a weighted averaging filter with a stronger center weight to create a subtle smoothing effect on raster images.
 * 3. When you must implement a custom blur operation in a .NET application without relying on external image‑editing tools.
 * 4. When you are building an automated pipeline that normalizes image data by applying a consistent convolution kernel to all PNG assets.
 * 5. When you need to experiment with different kernel values in C# to fine‑tune image sharpening or smoothing for computer‑vision preprocessing.
 */
