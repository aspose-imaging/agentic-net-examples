using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the multi‑page TIFF
        using (Image image = Image.Load(inputPath))
        {
            // Prepare APNG options with infinite looping (NumPlays = 0)
            var apngOptions = new ApngOptions
            {
                NumPlays = 0
                // DefaultFrameTime can be set here if a specific frame duration is required
            };

            // Save as animated APNG
            image.Save(outputPath, apngOptions);
        }
    }
}