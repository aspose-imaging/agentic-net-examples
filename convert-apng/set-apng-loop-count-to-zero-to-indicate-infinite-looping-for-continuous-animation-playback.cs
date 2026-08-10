// HOW-TO: Convert WebP to APNG with Infinite Looping in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (handles cases with no directory part)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure APNG options with infinite looping (NumPlays = 0)
                var apngOptions = new ApngOptions
                {
                    NumPlays = 0
                };

                // Save as APNG using the configured options
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
 * 1. When you need to transform a WebP animation into an APNG that repeats forever for use in web banners or UI components.
 * 2. When building a C# desktop application that displays continuous animated icons and requires setting the APNG loop count to zero.
 * 3. When generating game assets where an animated sprite must loop endlessly without manual frame resetting.
 * 4. When creating marketing emails with animated PNGs that should play continuously across email clients supporting APNG.
 * 5. When automating a batch process that converts multiple WebP files to APNGs with infinite playback for digital signage.
 */
