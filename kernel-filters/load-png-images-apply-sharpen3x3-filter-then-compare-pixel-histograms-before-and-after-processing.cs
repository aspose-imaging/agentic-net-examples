using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_sharpened.png";

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
            // Cast to RasterImage for pixel access and filtering
            RasterImage raster = (RasterImage)image;

            // Compute histogram before processing
            int[] beforeHistogram = ComputeLuminanceHistogram(raster);

            // Apply Sharpen 3x3 filter (kernel size 3, sigma 1.0)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(3, 1.0));

            // Compute histogram after processing
            int[] afterHistogram = ComputeLuminanceHistogram(raster);

            // Save the processed image
            raster.Save(outputPath);

            // Output histograms to console
            Console.WriteLine("Histogram before sharpening:");
            PrintHistogram(beforeHistogram);

            Console.WriteLine("\nHistogram after sharpening:");
            PrintHistogram(afterHistogram);
        }
    }

    // Computes a 256-bin luminance histogram for the given raster image
    private static int[] ComputeLuminanceHistogram(RasterImage raster)
    {
        int[] histogram = new int[256];
        int[] argbPixels = raster.LoadArgb32Pixels(raster.Bounds);

        foreach (int argb in argbPixels)
        {
            // Extract RGB components
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = argb & 0xFF;

            // Compute luminance using Rec. 601 luma formula
            int lum = (int)(0.299 * r + 0.587 * g + 0.114 * b);
            histogram[lum]++;
        }

        return histogram;
    }

    // Prints a simple representation of the histogram
    private static void PrintHistogram(int[] histogram)
    {
        for (int i = 0; i < histogram.Length; i++)
        {
            if (histogram[i] > 0)
            {
                Console.WriteLine($"{i}: {histogram[i]}");
            }
        }
    }
}