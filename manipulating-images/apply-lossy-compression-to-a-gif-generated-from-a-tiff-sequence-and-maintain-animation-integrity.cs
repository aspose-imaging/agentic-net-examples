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
            string[] inputPaths = {
                "frame1.tif",
                "frame2.tif",
                "frame3.tif"
            };

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            string outputPath = "Output\\animated.gif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage firstFrame = (RasterImage)Image.Load(inputPaths[0]))
            {
                using (GifImage gif = new GifImage(new GifFrameBlock((ushort)firstFrame.Width, (ushort)firstFrame.Height)))
                {
                    gif.AddPage(firstFrame);

                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(inputPaths[i]))
                        {
                            gif.AddPage(frame);
                        }
                    }

                    GifOptions options = new GifOptions
                    {
                        MaxDiff = 80
                    };

                    gif.Save(outputPath, options);
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
 * 1. When a web developer needs to create a lightweight animated banner from high‑resolution TIFF frames for faster page load, they can use this code to apply lossy compression to the GIF while preserving the animation sequence.
 * 2. When an e‑learning platform wants to convert a series of scanned lecture slides stored as TIFF images into an animated GIF for mobile devices, this snippet reduces the GIF file size without breaking slide transitions.
 * 3. When a digital marketing team must email a product showcase animation created from TIFF images and stay under attachment size limits, the code generates a compressed GIF that retains the original frame timing.
 * 4. When a game developer needs to bundle animated UI icons generated from TIFF assets into a single GIF file and control visual quality with the MaxDiff parameter, this example shows how to apply lossy compression in C#.
 * 5. When a scientific visualization tool converts a sequence of high‑detail TIFF microscopy images into an animated GIF for quick preview, the code ensures animation integrity while shrinking the preview file size.
 */