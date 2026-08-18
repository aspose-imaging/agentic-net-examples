// HOW-TO: Extract WebP Animation Frames To BMP And Create GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded paths
            string inputPath = "input.webp";
            string bmpOutputDir = "frames";
            string outputGifPath = "output.gif";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(bmpOutputDir);
            string outputGifDir = Path.GetDirectoryName(outputGifPath);
            if (!string.IsNullOrWhiteSpace(outputGifDir))
            {
                Directory.CreateDirectory(outputGifDir);
            }

            // Load the animated WebP image
            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                IMultipageImage multipage = webp as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage WebP image.");
                    return;
                }

                int frameCount = multipage.PageCount;
                var bmpPaths = new List<string>();

                // Extract each frame to BMP
                for (int i = 0; i < frameCount; i++)
                {
                    RasterImage frame = (RasterImage)webp.Pages[i];
                    string bmpPath = Path.Combine(bmpOutputDir, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    using (frame)
                    {
                        frame.Save(bmpPath, new BmpOptions());
                    }

                    bmpPaths.Add(bmpPath);
                }

                // Load BMP frames for GIF creation
                var bmpFrames = new List<RasterImage>();
                foreach (var path in bmpPaths)
                {
                    RasterImage img = (RasterImage)Image.Load(path);
                    bmpFrames.Add(img);
                }

                if (bmpFrames.Count == 0)
                {
                    Console.Error.WriteLine("No frames were extracted.");
                    return;
                }

                // Create GIF animation from BMP frames
                RasterImage first = bmpFrames[0];
                using (GifImage gif = new GifImage(new GifFrameBlock((ushort)first.Width, (ushort)first.Height)))
                {
                    // Draw first frame onto the initial GIF frame
                    Graphics g0 = new Graphics(gif.ActiveFrame);
                    g0.DrawImage(first, new Rectangle(0, 0, first.Width, first.Height));

                    // Add remaining frames
                    for (int i = 1; i < bmpFrames.Count; i++)
                    {
                        RasterImage frameImg = bmpFrames[i];
                        GifFrameBlock block = new GifFrameBlock((ushort)frameImg.Width, (ushort)frameImg.Height);
                        Graphics g = new Graphics(block);
                        g.DrawImage(frameImg, new Rectangle(0, 0, frameImg.Width, frameImg.Height));
                        gif.AddBlock(block);
                    }

                    // Save the GIF animation
                    gif.Save(outputGifPath, new GifOptions());
                }

                // Dispose BMP frames
                foreach (var img in bmpFrames)
                {
                    img.Dispose();
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
 * 1. When you need to convert an animated WebP advertisement into a series of BMP frames for legacy Windows applications that only support BMP.
 * 2. When you must generate a GIF preview from a WebP animation to embed in email newsletters that do not support WebP.
 * 3. When you want to extract individual frames from a WebP sprite sheet to edit them separately in a graphics editor that reads BMP files.
 * 4. When you are building a server‑side service that receives WebP animations and returns GIFs for browsers lacking WebP support.
 * 5. When you need to archive WebP animation frames as lossless BMP files before applying custom watermarking or processing pipelines.
 */
