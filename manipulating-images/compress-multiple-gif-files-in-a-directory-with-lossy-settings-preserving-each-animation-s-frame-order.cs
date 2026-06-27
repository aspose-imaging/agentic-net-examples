using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\InputGifs";
            string outputDirectory = @"C:\OutputGifs";

            // Ensure the output directory exists (creates parent if needed)
            Directory.CreateDirectory(outputDirectory);

            // Process every GIF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output folder exists (required before saving)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image, apply lossy compression, and save it
                using (Image image = Image.Load(inputPath))
                {
                    // Configure lossy compression (MaxDiff > 0)
                    var saveOptions = new GifOptions
                    {
                        MaxDiff = 80 // recommended value for good lossy compression
                    };

                    // Save the compressed GIF while preserving animation frames order
                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime error without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to reduce the bandwidth of animated GIFs on a website by applying lossy compression while keeping the original frame sequence intact.
 * 2. When a mobile app team wants to batch‑process user‑uploaded GIF stickers to fit size limits without breaking the animation order.
 * 3. When an e‑learning platform must archive a large collection of tutorial GIFs in a smaller footprint while preserving the step‑by‑step animation flow.
 * 4. When a digital marketing agency automates the optimization of promotional GIF banners stored in a folder before uploading them to an ad server.
 * 5. When a game developer prepares animated sprite sheets in GIF format for faster loading by compressing them lossily and ensuring each frame remains in the correct order.
 */