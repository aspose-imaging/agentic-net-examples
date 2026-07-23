using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Apply Gaussian blur to the entire GIF
                gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Configure lossy compression options
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80 // Recommended lossy compression level
                };

                // Save the blurred GIF with lossy compression
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
 * 1. When creating a privacy‑preserving animated meme, a developer can blur the original GIF and then reduce its file size with Aspose.Imaging’s lossy GIF compression to share quickly on social media.
 * 2. When optimizing an animated tutorial for a mobile app, a developer may apply a Gaussian blur to smooth visual noise and then save the result with a MaxDiff setting to meet bandwidth constraints.
 * 3. When preparing a GIF‑based loading indicator for a web page, a developer can use the code to soften the animation and compress it, ensuring faster page load times without noticeable quality loss.
 * 4. When generating a low‑resolution preview of a high‑detail animated advertisement, a developer can blur the frames and apply lossy compression to produce a lightweight GIF that still conveys the motion.
 * 5. When archiving user‑submitted animated content that may contain sensitive details, a developer can automatically blur the GIF and compress it with Aspose.Imaging to protect privacy while minimizing storage usage.
 */