// HOW-TO: Apply Sharpen and Median Filters to PNG and Verify Checksums in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.png";
            string outputSharpenPath = "Output/sample_sharpen.png";
            string outputMedianPath = "Output/sample_median.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputSharpenPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputMedianPath));

            // Process Sharpen filter
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                rasterImage.Save(outputSharpenPath);
            }

            // Process Median filter
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                rasterImage.Save(outputMedianPath);
            }

            // Compute simple checksum for verification
            byte[] sharpenBytes = File.ReadAllBytes(outputSharpenPath);
            long sharpenChecksum = sharpenBytes.Aggregate(0L, (acc, b) => acc + b);

            byte[] medianBytes = File.ReadAllBytes(outputMedianPath);
            long medianChecksum = medianBytes.Aggregate(0L, (acc, b) => acc + b);

            // Expected checksum values (replace with actual expected values)
            long expectedSharpenChecksum = 1234567890L;
            long expectedMedianChecksum = 987654321L;

            // Compare and report results
            if (sharpenChecksum == expectedSharpenChecksum)
                Console.WriteLine("Sharpen filter output matches expected checksum.");
            else
                Console.WriteLine($"Sharpen filter checksum mismatch. Got {sharpenChecksum}, expected {expectedSharpenChecksum}.");

            if (medianChecksum == expectedMedianChecksum)
                Console.WriteLine("Median filter output matches expected checksum.");
            else
                Console.WriteLine($"Median filter checksum mismatch. Got {medianChecksum}, expected {expectedMedianChecksum}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to enhance a PNG image by sharpening edges and then compare the result to a known good output using a checksum.
 * 2. When you want to reduce noise in a raster image with a median filter and validate the processed file programmatically.
 * 3. When automated tests must confirm that applying specific filter parameters produces consistent image data across builds.
 * 4. When a CI pipeline requires generating filtered versions of an input image and checking their integrity before deployment.
 * 5. When integrating Aspose.Imaging into a C# application to process user‑uploaded images and ensure the output matches expected hash values.
 */
