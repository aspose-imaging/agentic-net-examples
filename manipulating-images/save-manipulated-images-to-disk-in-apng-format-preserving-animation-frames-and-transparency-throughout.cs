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

        // Ensure output directory exists (creates if missing)
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the source image (animated or multi‑page) and save as APNG preserving frames and transparency
        using (Image image = Image.Load(inputPath))
        {
            // ApngOptions with default settings preserves animation cycles and transparency
            image.Save(outputPath, new ApngOptions());
        }
    }
}