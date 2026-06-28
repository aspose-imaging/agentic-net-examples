using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load GIF image
            using (Image gif = Image.Load(inputPath))
            {
                GifImage gifImage = gif as GifImage;
                if (gifImage == null)
                {
                    Console.Error.WriteLine("Failed to load GIF image.");
                    return;
                }

                // Verify the GIF has at least three frames
                if (gifImage.PageCount < 3)
                {
                    Console.Error.WriteLine("GIF does not contain a third frame.");
                    return;
                }

                // Set the active frame to the third frame (index 2)
                gifImage.ActiveFrame = (GifFrameBlock)gifImage.Pages[2];

                // Prepare lossless WebP options
                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the active frame as a lossless WebP file
                gifImage.Save(outputPath, webpOptions);
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
 * 1. When creating a thumbnail gallery for an animated advertisement, a developer can extract the third frame of a GIF and save it as a lossless WebP to ensure high‑quality preview images without animation overhead.
 * 2. When generating static assets for a mobile app that only supports WebP, extracting a specific frame from a multi‑frame GIF and converting it to lossless WebP reduces file size while preserving visual fidelity.
 * 3. When processing user‑uploaded GIF stickers for a messaging platform, a developer may need to isolate the third frame and store it as a lossless WebP to maintain crisp detail for display on high‑resolution screens.
 * 4. When building an e‑learning platform that extracts key steps from animated tutorials, extracting the third frame of a GIF and converting it to lossless WebP provides a clear, high‑quality snapshot for instructional material.
 * 5. When archiving promotional graphics, a developer can isolate the third frame of a GIF and save it as a lossless WebP to create a permanent, compression‑efficient representation for future reuse.
 */