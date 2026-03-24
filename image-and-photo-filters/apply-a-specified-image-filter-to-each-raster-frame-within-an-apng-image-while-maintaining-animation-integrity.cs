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
        string inputPath = @"C:\Images\input_animation.apng";
        string outputPath = @"C:\Images\output_animation_filtered.apng";

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
            // Iterate over each frame and apply a filter (example: gamma adjustment)
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Cast the page to ApngFrame
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Example filter: adjust gamma based on frame index
                // This can be replaced with any other filter logic as needed
                float gamma = 1.0f + (i % 5) * 0.1f; // Vary gamma slightly per frame
                frame.AdjustGamma(gamma);
            }

            // Save the modified APNG while preserving animation settings
            apngImage.Save(outputPath);
        }
    }
}