// HOW-TO: Convert Animated GIF to WebP with Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths (relative)
            string inputPath = "Input/animation.gif";
            string outputPath = "Output/animation.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑frame GIF
            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Preserve loop count if available
                int loopCount = gif.LoopsCount;

                // Configure WebP options
                WebPOptions webpOptions = new WebPOptions
                {
                    AnimLoopCount = (ushort)loopCount,
                    Lossless = false,
                    Quality = 80
                };

                // Create an empty WebP image with the same dimensions as the GIF
                using (WebPImage webp = new WebPImage(gif.Width, gif.Height, webpOptions))
                {
                    int pageCount = gif.PageCount;

                    // Iterate through each GIF frame
                    for (int i = 0; i < pageCount; i++)
                    {
                        // Activate the current frame
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                        // Cast the active frame to a raster image for pixel data
                        using (Aspose.Imaging.RasterImage frameRaster = (Aspose.Imaging.RasterImage)gif.ActiveFrame)
                        {
                            // Create a WebP frame block from the raster image
                            WebPFrameBlock block = new WebPFrameBlock(frameRaster)
                            {
                                Duration = (short)((GifFrameBlock)gif.ActiveFrame).FrameTime
                            };

                            // Add the block to the WebP animation
                            webp.AddBlock(block);
                        }
                    }

                    // Save the animated WebP file
                    webp.Save(outputPath);
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
 * 1. When you need to reduce the file size of an animated GIF for faster web loading while preserving its original frame timing, this C# code converts it to a WebP animation.
 * 2. When building a .NET image processing pipeline that must support modern browsers, you can transform legacy GIF animations into efficient WebP files using Aspose.Imaging.
 * 3. When creating a mobile app that displays animated content, this snippet generates WebP animations that keep the original GIF’s loop count and frame delays.
 * 4. When automating batch conversion of user‑uploaded GIFs to a more efficient format, the code retains the exact animation sequence in the resulting WebP files.
 * 5. When integrating Aspose.Imaging into a server‑side service that serves animated images, you can convert multi‑frame GIFs to WebP to improve loading speed without losing animation fidelity.
 */
