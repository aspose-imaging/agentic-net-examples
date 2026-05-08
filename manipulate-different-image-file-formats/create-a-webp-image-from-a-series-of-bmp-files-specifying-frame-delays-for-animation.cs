using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input BMP files (adjust paths as needed)
            string[] inputPaths = new string[]
            {
                @"C:\temp\frame1.bmp",
                @"C:\temp\frame2.bmp",
                @"C:\temp\frame3.bmp"
            };

            // Hard‑coded output WebP file
            string outputPath = @"C:\temp\animated.webp";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first BMP to obtain dimensions
            using (RasterImage firstBmp = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = firstBmp.Width;
                int height = firstBmp.Height;

                // Configure animation options
                WebPOptions createOptions = new WebPOptions
                {
                    Lossless = true,
                    Quality = 100f,
                    AnimLoopCount = 0, // 0 = infinite loop
                    AnimBackgroundColor = (uint)Color.White.ToArgb()
                };

                // Create an empty animated WebP image
                using (WebPImage webPImage = new WebPImage(width, height, createOptions))
                {
                    // Define a uniform frame delay (in milliseconds)
                    const int frameDelay = 100; // 0.1 second per frame

                    // Add each BMP as a frame
                    foreach (string inputPath in inputPaths)
                    {
                        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
                        {
                            // Create a frame block from the raster image
                            WebPFrameBlock block = new WebPFrameBlock(bmp);

                            // Set the frame duration (delay)
                            block.Duration = frameDelay;

                            // Add the block to the animated WebP
                            webPImage.AddBlock(block);
                        }
                    }

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