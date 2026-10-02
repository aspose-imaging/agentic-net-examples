// HOW-TO: Extract Each Frame From Animated GIF and Save As PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/animated.gif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pngOptions = new PngOptions())
                    {
                        gif.Save(outputPath, pngOptions);
                    }
                }
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
 * 1. When you need to break down an animated GIF into individual PNG images for further editing or analysis.
 * 2. When you want to generate thumbnail previews for each frame of a GIF to display in a gallery.
 * 3. When you are converting GIF animation frames to PNG to preserve transparency for use in UI components.
 * 4. When you need to extract frames from a GIF to create a sprite sheet or video sequence in a game.
 * 5. When you are processing GIF frames server‑side to store them as separate files for archival or compliance purposes.
 */
