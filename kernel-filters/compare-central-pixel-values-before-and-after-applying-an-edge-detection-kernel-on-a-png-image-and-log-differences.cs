// HOW-TO: How To Compare Central Pixel Values Before And After Edge Detection In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.png";
            string outputPath = "output\\sample_edge.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Determine central pixel coordinates
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                Rectangle centerRect = new Rectangle(centerX, centerY, 1, 1);

                // Read central pixel before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(centerRect);

                // Edge‑detection kernel (simple Laplacian)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply the convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Read central pixel after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(centerRect);

                // Log the difference
                if (beforePixels[0] != afterPixels[0])
                {
                    Console.WriteLine($"Central pixel changed from 0x{beforePixels[0]:X8} to 0x{afterPixels[0]:X8}");
                }
                else
                {
                    Console.WriteLine($"Central pixel unchanged: 0x{beforePixels[0]:X8}");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to verify that an edge‑detection filter actually modifies a PNG image by checking the central pixel value in a C# program.
 * 2. When debugging a computer‑vision pipeline and you want to log pixel‑level changes after applying a convolution kernel.
 * 3. When creating automated unit tests to ensure a custom Laplacian filter produces the expected result on sample images.
 * 4. When generating a quality‑control report that highlights differences between the original and processed PNG files in a .NET imaging workflow.
 * 5. When building a diagnostic tool that detects the presence of edges by comparing before‑and‑after pixel values of the image’s center.
 */
