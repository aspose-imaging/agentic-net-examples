// HOW-TO: Create Precise Color Mask on BMP Using Magic Wand in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\masked.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a color mask using MagicWand with a low threshold for precise selection
                MagicWandTool
                    .Select(image, new MagicWandSettings(50, 50) { Threshold = 10 })
                    .Apply();

                // Save the result as a PNG with alpha channel to preserve the mask
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
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
 * 1. When you need to isolate a specific colored region in a BMP and export it as a transparent PNG for overlay in a UI.
 * 2. When you want to generate a precise mask for a scanned diagram by using a low‑threshold Magic Wand selection in C#.
 * 3. When you are preparing assets for a game and must extract exact shapes from bitmap textures while preserving transparency.
 * 4. When you automate batch processing of BMP files to create alpha‑masked PNGs for web graphics without manual selection.
 * 5. When you integrate Aspose.Imaging into a .NET service to programmatically cut out objects from BMP images for document generation.
 */
