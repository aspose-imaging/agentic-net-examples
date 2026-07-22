using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Compute average luminance as the mean of the R, G, B components of all pixels.
    static double ComputeAverageLuminance(RasterImage rasterImage)
    {
        long sum = 0;
        int width = rasterImage.Width;
        int height = rasterImage.Height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // GetPixel returns an Aspose.Imaging.Color structure.
                var color = rasterImage.GetPixel(x, y);
                // Simple luminance approximation: average of R, G, B.
                sum += (color.R + color.G + color.B) / 3;
            }
        }

        return (double)sum / (width * height);
    }

    static void Main()
    {
        try
        {
            // Hardcoded input and output paths.
            string inputPath = @"c:\temp\sample.png";
            string outputPath = @"c:\temp\sample.GaussianBlur.png";

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel access and filtering.
                RasterImage rasterImage = (RasterImage)image;

                // Measure brightness before filtering.
                double beforeLuminance = ComputeAverageLuminance(rasterImage);
                Console.WriteLine($"Average luminance before filter: {beforeLuminance:F2}");

                // Apply a custom Gaussian blur filter (radius 5, sigma 4.0).
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Measure brightness after filtering.
                double afterLuminance = ComputeAverageLuminance(rasterImage);
                Console.WriteLine($"Average luminance after filter: {afterLuminance:F2}");

                // Save the filtered image.
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to verify that a PNG thumbnail generated with a Gaussian blur retains the same average luminance as the original for consistent UI brightness.
 * 2. When an image‑processing pipeline for JPEG photos must ensure that applying a custom Gaussian kernel (radius 5, sigma 4.0) does not unintentionally darken or brighten the image before saving to a web‑optimized folder.
 * 3. When a medical imaging application using C# and Aspose.Imaging must compare pre‑ and post‑filter luminance of DICOM‑converted PNG scans to maintain diagnostic visibility after noise reduction.
 * 4. When an automated batch script processes a folder of BMP assets and needs to log the average RGB luminance before and after applying a Gaussian blur to guarantee uniform visual appearance across game textures.
 * 5. When a developer integrates a custom Gaussian blur into a PDF conversion workflow and wants to measure the average luminance of the rasterized page image to keep printed output brightness consistent.
 */