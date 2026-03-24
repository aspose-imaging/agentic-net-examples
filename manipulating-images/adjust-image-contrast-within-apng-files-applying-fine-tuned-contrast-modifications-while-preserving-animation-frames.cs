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
        string inputPath = "input.apng";
        string outputPath = "output_contrast.apng";

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
            // Cast to ApngImage to access APNG-specific methods
            ApngImage apngImage = (ApngImage)image;

            // Adjust contrast for the entire animation (range: -100 to 100)
            apngImage.AdjustContrast(30f);

            // Save the modified APNG, preserving all frames
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}