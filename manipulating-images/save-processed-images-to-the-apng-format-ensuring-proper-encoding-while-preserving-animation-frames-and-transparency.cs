using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the source image (can be animated, e.g., WebP, GIF, multi-page TIFF)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Save as APNG preserving frames and transparency
            sourceImage.Save(outputPath, new ApngOptions());
        }
    }
}