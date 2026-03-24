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
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apng = (ApngImage)image;

            // Ensure there is at least one frame
            if (apng.PageCount > 0)
            {
                // Get the first frame
                ApngFrame firstFrame = (ApngFrame)apng.Pages[0];

                // Save the first frame as a PNG file
                firstFrame.Save(outputPath, new PngOptions());
            }
        }
    }
}