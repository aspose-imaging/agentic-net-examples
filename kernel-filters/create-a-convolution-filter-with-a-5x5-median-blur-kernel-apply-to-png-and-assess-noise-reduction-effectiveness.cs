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
            string inputPath = @"C:\Images\noisy.png";
            string outputPath = @"C:\Images\noisy_median.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load original image for quality assessment
            using (Image originalImg = Image.Load(inputPath))
            {
                // Load a second copy for filtering
                using (Image filteredImg = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering and pixel data
                    RasterImage originalRaster = (RasterImage)originalImg;
                    RasterImage filteredRaster = (RasterImage)filteredImg;

                    // Apply a 5x5 median filter (median blur kernel)
                    filteredRaster.Filter(filteredRaster.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image
                    filteredRaster.Save(outputPath);

                    // Assess noise reduction effectiveness
                    // Compute average absolute difference per channel between original and filtered images
                    long totalDiff = 0;
                    int width = originalRaster.Width;
                    int height = originalRaster.Height;
                    int pixelCount = width * height;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            var origColor = originalRaster.GetPixel(x, y);
                            var filtColor = filteredRaster.GetPixel(x, y);

                            totalDiff += Math.Abs(origColor.R - filtColor.R);
                            totalDiff += Math.Abs(origColor.G - filtColor.G);
                            totalDiff += Math.Abs(origColor.B - filtColor.B);
                            totalDiff += Math.Abs(origColor.A - filtColor.A);
                        }
                    }

                    double avgDiff = (double)totalDiff / (pixelCount * 4);
                    Console.WriteLine($"Average per-channel absolute difference after median filtering: {avgDiff:F2}");
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
 * 1. When a developer needs to reduce salt‑and‑pepper noise in scanned PNG documents before OCR processing, they can use this 5×5 median blur filter with Aspose.Imaging for .NET.
 * 2. When a C# application must improve the visual quality of noisy screenshots saved as PNG files for a reporting dashboard, the code demonstrates how to apply a median filter and save the cleaned image.
 * 3. When a software engineer wants to compare the effectiveness of a denoising algorithm by computing average absolute pixel differences between the original and filtered PNG images, this example shows the necessary raster operations.
 * 4. When an image‑processing pipeline requires automated batch processing of PNG assets stored on disk, the snippet illustrates loading, filtering, and ensuring output directories exist using Aspose.Imaging.
 * 5. When a developer is building a diagnostic tool that evaluates noise reduction on medical PNG scans, the code provides a practical way to apply a 5×5 median kernel and quantify the improvement per color channel.
 */