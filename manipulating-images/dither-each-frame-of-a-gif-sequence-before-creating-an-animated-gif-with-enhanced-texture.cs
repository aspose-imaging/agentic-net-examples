using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing individual frame images
        string inputDirectory = @"C:\temp\frames";
        // Hardcoded output animated GIF path
        string outputPath = @"C:\temp\output\animated_dithered.gif";

        try
        {
            // Verify input directory exists (if not, the subsequent file checks will fail)
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Gather image files (common raster formats)
            var frameFiles = Directory.GetFiles(inputDirectory)
                                      .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                                  f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                                      .OrderBy(f => f) // Ensure deterministic order
                                      .ToArray();

            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine($"No image files found in: {inputDirectory}");
                return;
            }

            GifImage gifImage = null;

            // Process each frame
            foreach (var filePath in frameFiles)
            {
                // Input file existence check
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the raster image
                using (Image img = Image.Load(filePath))
                {
                    // Cast to RasterImage for dithering
                    RasterImage raster = (RasterImage)img;

                    // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
                    raster.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                    // Create a GIF frame block from the dithered raster image
                    using (GifFrameBlock frameBlock = new GifFrameBlock(raster))
                    {
                        if (gifImage == null)
                        {
                            // First frame: initialize the GifImage
                            gifImage = new GifImage(frameBlock);
                        }
                        else
                        {
                            // Subsequent frames: add to the existing GifImage
                            gifImage.AddBlock(frameBlock);
                        }
                    }
                }
            }

            if (gifImage == null)
            {
                Console.Error.WriteLine("Failed to create GIF image.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the animated GIF
            gifImage.Save(outputPath);
            gifImage.Dispose();

            Console.WriteLine($"Animated GIF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating an animated product showcase from high‑resolution PNG frames, you can dither each frame with Aspose.Imaging for C# to reduce file size while preserving texture before saving the result as a GIF.
 * 2. When generating a retro‑style game sprite animation from BMP files, dithering each frame converts the images to a palette‑limited GIF that emulates classic console graphics.
 * 3. When building an email newsletter that includes an animated GIF assembled from JPEG screenshots, applying dithering to each frame prevents color banding and keeps the animation lightweight for email clients.
 * 4. When processing a batch of scanned documents saved as TIFF or PNG and converting them into an animated GIF for quick preview, dithering each frame maintains the readability of fine text on limited‑color displays.
 * 5. When developing a social‑media posting tool that stitches user‑uploaded images into an animated GIF, using Aspose.Imaging to dither each frame ensures the final GIF looks smooth on platforms that support only 256 colors.
 */