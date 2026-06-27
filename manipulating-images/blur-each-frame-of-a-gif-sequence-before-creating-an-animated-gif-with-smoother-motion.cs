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

                gif.Save(outputPath, new GifOptions());
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
 * 1. When creating an animated GIF for a website banner and you want to soften fast‑moving objects to reduce visual strain, you can use this C# code with Aspose.Imaging to apply a Gaussian blur to every frame before saving.
 * 2. When generating privacy‑preserving GIFs from surveillance footage, developers can blur each frame using Aspose.Imaging’s GaussianBlurFilterOptions to obscure faces while retaining motion.
 * 3. When preparing a GIF slideshow for a mobile app where smooth transitions are required, applying a blur filter to each frame with Aspose.Imaging helps achieve a more fluid visual effect.
 * 4. When converting a series of raw images into an animated GIF and need to reduce noise or grain in each frame, the code demonstrates how to load, blur, and save the GIF using C# and Aspose.Imaging.
 * 5. When building a social‑media sharing tool that automatically adds a subtle motion‑blur effect to user‑uploaded GIFs, this Aspose.Imaging example shows how to process each frame and export the result with GifOptions.
 */