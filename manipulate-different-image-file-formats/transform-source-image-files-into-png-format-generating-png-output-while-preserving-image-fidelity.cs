using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.jpg";
        string outputPath = @"C:\temp\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (any supported format)
        using (Image image = Image.Load(inputPath))
        {
            // Save the image as PNG preserving fidelity
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        Console.WriteLine($"Image converted and saved to: {outputPath}");
    }
}