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
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop central 400x400 area
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                // Apply feathered Magic Wand selection centered on the cropped image
                MagicWandTool.Select(image, new MagicWandSettings(cropWidth / 2, cropHeight / 2))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save as PNG with alpha channel
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