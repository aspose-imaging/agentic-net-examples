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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Measure brightness before filter
                int[] pixelsBefore = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double brightnessBefore = 0;
                foreach (int pixel in pixelsBefore)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    brightnessBefore += (r + g + b) / 3.0;
                }
                brightnessBefore /= pixelsBefore.Length;
                Console.WriteLine($"Average brightness before filter: {brightnessBefore:F2}");

                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Measure brightness after filter
                int[] pixelsAfter = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double brightnessAfter = 0;
                foreach (int pixel in pixelsAfter)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    brightnessAfter += (r + g + b) / 3.0;
                }
                brightnessAfter /= pixelsAfter.Length;
                Console.WriteLine($"Average brightness after filter: {brightnessAfter:F2}");

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
 * 1. When a developer needs to verify that applying the Aspose.Imaging Emboss3x3 convolution filter to a PNG image does not unintentionally darken or brighten the picture, they can measure average brightness before and after the filter.
 * 2. When building an automated C# image‑processing pipeline that adds artistic emboss effects while maintaining consistent exposure across batches, this code can compare the brightness of the original and embossed output.
 * 3. When creating a quality‑control test for an application that generates embossed thumbnails using Aspose.Imaging, the brightness comparison ensures the filter preserves visual balance.
 * 4. When integrating the Emboss3x3 filter into a photo‑editing tool and needing to display a numeric brightness metric to users, the sample demonstrates how to calculate and log the average RGB intensity.
 * 5. When troubleshooting why a series of JPEG or PNG files appear too dark after a convolution operation, a developer can use this code to isolate whether the Emboss3x3 filter is the cause by measuring pre‑ and post‑filter brightness.
 */