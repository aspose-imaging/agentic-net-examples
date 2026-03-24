using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

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
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Apply a series of filters to each frame
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Increase brightness
                frame.AdjustBrightness(20);          // +20 brightness

                // Enhance contrast
                frame.AdjustContrast(1.2f);          // 20% more contrast

                // Apply gamma correction
                frame.AdjustGamma(0.9f);             // Slight darkening
            }

            // Save the modified APNG with default options
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}