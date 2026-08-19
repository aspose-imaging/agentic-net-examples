// HOW-TO: Convert WebP to APNG with 5 Loops and 100ms Frame Delay in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input_animation.webp";
            string outputPath = "output_animation.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (could be animated)
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG with 5 loop cycles and a default frame time of 100 ms
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5,               // Loop count
                    DefaultFrameTime = 100      // Frame duration in milliseconds
                };

                image.Save(outputPath, apngOptions);
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
 * 1. When you need to embed an animated image in a web page that repeats exactly five times, you can convert a WebP animation to an APNG with a fixed loop count using C#.
 * 2. When testing how different browsers or image viewers handle APNG playback speed, you can set a consistent 100 ms frame duration and loop count to compare results.
 * 3. When creating a game asset that requires a limited number of animation cycles, you can generate an APNG with a predefined number of plays from an existing WebP file.
 * 4. When preparing marketing GIF alternatives that must comply with APNG specifications and need controlled looping, this code converts and configures the loop count in .NET.
 * 5. When automating a batch process to standardize animated images for an e‑learning platform, you can ensure each APNG repeats five times with uniform frame timing.
 */
