using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom 7x7 kernel (example: simple averaging kernel)
            double[,] kernel = new double[7, 7];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    kernel[i, j] = 1.0 / 49.0;
                }
            }

            // Validate that kernel dimensions are odd
            if (kernel.GetLength(0) % 2 == 0 || kernel.GetLength(1) % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to apply a custom 7x7 averaging convolution filter to a PNG image while ensuring the kernel has odd dimensions to avoid runtime errors.
 * 2. When building an image preprocessing pipeline in C# that validates input files, creates output directories, and applies an odd‑sized convolution kernel for smoothing before further analysis.
 * 3. When implementing a desktop application that performs real‑time noise reduction on user‑uploaded PNGs using a custom 7x7 kernel and must check kernel dimensions to comply with Aspose.Imaging’s filter requirements.
 * 4. When creating an automated batch process that loads PNG files, validates the existence of each file, applies a custom convolution filter with an odd‑sized kernel, and saves the results to a specified output folder.
 * 5. When developing a C# utility that verifies a custom kernel’s odd width and height before invoking Aspose.Imaging’s ConvolutionFilterOptions to ensure correct edge handling on PNG raster images.
 */