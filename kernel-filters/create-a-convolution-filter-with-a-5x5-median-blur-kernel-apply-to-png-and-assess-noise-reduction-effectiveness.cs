using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\noisy.png";
            string outputPath = @"C:\Images\noisy_median5x5.png";

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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Compute average intensity before filtering
                double avgBefore = ComputeAverageIntensity(rasterImage);

                // Apply a 5x5 median filter (median blur kernel)
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Compute average intensity after filtering
                double avgAfter = ComputeAverageIntensity(rasterImage);

                // Save the filtered image
                rasterImage.Save(outputPath);

                // Output simple noise‑reduction assessment
                Console.WriteLine($"Average intensity before filter: {avgBefore:F2}");
                Console.WriteLine($"Average intensity after filter:  {avgAfter:F2}");
                Console.WriteLine("A reduction in intensity variance typically indicates noise reduction.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method to compute average pixel intensity (simple metric)
    private static double ComputeAverageIntensity(RasterImage raster)
    {
        long sum = 0;
        int width = raster.Width;
        int height = raster.Height;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // GetPixel returns a Color structure with R, G, B components
                var color = raster.GetPixel(x, y);
                int intensity = (color.R + color.G + color.B) / 3;
                sum += intensity;
            }
        }

        return (double)sum / (width * height);
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce salt‑and‑pepper noise in scanned PNG documents before performing OCR, they can apply a 5×5 median blur filter using Aspose.Imaging for .NET.
 * 2. When a C# application must clean up noisy screenshots captured from remote desktops while preserving the PNG format, the code shows how to load, filter with MedianFilterOptions(5), and save the image.
 * 3. When a photo‑editing tool requires an automated step to smooth grainy product images yet retain edge detail, the median filter implementation provides a simple way to assess noise reduction by comparing average pixel intensity.
 * 4. When a batch‑processing service handles medical imaging PNG files and needs to evaluate the effectiveness of noise removal, the example demonstrates computing average intensity before and after applying the 5×5 median kernel.
 * 5. When a developer is building a quality‑control pipeline that validates image preprocessing by measuring intensity variance, this snippet illustrates using Aspose.Imaging to load, filter, and report intensity changes on PNG assets.
 */