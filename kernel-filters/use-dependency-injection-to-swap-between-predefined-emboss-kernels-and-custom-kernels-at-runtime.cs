using System;
using System.IO;
using System.Collections.Generic;
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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Dependency injection: map identifiers to filter option factories
            var filterFactories = new Dictionary<string, Func<Aspose.Imaging.ImageFilters.FilterOptions.FilterOptionsBase>>()
            {
                // Predefined emboss kernels
                { "emboss3x3", () => new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3) },
                { "emboss5x5", () => new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5) },

                // Custom kernel example (edge detection)
                { "custom", () => {
                    double[,] customKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };
                    return new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                } }
            };

            // Choose which filter to apply at runtime
            string selectedFilter = "emboss3x3"; // change to "emboss5x5" or "custom" as needed

            if (!filterFactories.ContainsKey(selectedFilter))
            {
                Console.Error.WriteLine($"Unknown filter identifier: {selectedFilter}");
                return;
            }

            // Load the raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply the selected filter to the whole image
                raster.Filter(raster.Bounds, filterFactories[selectedFilter]());

                // Save the result as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a photo‑editing web service needs to let users choose between a 3×3 emboss effect, a 5×5 emboss effect, or a custom edge‑detection filter for uploaded PNG or JPEG images, developers can use this DI‑based code to switch filters at runtime.
 * 2. When an automated batch‑processing pipeline must apply different emboss kernels to product photos based on product category, the dictionary of filter factories lets the C# application select the appropriate kernel without recompiling.
 * 3. When a desktop application that generates printable marketing materials wants to preview an emboss effect and also experiment with custom convolution kernels for artistic styling, this code enables developers to toggle filters dynamically during the preview.
 * 4. When a machine‑learning preprocessing step requires converting raw images to an embossed representation using either a standard kernel or a custom kernel tuned for specific edge patterns, the DI approach allows the same codebase to serve both scenarios.
 * 5. When a CI/CD build runs integration tests that validate image output for multiple filter configurations, developers can inject the desired filter identifier (e.g., "emboss5x5" or "custom") to verify that Aspose.Imaging correctly processes PNG files under each kernel.
 */