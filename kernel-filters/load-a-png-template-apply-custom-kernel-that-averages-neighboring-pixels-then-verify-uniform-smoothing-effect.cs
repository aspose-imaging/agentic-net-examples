// HOW-TO: Apply 3x3 Averaging Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/template.png";
        string outputPath = "output/smoothed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG template
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 averaging kernel (each weight = 1/9)
                double[,] kernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        kernel[i, j] = 1.0 / 9.0;
                    }
                }

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the result as PNG
                PngOptions saveOptions = new PngOptions();
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
 * 1. When you need to smooth a PNG template to reduce noise before adding dynamic graphics in a C# application.
 * 2. When you want to create a uniform blur effect on a raster image for background preprocessing in a .NET image pipeline.
 * 3. When you must apply a custom 3x3 averaging kernel to all pixels of a PNG to achieve consistent smoothing across the whole picture.
 * 4. When you are building a batch process that loads PNG files, applies a simple convolution filter, and saves the softened results automatically.
 * 5. When you require a quick way to verify that a convolution filter works correctly by comparing the original and smoothed PNG outputs in C#.
 */
