// HOW-TO: Set Custom Loop Count and Frame Delay for APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\animated.apng.png";

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

            // Configure APNG options: custom loop count and frame delay
            ApngOptions apngOptions = new ApngOptions
            {
                // Number of times the animation should loop (0 = infinite)
                NumPlays = 4,
                // Default frame duration in milliseconds
                DefaultFrameTime = 150
            };

            // Load source image and save as APNG with the configured options
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
 * 1. When you need an animated PNG that repeats a specific number of times instead of looping forever, you can set the NumPlays property with Aspose.Imaging in C#.
 * 2. When creating a web banner where each frame should display for a precise duration, you can define DefaultFrameTime to control the frame delay of the APNG.
 * 3. When generating product showcase animations that must stop after a set number of cycles for compliance reasons, configuring the loop count ensures the animation ends as required.
 * 4. When converting a static PNG into an animated sequence and you want consistent timing across all frames, using ApngOptions lets you apply a uniform frame time before saving.
 * 5. When integrating animated PNGs into a mobile app and need to limit playback to conserve battery, setting a custom loop count and frame delay helps manage resource usage.
 */
