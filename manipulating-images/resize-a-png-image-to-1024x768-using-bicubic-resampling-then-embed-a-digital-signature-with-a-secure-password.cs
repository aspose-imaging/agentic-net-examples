using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";
        string password = "StrongPassword123!";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage image = (PngImage)Image.Load(inputPath))
        {
            // Resize to 1024x768 using Bicubic (CubicConvolution) resampling
            image.Resize(1024, 768, ResizeType.CubicConvolution);

            // Embed a digital signature with the provided password
            image.EmbedDigitalSignature(password);

            // Save the processed image
            image.Save(outputPath);
        }
    }
}