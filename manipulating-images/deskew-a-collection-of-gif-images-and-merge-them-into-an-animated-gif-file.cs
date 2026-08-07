using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input GIF paths
            string inputPath1 = "input1.gif";
            string inputPath2 = "input2.gif";
            string inputPath3 = "input3.gif";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Output GIF path
            string outputPath = "output.gif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load and deskew the first GIF
            using (GifImage firstGif = (GifImage)Image.Load(inputPath1))
            {
                // Deskew using NormalizeAngle (no resizing, white background)
                firstGif.NormalizeAngle(false, Color.White);

                // Create output GIF using the first frame block
                GifFrameBlock firstBlock = (GifFrameBlock)firstGif.ActiveFrame;
                using (GifImage outputGif = new GifImage(firstBlock))
                {
                    // Load and deskew remaining GIFs, adding them as pages
                    using (GifImage secondGif = (GifImage)Image.Load(inputPath2))
                    {
                        secondGif.NormalizeAngle(false, Color.White);
                        outputGif.AddPage(secondGif);
                    }

                    using (GifImage thirdGif = (GifImage)Image.Load(inputPath3))
                    {
                        thirdGif.NormalizeAngle(false, Color.White);
                        outputGif.AddPage(thirdGif);
                    }

                    // Prepare GIF save options (default)
                    GifOptions gifOptions = new GifOptions();

                    // Save the animated GIF
                    outputGif.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to correct the orientation of scanned GIF frames and combine them into a single animated GIF for a web slideshow, they can use this Aspose.Imaging C# code to deskew each image and merge them.
 * 2. When an e‑learning platform must generate animated GIF tutorials from a series of hand‑drawn GIF sketches that are slightly tilted, the code provides a quick way to normalize angles and create a smooth animation.
 * 3. When a marketing automation script has to batch‑process product GIFs captured from different cameras, deskew them, and bundle them into a promotional animated GIF, this example shows the required C# operations.
 * 4. When a mobile app backend needs to receive user‑uploaded GIF stickers that may be skewed, correct them server‑side, and output a single animated GIF for sharing, the Aspose.Imaging workflow handles the deskew and merging.
 * 5. When a digital archivist wants to preserve a sequence of historical GIF photographs that are misaligned, the code enables deskewing each frame and assembling them into an animated GIF for online exhibition.
 */