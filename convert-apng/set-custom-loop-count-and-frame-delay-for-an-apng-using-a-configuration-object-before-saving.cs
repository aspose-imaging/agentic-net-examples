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
            // Hardcoded input and output file paths
            string inputPath = "input.webp";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure APNG options: custom loop count and frame delay
            ApngOptions apngOptions = new ApngOptions
            {
                // Number of times the animation should loop (0 = infinite)
                NumPlays = 3,
                // Default frame duration in milliseconds
                DefaultFrameTime = 200
            };

            // Load the source image and save it as APNG with the configured options
            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a developer needs to convert a WebP animation to an animated PNG (APNG) with a specific number of loops for use in a web banner that should repeat three times.
 * 2. When an e‑learning platform requires exporting slide animations as APNG files with a consistent 200 ms frame delay to ensure smooth playback across browsers.
 * 3. When a mobile app generates custom stickers from user‑uploaded WebP files and must limit the animation to three repeats to conserve battery and data usage.
 * 4. When a marketing email designer wants to embed an animated product showcase as an APNG that loops a fixed number of times instead of looping infinitely.
 * 5. When a game developer creates UI icons from WebP assets and needs to set a default frame time and loop count before saving them as APNG for cross‑platform compatibility.
 */