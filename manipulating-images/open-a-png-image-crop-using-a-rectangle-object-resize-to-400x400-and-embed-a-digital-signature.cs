using System;
using System.IO;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load PNG image
        using (PngImage image = (PngImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Define crop rectangle (x, y, width, height)
            var cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 200);
            image.Crop(cropRect);

            // Resize to 400x400 pixels
            image.Resize(400, 400);

            // Embed digital signature with a password
            image.EmbedDigitalSignature("myPassword");

            // Save the processed image
            image.Save(outputPath);
        }
    }
}