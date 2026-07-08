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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputSvgs";
            string outputDirectory = @"C:\OutputApng";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            // Random number generator for frame delays
            Random rnd = new Random();

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .png extension (APNG)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Generate a random frame delay between 100ms and 1000ms
                    uint randomDelay = (uint)rnd.Next(100, 1001);

                    // Set up APNG options with the random default frame time
                    ApngOptions apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = randomDelay
                    };

                    // Save as APNG
                    image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to generate animated PNGs from a library of SVG icons for web dashboards, assigning each frame a random delay to create a lively loading animation.
 * 2. When an e‑learning platform wants to batch‑convert SVG illustrations into APNG assets with varied frame timings to add subtle motion effects without manual editing.
 * 3. When a marketing automation script must transform SVG logos into animated PNGs for email campaigns, using random delays to avoid uniform animation patterns.
 * 4. When a game developer prepares sprite assets by converting SVG files into APNG frames with random display intervals to simulate natural, non‑repetitive character motions.
 * 5. When a reporting tool needs to convert a collection of SVG charts into animated PNGs where each chart appears for a random duration, enhancing visual storytelling in PDF exports.
 */