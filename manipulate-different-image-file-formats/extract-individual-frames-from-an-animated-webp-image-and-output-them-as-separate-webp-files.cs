using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class ExtractWebPFrames
{
    static void Main()
    {
        // Path to the animated WebP file
        string inputPath = @"C:\temp\animated.webp";

        // Directory where individual frames will be saved
        string outputDir = @"C:\temp\frames";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the animated WebP image using the provided constructor
        using (WebPImage animatedImage = new WebPImage(inputPath))
        {
            // Access all frames (blocks) of the animated image
            Image[] frames = animatedImage.Pages;

            // Iterate through each frame and save it as a separate WebP file
            for (int i = 0; i < frames.Length; i++)
            {
                // Each frame is a WebPFrameBlock; cast it accordingly
                WebPFrameBlock frameBlock = frames[i] as WebPFrameBlock;
                if (frameBlock == null)
                    continue; // Skip if casting fails (should not happen for animated WebP)

                // Create a new WebPImage from the single frame block using the provided constructor
                using (WebPImage singleFrameImage = new WebPImage(frameBlock))
                {
                    // Build the output file name
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.webp");

                    // Save the single frame as a WebP file using the provided Save method
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}