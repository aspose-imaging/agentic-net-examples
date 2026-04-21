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
        string inputPath = @"c:\temp\test.dng";
        string outputPath = @"c:\temp\test_white.png";

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
            // Cast to DngImage to access DNG-specific properties
            DngImage dngImage = (DngImage)image;

            // Set background color to white
            dngImage.BackgroundColor = Aspose.Imaging.Color.White;
            dngImage.HasBackgroundColor = true; // optional, ensures the flag is set

            // Save as PNG
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}