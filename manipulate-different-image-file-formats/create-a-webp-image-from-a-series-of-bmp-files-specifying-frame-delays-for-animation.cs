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
        try
        {
            // Hardcoded input BMP files
            string[] inputPaths = new string[]
            {
                @"C:\temp\frame1.bmp",
                @"C:\temp\frame2.bmp",
                @"C:\temp\frame3.bmp"
            };

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Output WebP file
            string outputPath = @"C:\temp\animated_output.webp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create WebP options for animation
            WebPOptions createOptions = new WebPOptions
            {
                Lossless = true,
                Quality = 100f,
                AnimBackgroundColor = (uint)Aspose.Imaging.Color.Gray.ToArgb(),
                AnimLoopCount = 0 // 0 = infinite loop
            };

            // Assume all BMPs have the same dimensions; load first to get size
            using (RasterImage firstBmp = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = firstBmp.Width;
                int height = firstBmp.Height;

                // Create an empty animated WebP image
                using (WebPImage webPImage = new WebPImage(width, height, createOptions))
                {
                    // Add each BMP as a frame with a specific delay
                    foreach (var inputPath in inputPaths)
                    {
                        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
                        {
                            // Create a frame block from the BMP raster image
                            WebPFrameBlock frameBlock = new WebPFrameBlock(bmp);

                            // Set frame duration (e.g., 200 ms per frame)
                            frameBlock.Duration = 200; // duration in milliseconds

                            // Add the frame to the animated WebP
                            webPImage.AddBlock(frameBlock);
                        }
                    }

                    // Save the animated WebP
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
 * 1. When a developer needs to convert a series of BMP screenshots into a lightweight animated WebP for embedding in a web page to reduce bandwidth while preserving lossless quality.
 * 2. When an application must generate an animated WebP advertisement from pre‑rendered BMP assets, specifying custom frame delays to control the timing of each visual element.
 * 3. When a game studio wants to create looping character animation loops by stitching together BMP sprite frames into an infinite‑loop WebP animation using C# and Aspose.Imaging.
 * 4. When a reporting tool has to export multi‑page BMP charts as a single animated WebP file so that stakeholders can view the progression of data over time with adjustable frame intervals.
 * 5. When a mobile app needs to package a series of BMP UI tutorials into an animated WebP tutorial guide, using the WebPOptions to set lossless compression, quality, and background color for consistent appearance across devices.
 */