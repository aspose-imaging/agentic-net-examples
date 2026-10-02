// HOW-TO: Save Merged JPEG Images as PNG with 150 DPI Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "merged.png";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Prepare PNG options with 150 DPI resolution
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions()
            {
                Source = src,
                ResolutionSettings = new ResolutionSetting(150, 150)
            };

            // Create canvas bound to output file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas
                canvas.Save();
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
 * 1. When you need to combine several JPEG photos into a single wide PNG for web galleries while ensuring the output has a fixed 150 DPI resolution.
 * 2. When generating print‑ready composite images from multiple source JPEGs and must set the DPI to meet publishing standards.
 * 3. When creating a high‑resolution PNG sprite sheet from individual JPEG assets for a game or UI and want to control the output resolution programmatically.
 * 4. When automating a batch process that merges scanned JPEG pages into a single PNG document with a specific DPI for archival purposes.
 * 5. When developing a C# service that receives JPEG uploads, stitches them side‑by‑side, and saves the result as a PNG with 150 DPI for downstream image‑analysis pipelines.
 */
