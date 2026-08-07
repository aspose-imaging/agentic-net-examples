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
            string inputPath = "input\\input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int width = raster.Width;
                int height = raster.Height;
                int centerX = width / 2;
                int centerY = height / 2;
                var centerRect = new Rectangle(centerX, centerY, 1, 1);

                int[] originalPixel = raster.LoadArgb32Pixels(centerRect);

                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                int[] filteredPixel = raster.LoadArgb32Pixels(centerRect);

                if (originalPixel[0] != filteredPixel[0])
                {
                    Console.WriteLine($"Central pixel changed from 0x{originalPixel[0]:X8} to 0x{filteredPixel[0]:X8}");
                }
                else
                {
                    Console.WriteLine("Central pixel unchanged after edge detection.");
                }

                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to verify that an Aspose.Imaging edge‑detection convolution filter actually modifies the central pixel of a PNG image, this code compares the original and filtered ARGB values and logs the difference.
 * 2. When building an automated quality‑control pipeline for scanned documents, a programmer can use this snippet to ensure the 3×3 edge‑detection kernel affects the middle pixel and report any unexpected unchanged values.
 * 3. When creating a diagnostic tool for image‑processing algorithms in C#, this example captures the exact ARGB32 value of the centre pixel before and after applying a custom convolution filter to a PNG raster image.
 * 4. When troubleshooting visual discrepancies between original and filtered PNG assets in a graphics‑intensive application, this code helps pinpoint whether the central region is being altered by the edge‑detection filter.
 * 5. When implementing a unit test for a .NET service that applies edge detection to raster images, a tester can use this script to assert that the central pixel value changes as expected after the filter execution.
 */