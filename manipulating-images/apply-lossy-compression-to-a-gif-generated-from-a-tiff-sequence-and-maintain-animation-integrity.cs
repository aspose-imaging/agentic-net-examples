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
        try
        {
            // Hardcoded input directory containing TIFF frames and output GIF path
            string inputDirectory = @"C:\temp\tiffseq";
            string outputPath = @"C:\temp\output.gif";

            // Verify input directory exists (at least one TIFF file must be present)
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Gather all TIFF files in the directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            if (tiffFiles.Length == 0)
            {
                Console.Error.WriteLine($"No TIFF files found in: {inputDirectory}");
                return;
            }

            // Load each TIFF file as a RasterImage, checking existence for safety
            List<RasterImage> frames = new List<RasterImage>();
            foreach (string tiffPath in tiffFiles)
            {
                if (!File.Exists(tiffPath))
                {
                    Console.Error.WriteLine($"File not found: {tiffPath}");
                    return;
                }

                // Load the TIFF image
                Image img = Image.Load(tiffPath);
                frames.Add((RasterImage)img);
            }

            // Ensure we have at least one frame to create the GIF
            if (frames.Count == 0)
            {
                Console.Error.WriteLine("No frames loaded.");
                return;
            }

            // Create the GIF image using the first frame
            using (GifImage gifImage = new GifImage(new GifFrameBlock(frames[0])))
            {
                // Add remaining frames to the GIF animation
                for (int i = 1; i < frames.Count; i++)
                {
                    gifImage.AddPage(frames[i]);
                }

                // Prepare GIF save options with lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for good lossy compression
                    MaxDiff = 80,
                    // Preserve animation timing (default is fine)
                    FullFrame = true
                };

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Animated GIF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}