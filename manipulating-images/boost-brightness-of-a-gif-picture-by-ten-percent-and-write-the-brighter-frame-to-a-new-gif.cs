using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\sample.gif";
        string outputPath = @"C:\temp\sample_brighter.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            GifImage gifImage = (GifImage)image;

            // Increase brightness by roughly 10% (≈26 out of 255)
            gifImage.AdjustBrightness(26);

            // Save the brighter GIF
            gifImage.Save(outputPath);
        }
    }
}