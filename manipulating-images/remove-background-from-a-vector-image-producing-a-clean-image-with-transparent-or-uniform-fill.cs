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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (vector or other supported format)
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a vector image, remove its background
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground();
            }

            // Prepare PNG options to preserve transparency
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save the processed image
            image.Save(outputPath, pngOptions);
        }
    }
}