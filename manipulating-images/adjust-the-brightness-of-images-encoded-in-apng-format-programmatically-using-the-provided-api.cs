using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.apng";
        string outputPath = "sample_brightness.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access AdjustBrightness
            ApngImage apng = (ApngImage)image;

            // Adjust brightness (positive values increase brightness, negative decrease)
            apng.AdjustBrightness(50);

            // Save the modified image
            apng.Save(outputPath);
        }
    }
}