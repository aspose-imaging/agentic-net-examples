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
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Validate that the sum of coefficients equals 1
                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                if (Math.Abs(sum - 1.0) > 1e-6)
                {
                    Console.Error.WriteLine($"Kernel sum is {sum}, which does not equal 1. Adjust the kernel to avoid brightness shift.");
                    return;
                }

                // Apply the convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the result as PNG
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to sharpen product images for an e‑commerce catalog using a custom 3×3 convolution kernel in C# with Aspose.Imaging, they validate the kernel sum to keep the overall brightness unchanged.
 * 2. When processing scanned documents to enhance text clarity without over‑exposing the page, a .NET application uses a custom kernel and checks that its coefficients total one before applying the filter.
 * 3. When preparing satellite or aerial PNG tiles for a GIS web map, a developer applies a custom edge‑enhancement filter and ensures the kernel sum equals one to prevent brightness drift across tiles.
 * 4. When creating a medical imaging tool that highlights subtle features in X‑ray PNG files, the code verifies the convolution kernel sum to maintain consistent image intensity for accurate diagnosis.
 * 5. When building an automated photo‑editing pipeline that batch‑processes PNG files for a social‑media app, the developer validates the custom kernel’s coefficient sum to avoid unintended brightening after each filter pass.
 */