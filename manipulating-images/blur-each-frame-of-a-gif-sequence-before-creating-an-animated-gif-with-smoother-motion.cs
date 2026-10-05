// HOW-TO: Apply Gaussian Blur to Each Frame of a GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string outputPath = "output\\animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    using (Aspose.Imaging.RasterImage frame = (Aspose.Imaging.RasterImage)gif.ActiveFrame)
                    {
                        frame.Filter(frame.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                    }
                }

                GifOptions gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When you need to soften motion artifacts in an animated GIF by applying a Gaussian blur to every frame before publishing it online.
 * 2. When creating a stylized animated thumbnail where each frame requires a consistent blur effect using Aspose.Imaging in a C# application.
 * 3. When preprocessing GIF frames for a video‑to‑GIF conversion pipeline to reduce sharp edges and improve visual smoothness.
 * 4. When generating privacy‑preserving animated memes that blur faces or details in each frame while keeping the animation intact.
 * 5. When building a C# tool that automatically enhances user‑uploaded GIFs by applying a uniform blur filter to all frames before saving.
 */
