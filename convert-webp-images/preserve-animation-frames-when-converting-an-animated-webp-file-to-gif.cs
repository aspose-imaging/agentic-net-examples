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
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image (preserves all frames)
        using (Image image = Image.Load(inputPath))
        {
            // Save as animated GIF, keeping all frames
            var gifOptions = new GifOptions
            {
                FullFrame = true // ensures each frame is saved
            };

            image.Save(outputPath, gifOptions);
        }
    }
}