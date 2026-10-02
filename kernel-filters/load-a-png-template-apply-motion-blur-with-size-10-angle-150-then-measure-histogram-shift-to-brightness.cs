// HOW-TO: Apply Motion Blur to PNG and Measure Brightness Shift in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] pixelsBefore = raster.LoadArgb32Pixels(raster.Bounds);
                double avgBrightnessBefore = ComputeAverageBrightness(pixelsBefore);

                var kernel = ConvolutionFilter.GetBlurMotion(10, 150);
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                int[] pixelsAfter = raster.LoadArgb32Pixels(raster.Bounds);
                double avgBrightnessAfter = ComputeAverageBrightness(pixelsAfter);

                double brightnessShift = avgBrightnessAfter - avgBrightnessBefore;
                Console.WriteLine($"Brightness shift after motion blur: {brightnessShift}");

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static double ComputeAverageBrightness(int[] argbPixels)
    {
        double total = 0;
        foreach (int argb in argbPixels)
        {
            byte r = (byte)((argb >> 16) & 0xFF);
            byte g = (byte)((argb >> 8) & 0xFF);
            byte b = (byte)(argb & 0xFF);
            double lum = 0.299 * r + 0.587 * g + 0.114 * b;
            total += lum;
        }
        return total / argbPixels.Length;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to simulate camera shake on a PNG template and evaluate how the motion blur affects overall image brightness.
 * 2. When generating visual effects for games or UI assets and you want to quantify the brightness change caused by a 10‑pixel, 150‑degree motion blur.
 * 3. When performing automated quality checks on processed images and need to compare pre‑ and post‑blur average brightness using Aspose.Imaging.
 * 4. When creating a batch workflow that applies a specific motion‑blur kernel to product photos and logs the brightness shift for analytics.
 * 5. When developing a photo‑editing tool that lets users preview motion blur on PNG files and see the exact change in image luminance.
 */
