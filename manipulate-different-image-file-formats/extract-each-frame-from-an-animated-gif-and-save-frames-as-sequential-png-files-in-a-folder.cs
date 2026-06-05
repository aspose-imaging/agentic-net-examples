using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input GIF and output folder paths
        string inputPath = "input.gif";
        string outputFolder = "output_frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Load the animated GIF
            using (GifImage gifImage = (GifImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (GifFrameBlock block in gifImage.Blocks)
                {
                    // Extract full raster image for the current frame
                    using (RasterImage frame = block.GetFullFrame())
                    {
                        // Build output file path (e.g., frame_0000.png)
                        string outputPath = Path.Combine(outputFolder, $"frame_{frameIndex:D4}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as PNG
                        frame.Save(outputPath);
                    }

                    frameIndex++;
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
 * 1. When a developer needs to convert an animated GIF into a sequence of high‑quality PNG images for frame‑by‑frame editing in a graphics editor, they can use this C# Aspose.Imaging code to extract each frame and save it as a lossless PNG file.
 * 2. When building a web application that generates preview thumbnails for each step of an animated advertisement, the code can extract individual GIF frames and store them as PNGs for faster loading and caching.
 * 3. When creating a dataset of image samples for machine‑learning models that require consistent file formats, developers can run this routine to split an animated GIF into separate PNG frames for labeling and training.
 * 4. When developing a game that uses sprite animations, the code allows developers to decompose a GIF sprite sheet into individual PNG frames that can be imported into the game engine’s animation system.
 * 5. When performing forensic analysis of user‑uploaded GIFs to detect hidden content or tampering, the code provides a reliable way to extract each frame as PNGs for detailed pixel‑level inspection.
 */