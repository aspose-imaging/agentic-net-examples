using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing individual frame images
        string inputDir = @"C:\temp\frames";
        // Hardcoded output path for the animated GIF
        string outputPath = @"C:\temp\output\animated_dithered.gif";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retrieve all files in the input directory
            string[] frameFiles = Directory.GetFiles(inputDir);
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine($"No frames found in: {inputDir}");
                return;
            }

            // Load the first frame to initialize the GifImage
            string firstPath = frameFiles[0];
            if (!File.Exists(firstPath))
            {
                Console.Error.WriteLine($"File not found: {firstPath}");
                return;
            }

            using (Image firstImg = Image.Load(firstPath))
            {
                // Cast to RasterImage to access Dither
                RasterImage firstRaster = (RasterImage)firstImg;
                // Apply Floyd‑Steinberg dithering with a 4‑bit palette
                firstRaster.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Create a GifFrameBlock from the dithered raster image
                using (GifFrameBlock firstBlock = new GifFrameBlock(firstRaster))
                {
                    // Initialize the animated GIF with the first block
                    using (GifImage gifImage = new GifImage(firstBlock))
                    {
                        // Process remaining frames
                        for (int i = 1; i < frameFiles.Length; i++)
                        {
                            string path = frameFiles[i];
                            if (!File.Exists(path))
                            {
                                Console.Error.WriteLine($"File not found: {path}");
                                continue; // Skip missing files
                            }

                            using (Image img = Image.Load(path))
                            {
                                RasterImage raster = (RasterImage)img;
                                raster.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);
                                using (GifFrameBlock block = new GifFrameBlock(raster))
                                {
                                    gifImage.AddBlock(block);
                                }
                            }
                        }

                        // Save the animated GIF with enhanced texture
                        gifImage.Save(outputPath);
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
 * 1. When a developer wants to generate an animated GIF from a series of high‑resolution PNG frames and add Floyd‑Steinberg dithering to reduce file size while preserving texture.
 * 2. When a game studio needs to create retro‑style sprite animations in GIF format and apply a 4‑bit palette dither to achieve a pixel‑art look across all frames.
 * 3. When an e‑learning platform must convert a set of scanned lecture slides into a lightweight animated GIF with consistent dithering to improve readability on low‑bandwidth connections.
 * 4. When a marketing automation tool assembles product showcase images into an animated GIF and uses Aspose.Imaging’s Dither method to ensure uniform color reduction for email campaigns.
 * 5. When a social media app processes user‑uploaded frame sequences into an animated GIF and applies Floyd‑Steinberg dithering to maintain visual quality on devices that only support 256 colors.
 */