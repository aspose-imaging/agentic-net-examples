// HOW-TO: Blend JPEG Onto Transparent PNG With 50% Opacity In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.jpg";
        string outputPath = "result.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Prepare PNG creation options (transparent background)
                PngOptions pngOptions = new PngOptions
                {
                    // Use a memory stream source; the stream itself is not used for creation
                    Source = new StreamSource(new MemoryStream(), false)
                };

                // Create a blank PNG image with the same dimensions as the JPEG
                using (RasterImage pngImage = (RasterImage)Image.Create(pngOptions, jpegImage.Width, jpegImage.Height))
                {
                    // Apply alpha blending with 127 (≈50% opacity)
                    // Blend the JPEG onto the PNG background at (0,0) with the specified alpha
                    pngImage.Blend(new Point(0, 0), jpegImage, 127);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the result as PNG
                    pngImage.Save(outputPath);
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
 * 1. When you need to convert a JPEG photograph to a PNG with a semi‑transparent background for web overlays.
 * 2. When creating watermarked thumbnails where the original JPEG must be blended at 50% opacity onto a PNG canvas.
 * 3. When preparing images for UI elements that require PNG format with controlled opacity to match design specifications.
 * 4. When integrating legacy JPEG assets into a game engine that only accepts PNG textures with alpha channels.
 * 5. When generating printable graphics where the JPEG content must be merged with a transparent PNG layer to preserve background flexibility.
 */
