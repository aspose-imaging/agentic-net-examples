using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\template.png";
            string outputPath = @"C:\temp\smoothed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Compute average color before smoothing
                double[] avgBefore = ComputeAverageColor(rasterImage);

                // Apply a simple averaging kernel (3x3 box blur) using GaussianBlurFilterOptions
                // Radius 1 and sigma 1.0 produce a uniform smoothing effect similar to averaging neighbors
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(1, 1.0));

                // Compute average color after smoothing
                double[] avgAfter = ComputeAverageColor(rasterImage);

                // Save the processed image
                rasterImage.Save(outputPath);

                // Output verification information
                Console.WriteLine($"Average color before smoothing: R={avgBefore[0]:F2}, G={avgBefore[1]:F2}, B={avgBefore[2]:F2}");
                Console.WriteLine($"Average color after smoothing:  R={avgAfter[0]:F2}, G={avgAfter[1]:F2}, B={avgAfter[2]:F2}");
                Console.WriteLine("Smoothing applied successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute the average RGB values of a RasterImage
    private static double[] ComputeAverageColor(RasterImage raster)
    {
        long sumR = 0, sumG = 0, sumB = 0;
        int width = raster.Width;
        int height = raster.Height;
        long totalPixels = (long)width * height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // GetPixel returns Aspose.Imaging.Color
                Aspose.Imaging.Color color = raster.GetPixel(x, y);
                sumR += color.R;
                sumG += color.G;
                sumB += color.B;
            }
        }

        return new double[]
        {
            sumR / (double)totalPixels,
            sumG / (double)totalPixels,
            sumB / (double)totalPixels
        };
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to smooth a PNG template before overlaying dynamic graphics to avoid harsh edges.
 * 2. When a C# application must preprocess scanned PNG documents with a uniform box blur to improve OCR accuracy.
 * 3. When an image‑processing pipeline requires verifying that a Gaussian blur filter produces consistent average color changes across PNG assets.
 * 4. When a game UI generator wants to apply a subtle blur to PNG button backgrounds to create a soft visual effect while preserving the file format.
 * 5. When a reporting tool needs to automatically reduce noise in PNG charts by applying a 3×3 averaging kernel and then confirm the smoothing result programmatically.
 */