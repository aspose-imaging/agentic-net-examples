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
        string outputPath = "output_filtered.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Apply a simple gamma adjustment to each frame as an example filter
            foreach (var page in apngImage.Pages)
            {
                ApngFrame frame = (ApngFrame)page;
                // AdjustGamma takes a float factor; 1.0 = no change
                frame.AdjustGamma(1.2f);
            }

            // Save the modified APNG using default options
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}