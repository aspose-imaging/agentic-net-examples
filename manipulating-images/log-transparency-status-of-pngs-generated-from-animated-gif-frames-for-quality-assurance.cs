using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameCount = gif.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    // Set the active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    bool hasTransparency = gif.HasTransparentColor;

                    string outputPath = Path.Combine(outputDir, $"frame_{i}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as PNG
                    gif.Save(outputPath, new PngOptions());

                    Console.WriteLine($"Frame {i}: Transparent = {hasTransparency}, saved to {outputPath}");
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
 * 1. When a QA engineer needs to verify that each frame extracted from an animated GIF retains its original transparency after conversion to PNG for a web‑based image gallery.
 * 2. When a developer is building a batch conversion tool that extracts every frame of a GIF, saves them as PNG files, and logs whether each frame contains a transparent color to ensure correct rendering in mobile apps.
 * 3. When a digital asset manager wants to audit a collection of animated GIFs by converting each frame to PNG and recording transparency status to maintain consistency across a content management system.
 * 4. When a testing script must automatically generate PNG thumbnails from GIF animation frames and capture the transparency flag to detect any loss of alpha channel during the conversion process.
 * 5. When an e‑learning platform processes animated GIFs into individual PNG slides and needs to log transparency information to guarantee that overlay graphics appear correctly in the final course material.
 */