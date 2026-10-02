// HOW-TO: Crop TGA Image to Circular Region and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tga";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int radius = 100;
                int centerX = image.Width / 2;
                int centerY = image.Height / 2;

                MagicWandTool.Select(image, new MagicWandSettings(centerX, centerY))
                    .Union(new CircleMask(centerX, centerY, radius))
                    .Invert()
                    .Apply();

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to extract a round thumbnail from a TGA texture for UI icons.
 * 2. When converting legacy game assets stored as TGA files to PNG with a transparent circular mask for web display.
 * 3. When preparing circular profile pictures from high‑resolution TGA scans for mobile applications.
 * 4. When generating circular cutouts from TGA maps for scientific visualizations that require PNG with an alpha channel.
 * 5. When automating batch processing of TGA images to create circular overlays for printed materials.
 */
