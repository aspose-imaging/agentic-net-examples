// HOW-TO: Apply Average Convolution Filter to PNG Template and Verify Smoothing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output/smoothed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                Rectangle bounds = raster.Bounds;

                int[] beforePixels = raster.LoadArgb32Pixels(bounds);

                double[,] kernel = new double[3, 3]
                {
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                };

                raster.Filter(bounds, new ConvolutionFilterOptions(kernel));

                int[] afterPixels = raster.LoadArgb32Pixels(bounds);

                double sumDiffBefore = 0;
                double sumDiffAfter = 0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width - 1; x++)
                    {
                        int idx = y * width + x;
                        int idxRight = idx + 1;

                        int p1 = beforePixels[idx];
                        int p2 = beforePixels[idxRight];
                        int p3 = afterPixels[idx];
                        int p4 = afterPixels[idxRight];

                        double intensity1 = ((p1 >> 16) & 0xFF) + ((p1 >> 8) & 0xFF) + (p1 & 0xFF);
                        double intensity2 = ((p2 >> 16) & 0xFF) + ((p2 >> 8) & 0xFF) + (p2 & 0xFF);
                        double intensity3 = ((p3 >> 16) & 0xFF) + ((p3 >> 8) & 0xFF) + (p3 & 0xFF);
                        double intensity4 = ((p4 >> 16) & 0xFF) + ((p4 >> 8) & 0xFF) + (p4 & 0xFF);

                        sumDiffBefore += Math.Abs(intensity1 - intensity2);
                        sumDiffAfter += Math.Abs(intensity3 - intensity4);
                    }
                }

                Console.WriteLine($"Total horizontal intensity difference before smoothing: {sumDiffBefore}");
                Console.WriteLine($"Total horizontal intensity difference after smoothing: {sumDiffAfter}");

                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to smooth a PNG template image before compositing it with other graphics in a C# application.
 * 2. When you want to reduce visual noise in a scanned PNG document by applying a simple averaging kernel.
 * 3. When you must programmatically confirm that a convolution filter produces uniform smoothing across all pixels of an image.
 * 4. When you are preparing PNG assets for a machine‑learning pipeline and require consistent neighboring pixel intensities.
 * 5. When you need to generate a smoothed version of a template for printing or web publishing while ensuring the filter was correctly applied.
 */
