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
            // Hardcoded input and output directories
            string inputPath = @"C:\Images\animation.webp";
            string outputDir = @"C:\Images\Frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the animated WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                var multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Iterate through each frame and save as BMP
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is an Image; cast to RasterImage for saving
                    using (RasterImage frame = (RasterImage)multipage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                        // Ensure the directory for the output file exists
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
 * 1. When a developer needs to extract every frame from an animated WebP file to BMP images for pixel‑level analysis or debugging of animation timing.
 * 2. When a video‑processing pipeline requires converting WebP animation frames into lossless BMP files before applying computer‑vision algorithms in a .NET application.
 * 3. When a quality‑control tool must compare each frame of a WebP animation against reference BMP assets to detect rendering artifacts.
 * 4. When a game‑engine asset pipeline imports animated WebP sprites and needs individual BMP frames for texture atlasing or sprite sheet generation.
 * 5. When a forensic analyst wants to archive each frame of a WebP animation as separate BMP files to preserve original color data for legal evidence.
 */