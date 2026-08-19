// HOW-TO: Convert Multi‑Page TIFF to Infinite Loop Animated APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.apng";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Save as animated APNG with infinite looping (NumPlays = 0)
                var apngOptions = new ApngOptions
                {
                    NumPlays = 0 // 0 indicates infinite looping
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
 * 1. When you need to display a multi‑page scanned document as a looping animation on a website, you can convert the TIFF to an APNG with infinite repeats using C#.
 * 2. When creating a product showcase that cycles through several design drafts automatically, converting the TIFF pages to an animated APNG ensures smooth, endless playback in browsers.
 * 3. When generating animated thumbnails for a gallery where the source images are stored as multi‑page TIFFs, this code creates a continuously looping APNG thumbnail.
 * 4. When building a desktop application that visualizes medical imaging slices as a seamless animation, converting the TIFF stack to an infinite‑loop APNG simplifies rendering.
 * 5. When preparing marketing assets that need to loop forever in presentations or social media, the code transforms the multi‑page TIFF into an APNG with NumPlays set to zero.
 */
