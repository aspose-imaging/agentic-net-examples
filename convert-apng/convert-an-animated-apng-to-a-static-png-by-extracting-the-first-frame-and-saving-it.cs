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

        // Load the animated APNG
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Extract the first frame (index 0)
            // Pages[0] returns an ApngFrame which derives from RasterImage
            using (RasterImage firstFrame = (RasterImage)apng.Pages[0])
            {
                // Save the first frame as a static PNG
                firstFrame.Save(outputPath, new PngOptions());
            }
        }
    }
}