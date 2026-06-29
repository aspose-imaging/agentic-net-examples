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
            // Hardcoded list of animated WEBP files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Images\anim1.webp",
                @"C:\Images\anim2.webp",
                // Add additional input paths as needed
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .png extension (APNG)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WEBP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG, preserving original frame order and timing
                    image.Save(outputPath, new ApngOptions());
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
 * 1. When a developer needs to migrate a library of animated WEBP assets to the widely‑supported APNG format for use in web applications while keeping the original frame order and timing metadata.
 * 2. When an e‑learning platform wants to convert user‑uploaded animated WEBP stickers into APNGs so they render correctly across browsers that only support PNG animation.
 * 3. When a game developer must batch‑process sprite animations stored as animated WEBP files into APNGs for integration with a Unity UI that reads PNG sequences.
 * 4. When a marketing automation tool has to transform promotional animated WEBP banners into APNGs before embedding them in email newsletters that require PNG compatibility.
 * 5. When a content management system needs to archive animated WEBP illustrations as APNG files to ensure long‑term accessibility and preserve frame timing for future playback.
 */