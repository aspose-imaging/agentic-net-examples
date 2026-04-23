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
            // Hard‑coded input BMP files (replace with your actual file names)
            string[] inputPaths = new string[]
            {
                @"C:\temp\frame1.bmp",
                @"C:\temp\frame2.bmp",
                @"C:\temp\frame3.bmp"
                // add more paths as needed
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

            // Hard‑coded output WebP file
            string outputPath = @"C:\temp\animated_output.webp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first BMP to obtain width/height
            using (RasterImage firstBmp = (RasterImage)Image.Load(inputPaths[0]))
            {
                // Configure animation options
                WebPOptions options = new WebPOptions
                {
                    Lossless = true,
                    Quality = 100f,
                    AnimBackgroundColor = (uint)Aspose.Imaging.Color.Gray.ToArgb(),
                    AnimLoopCount = 0 // 0 = infinite loop
                };

                // Create an empty animated WebP image with the size of the first frame
                using (WebPImage webPImage = new WebPImage(firstBmp.Width, firstBmp.Height, options))
                {
                    // Add each BMP as a frame
                    foreach (var inputPath in inputPaths)
                    {
                        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
                        {
                            // Create a frame block from the raster image
                            WebPFrameBlock frameBlock = new WebPFrameBlock(bmp);

                            // Set frame delay (in milliseconds). Adjust as needed.
                            // The property name for delay may differ; replace with the correct one if required.
                            // Example: frameBlock.Duration = 100; // 100 ms per frame
                            // If the API uses a different member, set it accordingly.
                            // frameBlock.Delay = 100;

                            // Add the frame to the animated WebP
                            webPImage.AddBlock(frameBlock);
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