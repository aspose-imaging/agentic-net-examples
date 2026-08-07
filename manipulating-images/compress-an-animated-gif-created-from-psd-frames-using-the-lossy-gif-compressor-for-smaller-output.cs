using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = @"C:\Input\Psds";
        string outputPath = @"C:\Output\animated_lossy.gif";

        try
        {
            // Verify input directory exists (if not, report and exit)
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Prepare output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PSD frames
            List<RasterImage> frames = new List<RasterImage>();
            foreach (string filePath in Directory.GetFiles(inputDirectory, "*.psd"))
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load each PSD as a raster image
                Image img = Image.Load(filePath);
                if (img is RasterImage raster)
                {
                    frames.Add(raster);
                }
                else
                {
                    img.Dispose();
                    Console.Error.WriteLine($"Unsupported image type: {filePath}");
                    return;
                }
            }

            if (frames.Count == 0)
            {
                Console.Error.WriteLine("No PSD frames found.");
                return;
            }

            // Create the first GIF frame block from the first raster image
            using (GifFrameBlock firstBlock = new GifFrameBlock(frames[0]))
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Add remaining frames
                for (int i = 1; i < frames.Count; i++)
                {
                    GifFrameBlock block = new GifFrameBlock(frames[i]);
                    gifImage.AddBlock(block);
                }

                // Set lossy compression options
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // Recommended value for optimal lossy compression
                };

                // Save the animated GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            // Dispose loaded frames (except the first which is already disposed by GifImage)
            for (int i = 1; i < frames.Count; i++)
            {
                frames[i].Dispose();
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
 * 1. When a developer needs to generate a lightweight animated GIF from a series of Photoshop PSD layers for web banners, they can use this code to load the PSD frames, assemble them into a GIF, and apply lossy compression to reduce file size.
 * 2. When an e‑commerce platform wants to display product color‑variation animations without slowing page load, the code can convert PSD mockups into a compressed animated GIF that fits bandwidth constraints.
 * 3. When a mobile app requires an animated tutorial that must stay under a strict size limit, developers can employ this snippet to read PSD assets, create a GIF, and compress it lossily for optimal download speed.
 * 4. When a marketing automation tool automatically generates promotional GIFs from designer‑provided PSD files, this example shows how to batch‑process the PSD directory, build the animation, and shrink it with the Aspose.Imaging lossy GIF compressor.
 * 5. When a game developer needs to embed animated UI icons created in Photoshop into a Unity project, they can use this code to turn PSD frames into a compact GIF that meets the game's asset size guidelines.
 */