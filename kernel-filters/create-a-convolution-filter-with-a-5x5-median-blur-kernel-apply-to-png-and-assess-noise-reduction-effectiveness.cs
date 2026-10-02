// HOW-TO: Apply 5x5 Median Blur to PNG and Measure Noise Reduction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);

                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                int[] filteredPixels = raster.LoadArgb32Pixels(raster.Bounds);

                long totalDiff = 0;
                for (int i = 0; i < originalPixels.Length; i++)
                {
                    int orig = originalPixels[i];
                    int filt = filteredPixels[i];

                    int aDiff = Math.Abs(((orig >> 24) & 0xFF) - ((filt >> 24) & 0xFF));
                    int rDiff = Math.Abs(((orig >> 16) & 0xFF) - ((filt >> 16) & 0xFF));
                    int gDiff = Math.Abs(((orig >> 8) & 0xFF) - ((filt >> 8) & 0xFF));
                    int bDiff = Math.Abs((orig & 0xFF) - (filt & 0xFF));

                    totalDiff += aDiff + rDiff + gDiff + bDiff;
                }

                double averageDiff = (double)totalDiff / (originalPixels.Length * 4);
                Console.WriteLine($"Average per-channel difference after median blur: {averageDiff:F2}");

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you need to reduce speckle noise in scanned PNG photographs before further analysis.
 * 2. When you want to compare the effect of a median filter on pixel values to evaluate image cleaning performance.
 * 3. When you are building an automated pipeline that processes PNG assets and must verify that the blur does not overly distort colors.
 * 4. When you need to generate a before‑and‑after report showing average per‑channel differences after applying a 5×5 median filter.
 * 5. When you are optimizing image preprocessing for computer‑vision models and require a quick C# method to assess noise‑reduction impact.
 */
