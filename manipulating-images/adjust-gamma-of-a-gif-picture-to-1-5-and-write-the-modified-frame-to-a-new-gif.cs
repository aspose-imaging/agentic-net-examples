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
        string inputPath = @"c:\temp\input.gif";
        string outputPath = @"c:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gifImage = (GifImage)image;

            // Adjust gamma for all channels to 1.5
            gifImage.AdjustGamma(1.5f);

            // Save the modified image as a GIF
            GifOptions saveOptions = new GifOptions();
            gifImage.Save(outputPath, saveOptions);
        }
    }
}