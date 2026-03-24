using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output/output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated APNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access frames
            ApngImage apngImage = (ApngImage)image;

            // Extract the first frame (single‑frame PNG)
            using (RasterImage firstFrame = (RasterImage)apngImage.Pages[0])
            {
                // Preserve metadata when saving
                var pngOptions = new PngOptions { KeepMetadata = true };
                firstFrame.Save(outputPath, pngOptions);
            }
        }
    }
}