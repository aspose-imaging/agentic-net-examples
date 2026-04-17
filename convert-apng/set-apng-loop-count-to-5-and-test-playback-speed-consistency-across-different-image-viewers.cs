using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Animation1.webp";
        string outputPath = "output/Animation1_5loops.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (could be animated or single-frame)
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options: set loop count to 5 and a default frame time (e.g., 100 ms)
            var apngOptions = new ApngOptions
            {
                NumPlays = 5,                 // Loop the animation 5 times
                DefaultFrameTime = 100       // 100 ms per frame to keep playback speed consistent
            };

            // Save as APNG with the specified options
            image.Save(outputPath, apngOptions);
        }
    }
}