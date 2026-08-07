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
            string inputPath = "template.png";
            string outputPath = "smoothed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG template as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Create a 3x3 averaging kernel (each weight = 1/9)
                double[,] kernel = new double[3, 3];
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] = 1.0 / 9.0;
                    }
                }

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the smoothed image
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
 * 1. When a developer needs to reduce noise in a PNG template before printing by applying a uniform smoothing filter using Aspose.Imaging’s convolution capabilities in C#.
 * 2. When a web application must generate a softened version of user‑uploaded PNG graphics for thumbnails, using a 3×3 averaging kernel to ensure consistent blur across the image.
 * 3. When an automated batch process has to prepare PNG assets for machine‑learning training by smoothing pixel variations with a custom convolution filter in .NET.
 * 4. When a desktop utility wants to preview the effect of a simple low‑pass filter on a raster image, loading the PNG, applying the averaging kernel, and saving the result for visual verification.
 * 5. When a developer is testing image‑processing pipelines and needs a quick way to verify that Aspose.Imaging correctly applies a uniform convolution filter to a PNG file’s pixel data.
 */