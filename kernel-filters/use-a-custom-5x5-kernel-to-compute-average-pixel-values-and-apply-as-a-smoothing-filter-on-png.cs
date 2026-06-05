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
            string outputPath = "output/output.png";

            // Verify input file exists
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

                // Create a 5x5 averaging kernel
                double[,] kernel = new double[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kernel[i, j] = 1.0 / 25.0;
                    }
                }

                // Apply the custom convolution filter to the whole image
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
 * 1. When a developer needs to reduce noise in scanned PNG documents before OCR by applying a 5x5 averaging convolution filter using Aspose.Imaging for .NET.
 * 2. When a C# application must generate a softened background effect for PNG UI assets by smoothing pixel values with a custom 5x5 kernel.
 * 3. When an image processing pipeline requires uniform blurring of PNG textures for game development, using the RasterImage.Filter method with a 5x5 average filter.
 * 4. When a batch script processes PNG photographs to create a consistent low‑pass filter for visual analytics, leveraging Aspose.Imaging's ConvolutionFilterOptions.
 * 5. When a developer wants to pre‑process PNG screenshots to remove high‑frequency details before compression, applying a 5x5 averaging kernel in C#.
 */