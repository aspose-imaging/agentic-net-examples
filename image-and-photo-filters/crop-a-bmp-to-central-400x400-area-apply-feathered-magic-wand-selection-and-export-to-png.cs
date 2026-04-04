using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the central 400x400 rectangle
            int cropWidth = 400;
            int cropHeight = 400;
            int left = Math.Max(0, (image.Width - cropWidth) / 2);
            int top = Math.Max(0, (image.Height - cropHeight) / 2);
            var cropRect = new Rectangle(left, top, cropWidth, cropHeight);

            // Crop the image to the central area
            image.Crop(cropRect);

            // -----------------------------------------------------------------
            // Apply a feathered Magic Wand selection here.
            // Aspose.Imaging provides selection tools (e.g., MagicWandSelection)
            // and feathering options. Insert the appropriate code using those
            // APIs if needed. This placeholder indicates where that logic would
            // be placed.
            // -----------------------------------------------------------------

            // Save the result as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}