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

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached) image.CacheData();

                // Calculate central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop to central area
                image.Crop(cropRect);

                // Apply feathered Magic Wand selection (center point of cropped area)
                MagicWandTool
                    .Select(image, new MagicWandSettings(cropWidth / 2, cropHeight / 2))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save result as PNG with alpha channel support
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