using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing frame images and output file path
        string inputDirectory = "C:\\temp\\frames";
        string outputPath = "C:\\temp\\output\\animated.gif";

        try
        {
            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all files in the input directory
            string[] frameFiles = Directory.GetFiles(inputDirectory);
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine($"No files found in: {inputDirectory}");
                return;
            }

            // Load the first frame to create the GIF image
            string firstFile = frameFiles[0];
            if (!File.Exists(firstFile))
            {
                Console.Error.WriteLine($"File not found: {firstFile}");
                return;
            }

            using (RasterImage firstFrame = (RasterImage)Image.Load(firstFile))
            using (GifImage gifImage = new GifImage(new GifFrameBlock(firstFrame)))
            {
                // Load and add remaining frames
                for (int i = 1; i < frameFiles.Length; i++)
                {
                    string filePath = frameFiles[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        gifImage.AddPage(frame);
                    }
                }

                // Increase contrast of the whole GIF (value range: -100 to 100)
                gifImage.AdjustContrast(50f);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the animated GIF with enhanced contrast
                gifImage.Save(outputPath);
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
 * 1. When creating an animated GIF from a series of PNG or JPEG frames for a marketing email, a developer can use this C# code with Aspose.Imaging to increase contrast and produce richer tones that stand out in the recipient’s inbox.
 * 2. When generating a product showcase slideshow as an animated GIF for an e‑commerce website, this snippet helps boost the visual impact by adjusting contrast before saving the final GIF file.
 * 3. When automating the conversion of low‑contrast security camera snapshots into a high‑contrast animated GIF for quick incident review, the code provides a C# solution that processes each frame and enhances image clarity.
 * 4. When building a social media content tool that assembles user‑uploaded images into a vibrant animated GIF, developers can apply this approach to improve contrast and ensure the GIF looks lively across platforms.
 * 5. When developing a desktop utility that batches multiple image sequences into animated GIFs with consistent tonal depth, this example demonstrates how to load, contrast‑enhance, and export the GIF using Aspose.Imaging for .NET.
 */