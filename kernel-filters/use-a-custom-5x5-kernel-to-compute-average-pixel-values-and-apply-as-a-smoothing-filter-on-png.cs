// HOW-TO: Apply 5x5 Averaging Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string outputPath = "output/output.png";

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

                // Create a 5x5 averaging kernel
                double[,] kernel = new double[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kernel[i, j] = 1.0 / 25.0;
                    }
                }

                // Apply the custom convolution filter
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                var saveOptions = new PngOptions();
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
 * 1. When you need to reduce noise in a scanned PNG photograph before OCR processing by applying a 5x5 averaging convolution filter.
 * 2. When you want to smooth texture maps in a game asset pipeline using C# and a custom 5x5 kernel.
 * 3. When you must create a uniform blur on medical imaging PNG files for anonymization with a convolution filter.
 * 4. When you are preparing PNG screenshots for a presentation and need a gentle smoothing filter applied programmatically.
 * 5. When you are building an automated batch job that normalizes sharp edges in PNG logos for web publishing using Aspose.Imaging.
 */
