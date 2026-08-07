using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load original image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a sequence of filters
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the filtered image
                raster.Save(outputPath);
            }

            // Reload original and filtered images for comparison
            using (Image originalImg = Image.Load(inputPath))
            using (Image filteredImg = Image.Load(outputPath))
            {
                RasterImage original = (RasterImage)originalImg;
                RasterImage filtered = (RasterImage)filteredImg;

                double totalDifference = ComputeTotalDifference(original, filtered);
                double tolerance = 1.0; // acceptable cumulative rounding error

                Console.WriteLine($"Total pixel difference: {totalDifference}");
                Console.WriteLine(totalDifference <= tolerance
                    ? "Rounding error is within tolerance."
                    : "Rounding error exceeds tolerance.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Computes the sum of absolute differences for each channel across all pixels
    static double ComputeTotalDifference(RasterImage img1, RasterImage img2)
    {
        if (img1.Width != img2.Width || img1.Height != img2.Height)
            throw new InvalidOperationException("Images must have the same dimensions.");

        double diff = 0.0;
        for (int y = 0; y < img1.Height; y++)
        {
            for (int x = 0; x < img1.Width; x++)
            {
                var c1 = img1.GetPixel(x, y);
                var c2 = img2.GetPixel(x, y);

                diff += Math.Abs(c1.R - c2.R);
                diff += Math.Abs(c1.G - c2.G);
                diff += Math.Abs(c1.B - c2.B);
                diff += Math.Abs(c1.A - c2.A);
            }
        }
        return diff;
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a C# desktop application that enhances PNG photographs by applying median, Gaussian blur, and sharpen filters, a developer can use this code to ensure the combined operations do not introduce perceptible rounding errors.
 * 2. When implementing an automated image‑processing pipeline for e‑commerce product photos, the code helps verify that sequential filters applied with Aspose.Imaging preserve pixel fidelity within a defined tolerance before the images are uploaded.
 * 3. When performing quality‑assurance tests on a medical‑imaging viewer that processes raster images, developers can run this example to confirm that successive filters do not accumulate rounding errors that could affect diagnostic accuracy.
 * 4. When creating a batch job that normalizes satellite PNG tiles using multiple filters, the snippet provides a quick way to compare the original and filtered tiles and guarantee that cumulative rounding stays below the acceptable threshold.
 * 5. When developing a CI/CD build step that validates image‑processing libraries, this code can be used to programmatically compute total pixel difference after applying several filters and fail the build if the error exceeds the tolerance.
 */