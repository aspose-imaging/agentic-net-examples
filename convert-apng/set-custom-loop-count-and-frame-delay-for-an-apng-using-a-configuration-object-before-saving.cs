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
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options: set frame delay (in ms) and loop count
                var apngOptions = new ApngOptions
                {
                    DefaultFrameTime = 150, // 150 ms per frame
                    NumPlays = 4            // Play the animation 4 times (0 = infinite)
                };

                // Save the image as an APNG with the specified options
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
 * 1. When a developer needs to generate a web banner as an animated PNG that repeats exactly four times with each frame displayed for 150 ms.
 * 2. When an e‑learning platform creates step‑by‑step tutorial visuals and wants the APNG animation to pause 150 ms per frame and stop after four loops.
 * 3. When a mobile application produces lightweight animated icons in APNG format, controlling the frame delay and limiting playback to four cycles to save battery life.
 * 4. When a reporting tool converts a series of PNG charts into an APNG slideshow, requiring a uniform 150 ms frame interval and a finite loop count for embedding in PDFs.
 * 5. When a game developer exports sprite animations as APNG files, setting a custom frame time and a loop count of four so the animation ends after four repetitions.
 */