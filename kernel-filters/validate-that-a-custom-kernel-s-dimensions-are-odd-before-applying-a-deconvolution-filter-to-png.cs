// HOW-TO: Validate Odd Kernel Size Before Deconvolution Filter on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/result.png";

            // Validate input file existence
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

                // Define custom kernel size (must be odd)
                int kernelSize = 5;
                if (kernelSize % 2 == 0)
                {
                    Console.Error.WriteLine("Kernel size must be odd.");
                    return;
                }

                // Create a simple averaging kernel
                double[,] kernel2D = new double[kernelSize, kernelSize];
                double value = 1.0 / (kernelSize * kernelSize);
                for (int y = 0; y < kernelSize; y++)
                {
                    for (int x = 0; x < kernelSize; x++)
                    {
                        kernel2D[y, x] = value;
                    }
                }

                // Create deconvolution filter options with the custom kernel
                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(kernel2D);

                // Apply the deconvolution filter to the entire image
                raster.Filter(raster.Bounds, deconvOptions);

                // Prepare PNG save options with a FileCreateSource
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
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
 * 1. When you need to apply a custom averaging deconvolution filter to a PNG image in C# and must verify that the kernel size is odd to avoid runtime errors.
 * 2. When you want to programmatically load a PNG, apply image sharpening or blurring using a user‑defined kernel, and save the processed result to a specific folder.
 * 3. When building an automated image‑processing pipeline that checks for the source file, creates missing output directories, and safely applies a deconvolution filter.
 * 4. When integrating Aspose.Imaging into a C# application to perform raster‑level filtering on PNGs with custom kernel parameters.
 * 5. When ensuring image‑processing code validates kernel dimensions before calling the Filter method to prevent exceptions in production environments.
 */
