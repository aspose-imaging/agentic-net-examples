// HOW-TO: Create Animated WebP from Multiple BMP Files with Frame Delays in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;

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

            // Load the first image to obtain width and height
            int width, height;
            using (RasterImage firstImg = (RasterImage)Image.Load(inputPaths[0]))
            {
                width = firstImg.Width;
                height = firstImg.Height;
            }

            // Configure WebP options for animation
            WebPOptions createOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 80f,
                AnimLoopCount = 0,                 // 0 = infinite loop
                AnimBackgroundColor = (uint)Color.White.ToArgb()
            };

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an empty animated WebP image
            using (WebPImage webPImage = new WebPImage(width, height, createOptions))
            {
                // Add each BMP as a frame with a specific delay (in milliseconds)
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

                // Save the animated WebP file
                webPImage.Save(outputPath);
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
 * 1. When you need to convert a series of BMP screenshots into a single animated WebP for faster web delivery.
 * 2. When you want to generate an infinite‑looping WebP animation with custom frame timing for use in mobile apps.
 * 3. When you have legacy BMP assets and must create a lightweight animated image without losing color fidelity.
 * 4. When you need to programmatically set the background color and loop count of an animated WebP in a .NET service.
 * 5. When you are building a batch process that validates BMP files, resizes them, and assembles them into an animated WebP with specific millisecond delays.
 */
