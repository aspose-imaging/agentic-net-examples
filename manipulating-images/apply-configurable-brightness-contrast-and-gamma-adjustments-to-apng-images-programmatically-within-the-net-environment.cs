using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.apng";
        string outputPath = @"C:\Images\output_adjusted.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Adjustable parameters
        int brightness = 20;          // Example brightness value (int)
        float contrast = 30f;         // Example contrast value (float, range -100 to 100)
        float gamma = 1.2f;           // Example gamma value (float)

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Apply adjustments
            apngImage.AdjustBrightness(brightness);
            apngImage.AdjustContrast(contrast);
            apngImage.AdjustGamma(gamma);

            // Save the adjusted image (using PNG options for compatibility)
            apngImage.Save(outputPath, new PngOptions());
        }
    }
}