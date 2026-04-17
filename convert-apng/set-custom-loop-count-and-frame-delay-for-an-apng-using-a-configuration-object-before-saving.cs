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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options: custom frame delay and loop count
            var apngOptions = new ApngOptions
            {
                // Frame duration in milliseconds (e.g., 200 ms per frame)
                DefaultFrameTime = 200,
                // Number of animation loops (0 = infinite)
                NumPlays = 3
            };

            // Save as APNG with the configured options
            image.Save(outputPath, apngOptions);
        }
    }
}