// HOW-TO: Convert a Single GIF Frame to Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output_frame.webp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific features
                GifImage gif = (GifImage)image;

                // Index of the frame to convert (0‑based)
                int frameIndex = 0;

                // Configure WebP options with lossless compression
                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = true,
                    // Export only the specified frame
                    MultiPageOptions = new MultiPageOptions(new IntRange(frameIndex, frameIndex + 1))
                };

                // Save the selected frame as a WebP image
                gif.Save(outputPath, webpOptions);
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
 * 1. When you need to extract the first frame of an animated GIF and store it as a high‑quality, lossless WebP image for web optimization.
 * 2. When you want to generate thumbnails from specific GIF frames without sacrificing visual fidelity, using C# and Aspose.Imaging.
 * 3. When a mobile app requires a single GIF frame in WebP format to reduce bandwidth while preserving exact pixel data.
 * 4. When converting legacy GIF assets to modern WebP files for a content management system, selecting only the required frame to save storage.
 * 5. When automating a batch process that extracts a chosen frame from multiple GIFs and saves each as lossless WebP for archival purposes.
 */
