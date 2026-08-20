// HOW-TO: Set Custom Frame Delay When Converting Animated WebP to GIF in C# (Aspose.Imaging for .NET)
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
            // Input and output paths
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/animation.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load animated WebP
            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                // Ensure there is at least one frame
                if (webp.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Use the first frame to create the GIF canvas
                RasterImage firstFrame = (RasterImage)webp.Pages[0];
                using (GifImage gif = new GifImage(new GifFrameBlock(firstFrame)))
                {
                    // Set delay for the first frame (e.g., 100 ms)
                    gif.ActiveFrame.FrameTime = (ushort)100;

                    // Process remaining frames
                    for (int i = 1; i < webp.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)webp.Pages[i];
                        // Create a new GIF frame block from the raster image
                        GifFrameBlock block = new GifFrameBlock(frame);
                        // Set individual frame delay (e.g., 100 ms)
                        block.FrameTime = (ushort)100;
                        // Draw the raster image onto the block
                        Graphics graphics = new Graphics(block);
                        graphics.DrawImage(frame, new Rectangle(0, 0, frame.Width, frame.Height));
                        // Add the block to the GIF
                        gif.AddPage(block);
                    }

                    // Save the resulting GIF
                    gif.Save(outputPath);
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
 * 1. When you need to preserve the original animation speed while converting an animated WebP file to a GIF for web display, this code lets you set a specific delay for each frame.
 * 2. When creating a GIF slideshow from a series of WebP frames and want each slide to pause for a defined duration, you can assign individual frame times using this example.
 * 3. When optimizing animated assets for email newsletters, you can control the GIF playback speed by defining frame delays after extracting frames from an animated WebP.
 * 4. When building a cross‑platform mobile app that receives animated WebP images and must output GIFs with consistent timing, this snippet shows how to map WebP frame timing to GIF frame delays in C#.
 * 5. When generating GIF previews of user‑uploaded animated WebP files and need to ensure the preview matches the original animation timing, you can use this code to set uniform or custom delays per frame.
 */
