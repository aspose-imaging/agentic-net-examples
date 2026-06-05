using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths (no argument validation)
        string inputDirectory = @"C:\Input\PsdFrames";
        string outputPath = @"C:\Output\animated_lossy.gif";

        try
        {
            // Verify that the input directory exists and contains PSD files
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get PSD files (sorted for deterministic order)
            var psdFiles = Directory.GetFiles(inputDirectory, "*.psd")
                                    .OrderBy(f => f)
                                    .ToArray();

            if (psdFiles.Length == 0)
            {
                Console.Error.WriteLine($"No PSD files found in: {inputDirectory}");
                return;
            }

            // Load the first frame and create the GIF image
            string firstFile = psdFiles[0];
            if (!File.Exists(firstFile))
            {
                Console.Error.WriteLine($"File not found: {firstFile}");
                return;
            }

            using (RasterImage firstRaster = (RasterImage)Image.Load(firstFile))
            using (GifFrameBlock firstBlock = new GifFrameBlock(firstRaster))
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Load remaining frames and add them to the GIF
                for (int i = 1; i < psdFiles.Length; i++)
                {
                    string filePath = psdFiles[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage raster = (RasterImage)Image.Load(filePath))
                    using (GifFrameBlock block = new GifFrameBlock(raster))
                    {
                        gifImage.AddBlock(block);
                    }
                }

                // Prepare lossy GIF options
                var saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to generate a lightweight animated preview of a multi‑layer Photoshop design for web pages, they can convert PSD frames to a lossy GIF to reduce bandwidth.
 * 2. When an e‑commerce platform wants to display product color‑variation animations without slowing page load, the code can compress the PSD‑derived GIF to a smaller size.
 * 3. When a mobile app must send animated tutorials over limited network connections, developers can use this routine to turn PSD storyboard frames into a compact lossy GIF.
 * 4. When a marketing team requires email‑friendly animated banners created from Photoshop assets, the code helps produce a GIF that fits typical email size limits.
 * 5. When a game developer wants to embed animated UI icons generated from PSD layers into a Unity project, the lossy GIF compression ensures the assets stay under the game's memory budget.
 */