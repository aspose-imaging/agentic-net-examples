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
            string inputPath = "input_animation.webp";
            string outputPath = "output_animation.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (supports animated formats)
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG with 5 loop cycles; default frame timing is preserved
                var apngOptions = new ApngOptions
                {
                    NumPlays = 5
                };
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
 * 1. When a developer needs to convert an animated WebP file to an APNG with a fixed loop count of 5 to guarantee consistent playback across web browsers and mobile apps.
 * 2. When building a C# desktop application that generates looping animated PNGs for UI notifications and wants to control the NumPlays property to limit the animation cycles.
 * 3. When creating marketing assets that must display a specific number of animation repeats in email newsletters, using Aspose.Imaging to set the APNG loop count while preserving original frame timing.
 * 4. When testing playback speed and loop behavior of animated images across different viewers, a developer can use this code to produce an APNG with a known loop count for reliable comparison.
 * 5. When automating a batch process that converts animated WebP files to APNGs, ensuring the output directory exists and handling missing input files gracefully in a .NET environment.
 */