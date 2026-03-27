using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.dng";
        string outputPath = @"c:\temp\test_gamma.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DngImage to access DNG-specific features
            DngImage dngImage = (DngImage)image;

            // Apply gamma correction (2.2 for all channels)
            dngImage.AdjustGamma(2.2f);

            // Save the result as PNG
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}