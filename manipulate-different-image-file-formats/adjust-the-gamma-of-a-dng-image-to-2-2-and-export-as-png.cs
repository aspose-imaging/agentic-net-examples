using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.dng";
        string outputPath = @"C:\temp\sample_gamma.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image, apply gamma correction, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Adjust gamma to 2.2 for all channels
            dngImage.AdjustGamma(2.2f);

            // Export to PNG with default options
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}