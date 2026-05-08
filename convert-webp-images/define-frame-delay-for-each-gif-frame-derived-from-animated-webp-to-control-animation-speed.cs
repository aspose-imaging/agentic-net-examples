using System;
using System.IO;
using Aspose.Imaging;
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
            // Hardcoded input and output paths
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

            // Load the animated WebP image
            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                IMultipageImage multipage = webpImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Prepare frame delay values (example: 100ms per frame)
                ushort[] frameDelays = new ushort[multipage.PageCount];
                for (int i = 0; i < frameDelays.Length; i++)
                {
                    frameDelays[i] = 100; // 100 ms for each frame
                }

                // Load the first frame to initialize the GIF image
                using (RasterImage firstRaster = (RasterImage)webpImage.Pages[0])
                {
                    using (GifImage gifImage = new GifImage(new GifFrameBlock((ushort)firstRaster.Width, (ushort)firstRaster.Height)))
                    {
                        // Copy first frame pixels
                        using (GifFrameBlock firstBlock = new GifFrameBlock((ushort)firstRaster.Width, (ushort)firstRaster.Height))
                        {
                            var pixels = firstRaster.LoadPixels(firstRaster.Bounds);
                            firstBlock.SavePixels(firstBlock.Bounds, pixels);
                            gifImage.AddPage(firstBlock);
                            gifImage.ActiveFrame.FrameTime = frameDelays[0];
                        }

                        // Process remaining frames
                        for (int i = 1; i < multipage.PageCount; i++)
                        {
                            using (RasterImage raster = (RasterImage)webpImage.Pages[i])
                            {
                                using (GifFrameBlock block = new GifFrameBlock((ushort)raster.Width, (ushort)raster.Height))
                                {
                                    var pixels = raster.LoadPixels(raster.Bounds);
                                    block.SavePixels(block.Bounds, pixels);
                                    gifImage.AddPage(block);
                                    gifImage.ActiveFrame.FrameTime = frameDelays[i];
                                }
                            }
                        }

                        // Save the resulting GIF with default options
                        gifImage.Save(outputPath, new GifOptions());
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