// HOW-TO: Invert Magic Wand Selection And Save As PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };

                using (RasterImage maskCanvas = (RasterImage)Image.Create(pngOptions, sourceImage.Width, sourceImage.Height))
                {
                    ImageBitMask invertedMask = MagicWandTool
                        .Select(sourceImage, new MagicWandSettings(0, 0))
                        .Invert();

                    invertedMask.ApplyTo(maskCanvas);
                    maskCanvas.Save();
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
 * 1. When you need to generate a transparent background mask for a PNG image by selecting the foreground with Magic Wand and then inverting it.
 * 2. When you want to programmatically create a binary mask that isolates the background of an image for further compositing or analysis.
 * 3. When you are building an automated image‑processing pipeline that must export the inverted selection as a true‑color PNG with alpha channel.
 * 4. When you need to replace or remove the original background of photos by saving the inverted mask for use in graphics editors.
 * 5. When you are developing a C# application that must detect edges, invert the selection, and store the result as a separate PNG file for machine‑learning preprocessing.
 */
