using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

public class Program
{
    public static void Main(string[] args)
    {
        try
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

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using Magic Wand at a specific point
                var magicMask = MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100));

                // Manually create a polygon mask (approximated here with a rectangle mask)
                var polygonMask = new RectangleMask(150, 150, 200, 100);

                // Combine the Magic Wand mask with the manual polygon mask using Union
                var combinedMask = magicMask.Union(polygonMask);

                // Apply the combined mask to the image
                combinedMask.Apply();

                // Save the resulting image with transparency support
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}