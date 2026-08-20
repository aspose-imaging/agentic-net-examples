// HOW-TO: Adjust Gamma of GIF Frames and Save Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.gif";
        string outputPath = @"C:\Temp\output_adjusted.gif";

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

            // Load the GIF image (may contain multiple frames)
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Apply gamma correction to balance luminance (example gamma value)
                gifImage.AdjustGamma(2.0f);

                // Save the adjusted image as an animated GIF
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to brighten or darken all frames of an existing GIF to achieve consistent visual brightness before publishing it online.
 * 2. When you want to preprocess a multi‑frame GIF with gamma correction using Aspose.Imaging for .NET to ensure the animated image looks uniform on different devices.
 * 3. When you are building a C# tool that automatically adjusts the luminance of user‑uploaded GIFs so the animation appears balanced without manually editing each frame.
 * 4. When you have a batch process that loads GIF sequences, applies a specific gamma value, and saves them as new animated GIFs for use in marketing campaigns.
 * 5. When you need to programmatically verify a GIF file exists, create the output folder, apply gamma correction, and export the result as an animated GIF in a .NET application.
 */
