using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output.dng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image, apply adjustments, and save back as DNG
        using (DngImage dng = (DngImage)Image.Load(inputPath))
        {
            // Example adjustments
            dng.AdjustBrightness(20);               // Increase brightness
            dng.AdjustContrast(0.2f);               // Increase contrast
            dng.Rotate(90f, true, Color.White);    // Rotate 90 degrees with white background

            // Save the modified image preserving DNG format
            dng.Save(outputPath);
        }
    }
}