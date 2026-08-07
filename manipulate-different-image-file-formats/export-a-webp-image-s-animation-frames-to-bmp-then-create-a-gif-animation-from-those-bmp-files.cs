using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\animation.webp";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // List to hold BMP file paths
            List<string> bmpPaths = new List<string>();

            // Load the animated WebP image
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                int frameCount = webpImage.PageCount;

                // Export each frame to BMP
                for (int i = 0; i < frameCount; i++)
                {
                    // Cast the page to RasterImage
                    RasterImage frame = (RasterImage)webpImage.Pages[i];

                    string bmpPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure the directory for the BMP exists
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    // Save the frame as BMP
                    BmpOptions bmpOptions = new BmpOptions();
                    frame.Save(bmpPath, bmpOptions);

                    bmpPaths.Add(bmpPath);
                }
            }

            // Create a GIF animation from the exported BMP frames
            if (bmpPaths.Count > 0)
            {
                string outputGifPath = Path.Combine(outputDirectory, "animation.gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

                // Load the first BMP frame and create the initial GIF frame block
                using (RasterImage firstBmp = (RasterImage)Image.Load(bmpPaths[0]))
                using (GifFrameBlock firstBlock = new GifFrameBlock(firstBmp))
                using (GifImage gifImage = new GifImage(firstBlock))
                {
                    // Add remaining BMP frames to the GIF
                    for (int i = 1; i < bmpPaths.Count; i++)
                    {
                        using (RasterImage bmp = (RasterImage)Image.Load(bmpPaths[i]))
                        using (GifFrameBlock block = new GifFrameBlock(bmp))
                        {
                            gifImage.AddBlock(block);
                        }
                    }

                    // Save the GIF animation
                    gifImage.Save(outputGifPath);
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
 * 1. When a developer needs to convert an animated WebP file into individual BMP frames for legacy systems that only support BMP, then reassemble those frames into a GIF for broader web compatibility.
 * 2. When a game developer wants to extract each frame of a WebP sprite animation, edit them as BMP images, and generate a GIF preview to share with designers.
 * 3. When an e‑learning platform must transform user‑uploaded animated WebP tutorials into BMP thumbnails and combine them into a GIF slideshow for email newsletters.
 * 4. When a digital archivist has a collection of animated WebP assets and requires a batch process in C# using Aspose.Imaging to export frames to BMP and create GIF animations for archival standards.
 * 5. When a marketing automation script needs to programmatically convert animated WebP ads into BMP frames for watermarking, then rebuild them as GIFs for display on platforms that do not support WebP.
 */