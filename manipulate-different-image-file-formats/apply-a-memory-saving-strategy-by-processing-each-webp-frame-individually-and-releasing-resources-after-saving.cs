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
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputDirectory = "frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Load the source WebP image
            using (WebPImage webP = new WebPImage(inputPath))
            {
                int frameCount = webP.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Build output path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                    // Ensure the directory for this frame exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Extract the frame as a RasterImage and save it individually
                    using (WebPImage frameImage = new WebPImage((RasterImage)webP.Pages[i]))
                    {
                        frameImage.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a developer needs to extract each frame from an animated WebP file and save them as separate PNG thumbnails for a web gallery while minimizing memory consumption.
 * 2. When a mobile application processes large animated WebP stickers and must convert each frame to PNG on‑the‑fly without loading the entire animation into memory.
 * 3. When a server‑side batch job converts animated WebP advertisements into individual PNG frames for analytics or further image manipulation, releasing resources after each save.
 * 4. When a game engine imports animated WebP assets and requires per‑frame PNG textures for sprite animation while preventing memory leaks in C# code.
 * 5. When a digital publishing workflow extracts frames from a WebP slideshow to generate printable PNG images on a low‑resource CI/CD build server.
 */