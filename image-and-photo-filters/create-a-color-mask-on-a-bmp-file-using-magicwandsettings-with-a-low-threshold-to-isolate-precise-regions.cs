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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(50, 50) { Threshold = 10 })
                    .Apply();

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
 * 1. When a developer needs to extract a small, uniformly colored logo from a BMP file and preserve its transparency for use on a website, they can apply a low‑threshold MagicWand mask and save the result as a PNG with alpha.
 * 2. When processing scanned documents in C# where a faint watermark must be isolated from a BMP background, a low Threshold in MagicWandSettings helps create an accurate mask before exporting to a transparent PNG.
 * 3. When building a desktop application that converts legacy BMP icons into modern PNG assets, using MagicWandTool with a low Threshold isolates the exact icon shape for clean alpha channel generation.
 * 4. When performing batch image cleanup to remove a specific colored background from BMP screenshots, a developer can use the low‑threshold MagicWand mask to retain only the foreground and output a TruecolorWithAlpha PNG.
 * 5. When integrating image analysis in a .NET workflow that requires precise region selection—such as highlighting a colored defect on a BMP product photo—a low Threshold MagicWand mask isolates the defect area before saving it as a transparent PNG for further reporting.
 */