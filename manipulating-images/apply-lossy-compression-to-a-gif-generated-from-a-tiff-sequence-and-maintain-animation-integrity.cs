using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing TIFF frames and output GIF path
        string inputDirectory = @"C:\temp\TiffFrames";
        string outputPath = @"C:\temp\output.gif";

        try
        {
            // Verify input directory exists by checking at least one expected file
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all TIFF files in the directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            if (tiffFiles.Length == 0)
            {
                Console.Error.WriteLine($"No TIFF files found in: {inputDirectory}");
                return;
            }

            // Load each TIFF frame, verifying existence before loading
            List<RasterImage> frames = new List<RasterImage>();
            foreach (string tiffPath in tiffFiles)
            {
                if (!File.Exists(tiffPath))
                {
                    Console.Error.WriteLine($"File not found: {tiffPath}");
                    return;
                }

                // Load the TIFF image and cast to RasterImage
                Image img = Image.Load(tiffPath);
                frames.Add((RasterImage)img);
            }

            // Create GIF image using the first frame
            using (GifImage gif = new GifImage(new GifFrameBlock(frames[0])))
            {
                // Add remaining frames to the GIF animation
                for (int i = 1; i < frames.Count; i++)
                {
                    gif.AddPage(frames[i]);
                }

                // Configure GIF options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80,
                    // Optional: keep palette correction and interlacing if desired
                    DoPaletteCorrection = true,
                    Interlaced = false
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with lossy compression
                gif.Save(outputPath, saveOptions);
            }

            // Dispose loaded frames
            foreach (var frame in frames)
            {
                frame.Dispose();
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
 * 1. When a developer needs to convert a series of high‑resolution TIFF frames captured from a medical imaging device into a lightweight animated GIF for quick web preview while preserving the animation sequence.
 * 2. When an e‑learning platform wants to generate animated GIF tutorials from a set of scanned TIFF slides and apply lossy compression to reduce bandwidth without breaking the slide order.
 * 3. When a marketing automation tool must batch‑process product photography stored as TIFF files into animated GIF banners, using C# and Aspose.Imaging to keep the animation timing intact while shrinking file size.
 * 4. When a game developer creates sprite animations from TIFF assets and needs to export them as GIFs with lossless‑to‑lossy compression to meet mobile app size constraints.
 * 5. When a digital archiving system needs to archive time‑lapse TIFF sequences as animated GIFs for quick visual inspection, applying lossy compression to balance storage savings with animation fidelity.
 */