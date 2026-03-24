using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.png";
        string newImagePath = @"C:\temp\newImage.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(newImagePath));

        // Load existing image, rotate it, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            image.RotateFlip(RotateFlipType.Rotate180FlipX);
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        // Create a new BMP image using FileCreateSource and save it
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(newImagePath, false) // non‑temporal file, will be saved to disk
        };

        using (Image newImage = Image.Create(bmpOptions, 200, 200))
        {
            // Example processing: fill with a solid color (optional)
            // newImage.Save(); // Save using the source path defined in bmpOptions
            newImage.Save(); // Saves to newImagePath as defined by the FileCreateSource
        }
    }
}