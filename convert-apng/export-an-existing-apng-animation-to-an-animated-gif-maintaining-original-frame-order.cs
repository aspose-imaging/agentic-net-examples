using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation.apng";
        string outputPath = @"C:\Images\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image (multi‑page animation)
        using (Image image = Image.Load(inputPath))
        {
            // Save as animated GIF, preserving frame order
            image.Save(outputPath, new GifOptions());
        }
    }
}