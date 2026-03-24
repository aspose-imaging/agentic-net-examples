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
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Example: adjust default frame time for any new frames
            apngImage.DefaultFrameTime = 80; // 80 ms

            // Iterate over existing frames and modify them
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Each page is an ApngFrame
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Example adjustment: modify gamma based on frame index
                float gamma = (i % 2 == 0) ? 1.2f : 0.8f;
                frame.AdjustGamma(gamma);
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Save the modified APNG
            apngImage.Save(outputPath);
        }
    }
}