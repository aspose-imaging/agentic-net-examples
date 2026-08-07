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

            // Load the source image (could be animated or single-frame)
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options: set loop count to 5 and a default frame time (e.g., 100 ms)
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5,                 // Loop the animation 5 times
                    DefaultFrameTime = 100       // 100 ms per frame to test playback speed
                };

                // Save as APNG with the specified options
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
 * 1. When a developer needs to generate an animated PNG (APNG) from a WebP source that loops exactly five times for use in product tutorials, ensuring consistent frame timing across browsers and image viewers.
 * 2. When a developer wants to create a looping banner ad in C# where the animation repeats a fixed number of times (five) and the 100 ms frame delay must be verified on desktop and mobile image viewers.
 * 3. When a developer is building a game UI and must export character sprite animations as APNG files that play five cycles with a uniform playback speed to test synchronization with sound effects.
 * 4. When a developer is implementing an automated quality‑control pipeline that converts animated WebP assets to APNG and checks that the NumPlays property of 5 and DefaultFrameTime of 100 ms render correctly in popular image editors.
 * 5. When a developer needs to produce a diagnostic sample for client support, converting an animated WebP to an APNG that repeats five times so that support staff can compare playback speed consistency across different viewer applications.
 */