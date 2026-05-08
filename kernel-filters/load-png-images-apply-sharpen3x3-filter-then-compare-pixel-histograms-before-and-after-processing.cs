using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load PNG image as RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Compute histogram before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] beforeHistogram = ComputeGrayscaleHistogram(beforePixels);

                // Apply Sharpen filter (default SharpenFilterOptions corresponds to 3x3 kernel)
                raster.Filter(raster.Bounds, new SharpenFilterOptions());

                // Save the processed image
                raster.Save(outputPath);

                // Compute histogram after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                int[] afterHistogram = ComputeGrayscaleHistogram(afterPixels);

                // Output histograms
                Console.WriteLine("Histogram before sharpening:");
                PrintHistogram(beforeHistogram);

                Console.WriteLine("\nHistogram after sharpening:");
                PrintHistogram(afterHistogram);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Computes a grayscale histogram (256 bins) from ARGB pixel array
    static int[] ComputeGrayscaleHistogram(int[] argbPixels)
    {
        int[] histogram = new int[256];
        foreach (int argb in argbPixels)
        {
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;
            int gray = (r + g + b) / 3;
            histogram[gray]++;
        }
        return histogram;
    }

    // Prints non-zero histogram entries
    static void PrintHistogram(int[] histogram)
    {
        for (int i = 0; i < histogram.Length; i++)
        {
            if (histogram[i] > 0)
            {
                Console.WriteLine($"Gray {i}: {histogram[i]}");
            }
        }
    }
}