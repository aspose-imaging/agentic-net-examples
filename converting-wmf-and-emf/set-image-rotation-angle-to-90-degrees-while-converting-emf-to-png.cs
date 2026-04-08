using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise
            if (image is EmfImage emfImage)
            {
                emfImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                // Fallback for non‑EMF images
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            // Save as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}