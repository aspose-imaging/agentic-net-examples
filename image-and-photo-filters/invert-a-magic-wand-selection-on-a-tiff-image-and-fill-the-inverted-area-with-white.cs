using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand based on a reference point (example: 10,10)
            var mask = MagicWandTool.Select(image, new MagicWandSettings(10, 10));

            // Invert the mask
            var invertedMask = mask.Invert();

            // Apply the inverted mask to the image
            invertedMask.Apply();

            // Fill the now-selected (inverted) area with white
            // The Graphics.Clear method fills the entire image; after applying the mask,
            // the selected area is transparent, so clearing to white effectively paints it white.
            var graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Save the modified image
            image.Save(outputPath);
        }
    }
}