using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputFolder = "Frames";
            Directory.CreateDirectory(outputFolder);

            using (Image img = Image.Load(inputPath))
            {
                GifImage gif = img as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The input file is not a GIF image.");
                    return;
                }

                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    string outputPath = Path.Combine(outputFolder, $"frame_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    gif.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract each frame from an animated GIF to create individual PNG images for use in a web carousel or slideshow.
 * 2. When a developer wants to convert GIF animation frames into high‑quality PNG files for further editing in graphic design tools.
 * 3. When a developer must generate separate PNG assets from a GIF to apply per‑frame watermarking or branding.
 * 4. When a developer is building a thumbnail preview system that requires saving each GIF frame as a PNG to display step‑by‑step animation.
 * 5. When a developer needs to archive or analyze the individual frames of a GIF by exporting them as PNG files for machine‑learning image classification.
 */