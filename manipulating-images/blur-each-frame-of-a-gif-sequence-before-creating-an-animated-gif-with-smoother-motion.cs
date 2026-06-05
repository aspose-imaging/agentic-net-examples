using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output\\blurred.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image img = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)img;

                // Apply Gaussian blur to each frame
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the active frame
                    gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[i];

                    // Apply Gaussian blur filter (radius 5, sigma 4.0)
                    gif.Filter(gif.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                }

                // Save the blurred animated GIF
                gif.Save(outputPath);
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
 * 1. When creating an animated GIF from a series of photos for a website banner, a developer may blur each frame to soften transitions and reduce visual noise.
 * 2. When generating a GIF preview of a video clip in a mobile app, applying a Gaussian blur to each frame can produce smoother motion and hide compression artifacts.
 * 3. When preparing a GIF for social media marketing that contains sensitive background details, a developer can blur each frame to protect privacy while keeping the main subject clear.
 * 4. When converting a high‑resolution screen capture sequence into an animated GIF for documentation, blurring each frame helps lower the file size and creates a more fluid animation.
 * 5. When building an interactive e‑learning module that uses animated GIFs to illustrate concepts, a developer might blur each frame to achieve a subtle motion‑blur effect that guides the learner’s focus.
 */