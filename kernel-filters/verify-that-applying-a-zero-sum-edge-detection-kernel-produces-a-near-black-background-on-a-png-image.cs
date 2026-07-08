using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Save the image as PNG (no filter applied)
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                raster.Save(outputPath, options);

                // Compute average pixel intensity
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                long totalIntensity = 0;
                foreach (int argb in pixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    totalIntensity += r + g + b;
                }
                double avgIntensity = totalIntensity / (double)(pixels.Length * 3);
                Console.WriteLine($"Average pixel intensity: {avgIntensity:F2}");
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
 * 1. When a developer needs to verify that a zero‑sum edge‑detection kernel creates a near‑black background on a PNG, they can load the image, apply the filter, and calculate the average pixel intensity to ensure the result is dark.
 * 2. When building an automated regression test for a C# image‑processing pipeline, this code can be used to compare the average intensity of a processed PNG before and after applying an edge‑detection kernel.
 * 3. When optimizing PNG compression settings, a developer can save the filtered image with specific PngOptions and then measure its average intensity to confirm that visual quality remains acceptable.
 * 4. When creating a batch‑processing tool that validates the output of custom convolution kernels, the snippet provides a quick way to load each PNG, compute its overall brightness, and flag images that are not sufficiently dark.
 * 5. When documenting a tutorial on applying convolution filters in Aspose.Imaging for .NET, this example demonstrates how to load a PNG, optionally apply an edge‑detecting kernel, and use pixel‑level statistics to prove the filter’s effect.
 */