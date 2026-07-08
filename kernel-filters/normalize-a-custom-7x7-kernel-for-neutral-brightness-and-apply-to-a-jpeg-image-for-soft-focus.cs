using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Create a 7x7 kernel with equal weights (neutral brightness)
                double[,] kernel = new double[7, 7];
                double weight = 1.0 / 49.0; // 7*7 = 49
                for (int y = 0; y < 7; y++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        kernel[y, x] = weight;
                    }
                }

                // Apply the custom convolution filter for soft focus
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer wants to add a subtle soft‑focus effect to user‑uploaded JPEG photos without changing overall brightness, they can use this Aspose.Imaging C# code to apply a normalized 7×7 convolution kernel.
 * 2. When building a .NET web service that automatically enhances product images by smoothing edges while preserving color balance, the example shows how to load a JPEG, apply a neutral‑weight kernel, and save the result.
 * 3. When creating a desktop photo‑editing tool that offers a “gentle blur” filter, the code demonstrates how to generate a 7×7 kernel, normalize it, and apply it with ConvolutionFilterOptions to a raster image.
 * 4. When integrating image preprocessing into a machine‑learning pipeline that requires uniformly bright, softly focused JPEG inputs, this snippet illustrates loading, filtering, and saving the image using Aspose.Imaging.
 * 5. When developing an automated batch‑processing script to improve the visual appeal of a catalog by applying a consistent soft‑focus across many JPEG files, the example provides the necessary C# steps for kernel creation, convolution, and JPEG output.
 */