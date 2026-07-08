using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input WebP animation path
            string inputPath = @"C:\temp\animation.webp";

            // Hardcoded output directory for BMP frames
            string outputDir = @"C:\temp\frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WebP image (could be animated)
            using (Image image = Image.Load(inputPath))
            {
                // Try to treat the image as a multipage (animated) image
                var multipage = image as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Iterate through each frame/page
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Retrieve the frame
                        using (Image frame = multipage.Pages[i])
                        {
                            // Build output BMP file path
                            string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the frame as BMP
                            frame.Save(outputPath, new BmpOptions());
                        }
                    }
                }
                else
                {
                    // Fallback for single-frame images
                    string outputPath = Path.Combine(outputDir, "frame_0.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract every frame from an animated WebP file to BMP images for pixel‑level analysis or debugging of animation sequences.
 * 2. When a QA engineer wants to compare individual frames of a WebP animation against reference BMP screenshots to verify visual fidelity across platforms.
 * 3. When a machine‑learning pipeline requires converting each frame of a WebP animation into a lossless BMP format before feeding them into a model for image classification.
 * 4. When a legacy system only supports BMP input, and a developer must decompose a modern WebP animation into separate BMP files for compatibility.
 * 5. When a developer is building a tool that generates frame‑by‑frame thumbnails from a WebP animation and needs to save them as BMP files for further processing.
 */