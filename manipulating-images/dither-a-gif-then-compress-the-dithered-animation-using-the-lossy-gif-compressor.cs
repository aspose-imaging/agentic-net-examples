using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output_lossy.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply dithering (Floyd‑Steinberg, 8‑bit palette)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Prepare GIF save options with lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression (recommended 80)
                    MaxDiff = 80,
                    // Optional: keep interlacing off
                    Interlaced = false,
                    // Optional: set color resolution (7 means 8 bits per channel)
                    ColorResolution = 7
                };

                // Save the dithered image with lossy compression
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to shrink an animated GIF for faster web page loading by applying Floyd‑Steinberg dithering to an 8‑bit palette and then saving it with lossy GIF compression options such as MaxDiff and palette correction.
 * 2. When a developer wants to reduce the attachment size of a GIF used in email newsletters while preserving acceptable visual quality by dithering the frames before applying lossy compression.
 * 3. When a developer is optimizing GIF stickers for a mobile app, converting high‑color frames to a limited palette with dithering and then using lossy GIF settings to meet device memory constraints.
 * 4. When a developer processes user‑uploaded GIFs on a server, ensuring each animation is dithered to a smaller palette and saved with lossy compression to stay within storage quotas.
 * 5. When a developer prepares legacy GIF animations for a game UI, using Floyd‑Steinberg dithering followed by lossy GIF compression to balance file size and visual fidelity.
 */