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
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Increase brightness by ~20% (51 out of 255)
            dngImage.AdjustBrightness(51);

            // Save the result as JPEG
            dngImage.Save(outputPath, new JpegOptions());
        }
    }
}