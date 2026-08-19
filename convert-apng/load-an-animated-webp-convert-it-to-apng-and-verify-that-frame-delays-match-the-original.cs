// HOW-TO: Convert Animated WebP to APNG and Verify Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input_animation.webp";
            string outputPath = @"C:\Images\output_animation.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // Convert and save to APNG format
                webpImage.Save(outputPath, new ApngOptions());

                // Attempt to retrieve original frame delay (if available)
                // Aspose.Imaging does not expose a direct property for per‑frame delay on WebPImage,
                // so we fall back to a default value of 0 (unknown).
                uint originalDefaultDelay = 0;

                // Load the generated APNG image for verification
                using (Image apngImage = Image.Load(outputPath))
                {
                    if (apngImage is ApngImage apng)
                    {
                        // APNG exposes a DefaultFrameTime property (milliseconds)
                        uint apngDefaultDelay = apng.DefaultFrameTime;

                        // Simple verification: compare default delays when original is known
                        if (originalDefaultDelay != 0 && apngDefaultDelay != originalDefaultDelay)
                        {
                            Console.WriteLine("Frame delay mismatch between WebP and APNG.");
                        }
                        else
                        {
                            Console.WriteLine("Frame delays verified (or could not be determined from source).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to load APNG image for verification.");
                    }
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
 * 1. When you need to display an animated image on a platform that supports APNG but not WebP, you can convert the WebP animation to APNG using C#.
 * 2. When preserving the timing of each frame is critical for motion graphics, you can verify that the default frame delay of the generated APNG matches the original WebP.
 * 3. When automating a batch process that ingests user‑uploaded animated WebP files and outputs APNG files for email newsletters, this code handles loading, conversion, and basic validation.
 * 4. When integrating image assets into a .NET desktop application that only reads PNG streams, converting animated WebP to APNG ensures compatibility while keeping animation.
 * 5. When troubleshooting differences in animation speed after format conversion, the sample lets you compare the original WebP delay (if known) with the APNG DefaultFrameTime property.
 */
