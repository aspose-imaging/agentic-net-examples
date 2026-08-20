// HOW-TO: Convert Animated WebP to GIF with Infinite Loop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image (preserves all frames)
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options to keep full frames (required for animation)
                var gifOptions = new GifOptions
                {
                    FullFrame = true
                    // Loop count defaults to infinite; set explicitly if needed:
                    // LoopCount = 0
                };

                // Save as an animated GIF, preserving frames and loop behavior
                image.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated WebP on platforms that only support GIF, you can convert it while keeping all animation frames.
 * 2. When a web application must generate endless looping GIFs from user‑uploaded WebP animations for banners or ads, this code handles the conversion.
 * 3. When migrating legacy assets, you can batch‑convert animated WebP files to GIF to ensure compatibility with older browsers.
 * 4. When creating email newsletters that require animated GIFs, you can transform WebP animations into GIFs with an infinite loop using Aspose.Imaging in C#.
 * 5. When building a server‑side image service that receives WebP animations and returns GIFs for mobile apps, this snippet provides the necessary conversion logic.
 */
