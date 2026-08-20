// HOW-TO: Measure Image Luminance Before and After Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Calculates average luminance (simple average of R, G, B) of a raster image
    static double CalculateAverageLuminance(RasterImage raster)
    {
        long sum = 0;
        int pixelCount = raster.Width * raster.Height;

        for (int y = 0; y < raster.Height; y++)
        {
            for (int x = 0; x < raster.Width; x++)
            {
                var color = raster.GetPixel(x, y);
                // Simple luminance approximation: average of R, G, B
                sum += (color.R + color.G + color.B) / 3;
            }
        }

        return (double)sum / pixelCount;
    }

    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Measure brightness before applying filter
                double beforeLuminance = CalculateAverageLuminance(raster);
                Console.WriteLine($"Average luminance before filter: {beforeLuminance:F2}");

                // Apply custom Gaussian blur (radius 5, sigma 4.0)
                var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, gaussianOptions);

                // Measure brightness after applying filter
                double afterLuminance = CalculateAverageLuminance(raster);
                Console.WriteLine($"Average luminance after filter: {afterLuminance:F2}");

                // Save the processed image
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
 * 1. When you need to verify that applying a Gaussian blur to a PNG does not unintentionally darken or brighten the image, you can calculate average luminance before and after the filter.
 * 2. When building an automated photo‑editing pipeline that must maintain consistent brightness across processed images, this code lets you measure and adjust luminance after each blur operation.
 * 3. When performing quality‑control on scanned documents, you can use the routine to ensure that the blur used for noise reduction preserves the original text readability by checking luminance levels.
 * 4. When creating a custom image‑processing library with Aspose.Imaging, you may need to benchmark the visual impact of different Gaussian kernel settings by comparing before‑and‑after luminance.
 * 5. When developing a C# application that dynamically adjusts UI thumbnails, you can use the luminance check to decide whether additional exposure compensation is required after applying the blur.
 */
