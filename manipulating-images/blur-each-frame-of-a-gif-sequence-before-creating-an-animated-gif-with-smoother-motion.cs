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
            string outputPath = "output/blurred.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

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
 * 1. When a developer wants to reduce visual noise in each frame of an animated GIF before publishing it on a website, they can use this code to apply a Gaussian blur to every frame and save a smoother‑motion GIF.
 * 2. When creating a GIF preview for a mobile app where bandwidth is limited, a developer can blur each frame to soften details and then save the animated GIF with reduced perceived flicker.
 * 3. When generating a stylized slideshow GIF from a series of photographs, a developer can use this code to apply a consistent blur filter across all frames, giving the animation a cohesive soft‑focus effect.
 * 4. When processing user‑uploaded GIFs for a social‑media platform to comply with content guidelines, a developer can automatically blur each frame to obscure sensitive details before storing the animated GIF.
 * 5. When building a diagnostic tool that visualizes motion blur in video frames converted to GIF, a developer can employ this code to programmatically apply a Gaussian blur to each frame and export the result as an animated GIF for analysis.
 */