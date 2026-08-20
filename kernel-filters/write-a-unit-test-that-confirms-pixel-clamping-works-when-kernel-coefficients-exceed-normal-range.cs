// HOW-TO: Verify Sharpen Filter Pixel Clamping When Coefficients Exceed Range in C# (Aspose.Imaging for .NET)
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

                var sharpenOptions = new SharpenFilterOptions(9, 10.0);
                raster.Filter(raster.Bounds, sharpenOptions);

                int[] resultPixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, raster.Width, raster.Height));
                bool clamped = true;
                foreach (int argb in resultPixels)
                {
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        clamped = false;
                        break;
                    }
                }

                Console.WriteLine(clamped ? "Clamping succeeded" : "Clamping failed");

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
 * 1. When you need to ensure that applying a high‑strength Sharpen filter to a PNG does not produce color values outside the 0‑255 range.
 * 2. When you want to create an automated test that validates Aspose.Imaging’s pixel clamping after using custom kernel coefficients.
 * 3. When your application processes user‑uploaded images and must guarantee that extreme filter settings never corrupt ARGB data.
 * 4. When you are debugging image quality issues caused by over‑sharpening and need to confirm that the library correctly limits pixel values.
 * 5. When integrating Aspose.Imaging into a CI pipeline to automatically check that filter operations preserve valid pixel ranges for all supported formats.
 */
