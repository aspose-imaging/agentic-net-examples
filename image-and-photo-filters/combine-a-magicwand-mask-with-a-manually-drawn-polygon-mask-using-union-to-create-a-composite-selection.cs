using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // ------------------------------------------------------------
                // 1. Create a mask using the Magic Wand tool based on a point.
                // ------------------------------------------------------------
                // Example point (120, 100); you can change coordinates as needed.
                var magicMask = MagicWandTool.Select(image, new MagicWandSettings(120, 100));

                // ------------------------------------------------------------
                // 2. Create a manually defined polygon mask.
                //    For simplicity, we use a RectangleMask to represent the polygon.
                // ------------------------------------------------------------
                // Rectangle positioned at (200,200) with width=150 and height=100.
                var polygonMask = new RectangleMask(200, 200, 150, 100);

                // ------------------------------------------------------------
                // 3. Combine the two masks using Union.
                // ------------------------------------------------------------
                var compositeMask = magicMask.Union(polygonMask);

                // Apply the combined mask to the image
                compositeMask.Apply();

                // ------------------------------------------------------------
                // 4. Save the resulting image.
                // ------------------------------------------------------------
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