// HOW-TO: Apply Gaussian Blur to BMP Image for Design Mockups in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output\\blurred.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                blurOptions.Radius = 5;
                blurOptions.Sigma = 2.0f;

                image.Filter(image.Bounds, blurOptions);
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to soften the background of a BMP screenshot before embedding it in a UI prototype.
 * 2. When generating blurred placeholders for high‑resolution BMP assets to improve perceived loading speed in web design.
 * 3. When preparing mockup images for print layouts where the foreground must stay sharp while the BMP background is gently blurred.
 * 4. When creating a series of BMP frames with a consistent Gaussian blur effect for a simple animation or transition.
 * 5. When automating the preprocessing of BMP textures in a game‑development pipeline to achieve a depth‑of‑field look without manual editing.
 */
