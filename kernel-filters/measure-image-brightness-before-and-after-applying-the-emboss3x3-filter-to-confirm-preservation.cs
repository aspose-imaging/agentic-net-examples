using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output_emboss.png";

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
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
                var options = new PngOptions();
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
 * 1. When a developer wants to verify that applying the Aspose.Imaging ConvolutionFilter.Emboss3x3 to a PNG image does not unintentionally alter the overall brightness, they can use this code to measure average brightness before and after the filter.
 * 2. When building an automated image‑processing pipeline in C# that applies artistic effects while maintaining consistent visual exposure across a batch of raster images, this snippet helps compare brightness levels pre‑ and post‑emboss.
 * 3. When creating a quality‑control test for a photo‑editing application that uses Aspose.Imaging to generate embossed thumbnails, the code provides a simple way to assert that the emboss operation preserves the original image’s luminance.
 * 4. When troubleshooting a client’s complaint that embossed PNG files appear too dark, a developer can run this example to calculate and log the average brightness, confirming whether the filter itself is responsible.
 * 5. When documenting a tutorial on convolution filters in Aspose.Imaging for .NET, the example demonstrates how to load an image, apply the Emboss3x3 filter, and programmatically compare brightness to illustrate that the effect is primarily edge‑enhancement rather than exposure change.
 */