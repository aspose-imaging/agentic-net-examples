// HOW-TO: Create PNG Mask From JPEG Using Magic Wand Tool In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputMaskPath = "mask.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputMaskPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using MagicWandTool.
                // Here we start from pixel (0,0); adjust coordinates as needed.
                ImageMask mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0));

                // Apply the mask to the source image (adds transparency where mask is transparent)
                mask.Apply();

                // Save the resulting mask as a PNG with alpha channel
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputMaskPath, pngOptions);
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
 * 1. When you need to isolate a subject in a JPEG and export the selection as a transparent PNG for further editing in Photoshop.
 * 2. When building a web application that lets users click on an image to generate a mask for background removal.
 * 3. When automating batch processing to create alpha‑channel masks from product photos for e‑commerce catalogs.
 * 4. When integrating image analysis that requires a binary mask derived from a JPEG for computer‑vision algorithms.
 * 5. When preparing assets for game development where a JPEG texture must be converted into a PNG mask for sprite compositing.
 */
