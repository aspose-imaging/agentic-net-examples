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
        // Hardcoded paths
        string inputPath = "Input/input.bmp";
        string outputPath = "Output/output.png";

        // Input file validation
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP as raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop central 400x400 area
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                // Apply feathered Magic Wand selection (center point, feather size 5)
                int pointX = cropWidth / 2;
                int pointY = cropHeight / 2;
                MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save as PNG with alpha support
                PngOptions pngOptions = new PngOptions
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