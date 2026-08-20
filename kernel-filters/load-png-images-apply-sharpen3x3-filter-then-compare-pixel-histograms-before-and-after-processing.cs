// HOW-TO: Compare PNG Histogram Before and After Sharpen Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Load original pixels and compute histogram
                int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] originalHistogram = new int[256];
                for (int i = 0; i < originalPixels.Length; i++)
                {
                    int argb = originalPixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    int intensity = (r + g + b) / 3;
                    originalHistogram[intensity]++;
                }

                Console.WriteLine("Original histogram:");
                for (int i = 0; i < originalHistogram.Length; i++)
                {
                    if (originalHistogram[i] > 0)
                    {
                        Console.WriteLine($"{i}: {originalHistogram[i]}");
                    }
                }

                // Apply Sharpen filter (kernel size 5, sigma 4.0)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Load processed pixels and compute histogram
                int[] processedPixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] processedHistogram = new int[256];
                for (int i = 0; i < processedPixels.Length; i++)
                {
                    int argb = processedPixels[i];
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    int intensity = (r + g + b) / 3;
                    processedHistogram[intensity]++;
                }

                Console.WriteLine("Processed histogram:");
                for (int i = 0; i < processedHistogram.Length; i++)
                {
                    if (processedHistogram[i] > 0)
                    {
                        Console.WriteLine($"{i}: {processedHistogram[i]}");
                    }
                }

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
 * 1. When you need to evaluate how a sharpening filter affects the brightness distribution of a PNG image for quality control.
 * 2. When you want to generate side‑by‑side histograms to verify that image enhancement does not introduce unwanted artifacts.
 * 3. When building an automated pipeline that sharpens product photos and logs intensity changes to ensure consistent visual appearance.
 * 4. When performing forensic analysis to compare original and processed images by examining their pixel intensity histograms.
 * 5. When creating a diagnostic tool that measures the impact of different filter parameters on PNG image contrast in a C# application.
 */
