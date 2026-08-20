// HOW-TO: Validate Custom Sharpening Kernel Sum Exceeds One for PNG Brightness in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom sharpening kernel
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
            };

            // Validate that the sum of kernel elements exceeds 1
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    sum += kernel[i, j];
                }
            }

            if (sum <= 1)
            {
                Console.Error.WriteLine("Kernel sum must exceed 1 to increase brightness. Filter not applied.");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom sharpening kernel using ConvolutionFilterOptions
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. Use this code when you need to ensure a custom sharpening filter actually brightens a PNG image before saving it in a .NET application.
 * 2. Apply the validation to avoid applying a convolution filter whose kernel sum is too low, which would unintentionally darken the image.
 * 3. Employ the routine in batch image processing pipelines to verify kernel parameters and maintain consistent visual output across many PNG files.
 * 4. Integrate the logic into a photo‑editing tool built with Aspose.Imaging that allows users to define their own sharpening kernels safely.
 * 5. Use the approach when you want to increase image brightness while sharpening in a single step, eliminating the need for separate brightness adjustments.
 */
