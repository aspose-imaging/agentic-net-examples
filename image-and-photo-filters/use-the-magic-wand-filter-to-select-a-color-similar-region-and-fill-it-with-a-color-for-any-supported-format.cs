using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask selecting a region similar to the color at (120,100) with a threshold
            ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(120, 100) { Threshold = 150 });

            // Load pixel data
            Color[] pixels = image.LoadPixels(image.Bounds);

            // Desired fill color
            Color fillColor = Color.Red;

            // Iterate over the mask bounds and replace opaque mask pixels with the fill color
            Rectangle maskBounds = mask.Bounds;
            for (int y = maskBounds.Y; y < maskBounds.Y + maskBounds.Height; y++)
            {
                for (int x = maskBounds.X; x < maskBounds.X + maskBounds.Width; x++)
                {
                    if (mask.IsOpaque(x, y))
                    {
                        int index = y * image.Width + x;
                        pixels[index] = fillColor;
                    }
                }
            }

            // Save modified pixels back to the image
            image.SavePixels(image.Bounds, pixels);

            // Save the resulting image
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}