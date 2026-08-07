using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output/output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options with infinite looping (NumPlays = 0)
                var apngOptions = new ApngOptions
                {
                    NumPlays = 0
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
 * 1. When creating a web banner ad that must animate continuously, a developer can use this code to convert a WebP animation to an APNG with infinite looping (NumPlays = 0).
 * 2. When building a digital signage application that displays looping graphics without user interaction, the code ensures the APNG plays endlessly on the screen.
 * 3. When developing a mobile game UI with animated icons that should never stop, setting NumPlays to zero provides perpetual animation playback.
 * 4. When generating tutorial animations that need to repeat automatically in a desktop app, converting the source WebP to an APNG with infinite loops creates smooth, never‑ending playback.
 * 5. When preparing e‑learning content where animated diagrams must loop continuously for learners, this C# snippet converts the image to an APNG with an infinite loop count using Aspose.Imaging.
 */