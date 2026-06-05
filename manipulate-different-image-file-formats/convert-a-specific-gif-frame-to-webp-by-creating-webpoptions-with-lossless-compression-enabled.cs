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
            string inputPath = @"C:\Images\sample.gif";
            string outputPath = @"C:\Images\frame0.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameIndex = 0; // index of the frame to convert

                // Validate frame index
                if (gif.PageCount <= frameIndex)
                {
                    Console.Error.WriteLine($"Frame index {frameIndex} out of range. Total frames: {gif.PageCount}");
                    return;
                }

                // Set the active frame to the desired GIF frame
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[frameIndex];

                // Cast the active frame to RasterImage
                RasterImage frameRaster = (RasterImage)gif.ActiveFrame;

                // Create a WebP image from the raster frame
                using (Aspose.Imaging.FileFormats.Webp.WebPImage webp = new Aspose.Imaging.FileFormats.Webp.WebPImage(frameRaster))
                {
                    // Configure lossless WebP options
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save the WebP image
                    webp.Save(outputPath, options);
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
 * 1. When a developer needs to extract the first frame of an animated GIF and store it as a lossless WebP file for high‑quality thumbnails on a web page.
 * 2. When an e‑commerce platform wants to convert a specific product animation frame from GIF to WebP to reduce bandwidth while preserving exact colors for mobile apps.
 * 3. When a social‑media analytics tool must isolate a particular GIF frame and save it as a lossless WebP image for archival and further image‑processing pipelines.
 * 4. When a game developer requires converting a chosen GIF sprite frame to WebP to embed it in a UI asset bundle with lossless compression.
 * 5. When a content‑management system needs to generate a WebP preview of a selected GIF frame for SEO‑friendly image tags without quality loss.
 */