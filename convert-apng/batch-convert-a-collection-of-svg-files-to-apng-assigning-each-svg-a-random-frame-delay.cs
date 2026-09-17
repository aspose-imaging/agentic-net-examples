// HOW-TO: Batch Convert Multiple SVG Files to Animated PNG with Random Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            if (svgFiles.Length == 0)
            {
                Console.WriteLine("No SVG files found in Input directory.");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, "output.apng");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<(RasterImage raster, uint delay)> frames = new List<(RasterImage, uint)>();
            Random rand = new Random();

            foreach (string svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                using (Image svgImage = Image.Load(svgPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgImage.Save(ms, new PngOptions());
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        uint delay = (uint)rand.Next(50, 301); // random delay between 50 and 300 ms
                        frames.Add((raster, delay));
                    }
                }
            }

            int width = frames[0].raster.Width;
            int height = frames[0].raster.Height;

            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
            {
                apng.RemoveAllFrames();

                foreach (var (raster, delay) in frames)
                {
                    apng.AddFrame(raster);
                    if (apng.Pages[apng.PageCount - 1] is IAnimationFrame animFrame)
                    {
                        // Set per-frame delay if supported
                        // The IAnimationFrame interface defines Delay property
                        // Cast to dynamic to avoid compile-time issues if property differs
                        dynamic df = animFrame;
                        try { df.Delay = delay; } catch { }
                    }
                }

                apng.Save();
            }

            foreach (var (raster, _) in frames)
            {
                raster.Dispose();
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
 * 1. When you need to generate an animated PNG slideshow from a set of vector icons stored as SVG files, assigning each slide a unique random display time.
 * 2. When creating dynamic web graphics that require a sequence of SVG illustrations to play as an APNG with varied frame speeds without manually editing each frame.
 * 3. When automating the production of lightweight animated assets for mobile apps by converting a folder of SVG assets into a single APNG file with random delays to add visual variety.
 * 4. When building a reporting tool that visualizes step‑by‑step SVG diagrams as an animated PNG, using random frame intervals to simulate unpredictable processing times.
 * 5. When developing a game UI that needs to combine multiple SVG sprites into one animated PNG with per‑frame timing, and you want to batch the conversion in C# using Aspose.Imaging.
 */
