using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.gif";
        string outputPath = "sample.adjusted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image, adjust contrast, and save the result
        using (Image image = Image.Load(inputPath))
        {
            GifImage gifImage = (GifImage)image;

            // Apply high contrast (maximum allowed value)
            gifImage.AdjustContrast(100f);

            // Save the modified image as GIF
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}