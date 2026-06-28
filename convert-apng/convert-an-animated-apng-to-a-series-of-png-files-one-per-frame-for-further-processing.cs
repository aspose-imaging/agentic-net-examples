using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDirectory = "output_frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the animated APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frame collection
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The loaded image is not an APNG file.");
                    return;
                }

                int frameCount = apng.PageCount;

                // Iterate through each frame and save as a separate PNG file
                for (int i = 0; i < frameCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as PNG
                    apng.Pages[i].Save(outputPath, new PngOptions());
                }
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
 * 1. When a developer needs to extract each frame from an animated APNG to create individual PNG assets for a sprite sheet in a game engine.
 * 2. When a web developer wants to generate static thumbnail images from each frame of an APNG for use in a product gallery or preview carousel.
 * 3. When a data‑science team must feed individual PNG frames into a machine‑learning model that only accepts single‑image inputs for video‑frame analysis.
 * 4. When an automation script must convert an APNG animation into separate PNG files to apply per‑frame watermarking or image‑processing filters using Aspose.Imaging in C#.
 * 5. When a CI/CD pipeline needs to validate the visual quality of each animation frame by exporting them as PNGs and comparing them against baseline images.
 */