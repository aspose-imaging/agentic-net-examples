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
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.apng.png";
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the source image (can be multi‑page)
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options: custom loop count and frame delay
            ApngOptions apngOptions = new ApngOptions
            {
                NumPlays = 3,            // Loop the animation 3 times (0 = infinite)
                DefaultFrameTime = 150  // Frame duration in milliseconds
            };

            // Save the image as APNG with the specified options
            image.Save(outputPath, apngOptions);
        }
    }
}