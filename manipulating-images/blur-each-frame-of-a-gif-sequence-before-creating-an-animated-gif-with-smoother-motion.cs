// HOW-TO: Apply Gaussian Blur to Each Frame of a GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image img = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)img;

                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                }

                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When you need to soften the visual noise of each frame in an animated GIF before publishing it on a website.
 * 2. When creating a GIF slideshow where a subtle blur transition improves the perceived motion smoothness.
 * 3. When preparing GIF assets for a mobile app and want to reduce sharp edges to save bandwidth and improve rendering.
 * 4. When automating a batch process that adds a Gaussian blur to every frame of user‑uploaded GIFs to meet brand style guidelines.
 * 5. When integrating Aspose.Imaging in a C# service that generates animated GIFs with a consistent blur effect for marketing emails.
 */
