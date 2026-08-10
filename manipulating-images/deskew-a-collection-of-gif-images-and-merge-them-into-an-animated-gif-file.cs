// HOW-TO: Deskew Multiple GIFs and Combine into Animated GIF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string[] inputPaths = { "input1.gif", "input2.gif", "input3.gif" };
            string outputPath = "output\\merged.gif";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first GIF to initialize the canvas
            using (var firstGif = (GifImage)Image.Load(inputPaths[0]))
            {
                // Deskew the first GIF
                firstGif.NormalizeAngle(false, Color.White);

                // Create a new GIF canvas with the same dimensions
                using (var canvas = new GifImage(new GifFrameBlock((ushort)firstGif.Width, (ushort)firstGif.Height)))
                {
                    // Add the first (deskewed) frame
                    canvas.AddPage(firstGif);

                    // Process remaining GIFs
                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (var gif = (GifImage)Image.Load(inputPaths[i]))
                        {
                            // Deskew each GIF
                            gif.NormalizeAngle(false, Color.White);
                            // Add as a new frame to the animated GIF
                            canvas.AddPage(gif);
                        }
                    }

                    // Save the animated GIF
                    var gifOptions = new GifOptions();
                    canvas.Save(outputPath, gifOptions);
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
 * 1. When you need to correct rotation of scanned GIF frames before creating a looping animation for a web banner.
 * 2. When you have several GIF screenshots taken from a camera that are slightly tilted and you want to produce a single animated GIF for a product demo.
 * 3. When an e‑learning platform requires a deskewed animated GIF compiled from multiple lesson‑step images to ensure consistent orientation.
 * 4. When a marketing tool must automatically process a batch of user‑uploaded GIFs, straighten them, and merge them into one animated GIF for social media sharing.
 * 5. When a desktop application generates sequential GIF charts that need angle normalization before being combined into an animated GIF report.
 */
