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
            string inputPath = "input.png";
            string outputPath = "output.png";

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
                int[] beforePixel = raster.LoadArgb32Pixels(centerRect);

                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var convOptions = new ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, convOptions);

                int[] afterPixel = raster.LoadArgb32Pixels(centerRect);

                Console.WriteLine($"Before ARGB: 0x{beforePixel[0]:X8}");
                Console.WriteLine($"After ARGB: 0x{afterPixel[0]:X8}");

                if (beforePixel[0] != afterPixel[0])
                {
                    Console.WriteLine("Pixel value changed after edge detection.");
                }
                else
                {
                    Console.WriteLine("Pixel value unchanged.");
                }

                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to verify that applying a 3×3 edge‑detection convolution filter changes the central pixel of a PNG image for quality‑control testing.
 * 2. When a developer wants to log the before‑and‑after ARGB values of a specific raster pixel to debug an image‑processing pipeline in C# using Aspose.Imaging.
 * 3. When a developer must compare pixel intensity changes after applying an edge‑detection kernel to detect features in medical scans saved as PNG files.
 * 4. When a developer is building an automated regression test that ensures a custom edge‑detection filter produces consistent central‑pixel results across image versions.
 * 5. When a developer needs to extract and record pixel differences to generate a change‑report for surveillance footage processed with a convolution filter.
 */