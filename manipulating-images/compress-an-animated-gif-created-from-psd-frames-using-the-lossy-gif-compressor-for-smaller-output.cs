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
        // Hard‑coded input directory containing PSD frames and output file path
        string inputDirectory = @"C:\temp\psd_frames";
        string outputPath = @"C:\temp\output\animated_lossy.gif";

        try
        {
            // Verify the input directory exists (no explicit rule, but safe to check)
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Load all PSD files from the directory
            string[] psdFiles = Directory.GetFiles(inputDirectory, "*.psd");
            if (psdFiles.Length == 0)
            {
                Console.Error.WriteLine("No PSD files found in the input directory.");
                return;
            }

            // Load each PSD as a RasterImage and store in a list
            List<RasterImage> frames = new List<RasterImage>();
            foreach (string filePath in psdFiles)
            {
                // Input file existence check (rule 2)
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the PSD image (load rule)
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

            // Create the first GIF frame block from the first raster image
            using (GifFrameBlock firstBlock = new GifFrameBlock(frames[0]))
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Add remaining frames to the GIF animation
                for (int i = 1; i < frames.Count; i++)
                {
                    gifImage.AddPage(frames[i]);
                }

                // Prepare lossy GIF options
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended lossy compression level
                    MaxDiff = 80
                };

                // Ensure output directory exists (rule 3)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with lossy compression (save rule)
                gifImage.Save(outputPath, saveOptions);
            }

            // Dispose all loaded frames (they are no longer needed)
            foreach (var frame in frames)
            {
                frame.Dispose();
            }

            Console.WriteLine("Animated GIF created and compressed successfully.");
        }
        catch (Exception ex)
        {
            // Global exception handling (rule 4)
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# web developer needs to generate lightweight animated GIFs from layered Photoshop (PSD) assets to improve page load speed.
 * 2. When an e‑commerce site built with .NET creates product showcase animations from PSD files and must keep the GIF file size small for faster browsing.
 * 3. When a mobile app written in C# builds promotional GIFs on‑the‑fly from PSD frames and must reduce the output size to satisfy app store size limits.
 * 4. When a digital marketing team automates the conversion of PSD storyboard frames into a lossy animated GIF for email campaigns that have strict attachment size restrictions.
 * 5. When a game developer using Aspose.Imaging for .NET exports character animation sequences stored as PSD layers into a compressed GIF for UI tutorials or loading screens.
 */