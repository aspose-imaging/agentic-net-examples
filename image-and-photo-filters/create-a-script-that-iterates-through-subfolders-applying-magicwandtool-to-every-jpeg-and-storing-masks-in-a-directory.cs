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
        // Hardcoded input and output root directories
        string inputRoot = "InputImages";
        string outputRoot = "Masks";

        // Enumerate all JPEG files in subfolders
        foreach (string inputPath in Directory.GetFiles(inputRoot, "*.jpg", SearchOption.AllDirectories))
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Compute relative path and corresponding output mask path
            string relativePath = Path.GetRelativePath(inputRoot, inputPath);
            string outputPath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".png"));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using MagicWandTool at pixel (0,0) and apply it
                MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                // Save the resulting mask as PNG with alpha channel
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
            }
        }
    }
}