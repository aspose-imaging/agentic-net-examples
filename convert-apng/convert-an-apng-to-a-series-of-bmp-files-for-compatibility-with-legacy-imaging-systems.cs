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
        string outputDirectory = "output_frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates even if null)
        Directory.CreateDirectory(outputDirectory);

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Iterate over each frame and save as BMP
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                // Retrieve the frame (ApngFrame)
                ApngFrame frame = (ApngFrame)apngImage.Pages[i];

                // Build output file path for the current frame
                string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.bmp");

                // Ensure the directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the frame as BMP using default BmpOptions
                frame.Save(outputPath, new BmpOptions());
            }
        }
    }
}