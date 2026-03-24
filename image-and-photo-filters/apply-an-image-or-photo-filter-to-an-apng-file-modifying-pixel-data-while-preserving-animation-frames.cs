using System;
using System.IO;
using Aspose.Imaging;
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
            // Apply a simple gamma adjustment to each frame
            // This modifies pixel data while preserving animation timing and order
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];
                // AdjustGamma takes a float; values >1 increase brightness, <1 darken
                frame.AdjustGamma(1.2f);
            }

            // Save the modified APNG to the output path
            apngImage.Save(outputPath);
        }
    }
}