using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output_contrast.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image (may contain multiple frames)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF‑specific methods
            GifImage gifImage = (GifImage)image;

            // Increase contrast; valid range is [-100, 100]
            // Here we use a positive value to make tones richer
            gifImage.AdjustContrast(50f);

            // Save the modified GIF, preserving animation
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}