using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input_animation.webp";
        string outputPath = "output_animation.png";

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

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG, preserving original frame timing
                image.Save(outputPath, new ApngOptions());
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
 * 1. When a developer needs to convert an animated WebP banner into an APNG for better cross‑browser support while keeping the original frame delays, this code provides a quick C# solution using Aspose.Imaging.
 * 2. When a mobile app requires animated assets in APNG format for iOS compatibility, the snippet can transform existing WebP animations without losing timing information.
 * 3. When an email marketing platform wants to embed animated images that are widely supported in email clients, the code converts WebP to APNG while preserving the animation speed.
 * 4. When a game developer stores sprite animations as WebP files but the game engine only accepts APNG, this example shows how to batch‑convert them in .NET while retaining frame timing.
 * 5. When a content management system needs to serve animated images in APNG to reduce bandwidth and maintain smooth playback, the program demonstrates the necessary file‑format conversion with Aspose.Imaging.
 */