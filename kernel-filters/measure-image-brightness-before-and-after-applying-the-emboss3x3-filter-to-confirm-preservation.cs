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
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Measure brightness before filter
                int[] pixelsBefore = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumBefore = 0;
                foreach (int argb in pixelsBefore)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    sumBefore += (r + g + b) / 3.0;
                }
                double avgBrightnessBefore = sumBefore / pixelsBefore.Length;
                Console.WriteLine($"Average brightness before: {avgBrightnessBefore}");

                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Measure brightness after filter
                int[] pixelsAfter = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double sumAfter = 0;
                foreach (int argb in pixelsAfter)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    sumAfter += (r + g + b) / 3.0;
                }
                double avgBrightnessAfter = sumAfter / pixelsAfter.Length;
                Console.WriteLine($"Average brightness after: {avgBrightnessAfter}");

                // Save the filtered image
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
 * 1. When a developer needs to verify that applying an Emboss3x3 convolution filter to a PNG image does not unintentionally darken or brighten the picture, they can use this code to compute average brightness before and after the filter.
 * 2. When building an automated image‑processing pipeline in C# that applies artistic effects while preserving overall exposure, the sample shows how to load a raster image, cache data, and compare brightness metrics.
 * 3. When creating a quality‑control test for a photo‑editing application that supports multiple file formats such as PNG, JPEG, or BMP, this snippet demonstrates measuring pixel luminance to ensure the emboss effect maintains visual consistency.
 * 4. When debugging a custom filter implementation in Aspose.Imaging for .NET and needing a quick way to log the average RGB brightness of the source and filtered images, the code provides a straightforward console output.
 * 5. When generating documentation or tutorials that illustrate the impact of convolution filters on image luminance, developers can reuse this example to show how to retrieve ARGB32 pixels, calculate mean brightness, and confirm the filter’s effect on a raster image.
 */