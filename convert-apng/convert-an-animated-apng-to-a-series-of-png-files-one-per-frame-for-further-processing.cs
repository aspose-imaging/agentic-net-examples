// HOW-TO: Extract Frames from Animated APNG to PNG Files in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDirectory = "output_frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = image as ApngImage;
                if (apngImage == null)
                {
                    Console.Error.WriteLine("The provided file is not a valid APNG image.");
                    return;
                }

                // Iterate through each frame and save as a separate PNG file
                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apngImage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.png");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as PNG
                        frame.Save(outputPath, new PngOptions());
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
 * 1. When you need to analyze or edit each individual frame of an animated APNG for tasks such as adding watermarks or applying filters.
 * 2. When you want to generate a thumbnail gallery by extracting every frame of an APNG and saving them as separate PNG images for a web preview.
 * 3. When a game developer must convert APNG sprite animations into separate PNG assets to integrate with a custom rendering engine.
 * 4. When a data‑processing pipeline requires breaking down an APNG into static images to feed a machine‑learning model that only accepts PNG inputs.
 * 5. When you are creating a video from an APNG and need to export each frame as PNG to assemble with a video encoder.
 */
