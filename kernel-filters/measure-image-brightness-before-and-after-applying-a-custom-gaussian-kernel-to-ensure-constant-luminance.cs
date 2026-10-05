// HOW-TO: Measure Image Brightness Before and After Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = (Aspose.Imaging.RasterImage)image;

                double brightnessBefore = ComputeAverageLuminance(raster);

                double[,] kernel = GenerateGaussianKernel(5, 1.0);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                double brightnessAfter = ComputeAverageLuminance(raster);

                Console.WriteLine($"Brightness before: {brightnessBefore:F2}");
                Console.WriteLine($"Brightness after: {brightnessAfter:F2}");

                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static double ComputeAverageLuminance(Aspose.Imaging.RasterImage raster)
    {
        if (!raster.IsCached)
            raster.CacheData();

        int[] pixels = new int[raster.Width * raster.Height];
        raster.SaveArgb32Pixels(raster.Bounds, pixels);
        double sum = 0;

        foreach (int argb in pixels)
        {
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;
            double lum = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            sum += lum;
        }

        return sum / pixels.Length;
    }

    static double[,] GenerateGaussianKernel(int size, double sigma)
    {
        double[,] kernel = new double[size, size];
        double sum = 0;
        int half = size / 2;
        double twoSigmaSq = 2 * sigma * sigma;

        for (int y = -half; y <= half; y++)
        {
            for (int x = -half; x <= half; x++)
            {
                double exponent = -(x * x + y * y) / twoSigmaSq;
                double value = Math.Exp(exponent);
                kernel[y + half, x + half] = value;
                sum += value;
            }
        }

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                kernel[y, x] /= sum;
            }
        }

        return kernel;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that a custom Gaussian blur filter does not unintentionally darken or brighten an image in a photo‑editing application.
 * 2. When you want to compare luminance levels of original and processed JPEG files to maintain consistent visual appearance across a batch.
 * 3. When implementing automated quality‑control for image preprocessing pipelines that require constant average brightness after applying convolution kernels.
 * 4. When developing a scientific imaging tool that must ensure smoothing operations preserve the overall intensity of microscopy images.
 * 5. When creating a custom image‑filter library in C# and need a simple method to calculate average luminance before saving the filtered output.
 */
