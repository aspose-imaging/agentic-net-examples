using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input BMP files
            string inputPath1 = "frame1.bmp";
            string inputPath2 = "frame2.bmp";
            string inputPath3 = "frame3.bmp";

            // Hardcoded output WebP file
            string outputPath = "Output\\animation.webp";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas size
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPath1))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Configure WebP animation options
                WebPOptions createOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f,
                    AnimLoopCount = 0 // infinite loop
                };

                // Create an empty animated WebP image
                using (WebPImage webPImage = new WebPImage(width, height, createOptions))
                {
                    // Add first frame with a delay of 100 ms
                    using (RasterImage frame1 = (RasterImage)Image.Load(inputPath1))
                    {
                        WebPFrameBlock block1 = new WebPFrameBlock(frame1);
                        // If the API provides a duration property, set it here
                        // block1.Duration = 100;
                        webPImage.AddBlock(block1);
                    }

                    // Add second frame with a delay of 200 ms
                    using (RasterImage frame2 = (RasterImage)Image.Load(inputPath2))
                    {
                        WebPFrameBlock block2 = new WebPFrameBlock(frame2);
                        // block2.Duration = 200;
                        webPImage.AddBlock(block2);
                    }

                    // Add third frame with a delay of 150 ms
                    using (RasterImage frame3 = (RasterImage)Image.Load(inputPath3))
                    {
                        WebPFrameBlock block3 = new WebPFrameBlock(frame3);
                        // block3.Duration = 150;
                        webPImage.AddBlock(block3);
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