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
            string inputPath = "input.webp";
            string outputPath = "output/output.png";

            // Verify input file exists
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
 * 1. When a developer needs to convert an animated WebP file to an APNG that loops indefinitely for a continuously playing website banner, this code provides the solution.
 * 2. When a game developer wants to create an infinite looping sprite animation from a source image using C# and Aspose.Imaging, they can apply the NumPlays = 0 setting shown here.
 * 3. When a digital signage system requires a never‑ending animated PNG to display promotional content without manual restarts, this example demonstrates how to generate it programmatically.
 * 4. When an e‑learning platform needs to embed a looping instructional animation in HTML5 without relying on GIF, the code converts the source to an APNG with infinite playback.
 * 5. When a mobile app developer wants to ensure an animated icon repeats forever on both iOS and Android by converting a WebP animation to an APNG, this snippet shows the required steps.
 */