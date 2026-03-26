using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation_input.webp";
        string outputPath = @"C:\Images\animation_output.gif";

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
            // Configure GIF options to keep all frames
            GifOptions gifOptions = new GifOptions
            {
                FullFrame = true // Preserve each frame as a full image
            };

            // Save as animated GIF
            image.Save(outputPath, gifOptions);
        }
    }
}