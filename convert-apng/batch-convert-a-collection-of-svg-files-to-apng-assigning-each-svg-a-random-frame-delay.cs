// HOW-TO: Batch Convert SVG Files to Animated PNG with Random Frame Delays in C# (Aspose.Imaging for .NET)
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
            string outputDirectory = @"C:\OutputApngs";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            Random random = new Random();

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Assign a random frame delay between 100ms and 1000ms
                    int delayMs = random.Next(100, 1001);
                    ApngOptions options = new ApngOptions
                    {
                        DefaultFrameTime = (uint)delayMs
                    };

                    // Save as APNG
                    image.Save(outputPath, options);
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
 * 1. When you need to generate a series of animated PNGs from vector SVG assets for a web slideshow, assigning each frame a unique display time.
 * 2. When automating the creation of lightweight animated icons from design files, ensuring each icon plays at a different speed without manual editing.
 * 3. When preparing a batch of SVG illustrations for a mobile app that requires APNG support and varied frame timing to create dynamic visual effects.
 * 4. When converting a folder of SVG diagrams into animated PNGs for an e‑learning platform, using random delays to add visual variety to each illustration.
 * 5. When building a CI pipeline that transforms SVG resources into APNGs with per‑image random delays to simulate natural motion in a game UI.
 */
