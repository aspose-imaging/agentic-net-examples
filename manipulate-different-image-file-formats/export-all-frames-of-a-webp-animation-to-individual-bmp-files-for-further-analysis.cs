using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\animation.webp";
            string outputDirectory = @"C:\temp\frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP animation
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP
                    multipage.Pages[i].Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract each frame from a WebP animation to BMP files for pixel‑perfect quality inspection using Aspose.Imaging in a C# application.
 * 2. When a video processing pipeline requires converting animated WebP assets into individual BMP images for compatibility with legacy image analysis tools.
 * 3. When a game developer wants to decompose a WebP sprite sheet animation into separate BMP frames to apply custom per‑frame effects or physics calculations.
 * 4. When a machine‑learning engineer must generate a dataset of BMP frames from a WebP animation to train an image classification model on individual motion steps.
 * 5. When a digital archivist needs to preserve each frame of a WebP animation as lossless BMP files for long‑term storage and metadata extraction.
 */