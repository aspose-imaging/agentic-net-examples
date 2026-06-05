using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int[] beforePixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double brightnessBefore = beforePixels.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                int radius = 5;
                double sigma = 4.0;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(radius, sigma));

                int[] afterPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
                double brightnessAfter = afterPixels.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                Console.WriteLine($"Brightness before: {brightnessBefore:F2}, after: {brightnessAfter:F2}");

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
 * 1. When a developer needs to verify that applying a custom Gaussian blur to a PNG image does not unintentionally darken or brighten the picture, they can use this code to measure average luminance before and after the filter.
 * 2. When building an automated image‑processing pipeline that must maintain consistent brightness across scanned documents, the code can be used to compare the mean RGB value of the original raster and the blurred output.
 * 3. When optimizing visual quality for a web‑gallery and wants to ensure that the Gaussian kernel (radius 5, sigma 4.0) preserves perceived brightness, the snippet provides a quick C# way to calculate and log the change.
 * 4. When creating a photo‑editing application that offers a “soft‑focus” effect and needs to adjust exposure automatically, developers can employ this example to detect any luminance shift caused by the Aspose.Imaging GaussianBlurFilterOptions.
 * 5. When performing quality‑control on batch‑processed images stored as PNG files, the code lets developers programmatically compare brightness levels to guarantee that the custom blur filter does not violate luminance specifications.
 */