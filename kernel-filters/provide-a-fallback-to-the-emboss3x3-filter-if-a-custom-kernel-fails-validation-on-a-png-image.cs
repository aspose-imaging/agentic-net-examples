using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a custom 3x3 kernel (example)
                double[,] customKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                bool customApplied = false;

                // Attempt to apply the custom kernel
                try
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));
                    customApplied = true;
                }
                catch (Exception)
                {
                    // Fallback to Emboss3x3 filter if custom kernel fails
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                }

                // Prepare PNG save options
                PngOptions options = new PngOptions
                {
                    // Example: set maximum compression
                    CompressionLevel = 9,
                    // Use adaptive filter for better compression
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };

                // Save the processed image
                raster.Save(outputPath, options);
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
 * 1. When a web application needs to apply a user‑defined edge‑detecting convolution to uploaded PNG photos but must guarantee a result even if the kernel is invalid, the code falls back to the built‑in Emboss3x3 filter.
 * 2. When an automated batch job processes thousands of PNG assets and a custom sharpening kernel may be corrupted, the fallback ensures each image still receives a visual enhancement without stopping the pipeline.
 * 3. When a desktop C# tool lets designers experiment with custom 3×3 kernels on PNG graphics, the fallback to Emboss3x3 provides a safe preview when the entered matrix fails Aspose.Imaging validation.
 * 4. When a server‑side image‑processing service validates incoming kernel data for security and, upon rejection, needs to return a consistently embossed PNG to maintain UI layout.
 * 5. When integrating Aspose.Imaging into a CI/CD workflow that applies custom convolution filters to PNG screenshots, the fallback guarantees the build does not fail if the kernel definition is malformed.
 */