using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output_flipped.gif";

        // Check that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (GifImage image = (GifImage)Image.Load(inputPath))
        {
            // Flip the active frame horizontally (no rotation)
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Save the flipped image to the output path
            image.Save(outputPath);
        }
    }
}