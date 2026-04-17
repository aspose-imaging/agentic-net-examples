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
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // If the image is an APNG with more than one frame, save as APNG
            if (image is ApngImage apng && apng.PageCount > 1)
            {
                // Save using APNG options (default settings)
                apng.Save(outputPath, new ApngOptions());
            }
            else
            {
                // For single‑frame images (including APNG with one frame), save as regular PNG
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}