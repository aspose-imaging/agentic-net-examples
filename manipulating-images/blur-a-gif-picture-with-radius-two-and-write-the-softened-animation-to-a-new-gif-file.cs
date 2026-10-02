// HOW-TO: Blur a GIF with Gaussian Radius 2 and Save in C# (Aspose.Imaging for .NET)
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

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[i];
                    RasterImage frame = (RasterImage)gif.ActiveFrame;
                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 1.0);
                    frame.Filter(frame.Bounds, blurOptions);
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
 * 1. When you need to soften a looping GIF animation for a website banner without changing its frame count, you can apply a Gaussian blur of radius two using Aspose.Imaging in C#.
 * 2. When creating a privacy‑preserving preview of an animated GIF, developers can blur each frame before saving the new GIF file.
 * 3. When preparing animated GIF assets for a mobile app that requires a subtle visual effect, you can programmatically apply a radius‑2 blur to all frames with Aspose.Imaging.
 * 4. When an e‑learning platform wants to highlight focus areas by de‑emphasizing background motion in GIF tutorials, this code blurs the entire animation while preserving timing.
 * 5. When automating a batch process that reduces visual noise in user‑generated GIFs, you can use the Gaussian blur filter on each frame and output a softened GIF.
 */
