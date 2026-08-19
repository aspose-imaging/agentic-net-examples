// HOW-TO: Batch Convert SVG Files to APNG with Default Frame Delay in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputSvgs";
            string outputDir = @"C:\OutputApngs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            // Default frame delay in milliseconds
            const uint defaultFrameDelay = 100;

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct the output file path with .png extension (APNG)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image and save it as an APNG with the default frame time
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions() { DefaultFrameTime = defaultFrameDelay });
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
 * 1. When you need to generate animated PNG icons from a collection of SVG assets for a web dashboard.
 * 2. When an automated build process must convert design‑team SVG illustrations into APNGs for mobile app resources.
 * 3. When a reporting tool requires each SVG chart to be saved as an APNG with a consistent frame timing for slide shows.
 * 4. When migrating legacy SVG animations to a format supported by browsers that only display APNG, using C# batch conversion.
 * 5. When creating a sprite sheet of multiple SVG logos as separate APNG files with a uniform default frame delay for game development.
 */
