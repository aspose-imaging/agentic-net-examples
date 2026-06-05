using System;
using System.IO;
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
            string inputDirectory = @"C:\temp\tiffframes";
            string outputPath = @"C:\temp\output.gif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            if (tiffFiles.Length == 0)
            {
                Console.Error.WriteLine("No TIFF files found in the input directory.");
                return;
            }

            // Load the first TIFF frame
            string firstFile = tiffFiles[0];
            if (!File.Exists(firstFile))
            {
                Console.Error.WriteLine($"File not found: {firstFile}");
                return;
            }

            using (RasterImage firstFrame = (RasterImage)Image.Load(firstFile))
            using (GifImage gif = new GifImage(new GifFrameBlock(firstFrame)))
            {
                // Add remaining TIFF frames to the GIF
                for (int i = 1; i < tiffFiles.Length; i++)
                {
                    string filePath = tiffFiles[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        gif.AddPage(frame);
                    }
                }

                // Configure lossy compression options
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // Recommended value for optimal lossy compression
                };

                // Save the animated GIF with lossy compression
                gif.Save(outputPath, saveOptions);
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
 * 1. When a web developer needs to convert a series of high‑resolution TIFF screenshots into a lightweight animated GIF for faster page load while preserving the animation sequence.
 * 2. When an e‑learning platform must generate animated instructional GIFs from scanned TIFF slides and reduce file size with lossy compression to fit within LMS bandwidth limits.
 * 3. When a digital marketing team wants to create a compact product‑showcase GIF from a TIFF photo shoot, ensuring the animation loops correctly after compression.
 * 4. When a mobile app processes TIFF camera bursts into an animated GIF and applies lossy compression to meet app‑store size restrictions without breaking frame order.
 * 5. When a scientific visualization tool assembles time‑lapse TIFF images into an animated GIF and needs to shrink the output for email distribution while keeping the temporal integrity of the frames.
 */