// HOW-TO: Validate PNG Pixel Values After Applying Custom Convolution Kernel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] customKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool allInRange = true;
                foreach (int argb in pixels)
                {
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        allInRange = false;
                        break;
                    }
                }

                if (!allInRange)
                {
                    Console.Error.WriteLine("Pixel values out of 0-255 range detected.");
                }
                else
                {
                    Console.WriteLine("All pixel values are within the 0-255 range.");
                }

                var saveOptions = new PngOptions();
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
 * 1. When you need to ensure that a PNG image processed with a custom convolution filter does not produce out‑of‑range color values that could corrupt the file.
 * 2. When you want to verify that applying edge‑enhancement or sharpening kernels to raster images in a C# application keeps all ARGB components within the 0‑255 range.
 * 3. When building an automated image‑processing pipeline that must detect and reject images with invalid pixel data after applying user‑defined filters.
 * 4. When debugging a graphics algorithm that modifies pixel intensities and you need a quick check that the resulting PNG can be displayed correctly in browsers.
 * 5. When integrating Aspose.Imaging into a .NET service that processes uploaded PNGs and must guarantee safe pixel values before saving them to storage.
 */
