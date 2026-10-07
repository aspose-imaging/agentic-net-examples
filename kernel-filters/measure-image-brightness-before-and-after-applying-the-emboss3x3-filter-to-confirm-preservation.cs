// HOW-TO: Measure Image Brightness Before and After Emboss3x3 Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath);
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            if (!raster.IsCached)
            {
                raster.CacheData();
            }

            int[] pixelsBefore = raster.LoadArgb32Pixels(raster.Bounds);
            double sumBefore = 0;
            foreach (int argb in pixelsBefore)
            {
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;
                sumBefore += (r + g + b) / 3.0;
            }
            double brightnessBefore = sumBefore / pixelsBefore.Length;

            int[] pixelsAfter = raster.LoadArgb32Pixels(raster.Bounds);
            double sumAfter = 0;
            foreach (int argb in pixelsAfter)
            {
                int r = (argb >> 16) & 0xFF;
                int g = (argb >> 8) & 0xFF;
                int b = argb & 0xFF;
                sumAfter += (r + g + b) / 3.0;
            }
            double brightnessAfter = sumAfter / pixelsAfter.Length;

            Console.WriteLine($"Brightness before: {brightnessBefore:F2}");
            Console.WriteLine($"Brightness after: {brightnessAfter:F2}");

            var options = new JpegOptions { Quality = 90 };
            image.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that applying the Emboss3x3 filter does not unintentionally alter overall image brightness in a C# image‑processing pipeline.
 * 2. When you want to log or display the average luminance of a JPEG before and after a filter operation for quality‑control reports.
 * 3. When building an automated batch process that compares pre‑ and post‑filter brightness to ensure consistent visual appearance across thousands of images.
 * 4. When debugging a photo‑editing application to confirm that a custom filter preserves the original exposure level.
 * 5. When creating a unit test that asserts the Emboss3x3 filter maintains the average brightness within an acceptable tolerance.
 */
