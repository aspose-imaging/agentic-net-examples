using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
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
            // Create a magic wand mask at a sample point (e.g., 100,100)
            // Invert the mask to select the opposite area
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100))
                .Invert()
                .Apply();

            // Save the modified image as TIFF
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, tiffOptions);
        }
    }
}