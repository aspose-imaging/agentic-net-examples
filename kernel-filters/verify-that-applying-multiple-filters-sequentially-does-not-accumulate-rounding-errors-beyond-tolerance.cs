// HOW-TO: Verify Sequential Image Filters Do Not Accumulate Rounding Errors In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the original image to obtain baseline pixel data
            using (Image originalImage = Image.Load(inputPath))
            {
                RasterImage originalRaster = (RasterImage)originalImage;
                int[] originalPixels = originalRaster.GetDefaultArgb32Pixels(originalRaster.Bounds);

                // Load a fresh copy for sequential filtering
                using (Image filteredImage = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)filteredImage;

                    // Apply multiple filters sequentially
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0));
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save the filtered image
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);

                    // Retrieve filtered pixel data
                    int[] filteredPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                    // Compute average absolute per‑channel difference
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

                    double avgDiff = (double)totalDiff / (originalPixels.Length * 4);
                    double tolerance = 0.5; // Example tolerance value

                    Console.WriteLine($"Average per‑channel difference: {avgDiff:F3}");
                    if (avgDiff <= tolerance)
                    {
                        Console.WriteLine("Rounding error within tolerance.");
                    }
                    else
                    {
                        Console.WriteLine("Rounding error exceeds tolerance.");
                    }
                }
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
 * 1. When you need to ensure that applying a median filter, Gaussian blur, and sharpen filter one after another on a PNG does not introduce noticeable rounding errors, this code lets you compare original and processed pixel values.
 * 2. When performing automated quality‑control tests for an image‑processing service built with Aspose.Imaging for .NET, you can use this example to validate that sequential filters preserve color fidelity within a defined tolerance.
 * 3. When developing a photo‑editing application that chains multiple filters, you can run this snippet to confirm that the cumulative effect does not degrade image data beyond acceptable limits.
 * 4. When creating a CI/CD pipeline for image‑conversion jobs, this code helps verify that each filter step produces consistent ARGB32 pixel results across builds.
 * 5. When troubleshooting discrepancies between expected and actual output after applying filters to PNG files, the example provides a straightforward way to measure per‑channel differences and detect rounding issues.
 */
