using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the source image (animated or static)
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options: loop 5 times, keep original frame timing
            var apngOptions = new ApngOptions
            {
                NumPlays = 5
                // DefaultFrameTime is left unchanged to preserve playback speed
            };

            // Save as APNG with the specified loop count
            image.Save(outputPath, apngOptions);
        }
    }
}