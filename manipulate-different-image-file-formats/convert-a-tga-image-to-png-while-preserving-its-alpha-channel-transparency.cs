using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.png";
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TGA image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Save as PNG preserving the alpha channel
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}