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
            string inputPath = "input.png";
            string outputPath = "output_median5.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load original image for metric calculation
            using (Image originalImage = Image.Load(inputPath))
            {
                // Load image to be filtered (a separate instance)
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a 5x5 median filter
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }

                // Assess noise reduction effectiveness
                // Compute average absolute per‑channel difference between original and filtered image
                using (Image filteredImage = Image.Load(outputPath))
                {
                    RasterImage origRaster = (RasterImage)originalImage;
                    RasterImage filtRaster = (RasterImage)filteredImage;

                    long totalDiff = 0;
                    long pixelCount = 0;

                    for (int y = 0; y < origRaster.Height; y++)
                    {
                        for (int x = 0; x < origRaster.Width; x++)
                        {
                            var origColor = origRaster.GetPixel(x, y);
                            var filtColor = filtRaster.GetPixel(x, y);

                            totalDiff += Math.Abs(origColor.R - filtColor.R);
                            totalDiff += Math.Abs(origColor.G - filtColor.G);
                            totalDiff += Math.Abs(origColor.B - filtColor.B);
                            totalDiff += Math.Abs(origColor.A - filtColor.A);
                            pixelCount++;
                        }
                    }

                    double avgDiff = (double)totalDiff / (pixelCount * 4);
                    Console.WriteLine($"Average per‑channel absolute difference: {avgDiff:F2}");
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
 * 1. When a developer needs to reduce salt‑and‑pepper noise in a PNG photograph using a 5×5 median blur filter with Aspose.Imaging for .NET.
 * 2. When a C# application must preprocess scanned documents before OCR by applying a median filter to smooth pixel variations while preserving edges.
 * 3. When an image‑processing pipeline requires evaluating the effectiveness of a noise‑reduction algorithm by comparing per‑channel differences between the original and filtered PNG images.
 * 4. When a software solution has to batch‑process PNG assets and automatically create denoised versions for web delivery using Aspose.Imaging’s MedianFilterOptions.
 * 5. When a developer wants to validate that a custom image filter improves visual quality by measuring average absolute pixel differences after applying a 5×5 median blur in a .NET environment.
 */