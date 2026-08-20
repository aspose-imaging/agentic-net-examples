// HOW-TO: Apply Magic Wand Selection to First Frame of GIF and Reassemble Animation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

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

            // Load original GIF to retrieve all frames
            using (GifImage originalGif = (GifImage)Image.Load(inputPath))
            {
                // Load first frame as RasterImage for Magic Wand processing
                using (RasterImage firstFrame = (RasterImage)Image.Load(inputPath))
                {
                    // Apply Magic Wand selection on the first frame
                    MagicWandTool
                        .Select(firstFrame, new MagicWandSettings(10, 10) { Threshold = 100 })
                        .Apply();

                    // Create a GifFrameBlock from the processed first frame
                    using (GifFrameBlock firstBlock = new GifFrameBlock(firstFrame))
                    {
                        // Create a new GIF image with the processed first frame
                        using (GifImage newGif = new GifImage(firstBlock))
                        {
                            // Append remaining frames from the original GIF
                            for (int i = 1; i < originalGif.PageCount; i++)
                            {
                                GifFrameBlock block = (GifFrameBlock)originalGif.Pages[i];
                                newGif.AddBlock(block);
                            }

                            // Save the reassembled GIF animation
                            newGif.Save(outputPath, new GifOptions());
                        }
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
 * 1. When you need to programmatically isolate a region in the first frame of an animated GIF using a tolerance‑based selection and keep the rest of the animation unchanged.
 * 2. When you want to create a custom thumbnail or highlight effect on the initial frame of a GIF without losing subsequent frames.
 * 3. When you are building a web service that processes user‑uploaded GIFs to apply selective masking before storing or streaming them.
 * 4. When you need to batch‑process animated stickers, applying a Magic Wand cut‑out to the first frame while preserving the original animation timing.
 * 5. When you are developing a desktop tool that lets designers quickly remove background colors from the first frame of a GIF while keeping the animation intact.
 */
