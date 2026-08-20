// HOW-TO: Apply 5x5 Median Blur to PNG and Measure Noise Reduction in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\noisy_input.png";
            string outputPath = @"C:\Images\filtered_output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load original image for assessment
            using (Image originalImg = Image.Load(inputPath))
            {
                // Load a separate copy to apply the median filter
                using (Image filteredImg = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering functionality
                    RasterImage originalRaster = (RasterImage)originalImg;
                    RasterImage filteredRaster = (RasterImage)filteredImg;

                    // Apply a 5x5 median filter (median blur kernel)
                    var medianOptions = new MedianFilterOptions(5);
                    filteredRaster.Filter(filteredRaster.Bounds, medianOptions);

                    // Save the filtered image
                    filteredRaster.Save(outputPath);

                    // Assess noise reduction effectiveness
                    // Compute average absolute difference per channel between original and filtered images
                    long totalDiff = 0;
                    long pixelCount = (long)originalRaster.Width * originalRaster.Height;

                    for (int y = 0; y < originalRaster.Height; y++)
                    {
                        for (int x = 0; x < originalRaster.Width; x++)
                        {
                            // Get pixel colors from both images
                            var origColor = originalRaster.GetPixel(x, y);
                            var filtColor = filteredRaster.GetPixel(x, y);

                            // Calculate absolute differences for each channel
                            totalDiff += Math.Abs(origColor.R - filtColor.R);
                            totalDiff += Math.Abs(origColor.G - filtColor.G);
                            totalDiff += Math.Abs(origColor.B - filtColor.B);
                            totalDiff += Math.Abs(origColor.A - filtColor.A);
                        }
                    }

                    double avgDiffPerChannel = (double)totalDiff / (pixelCount * 4);
                    Console.WriteLine($"Average absolute difference per channel: {avgDiffPerChannel:F2}");
                    Console.WriteLine("A lower value indicates effective noise reduction.");
                }
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
 * 1. When you need to clean up grainy scanned PNG photos before archiving them, you can use a 5x5 median blur to reduce speckle noise while preserving edges.
 * 2. When preparing PNG assets for a web gallery, applying a median filter helps smooth out compression artifacts without blurring important details.
 * 3. When evaluating the effectiveness of a denoising algorithm, you can compare the original and filtered PNG images by calculating average pixel differences.
 * 4. When integrating image preprocessing into a C# automation pipeline, the Aspose.Imaging median filter can be applied to batch‑process PNG files for downstream computer‑vision tasks.
 * 5. When developing a quality‑control tool for medical imaging, a 5x5 median blur can be used to suppress random noise in PNG scans and quantify the improvement programmatically.
 */
