using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files and output WebP file
        string[] inputPaths = new string[]
        {
            @"C:\temp\frame1.bmp",
            @"C:\temp\frame2.bmp",
            @"C:\temp\frame3.bmp"
        };
        string outputPath = @"C:\temp\animated.webp";

        try
        {
            // Verify that every input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load the first image to obtain width and height (all frames must share the same size)
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Configure WebP options for an animated image
                WebPOptions createOptions = new WebPOptions
                {
                    Lossless = true,
                    Quality = 100f,
                    AnimLoopCount = 0,               // 0 = infinite loop
                    AnimBackgroundColor = (uint)Color.Transparent.ToArgb()
                };

                // Create an empty animated WebP image
                using (WebPImage webPImage = new WebPImage(width, height, createOptions))
                {
                    // Add each BMP as a frame with a specific delay (duration in milliseconds)
                    foreach (string inputPath in inputPaths)
                    {
                        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
                        {
                            // Create a frame block from the BMP raster image
                            WebPFrameBlock block = new WebPFrameBlock(bmp);

                            // Set frame duration (e.g., 200 ms per frame)
                            block.Duration = 200;

                            // Add the block to the animated WebP image
                            webPImage.AddBlock(block);
                        }
                    }

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the animated WebP file
                    webPImage.Save(outputPath);
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
 * 1. When a developer needs to convert a series of legacy BMP screenshots into a lightweight animated WebP for embedding in a web page with custom frame timing.
 * 2. When an application must generate an animated WebP advertisement from pre‑rendered BMP assets while preserving lossless quality and infinite looping.
 * 3. When a game tool exports character pose BMP images and requires a single animated WebP sprite sheet with specific millisecond delays for smooth playback.
 * 4. When a reporting system creates step‑by‑step BMP diagrams and wants to bundle them into an animated WebP tutorial that can be shared via email.
 * 5. When a mobile app needs to programmatically assemble BMP UI mockups into an animated WebP preview with transparent background and precise frame intervals.
 */