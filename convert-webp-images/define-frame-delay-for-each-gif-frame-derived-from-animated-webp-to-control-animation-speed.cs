using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load animated WebP
            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                // Ensure there are frames
                if (webp.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Create an empty GIF image using the first frame as a base
                using (RasterImage firstFrame = (RasterImage)webp.Pages[0])
                using (GifFrameBlock firstBlock = new GifFrameBlock(firstFrame))
                using (GifImage gif = new GifImage(firstBlock))
                {
                    // Set delay for the first frame (example: 100 ms)
                    firstBlock.FrameTime = 100;

                    // Process remaining frames
                    for (int i = 1; i < webp.PageCount; i++)
                    {
                        using (RasterImage frame = (RasterImage)webp.Pages[i])
                        using (GifFrameBlock block = new GifFrameBlock(frame))
                        {
                            // Example: set each frame delay to 80 ms
                            block.FrameTime = 80;
                            gif.AddPage(block);
                        }
                    }

                    // Optional: set loop count (0 = infinite)
                    GifOptions gifOptions = new GifOptions
                    {
                        LoopsCount = 0
                    };

                    // Save the GIF
                    gif.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}