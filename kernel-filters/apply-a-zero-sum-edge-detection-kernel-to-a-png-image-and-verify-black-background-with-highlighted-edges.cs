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

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                int topLeftPixel = pixels[0];
                if ((topLeftPixel & 0xFFFFFF) != 0)
                {
                    Console.WriteLine("Verification failed: background pixel is not black.");
                }
                else
                {
                    Console.WriteLine("Verification passed: background is black.");
                }

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to highlight the edges of objects in a PNG photograph for a computer‑vision preprocessing step, they can use Aspose.Imaging’s ConvolutionFilterOptions with a zero‑sum kernel to produce a black background with white edge outlines.
 * 2. When building an automated quality‑control pipeline that checks scanned documents for proper edge detection, the code can apply the kernel and verify that the top‑left pixel remains black, confirming the background was correctly set.
 * 3. When creating visual effects for a web application that requires converting a colored PNG into a stylized line‑art version, the zero‑sum edge detection filter in C# quickly generates the effect while preserving the original image dimensions.
 * 4. When integrating image analysis into a .NET desktop tool that must export processed PNG files, developers can use this snippet to apply the convolution filter and save the result with Aspose.Imaging’s PngOptions.
 * 5. When troubleshooting image‑processing algorithms and needing a reproducible way to confirm that the convolution operation produces a black background with highlighted edges, the verification step in the code provides an immediate pass/fail check.
 */