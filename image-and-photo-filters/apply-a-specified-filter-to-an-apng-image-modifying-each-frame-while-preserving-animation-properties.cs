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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Preserve original animation settings
            uint originalFrameTime = apngImage.DefaultFrameTime;
            int originalNumPlays = apngImage.NumPlays;

            // Apply a filter to each frame (example: adjust gamma)
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];
                // Adjust gamma; value can be changed as needed
                frame.AdjustGamma(0.8f);
            }

            // Save the modified APNG with original animation properties
            var saveOptions = new ApngOptions
            {
                DefaultFrameTime = originalFrameTime,
                NumPlays = originalNumPlays
            };
            apngImage.Save(outputPath, saveOptions);
        }
    }
}