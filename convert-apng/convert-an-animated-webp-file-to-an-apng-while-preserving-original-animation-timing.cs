using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input_animation.webp";
        string outputPath = "output_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        // Load the animated WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Save as APNG preserving animation timing
            image.Save(outputPath, new ApngOptions());
        }
    }
}