// HOW-TO: Apply Gaussian Blur to GIF and Save with Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Apply Gaussian blur to the entire GIF
                gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Set lossy compression options
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // recommended value for lossy compression
                };

                gif.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of an animated GIF for faster web loading while softening its visual appearance.
 * 2. When you want to apply a uniform Gaussian blur to every frame of a GIF before archiving it to hide sensitive details.
 * 3. When creating preview thumbnails of animated content that require both a blurred effect and a smaller storage footprint.
 * 4. When optimizing GIFs for email newsletters where bandwidth is limited and a subtle blur improves readability.
 * 5. When preprocessing GIF animations for machine‑learning pipelines that expect compressed, low‑detail input images.
 */
