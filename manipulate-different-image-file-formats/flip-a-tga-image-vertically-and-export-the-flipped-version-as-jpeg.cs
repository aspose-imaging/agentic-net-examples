using System;
using System.IO;
using System.Drawing; // for RotateFlipType
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image, flip it vertically, and save as JPEG
        using (TgaImage image = (TgaImage)Image.Load(inputPath))
        {
            // Flip vertically (no rotation, flip on Y axis)
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // Save the flipped image as JPEG using default JPEG options
            image.Save(outputPath, new JpegOptions());
        }
    }
}