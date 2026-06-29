using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

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

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a blank PNG image with the same dimensions
                PngOptions pngCreateOptions = new PngOptions();
                using (RasterImage pngImage = (RasterImage)Image.Create(pngCreateOptions, jpegImage.Width, jpegImage.Height))
                {
                    // Blend the JPEG onto the PNG with 127 (≈50%) opacity
                    // Origin (0,0) means top‑left corner
                    pngImage.Blend(new Aspose.Imaging.Point(0, 0), jpegImage, 127);

                    // Save the result as PNG
                    pngImage.Save(outputPath, new PngOptions());
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
 * 1. When a web developer needs to overlay a semi‑transparent JPEG watermark onto a transparent PNG background for dynamic image generation.
 * 2. When a desktop application must convert high‑resolution JPEG photos to PNG format while preserving 50 % opacity for preview thumbnails.
 * 3. When an e‑commerce platform wants to display product images with a faded background effect by blending JPEGs into PNG canvases at 127 opacity.
 * 4. When a reporting tool generates charts as JPEGs and needs to embed them into PNG‑based PDF assets with partial transparency.
 * 5. When a mobile app processes user‑uploaded JPEG avatars and creates PNG avatars with reduced opacity for UI overlay effects.
 */