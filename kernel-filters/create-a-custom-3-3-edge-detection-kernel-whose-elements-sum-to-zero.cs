using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Custom 3x3 edge‑detection kernel (sum = 0)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                double factor = 1.0;
                int bias = 0;

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, factor, bias);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the result as PNG
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
 * 1. When a developer needs to highlight object boundaries in PNG photographs for a medical imaging analysis tool using Aspose.Imaging’s convolution filter.
 * 2. When a developer wants to preprocess scanned documents saved as PNG to emphasize text edges before running OCR with C#.
 * 3. When a developer builds a security‑camera system that extracts edge features from PNG video frames to detect motion using a custom 3×3 kernel.
 * 4. When a developer adds an “edge‑enhance” filter to a graphic‑design application that applies a zero‑sum convolution kernel to user‑uploaded images.
 * 5. When a developer automates visual quality inspection in manufacturing by detecting defects through edge detection on product PNG images.
 */