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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[3, 3]
                {
                    { 0.1, 0.1, 0.1 },
                    { 0.1, 0.6, 0.1 },
                    { 0.1, 0.1, 0.1 }
                };

                double sum = 0;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        sum += kernel[y, x];
                    }
                }
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, filterOptions);

                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer wants to reduce noise in a PNG screenshot while preserving overall brightness by applying a custom 3×3 convolution kernel with normalized weights.
 * 2. When an image‑processing pipeline needs to smooth medical imaging PNG files using a weighted average filter before further analysis.
 * 3. When a web application must automatically enhance uploaded PNG avatars by applying a gentle blur that keeps the central pixel dominant.
 * 4. When a batch job processes PNG product photos to create a consistent softening effect across all images using Aspose.Imaging’s ConvolutionFilterOptions in C#.
 * 5. When a developer is building a desktop tool that applies a custom low‑pass filter to PNG graphics to prepare them for printing, ensuring the kernel sums to one for correct exposure.
 */