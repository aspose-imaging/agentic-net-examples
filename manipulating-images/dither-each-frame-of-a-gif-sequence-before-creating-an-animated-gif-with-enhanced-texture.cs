// HOW-TO: Dither Each Frame And Create Animated GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing individual frames and output file path
        string inputFolder = @"C:\temp\frames\";
        string outputPath = @"C:\temp\output\animated_dithered.gif";

        try
        {
            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Folder not found: {inputFolder}");
                return;
            }

            // Get all image files in the folder
            var frameFiles = Directory.GetFiles(inputFolder)
                                      .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                      .OrderBy(f => f) // Ensure deterministic order
                                      .ToArray();

            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine("No image frames found in the input folder.");
                return;
            }

            // Load the first frame, dither it, and create the initial GifImage
            using (Image firstImg = Image.Load(frameFiles[0]))
            {
                var firstRaster = (RasterImage)firstImg;
                firstRaster.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                using (var firstBlock = new GifFrameBlock(firstRaster))
                using (var gifImage = new GifImage(firstBlock))
                {
                    // Process remaining frames
                    for (int i = 1; i < frameFiles.Length; i++)
                    {
                        // Verify each input file exists (redundant but follows the rule)
                        if (!File.Exists(frameFiles[i]))
                        {
                            Console.Error.WriteLine($"File not found: {frameFiles[i]}");
                            continue;
                        }

                        using (Image img = Image.Load(frameFiles[i]))
                        {
                            var raster = (RasterImage)img;
                            raster.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                            // Create a frame block from the dithered raster and add it to the GIF
                            var block = new GifFrameBlock(raster);
                            gifImage.AddBlock(block);
                        }
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the animated GIF
                    gifImage.Save(outputPath);
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
 * 1. When you need to add a retro pixelated look to a series of PNG or JPEG images before combining them into an animated GIF.
 * 2. When you want to reduce color banding in each frame of a GIF animation by applying Floyd‑Steinberg dithering with Aspose.Imaging.
 * 3. When you have a folder of individual image frames and must generate a single animated GIF while preserving the original frame order.
 * 4. When you are building a C# utility that processes user‑uploaded images and outputs a dithered animated GIF for web or mobile display.
 * 5. When you need to improve the visual quality of low‑color GIFs by dithering each frame before saving the final GifImage.
 */
