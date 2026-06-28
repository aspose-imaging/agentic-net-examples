using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop central 400x400 area
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                image.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                // Apply feathered Magic Wand selection at the center of the cropped image
                int centerX = image.Width / 2;
                int centerY = image.Height / 2;
                MagicWandTool
                    .Select(image, new MagicWandSettings(centerX, centerY))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save result as PNG with truecolor with alpha
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract the central 400×400 region from a large BMP file, apply a soft‑edge Magic Wand selection, and save the result as a transparent PNG for use as a profile picture thumbnail.
 * 2. When creating game assets by cropping a BMP sprite sheet to a fixed 400×400 tile, applying a feathered Magic Wand mask to isolate the character, and exporting the image as a PNG with an alpha channel.
 * 3. When automating document digitization that trims scanned BMP pages to the central area, uses a feathered Magic Wand selection to remove background noise, and stores the cleaned image as a PNG.
 * 4. When generating web‑ready icons from high‑resolution BMP graphics by extracting the central square, applying a feathered selection to smooth edges, and outputting a transparent PNG.
 * 5. When building a batch‑processing tool that standardizes BMP images to a 400×400 focal area, applies a feathered Magic Wand selection for smooth cut‑outs, and converts them to PNG for downstream image‑analysis pipelines.
 */