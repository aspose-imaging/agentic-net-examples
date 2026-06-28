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
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The provided file is not an APNG image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    using (RasterImage frame = (RasterImage)apng.Pages[i])
                    {
                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        frame.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract each frame of an animated PNG (APNG) into BMP files for a legacy system that only supports static bitmap images.
 * 2. When integrating a .NET application with an older printing pipeline that requires BMP input, and the source assets are delivered as APNG animations.
 * 3. When creating frame‑by‑frame analysis or computer‑vision preprocessing on an APNG animation, and the analysis library only accepts BMP raster images.
 * 4. When migrating a game’s sprite animations stored as APNG to a classic game engine that loads individual BMP frames from a directory.
 * 5. When generating thumbnails or preview images for an archival tool that stores each APNG frame as a separate BMP to maintain compatibility with older Windows viewers.
 */