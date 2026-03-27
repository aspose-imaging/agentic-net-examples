using System;
using System.IO;
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TGA image, flip it vertically, and save as JPEG
        using (TgaImage tgaImage = new TgaImage(inputPath))
        {
            // Flip vertically (no rotation, flip on Y axis)
            tgaImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // Prepare JPEG save options (default settings)
            var jpegOptions = new JpegOptions();

            // Save the flipped image as JPEG
            tgaImage.Save(outputPath, jpegOptions);
        }
    }
}