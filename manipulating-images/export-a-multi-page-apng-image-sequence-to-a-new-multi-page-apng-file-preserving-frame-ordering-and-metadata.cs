using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input_multi.tif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the multi‑page image (any supported format)
        using (Image image = Image.Load(inputPath))
        {
            // Export to APNG, preserving frame order and metadata
            image.Save(outputPath, new ApngOptions());
        }
    }
}