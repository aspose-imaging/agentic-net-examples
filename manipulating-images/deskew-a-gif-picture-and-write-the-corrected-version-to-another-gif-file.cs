using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify that the input file exists
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
            // Deskew the image by normalizing its angle
            image.NormalizeAngle();

            // Reorder GIF blocks to maintain a valid structure
            image.OrderBlocks();

            // Save the corrected image to the output path
            image.Save(outputPath);
        }
    }
}