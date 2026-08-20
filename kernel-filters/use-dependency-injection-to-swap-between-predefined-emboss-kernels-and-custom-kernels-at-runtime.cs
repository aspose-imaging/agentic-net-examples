// HOW-TO: Apply Emboss Filter with Swappable Kernels Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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
                RasterImage raster = (RasterImage)image;

                // Dependency injection simulation: select kernel at runtime
                // Possible values: "emboss3x3", "emboss5x5", "custom"
                string kernelChoice = "emboss3x3";

                double[,] kernel;

                if (kernelChoice == "emboss3x3")
                {
                    kernel = ConvolutionFilter.Emboss3x3;
                }
                else if (kernelChoice == "emboss5x5")
                {
                    kernel = ConvolutionFilter.Emboss5x5;
                }
                else // custom kernel
                {
                    // Example custom 3x3 emboss-like kernel
                    kernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1,  1, 1 },
                        {  0,  1, 2 }
                    };
                }

                // Create convolution filter options with the selected kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
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
 * 1. When you need to add an emboss effect to PNG or JPEG images and want to choose between built‑in 3×3 or 5×5 kernels or a custom kernel at runtime.
 * 2. When your application processes user‑uploaded photos and must dynamically switch the emboss intensity based on user preferences without recompiling.
 * 3. When you are building a batch image‑processing service that applies different convolution filters to each file depending on configuration settings.
 * 4. When you want to experiment with new emboss kernels for artistic effects while keeping the same Aspose.Imaging ConvolutionFilterOptions code.
 * 5. When you integrate image editing into a .NET microservice and need dependency‑injection‑friendly code to select the appropriate kernel for each request.
 */
