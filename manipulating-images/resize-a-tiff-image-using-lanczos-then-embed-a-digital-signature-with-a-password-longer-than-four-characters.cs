using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Resize using Lanczos resampling (example: double size)
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.LanczosResample);

            // Embed a digital signature with a password longer than four characters
            image.EmbedDigitalSignature("StrongPassword123");

            // Save the modified image
            image.Save(outputPath);
        }
    }
}