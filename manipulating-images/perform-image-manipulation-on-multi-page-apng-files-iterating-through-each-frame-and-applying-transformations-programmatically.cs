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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Iterate through each frame and apply a transformation
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Get the current frame
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Example transformation: adjust gamma based on frame index
                // Even frames get a darker gamma, odd frames get a lighter gamma
                float gamma = (i % 2 == 0) ? 0.5f : 2.0f;
                frame.AdjustGamma(gamma);
            }

            // Save the modified APNG image
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}