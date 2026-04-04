using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Calculate new dimensions (example: reduce size by 50%)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using Lanczos algorithm
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Embed digital signature with a password
            string password = "secret";
            image.EmbedDigitalSignature(password);

            // Save the result as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}